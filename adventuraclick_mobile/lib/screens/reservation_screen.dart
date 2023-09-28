import 'dart:convert';
import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';
import 'dart:ui';
import 'package:adventuraclick_mobile/model/additional_services.dart';
import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/providers/additional_service_provider.dart';
import 'package:adventuraclick_mobile/providers/payment_provider.dart';
import 'package:adventuraclick_mobile/providers/reservation_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_stripe/flutter_stripe.dart' hide Card;
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import '../../main.dart';

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
  late PaymentProvider _paymentProvider;
  Travel? _data;
  List<AdditionalServices>? _additionalServices = [];
  String? selectedDate;
  String? expDate;
  Map<String, dynamic>? paymentIntentData;
  final _formKey = GlobalKey<FormState>();
  List<int> valuesIds = [];
  List<AdditionalServices>? valuesObjects = [];
  double amount = 0;

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _travelProvider = context.read<TravelProvider>();
    _reservationProvider = context.read<ReservationProvider>();
    _additionalServiceProvider = context.read<AdditionalServiceProvider>();
    _paymentProvider = context.read<PaymentProvider>();
    Stripe.publishableKey =
        "pk_test_51LYvFoDcMolufBl1C62vG2kBj4cwnEI4ZCqxnYDr321H8jJXCW0PkOpVdR7HOBiotcUCtKAVShIpJDIAugULk84H00c5JG5CcC";
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
    if (_data == null) {
      return const Text('Loading...');
    }
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              SizedBox(
                height: 200,
                width: 500,
                child: Image.memory(dataFromBase64String(_data!.image!),
                    fit: BoxFit.cover),
              ),
              Container(
                margin: const EdgeInsets.only(top: 20),
                padding: const EdgeInsets.all(20),
                child: Center(
                  child: Center(
                      child: Text(
                    "Reservation for travel : ${_data!.name!}",
                    style: const TextStyle(
                        color: Colors.cyan,
                        fontSize: 25,
                        fontWeight: FontWeight.bold),
                  )),
                ),
              ),
              const SizedBox(
                height: 35,
              ),
              Form(
                key: _formKey,
                autovalidateMode: AutovalidateMode.onUserInteraction,
                child: Column(
                  children: [
                    const SizedBox(height: 15),
                    ElevatedButton(
                      onPressed: () => _selectDate(context),
                      child: Text(selectedDate != null
                          ? "$selectedDate"
                          : 'Select date for your reservation'),
                    ),
                    Row(
                      children: [
                        Container(
                          margin: const EdgeInsets.only(top: 15),
                          width: MediaQuery.of(context).size.width / 2,
                          padding: const EdgeInsets.all(10),
                          child: TextFormField(
                            validator: (value) {
                              if (value!.isEmpty) {
                                return "Required field!";
                              }
                            },
                            decoration: const InputDecoration(
                                labelText: "First name",
                                labelStyle: TextStyle(color: Colors.cyan),
                                enabledBorder: OutlineInputBorder(
                                    borderSide: BorderSide(
                                        width: 1, color: Colors.cyan))),
                            controller: _firstNameController,
                          ),
                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 15),
                          width: MediaQuery.of(context).size.width / 2,
                          padding: const EdgeInsets.all(8),
                          child: TextFormField(
                            validator: (value) {
                              if (value!.isEmpty) {
                                return "Required field!";
                              }
                            },
                            decoration: const InputDecoration(
                                labelText: "Last name",
                                labelStyle: TextStyle(color: Colors.cyan),
                                enabledBorder: OutlineInputBorder(
                                    borderSide: BorderSide(
                                        width: 1, color: Colors.cyan))),
                            controller: _lastNameController,
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 20),
                    Column(
                      children: _buildAddServices(),
                    ),
                    const SizedBox(height: 20),
                    Container(
                      height: 50,
                      margin: EdgeInsets.fromLTRB(50, 20, 50, 0),
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          gradient: const LinearGradient(
                              colors: [Colors.cyan, Colors.blue])),
                      child: InkWell(
                        onTap: () async {
                          await makePayment(calculateAmount(_data!.price!));
                        },
                        child: const Center(child: Text("Reserve travel")),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: DateTime.now(),
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));

    if (picked != null && picked != selectedDate) {
      setState(() {
        String formated = DateFormat('yyyy-MM-dd').format(picked);
        selectedDate = formated;
      });
    }
  }

  Future<void> makePayment(double amount) async {
    try {
      if (_formKey.currentState!.validate() && selectedDate != null) {
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
          builder: (_) => const AlertDialog(
                title: Text("Payment"),
                content: Text("Your reservation is completed"),
                // actions: [
                //   TextButton(
                //     onPressed: () async => await Navigator.pushNamed(
                //         context, ReservationListScreen.routeName),
                //     child: const Text("Ok"),
                //   ),
                // ],
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
            'Authorization':
                'Bearer sk_test_51LYvFoDcMolufBl1uKvRlAoWHLj0jASSB4GN33lYWbm1ivdZHXykGJvEsxrXVQgPJsLg9ayg5vzLYfzaiGcYonTw00aCnZElga',
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

    List<int>? addServiceIds = [];

    List<Widget> list = _additionalServices!
        .map(
          (x) => Center(
            child: CheckboxListTile(
              title: Text("${x.name!}" "(${x.price!}\$)"),
              secondary: const Icon(Icons.plus_one),
              autofocus: false,
              // isThreeLine: true,
              activeColor: Colors.green,
              checkColor: Colors.white,
              value: valuesIds.indexOf(x.addServiceId!) != -1 ? true : false,
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
      var reservation = await _reservationProvider.insert({
        'date': selectedDate,
        'userId': Authorization.user!.userId,
        'travelId': _data!.travelId,
        'status': "Active",
        'additionalServices': valuesIds,
        'payment': {
          'transactionNumber': paymentIntentData!['id'],
          'amount': calculateAmount(_data!.price!),
          'date': DateFormat('yyyy-MM-dd').format(DateTime.now()),
          'fullName': "${_firstNameController.text} ${_lastNameController.text}"
        }
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
