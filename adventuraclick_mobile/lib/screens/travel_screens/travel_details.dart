import 'dart:developer';

import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/model/travel_information.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/providers/user_provider.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/rating_screen.dart';
import 'package:adventuraclick_mobile/screens/reservation_screens/reservation_screen.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
import 'package:adventuraclick_mobile/utils/format_date.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:adventuraclick_mobile/widgets/drawer_screen.dart';
import 'package:adventuraclick_mobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class TravelDetailsScreen extends StatefulWidget {
  static const String routeName = "/travelDetails";
  String id;

  TravelDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<TravelDetailsScreen> createState() =>
      // ignore: no_logic_in_create_state
      _TravelDetailsScreenState(id);
}

class _TravelDetailsScreenState extends State<TravelDetailsScreen> {
  TravelProvider? _travelProvider;
  UserProvider? _userProvider;
  Travel data = Travel();
  String id;

  _TravelDetailsScreenState(this.id);

  @override
  void initState() {
    super.initState();
    _travelProvider = context.read<TravelProvider>();
    _userProvider = context.read<UserProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData = await _travelProvider?.getById(int.parse(id));
    inspect(tempData);
    setState(() {
      data = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: _buildTravelDetails(),
      drawer: const DrawerMenu(),
    );
  }

  _buildTravelDetails() {
    if (data.name == null) {
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.black,
        ),
      );
    }

