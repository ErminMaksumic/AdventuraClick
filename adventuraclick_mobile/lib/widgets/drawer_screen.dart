import 'package:adventuraclick_mobile/screens/user_screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_list.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
import 'package:flutter/material.dart';

class DrawerMenu extends StatelessWidget {
  const DrawerMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      backgroundColor: AppColors.primaryHeader.withOpacity(0.9),
      shadowColor: Colors.black,
      child: ListView(
        children: [
          ListTile(
            title: const Text('Home', style: TextStyle(color: Colors.white)),
            onTap: () {
              Navigator.pushNamed(context, TravelListScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('Logout', style: TextStyle(color: Colors.white)),
            onTap: () {
              Navigator.popAndPushNamed(context, LoginScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
}