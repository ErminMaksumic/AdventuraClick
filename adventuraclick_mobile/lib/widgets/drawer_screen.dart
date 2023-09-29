import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/reservation_screen.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/material.dart';

class DrawerMenu extends StatelessWidget {
  const DrawerMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: const Text('TBC'),
            onTap: () {
              Navigator.pushNamed(context, LoginScreen.routeName);
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