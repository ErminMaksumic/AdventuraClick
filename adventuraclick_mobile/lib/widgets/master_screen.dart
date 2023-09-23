import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/widgets/drawer_screen.dart';
import 'package:provider/single_child_widget.dart';

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
            icon: Icon(Icons.add),
            label: 'TBC',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.settings),
            label: 'My profile',
          ),
        ],
        currentIndex: index!,
        backgroundColor: Colors.deepPurple, // Promijenite boju pozadine ovdje
        onTap: (index) {
          switch (index) {
            case 0:
              Navigator.pushNamed(context, LoginScreen.routeName);
              break;
            case 1:
              Navigator.pushNamed(context, LoginScreen.routeName);
              break;
            case 2:
              Navigator.pushNamed(context, LoginScreen.routeName);
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