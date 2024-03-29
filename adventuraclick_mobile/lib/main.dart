import 'package:adventuraclick_mobile/providers/additional_service_provider.dart';
import 'package:adventuraclick_mobile/providers/payment_provider.dart';
import 'package:adventuraclick_mobile/providers/rating_provider.dart';
import 'package:adventuraclick_mobile/providers/reservation_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_provider.dart';
import 'package:adventuraclick_mobile/providers/travel_type_provider.dart';
import 'package:adventuraclick_mobile/providers/user_provider.dart';
import 'package:adventuraclick_mobile/screens/user_screens/login_screen.dart';
import 'package:adventuraclick_mobile/screens/user_screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/rating_screen.dart';
import 'package:adventuraclick_mobile/screens/user_screens/register_screen.dart';
import 'package:adventuraclick_mobile/screens/reservation_screens/reservation_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_details.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_list.dart';
import 'package:adventuraclick_mobile/screens/reservation_screens/user_reservation_list.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:provider/provider.dart';

Future<void> main() async {
  // Load env variables
  await dotenv.load(fileName: "lib/.env");

  runApp(MultiProvider(providers: [
    ChangeNotifierProvider(create: (_) => UserProvider()),
    ChangeNotifierProvider(create: (_) => RatingProvider()),
    ChangeNotifierProvider(create: (_) => TravelProvider()),
    ChangeNotifierProvider(create: (_) => PaymentProvider()),
    ChangeNotifierProvider(create: (_) => ReservationProvider()),
    ChangeNotifierProvider(create: (_) => AdditionalServiceProvider()),
    ChangeNotifierProvider(create: (_) => TravelTypeProvider()),
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
        if (settings.name == TravelListScreen.routeName) {
          return MaterialPageRoute(builder: (context) => const TravelListScreen());
        }
        if (settings.name == UserReservationListScreen.routeName) {
          return MaterialPageRoute(builder: (context) => const UserReservationListScreen());
        }

        // dynamic paths
        var uri = Uri.parse(settings.name!);
        var id = uri.pathSegments[1];
        if ("/${uri.pathSegments.first}" == RatingScreen.routeName) {
          return MaterialPageRoute(builder: (context) => RatingScreen(id));
        }
        if ("/${uri.pathSegments.first}" == TravelDetailsScreen.routeName) {
          return MaterialPageRoute(
              builder: (context) => TravelDetailsScreen(id));
        }
        if ("/${uri.pathSegments.first}" ==
              ReservationScreen.routeName) {
            return MaterialPageRoute(
                builder: (context) => ReservationScreen(id));
          }
        return null;
      },
    );
  }
}