    return MasterScreenWidget(
        index: 0,
        child: SafeArea(
          child: Stack(
            children: <Widget>[
              SingleChildScrollView(
                padding: const EdgeInsets.only(top: 16.0, bottom: 20.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: <Widget>[
                    Stack(
                      children: <Widget>[
                        SizedBox(
                          width: MediaQuery.of(context).size.width,
                          child: Image.memory(
                            dataFromBase64String(data.image!),
                            fit: BoxFit.cover,
                          ),
                        ),
                        Positioned(
                          bottom: 15,
                          left: 20,
                          child: Container(
                            padding: const EdgeInsets.symmetric(
                              vertical: 10.0,
                              horizontal: 16.0,
                            ),
                            decoration: BoxDecoration(
                              color: AppColors.card,
                              borderRadius: BorderRadius.circular(20.0),
                            ),
                            child: Text(
                              data.travelType?.name ?? 'Unknown',
                              style: const TextStyle(
                                  color: Color.fromARGB(255, 48, 46, 46),
                                  fontSize: 15.0,
                                  fontWeight: FontWeight.bold),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Container(
                        padding: const EdgeInsets.fromLTRB(32, 20, 32, 32),
                        color: Colors.white,
                        child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            mainAxisSize: MainAxisSize.min,
                            children: <Widget>[
                              Center(
                                child: Text(
                                  data.name!,
                                  style: const TextStyle(
                                      color: AppColors.text,
                                      fontSize: 30.0,
                                      fontWeight: FontWeight.bold),
                                ),
                              ),
                              Row(
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: <Widget>[
                                  Text(
                                    "${data.price}",
                                    style: const TextStyle(
                                        color: Color.fromARGB(156, 23, 32, 160),
                                        fontSize: 18.0),
                                  ),
                                  const SizedBox(
                                    width: 5,
                                  ),
                                  const Text(
                                    "/€",
                                    style: TextStyle(
                                        fontSize: 14.0, color: Colors.red),
                                  )
                                ],
                              ),
                              const SizedBox(height: 10.0),
                              Text(
                                "Nights: ".toUpperCase(),
                                style: const TextStyle(
                                    fontWeight: FontWeight.w600,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 10.0),
                              Text(
                                data.numberOfNights.toString(),
                                textAlign: TextAlign.justify,
                                style: const TextStyle(
                                    fontWeight: FontWeight.w300,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 15.0),
                              Text(
                                "Location".toUpperCase(),
                                style: const TextStyle(
                                    fontWeight: FontWeight.w600,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 10.0),
                              Text(
                                '${data.location?.cityName}, ${data.location?.countryName}',
                                textAlign: TextAlign.justify,
                                style: const TextStyle(
                                    fontWeight: FontWeight.w300,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 15.0),
                              Text(
                                "Date(s)".toUpperCase(),
                                style: const TextStyle(
                                    fontWeight: FontWeight.w600,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 10.0),
                              Column(
                                children: getAllDatesAsWidgets(
                                    data.travelInformations!),
                              ),
                              Column(
                                children: _buildIncludedItems(),
                              ),
                              const SizedBox(height: 15.0),
                              Text(
                                "Description".toUpperCase(),
                                style: const TextStyle(
                                    fontWeight: FontWeight.w600,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 10.0),
                              Text(
                                data.description ?? '',
                                textAlign: TextAlign.justify,
                                style: const TextStyle(
                                    fontWeight: FontWeight.w300,
                                    fontSize: 14.0),
                              ),
                              const SizedBox(height: 30),
                              Row(
                                children: [
                                  Container(
                                    margin: const EdgeInsets.only(right: 30),
                                    width: 150,
                                    height: 50,
                                    decoration: BoxDecoration(
                                        borderRadius: BorderRadius.circular(50),
                                        gradient: const LinearGradient(
                                            colors: AppColors.submitButton)),
                                    child: InkWell(
                                        onTap: () {
                                          Navigator.pushNamed(context,
                                              "${ReservationScreen.routeName}/${data.travelId}");
                                        },
                                        child: const Center(
                                            child: Text(
                                          "Reserve this travel",
                                          style: TextStyle(color: Colors.white),
                                        ))),
                                  ),
                                  Container(
                                      width: 150,
                                      height: 50,
                                      decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(50),
                                          gradient: const LinearGradient(
                                              colors: AppColors.submitButton)),
                                      child: FutureBuilder<bool>(
                                        future: _userProvider?.isReserved(id),
                                        builder: (BuildContext context,
                                            AsyncSnapshot<bool> snapshot) {
                                          if (snapshot.connectionState ==
                                              ConnectionState.waiting) {
                                            return const CircularProgressIndicator();
                                          } else if (snapshot.connectionState ==
                                                  ConnectionState.done &&
                                              !snapshot.hasError) {
                                            if (snapshot.data!) {
                                              // if isReserved returns true
                                              return InkWell(
                                                onTap: () {
                                                  Navigator.pushNamed(context,
                                                      "${RatingScreen.routeName}/${data.travelId}");
                                                },
                                                child: const Center(
                                                  child: Text(
                                                    "Rate this travel",
                                                    style: TextStyle(
                                                        color: Colors.white),
                                                  ),
                                                ),
                                              );
                                            } else {
                                              // if isReserved returns false
                                              return const Center(
                                                child: Text(
                                                  "Rate this travel",
                                                  style: TextStyle(
                                                    color: Colors.white,
                                                    decoration: TextDecoration
                                                        .lineThrough,
                                                  ),
                                                ),
                                              );
                                            }
                                          } else {
                                            return const Center(
                                                child:
                                                    Text('An error occurred'));
                                          }
                                        },
                                      )),
                                ],
                              ),
                            ])),
                  ],
                ),
              ),
            ],
          ),
        ));
  }

  List<Widget> _buildIncludedItems() {
    List<Widget> list = data.includedItems!
        .map(
          (x) => Row(
            children: [
              const Icon(
                Icons.travel_explore_rounded,
                color: Colors.green,
              ),
              const SizedBox(width: 10),
              Text(x.name!,
                  textAlign: TextAlign.justify,
                  style: const TextStyle(
                      fontWeight: FontWeight.w300, fontSize: 14.0)),
            ],
          ),
        )
        .cast<Widget>()
        .toList();

    list.insert(
        0,
        Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Container(
              margin: const EdgeInsets.only(bottom: 10, top: 10),
              child: Text(
                "Included: ".toUpperCase(),
                style: const TextStyle(
                    fontWeight: FontWeight.w600, fontSize: 14.0),
              ),
            ),
          ],
        ));

    return list;
  }

  List<Widget> getAllDatesAsWidgets(
      List<TravelInformation> travelInformations) {
    return travelInformations.map((info) {
      return Padding(
        padding: const EdgeInsets.only(bottom: 8.0),
        child: Text(
          formatDate(info.departureTime.toString()),
          textAlign: TextAlign.justify,
          style: const TextStyle(
            fontWeight: FontWeight.w300,
            fontSize: 14.0,
          ),
        ),
      );
    }).toList();
  }
}
