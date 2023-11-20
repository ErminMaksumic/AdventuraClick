import 'package:adventuraclick_mobile/providers/reservation_provider.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:adventuraclick_mobile/utils/format_date.dart';
import 'package:adventuraclick_mobile/utils/format_number.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../../model/reservation.dart';
import '../../../widgets/master_screen.dart';

class UserReservationListScreen extends StatefulWidget {
  static const String routeName = "/userReservationList";
  const UserReservationListScreen({Key? key}) : super(key: key);

  @override
  State<UserReservationListScreen> createState() =>
      _ReservationListScreenScreenState();
}

class _ReservationListScreenScreenState
    extends State<UserReservationListScreen> {
  ReservationProvider? _reservationProvider;
  List<Reservation>? data = [];
  final TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _reservationProvider = context.read<ReservationProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _reservationProvider?.get({
      'userId': Authorization.user!.userId,
      'excludeDefaultValues': true,
      'includeTravel': true,
    });
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      index: 2,
      child: SingleChildScrollView(
        child: Column(
          children: [
            _buildHeader(),
            _buildReservationSearch(),
            ..._buildCard(),
          ],
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return const Padding(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        "My Travels",
        style: TextStyle(
            color: AppColors.text, fontWeight: FontWeight.bold, fontSize: 40),
      ),
    );
  }

  Widget _buildReservationSearch() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Column(
        children: [
          TextField(
            controller: _searchController,
            onSubmitted: (value) => _searchReservations(),
            decoration: const InputDecoration(
              hintText: "Search by travel name",
              hintStyle:
                  TextStyle(color: AppColors.text, fontWeight: FontWeight.bold),
              prefixIcon: Icon(Icons.search),
              enabledBorder: OutlineInputBorder(
                borderSide: BorderSide(color: AppColors.borders),
              ),
            ),
          ),
          IconButton(
            icon: const Icon(Icons.filter_list),
            color: Colors.black,
            onPressed: () => _searchReservations(),
          ),
        ],
      ),
    );
  }

  Future _searchReservations() async {
    var tempData = await _reservationProvider?.get({
      'userId': Authorization.user?.userId,
      'name': _searchController.text,
      'excludeDefaultValues': true,
      'includeTravel': true,
    });
    setState(() {
      data = tempData;
    });
  }

  List<Widget> _buildCard() {
    if (data!.isEmpty) return [const Text("Loading data")];

    return data!
        .map((x) => Card(
              margin: const EdgeInsets.all(10.0),
              color: AppColors.card,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    Text(
                      x.travel?.name ?? '',
                      textAlign: TextAlign.center,
                      style: const TextStyle(
                          color: Colors.black,
                          fontWeight: FontWeight.bold,
                          fontSize: 25),
                    ),
                    const SizedBox(height: 10),
                    _buildDetailRow("- Date: ", formatDate(x.date.toString())),
                    _buildDetailRow("- Status: ", x.status!, isStatus: true),
                    _buildDetailRow(
                        "- Price: ", "${formatNumber(x.travel!.price)} €"),
                  ],
                ),
              ),
            ))
        .toList();
  }

  Row _buildDetailRow(String label, String value, {bool isStatus = false}) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(label, style: const TextStyle(color: Colors.black, fontSize: 15)),
        Text(
          value,
          style: TextStyle(
            color: isStatus && (value == "Active" || value == "active")
                ? Colors.green
                : Colors.black,
            fontWeight: FontWeight.bold,
            fontSize: 15,
          ),
        ),
      ],
    );
  }
}
