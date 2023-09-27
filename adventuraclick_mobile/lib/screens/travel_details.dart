import 'dart:developer';

import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:adventuraclick_mobile/widgets/drawer_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class TravelDetailsScreen extends StatefulWidget {
  static const String routeName = "/travelDetails";
  String id;

  TravelDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<TravelDetailsScreen> createState() =>
      _TravelDetailsScreenState(this.id);
}

class _TravelDetailsScreenState extends State<TravelDetailsScreen> {
  TravelProvider? _travelProvider;
  Travel data = Travel();
  String id;

  _TravelDetailsScreenState(this.id);

  @override
  void initState() {
    super.initState();
    _travelProvider = context.read<TravelProvider>();
    loadData();
  }

  Future loadData() async {

    //debug
    //inspect(mockedData);

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
        appBar: AppBar(
          backgroundColor: Colors.deepPurple,
          title: const Text("AdventuraClick"),
        ));
  }

  _buildTravelDetails() {
    if (data.name == null) {
      return const Center(
        child: CircularProgressIndicator(
          color: Colors.black,
        ),
      );
    }

    return SafeArea(
      child: Stack(
        children: <Widget>[
          SizedBox(
            height: 350,
            child: Image.memory(dataFromBase64String(data.image!),
                fit: BoxFit.cover),
          ),
          SingleChildScrollView(
            padding: const EdgeInsets.only(top: 16.0, bottom: 20.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                const SizedBox(height: 250),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16.0),
                  child: Text(
                    data.name!,
                    style: const TextStyle(
                        color: Colors.deepPurple,
                        fontSize: 28.0,
                        fontWeight: FontWeight.bold),
                  ),
                ),
                Row(
                  children: <Widget>[
                    const SizedBox(width: 16.0),
                    Container(
                      padding: const EdgeInsets.symmetric(
                        vertical: 8.0,
                        horizontal: 16.0,
                      ),
                      decoration: BoxDecoration(
                          color: Colors.black,
                          borderRadius: BorderRadius.circular(20.0)),
                      child: Text(
                        data.travelType?.name ?? '',
                        style: const TextStyle(
                            color: Colors.white, fontSize: 13.0),
                      ),
                    ),
                    const Spacer(),
                  ],
                ),
                Container(
                  padding: const EdgeInsets.all(32.0),
                  color: Colors.white,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisSize: MainAxisSize.min,
                    children: <Widget>[
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: <Widget>[
                          Text(
                            "${data.price}",
                            style: const TextStyle(
                                color: Colors.deepPurple,
                                fontWeight: FontWeight.bold,
                                fontSize: 22.0),
                          ),
                          const SizedBox(
                            width: 5,
                          ),
                          const Text(
                            "/€",
                            style: TextStyle(fontSize: 14.0, color: Colors.red),
                          )
                        ],
                      ),
                      const SizedBox(height: 10.0),
                      Text(
                        "Location".toUpperCase(),
                        style: const TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14.0),
                      ),
                      const SizedBox(height: 10.0),
                      Text(
                        '${data.location?.cityName}, ${data.location?.countryName}',
                        textAlign: TextAlign.justify,
                        style: const TextStyle(
                            fontWeight: FontWeight.w300, fontSize: 14.0),
                      ),
                      const SizedBox(height: 30.0),
                      Text(
                        "Date".toUpperCase(),
                        style: const TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14.0),
                      ),
                      const SizedBox(height: 10.0),
                      Text(
                        data.date.toString(),
                        textAlign: TextAlign.justify,
                        style: const TextStyle(
                            fontWeight: FontWeight.w300, fontSize: 14.0),
                      ),
                      const SizedBox(height: 30.0),
                      Text(
                        "Description".toUpperCase(),
                        style: const TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14.0),
                      ),
                      const SizedBox(height: 10.0),
                      Text(
                        data.description ?? '',
                        textAlign: TextAlign.justify,
                        style: const TextStyle(
                            fontWeight: FontWeight.w300, fontSize: 14.0),
                      ),
                      const SizedBox(height: 30),
                      Container(
                        height: 50,
                        width: 400,
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(50),
                            gradient: const LinearGradient(
                                colors: [Colors.deepPurple, Colors.red])),
                        child: const InkWell(
                            // onTap: () {
                            //   Navigator.pushNamed(context,
                            //       "${reservation.routeName}/${data.travelId}");
                            // },
                            child: Center(child: Text("Reserve your travel!"))),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
