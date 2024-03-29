import 'package:adventuraclick_mobile/screens/user_screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/user_screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/screens/reservation_screens/reservation_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_details.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_list.dart';
import 'package:adventuraclick_mobile/screens/reservation_screens/user_reservation_list.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
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
        fixedColor: Colors.white,
        unselectedItemColor: Colors.black,
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
        backgroundColor: AppColors.primaryHeader,
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
        backgroundColor: AppColors.primaryHeader,
        title: const Text("AdventuraClick"),
        );
  }
}