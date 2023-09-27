import 'package:adventuraclick_mobile/providers/additional_service_provider.dart';
import 'package:adventuraclick_mobile/providers/payment_provider.dart';
import 'package:adventuraclick_mobile/providers/rating_provider.dart';
import 'package:adventuraclick_mobile/providers/reservation_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/providers/user_provider.dart';
import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/screens/rating_screen.dart';
import 'package:adventuraclick_mobile/screens/register_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_details.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(providers: [
    ChangeNotifierProvider(create: (_) => UserProvider()),
    ChangeNotifierProvider(create: (_) => RatingProvider()),
    ChangeNotifierProvider(create: (_) => TravelProvider()),
    ChangeNotifierProvider(create: (_) => PaymentProvider()),
    ChangeNotifierProvider(create: (_) => ReservationProvider()),
    ChangeNotifierProvider(create: (_) => AdditionalServiceProvider()),
  ], child: const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: true,
      title: "Adventura Click",
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: LoginScreen(),
      onGenerateRoute: (settings) {
        if (settings.name == LoginScreen.routeName) {
          return MaterialPageRoute(builder: (context) => LoginScreen());
        }
        if (settings.name == RegistrationScreen.routeName) {
          return MaterialPageRoute(
              builder: (context) => const RegistrationScreen());
        }
        if (settings.name == ProfileScreen.routeName) {
          return MaterialPageRoute(builder: (context) => const ProfileScreen());
        }

        // dynamic uri for sending url with id
        var uri = Uri.parse(settings.name!);
        // temporary solution
        var id1 = '1'; //uri.pathSegments[1];
        if ("/${uri.pathSegments.first}" == RatingScreen.routeName) {
          return MaterialPageRoute(builder: (context) => RatingScreen(id1));
        }
        if ("/${uri.pathSegments.first}" == TravelDetailsScreen.routeName) {
          var id2 = '1'; //uri.pathSegments[1];
          return MaterialPageRoute(
              builder: (context) => TravelDetailsScreen(id2));
        }
        return null;
      },
    );
  }
}
