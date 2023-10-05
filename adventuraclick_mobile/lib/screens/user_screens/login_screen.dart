import 'package:adventuraclick_mobile/providers/user_provider.dart';
import 'package:adventuraclick_mobile/screens/user_screens/profile_edit_screen.dart';
import 'package:adventuraclick_mobile/screens/user_screens/register_screen.dart';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_list.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:adventuraclick_mobile/utils/buildInputFields.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

// ignore: must_be_immutable
class LoginScreen extends StatelessWidget {
  static const String routeName = "/login";
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;
  final _formKey = GlobalKey<FormState>();

  LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of(context, listen: false);

    return Scaffold(
      appBar: AppBar(
          backgroundColor: const Color.fromARGB(156, 126, 97, 101),
          title: const Text("AdventuraClick")),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 350,
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/background.jpg'),
                  fit: BoxFit.cover,
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: Card(
                elevation: 5,
                child: Padding(
                  padding: const EdgeInsets.all(20),
                  child: Form(
                    key: _formKey,
                    autovalidateMode: AutovalidateMode.onUserInteraction,
                    child: Column(
                      children: [
                        buildInputField(_usernameController, 'Username'),
                        const SizedBox(height: 20),
                        buildInputField(_passwordController, 'Password',
                            isPassword: true),
                      ],
                    ),
                  ),
                ),
              ),
            ),
            Container(
              height: 50,
              margin: const EdgeInsets.symmetric(horizontal: 20),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                boxShadow: [
                  BoxShadow(
                    color: Colors.blue.withOpacity(0.5),
                    spreadRadius: 1,
                    blurRadius: 5,
                    offset: const Offset(0, 3),
                  ),
                ],
                gradient: const LinearGradient(
                  colors: AppColors.submitButton,
                ),
              ),
              child: InkWell(
                onTap: () async {
                  try {
                    if (_formKey.currentState!.validate()) {
                      Authorization.username = _usernameController.text;
                      Authorization.password = _passwordController.text;
                      Authorization.user = await _userProvider.login();
                      if (!context.mounted) return;
                      Navigator.popAndPushNamed(
                          context, TravelListScreen.routeName);
                    }
                  } on Exception {
                    if (!context.mounted) return;
                    showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                        title: const Text("Login failed"),
                        content: const Text("Invalid username and/or password"),
                        actions: [
                          TextButton(
                            child: const Text("Ok"),
                            onPressed: () => Navigator.pop(context),
                          )
                        ],
                      ),
                    );
                  }
                },
                child: const Center(
                  child: Text(
                    "Login",
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                      fontSize: 18,
                    ),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 20),
            GestureDetector(
              onTap: () {
                // Navigate to registration screen
                Navigator.pushNamed(context, RegistrationScreen.routeName);
              },
              child: const Text(
                "Not Registered? Click here!",
                style: TextStyle(
                  color: Color.fromARGB(255, 23, 43, 24),
                  decoration: TextDecoration.underline,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
