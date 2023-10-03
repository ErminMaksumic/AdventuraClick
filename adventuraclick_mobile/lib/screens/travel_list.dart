import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/model/travel_type.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_type_provider.dart';
import 'package:adventuraclick_mobile/screens/travel_details.dart';
import 'package:adventuraclick_mobile/utils/format_number.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:adventuraclick_mobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class TravelListScreen extends StatefulWidget {
  static const String routeName = "/travelList";

  const TravelListScreen({Key? key}) : super(key: key);

  @override
  State<TravelListScreen> createState() => _TravelListScreenState();
}

class _TravelListScreenState extends State<TravelListScreen> {
  TravelProvider? _travelProvider;
  TravelTypeProvider? _travelTypeProvider;
  List<Travel>? data;
  List<TravelType> travelTypes = [];
  final TextEditingController _nameSearchController = TextEditingController();
  final TextEditingController _priceSearchController = TextEditingController();
  int? selectedTravelTypeValue = 99;

  @override
  void initState() {
    super.initState();
    _travelProvider = context.read<TravelProvider>();
    _travelTypeProvider = context.read<TravelTypeProvider>();
    loadData();
  }

  Future loadData() async {
    var search = {
      "name": _nameSearchController.text,
      "price":
          _priceSearchController.text.isEmpty ? 0 : _priceSearchController.text,
      "travelTypeId": selectedTravelTypeValue == 99 ? 0 : selectedTravelTypeValue,
      "IncludeTravelType": true,
    };
    var tempData = await _travelProvider?.get(search);
    var travelTypesData = await _travelTypeProvider?.get();
    setState(() {
      data = tempData!;
      travelTypes = travelTypesData!;
    });
  }

  List<Widget> _buildSearchAndCards() {
    List<Widget> list = <Widget>[];
    list.add(_buildSearch());
    list.addAll(_buildCards());
    return list;
  }

