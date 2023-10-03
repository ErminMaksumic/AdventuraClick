import 'dart:convert';
import 'package:adventuraclick_mobile/model/additional_services.dart';
import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/providers/additional_service_provider.dart';
import 'package:adventuraclick_mobile/providers/reservation_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/screens/travel_details.dart';
import 'package:adventuraclick_mobile/screens/travel_list.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:adventuraclick_mobile/utils/buildInputFields.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_stripe/flutter_stripe.dart' hide Card;
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

class ReservationScreen extends StatefulWidget {
  static const String routeName = "/reservation";
  String id;
  ReservationScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ReservationScreen> createState() => _ReservationScreenState();
}

class _ReservationScreenState extends State<ReservationScreen> {
  late TravelProvider _travelProvider;
  late ReservationProvider _reservationProvider;
  late AdditionalServiceProvider _additionalServiceProvider;
  Travel? _data;
  List<AdditionalServices>? _additionalServices = [];
  String? expDate;
  Map<String, dynamic>? paymentIntentData;
  final _formKey = GlobalKey<FormState>();
  List<int> valuesIds = [];
  List<AdditionalServices>? valuesObjects = [];
  double amount = 0;
  int selectedDate = 99;

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _travelProvider = context.read<TravelProvider>();
    _reservationProvider = context.read<ReservationProvider>();
    _additionalServiceProvider = context.read<AdditionalServiceProvider>();
    Stripe.publishableKey = dotenv.env['STRIPE_PUBLISHABLE_KEY']!;
    setState(() {});
    loadData();
  }

  void loadData() async {
    var tempData = await _travelProvider.getById(int.parse(widget.id));
    var tempAddServices = await _additionalServiceProvider.get();
    setState(() {
      _data = tempData;
      _additionalServices = tempAddServices;
    });

    _firstNameController.text = Authorization.user!.firstName!;
    _lastNameController.text = Authorization.user!.lastName!;
  }

  @override
  Widget build(BuildContext context) {
    Widget content;

    if (_data == null) {
      content = const Column(
        children: [
          SizedBox(
            height: 50,
          ),
          Center(
              child: CircularProgressIndicator(
            color: Colors.black,
          )),
        ],
      );
    } else {
      content = Scaffold(
        body: SafeArea(
          child: SingleChildScrollView(
            child: Card(
              elevation: 5,
              child: Column(
                children: [
                  SizedBox(
                    height: 300,
                    width: 500,
                    child: Image.memory(dataFromBase64String(_data!.image!),
                        fit: BoxFit.cover),
                  ),
                  Container(
                    margin: const EdgeInsets.only(top: 20),
                    padding: const EdgeInsets.all(20),
                    decoration: const BoxDecoration(
                      color: Colors.deepPurple,
                    ),
                    child: Center(
                      child: Text(
                        _data!.name!,
                        style: const TextStyle(
                          color: Colors.white,
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ),
                  ),
                  const SizedBox(height: 20),
                  Form(
                    key: _formKey,
                    autovalidateMode: AutovalidateMode.onUserInteraction,
                    child: Column(
                      children: [
                        const SizedBox(height: 15),
                        const Text(
                          'Select a travel date:',
                          style: TextStyle(
                              fontWeight: FontWeight.bold,
                              color: Colors.deepPurple),
                        ),
                        const SizedBox(height: 15),
                        SizedBox(
                            width: 135,
                            child: DropdownButton(
                                items: _buildDateDownList(),
                                isExpanded: true,
                                value: selectedDate,
                                icon: const Icon(Icons.date_range),
                                hint: const Text("Dates"),
                                onChanged: (dynamic value) {
                                  setState(() {
                                    selectedDate = value;
                                  });
                                })),
                        const SizedBox(height: 35.0),
                        Column(
                          children: [
                            buildInputField(_firstNameController, 'First Name'),
                            const SizedBox(height: 20),
                            buildInputField(_lastNameController, 'Last Name'),
                          ],
                        ),
                        const SizedBox(height: 20),
                        Container(
                          padding: const EdgeInsets.all(10),
                          decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.deepPurple,
                            ),
                            borderRadius: BorderRadius.circular(10),
                          ),
                          child: SizedBox(
                            width: 365,
                            child: Column(
                              children: [
                                const Text(
                                  "Choose additional services",
                                  style: TextStyle(
                                    color: Colors.deepPurple,
                                    fontWeight: FontWeight.bold,
                                  ),
                                ),
                                const SizedBox(height: 10),
                                ..._buildAddServices(),
                              ],
                            ),
                          ),
                        ),
                        const SizedBox(height: 20),
                        Container(
                          height: 50,
                          margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(10),
                              gradient: const LinearGradient(
                                  colors: [Colors.red, Colors.deepPurple])),
                          child: InkWell(
                            onTap: () async {
                              await makePayment(calculateAmount(_data!.price!));
                            },
                            child: const Center(child: Text("Reserve travel")),
                          ),
                        ),
                        const SizedBox(height: 20),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      );
    }
    return content;
  }

  List<DropdownMenuItem> _buildDateDownList() {
    List<DropdownMenuItem> list = <DropdownMenuItem>[];

    list.add(const DropdownMenuItem(
      value: 99,
      enabled: false,
      child: Text("Available dates", style: TextStyle(color: Colors.black)),
    ));

    list.addAll(_data!.travelInformations!
        .map((x) => DropdownMenuItem(
              value: _data!.travelInformations!.indexOf(x),
              child: Text(DateFormat('dd-MM-yyyy').format(x.departureTime!),
                  style: const TextStyle(color: Colors.black)),
            ))
        .toList());

    return list;
  }

  Future<void> makePayment(double amount) async {
    try {
      if (_formKey.currentState!.validate() && selectedDate != 99) {
        paymentIntentData =
            await createPaymentIntent((amount * 100).round().toString(), 'usd');
        await Stripe.instance
            .initPaymentSheet(
                paymentSheetParameters: SetupPaymentSheetParameters(
                    paymentIntentClientSecret:
                        paymentIntentData!['client_secret'],
                    style: ThemeMode.dark,
                    merchantDisplayName: 'AdventuraClick'))
            .then((value) {});
        displayPaymentSheet();
      } else {
        throw Exception("Please check your inputs!");
      }
    } on Exception catch (e) {
      if (!mounted) return;
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: const Text("Error ocurred"),
                content: Text(e.toString()),
                actions: [
                  TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pop(context),
                  )
                ],
              ));
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((newValue) {
        createReservationPayment();

        paymentIntentData = null;
      }).onError((error, stackTrace) {
        throw Exception(error);
      });

      if (!mounted) return;
      showDialog(
          context: context,
          builder: (_) => AlertDialog(
                title: const Text("Payment"),
                content: const Text("Your reservation is completed"),
                actions: [
                  TextButton(
                    onPressed: () async => await Navigator.pushNamed(
                        context, TravelListScreen.routeName),
                    child: const Text("Ok"),
                  ),
                ],
              ));
    } on Exception {
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
                title: Text("Error ocurred"),
                content: Text("Payment canceled!"),
              ));
    } catch (e) {
      print('$e');
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization': 'Bearer ${dotenv.env['STRIPE_SECRET_KEY']!}',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('Error: ${err.toString()}');
    }
  }

  _buildAddServices() {
    if (_additionalServices!.isEmpty) {
      return [const Text("Loading data")];
    }

    List<Widget> list = _additionalServices!
        .map(
          (x) => Center(
            child: CheckboxListTile(
              title: Text("${x.name!}" "(${x.price!}\$)"),
              secondary: const Icon(Icons.plus_one),
              autofocus: false,
              activeColor: Colors.green,
              checkColor: Colors.white,
              value: valuesIds.contains(x.addServiceId!) ? true : false,
              onChanged: (bool? value) {
                setState(() {
                  if (value! == true) {
                    valuesIds.add(x.addServiceId!);
                    valuesObjects!.add(x);
                  } else {
                    valuesIds.remove(x.addServiceId);
                    valuesObjects!.remove(x);
                  }
                });
              },
            ),
          ),
        )
        .cast<Widget>()
        .toList();
    return list;
  }

  void createReservationPayment() async {
    try {
      await _reservationProvider.insert({
        'userId': Authorization.user!.userId,
        'travelId': _data!.travelId,
        'date': DateFormat('yyyy-MM-dd').format(DateTime.now()),
        'status': "Active",
        'additionalServices': valuesIds,
        'travelInformationId': selectedDate == 99
            ? null
            : _data!.travelInformations![selectedDate].travelInformationId,
        'payment': {
          'transactionNumber': paymentIntentData!['id'],
          'amount': calculateAmount(_data!.price!),
          'date': DateFormat('yyyy-MM-dd').format(DateTime.now()),
          'fullName': "${_firstNameController.text} ${_lastNameController.text}"
        }
      });
      await _reservationProvider.sendConfirmationEmail({
        "fullName":
            '${Authorization.user!.firstName} ${Authorization.user!.lastName}',
        "email": Authorization.user!.email,
        "travelName": _data!.name!,
      });
    } catch (e) {
      if (!mounted) return;
      showDialog(
          context: context,
          builder: (_) => AlertDialog(
                title: const Text("Error ocurred"),
                content: Text(e.toString()),
              ));
    }
  }

  double calculateAmount(double offerPrice) {
    double addServicesAmount = 0;
    for (var element in valuesObjects!) {
      addServicesAmount += element.price!;
    }

    return addServicesAmount + offerPrice;
  }
}
