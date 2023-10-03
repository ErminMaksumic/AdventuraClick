import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/screens/reservation_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_details.dart';
import 'package:adventuraclick_mobile/screens/travel_list.dart';
import 'package:adventuraclick_mobile/screens/user_reservation_list.dart';
import 'package:adventuraclick_mobile/widgets/drawer_screen.dart';

import 'package:flutter/material.dart';

class MasterScreenWidget extends StatelessWidget {
  Widget? child;
  int? index = 0;
  MasterScreenWidget({this.child, this.index, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: _buildAppBar(),
      drawer: const DrawerMenu(),
      body: SafeArea(child: child!),
      bottomNavigationBar: BottomNavigationBar(
        fixedColor: Colors.red,
        unselectedItemColor: Colors.white,
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.settings_accessibility),
            label: 'Edit profile',
          ),
          // temporary travel screen
          BottomNavigationBarItem(
            icon: Icon(Icons.list),
            label: 'Reservations',
          ),
        ],
        currentIndex: index!,
        backgroundColor: Colors.deepPurple,
        onTap: (index) {
          switch (index) {
            case 0:
              Navigator.pushNamed(context, TravelListScreen.routeName);
              break;
            case 1:
              Navigator.pushNamed(context, ProfileScreen.routeName);
              break;
            case 2:
              Navigator.pushNamed(context, UserReservationListScreen.routeName);
              break;
          }
        },
      ),
    );
  }

  _buildAppBar() {
    return AppBar(
        backgroundColor: Colors.deepPurple,
        title: const Text("AdventuraClick"),
        );
  }
}