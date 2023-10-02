import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_list.dart';
import 'package:flutter/material.dart';

class DrawerMenu extends StatelessWidget {
  const DrawerMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: const Text('Home'),
            onTap: () {
              Navigator.pushNamed(context, TravelListScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('TBC'),
            onTap: () {
              Navigator.popAndPushNamed(
                  context, LoginScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('Logout'),
            onTap: () {
              Navigator.popAndPushNamed(context, LoginScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
}