  List<DropdownMenuItem> _buildTypes() {
    if (travelTypes.isEmpty) {
      return [];
    }
    List<DropdownMenuItem> list = <DropdownMenuItem>[];

    list.add(const DropdownMenuItem(
      enabled: false,
      value: 99,
      child: Text("Travel Type", style: TextStyle(color: Colors.black)),
    ));

    list.addAll(travelTypes
        .map((x) => DropdownMenuItem(
              value: x.travelTypeId,
              child: Text(x.name!, style: const TextStyle(color: Colors.black)),
            ))
        .toList());

    return list;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        index: 0,
        child: SafeArea(
            child: SingleChildScrollView(
          child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: _buildSearchAndCards()),
        )));
  }

  Widget _buildSearch() {
  return Column(
    children: [
      Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Expanded(
            child: Container(
              padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
              child: TextField(
                controller: _nameSearchController,
                decoration: const InputDecoration(
                  hintText: "Name",
                  prefixIcon: Icon(Icons.search),
                ),
                onSubmitted: (value) async {
                  var tmpData = await _travelProvider?.get({
                    "name": value,
                    "IncludeTravelType": "true",
                  });
                  setState(() {
                    data = tmpData!;
                  });
                },
              ),
            ),
          ),
          Expanded(
            child: Container(
              padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
              child: TextField(
                controller: _priceSearchController,
                decoration: const InputDecoration(
                  hintText: "Price",
                  prefixIcon: Icon(Icons.money),
                ),
                keyboardType: TextInputType.number,
              ),
            ),
          ),
        ],
      ),
      Column(
        children: [
          Container(
            width: MediaQuery.of(context).size.width * 0.3,
            padding: const EdgeInsets.symmetric(horizontal: 15, vertical: 10),
            child: DropdownButton(
              iconSize: 1,
              items: _buildTypes(),
              value: selectedTravelTypeValue,
              onChanged: (dynamic value) {
                setState(() {
                  selectedTravelTypeValue = value;
                  loadData();
                });
              },
            ),
          ),
        ],
      ),
      Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Expanded(
            child: Container(
              padding: const EdgeInsets.symmetric(horizontal: 5, vertical: 5),
              child: IconButton(
                icon: const Icon(Icons.filter_list),
                onPressed: () async {
                  var tmpData = await _travelProvider?.get({
                    "name": _nameSearchController.text,
                    "price": _priceSearchController.text.isEmpty ? 0 : _priceSearchController.text,
                    "travelTypeId": selectedTravelTypeValue == 99 ? 0 : selectedTravelTypeValue,
                    "IncludeTravelType": "true"
                  });
                  setState(() {
                    data = tmpData!;
                  });
                },
              ),
            ),
          ),
          Expanded(
            child: Container(
              padding: const EdgeInsets.symmetric(horizontal: 5, vertical: 5),
              child: IconButton(
                icon: const Icon(Icons.delete_outline),
                onPressed: () async {
                  _nameSearchController.text = "";
                  _priceSearchController.text = "";
                  setState(() {
                    selectedTravelTypeValue = 99;
                  });
                },
              ),
            ),
          ),
        ],
      ),
      Container(
        padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
        child: const Center(
          child: Text(
            "Search Travels",
            style: TextStyle(
              color: Colors.deepPurple,
              fontSize: 20,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
      ),
    ],
  );
}


  List<Widget> _buildCards() {
    if (data == null) {
      return [
        const Center(
          child: CircularProgressIndicator(
            color: Colors.black,
          ),
        )
      ];
    }

    if (data!.isEmpty) {
      return [
        const Center(
          child: Text(
            "No travels available.",
          ),
        )
      ];
    }

    List<Widget> list = data!
        .map((x) => SizedBox(
              height: 270,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Card(
                  color: const Color.fromARGB(255, 187, 144, 198),
                  child: ClipRRect(
                    child: Stack(children: [
                      Column(
                        children: [
                          GestureDetector(
                            onTap: () => Navigator.pushNamed(context,
                                "${TravelDetailsScreen.routeName}/${x.travelId}"),
                            child: SizedBox(
                              height: 115,
                              width: 500,
                              child: Image.memory(
                                dataFromBase64String(x.image!),
                                fit: BoxFit.cover,
                              ),
                            ),
                          ),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Expanded(
                                  child: Padding(
                                padding: const EdgeInsets.only(
                                    top: 8, bottom: 8, right: 8, left: 16),
                                child: Column(
                                  children: [
                                    GestureDetector(
                                      onTap: () => Navigator.pushNamed(
                                        context,
                                        "${TravelDetailsScreen.routeName}/${x.travelId}",
                                      ),
                                      child: Text(
                                        x.name!,
                                        textAlign: TextAlign.center,
                                        style: const TextStyle(
                                          fontSize: 16,
                                          color: Colors.white,
                                          fontWeight: FontWeight.bold,
                                        ),
                                      ),
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.start,
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        const Text(
                                          "- Price: ",
                                          textAlign: TextAlign.center,
                                          style: TextStyle(
                                            color: Colors.black,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                        Text(
                                          "${formatNumber(x.price)} \$",
                                          textAlign: TextAlign.center,
                                          style: const TextStyle(
                                            color: Colors.white,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                      ],
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.start,
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        const Text(
                                          "- Nights: ",
                                          textAlign: TextAlign.center,
                                          style: TextStyle(
                                            color: Colors.black,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                        Text(
                                          x.numberOfNights.toString(),
                                          textAlign: TextAlign.center,
                                          style: const TextStyle(
                                            color: Colors.white,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                      ],
                                    ),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.start,
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        const Text(
                                          "- Travel Type: ",
                                          textAlign: TextAlign.center,
                                          style: TextStyle(
                                            color: Colors.black,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                        Text(
                                          x.travelType!.name!,
                                          textAlign: TextAlign.center,
                                          style: const TextStyle(
                                            color: Colors.white,
                                            fontWeight: FontWeight.bold,
                                            fontSize: 15,
                                          ),
                                        ),
                                      ],
                                    ),
                                    Row(
                                      mainAxisAlignment: MainAxisAlignment.end,
                                      children: [
                                        InkWell(
                                          onTap: () {
                                            Navigator.pushNamed(
                                              context,
                                              "${TravelDetailsScreen.routeName}/${x.travelId}",
                                            );
                                          },
                                          child: const Text(
                                            "More info",
                                            textAlign: TextAlign.center,
                                            style: TextStyle(
                                              color: Colors.black,
                                              fontWeight: FontWeight.bold,
                                              fontSize: 15,
                                            ),
                                          ),
                                        ),
                                      ],
                                    ),
                                  ],
                                ),
                              )),
                            ],
                          )
                        ],
                      )
                    ]),
                  ),
                ),
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
