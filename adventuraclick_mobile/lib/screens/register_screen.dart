import 'dart:io';
import 'package:adventuraclick_mobile/utils/icons.enum.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import 'package:adventuraclick_mobile/model/user_insert_request.dart';
import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import '../../providers/user_provider.dart';
import '../utils/buildInputFields.dart';

class RegistrationScreen extends StatefulWidget {
  static const String routeName = "/register";
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  State<RegistrationScreen> createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  late UserProvider _userProvider;
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _userNameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _passwordConfirmationController =
      TextEditingController();
  final _formKey = GlobalKey<FormState>();

  String? imageString;
  File? image;

  @override
  void initState() {
    setState(() {});
    super.initState();
  }

  Future<void> pickImage() async {
    try {
      final image = await ImagePicker().pickImage(source: ImageSource.gallery);

      debugPrint(image.toString());

      if (image == null) return;

      final imageTemp = File(image.path);
      final bytes = await image.readAsBytes();
      ByteData.view(bytes.buffer);
      final x = base64String(bytes);

      setState(() {
        this.image = imageTemp;
        imageString = x;
      });
    } on Exception catch (e) {
      print("Failed to pick an image: ${e.toString()}");
    }
  }

  Future<void> register() async {
    try {
      final request = UserInsertRequest();

      request.firstName = _firstNameController.text;
      request.lastName = _lastNameController.text;
      request.userName = _userNameController.text;
      request.email = _emailController.text;
      request.password = _passwordController.text;
      request.passwordConfirmation = _passwordConfirmationController.text;
      request.image = imageString;
      await _userProvider.register(request);

      showDialog(
        context: context,
        builder: (BuildContext context) => AlertDialog(
          title: const Text("Success"),
          content: Text("You are registered as ${_userNameController.text}"),
          actions: [
            TextButton(
              onPressed: () async => await Navigator.popAndPushNamed(
                context,
                LoginScreen.routeName,
              ),
              child: const Text("Ok"),
            ),
          ],
        ),
      );
    } on Exception catch (e) {
      showDialog(
        context: context,
        builder: (BuildContext context) => AlertDialog(
          title: const Text("Error"),
          content: Text(e.toString()),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text("Ok"),
            ),
          ],
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: 200,
                margin: const EdgeInsets.only(top: 10),
                decoration: const BoxDecoration(
                  image: DecorationImage(
                    image: AssetImage('assets/images/background.jpg'),
                    fit: BoxFit.fill,
                  ),
                ),
                child: Center(
                  child: Container(
                    margin: const EdgeInsets.only(top: 160),
                    child: const Text(
                      "Register",
                      style: TextStyle(
                        color: Colors.cyan,
                        fontSize: 40,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
              ),
              image != null
                  ? Image.file(
                      image!,
                      width: 160,
                      height: 160,
                      fit: BoxFit.fill,
                    )
                  : Container(
                      height: 50,
                      margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(10),
                        gradient: const LinearGradient(
                          colors: [Colors.cyan, Colors.blue],
                        ),
                      ),
                      child: InkWell(
                        onTap: () async {
                          pickImage();
                        },
                        child: const Center(
                          child: Text("Select the picture"),
                        ),
                      ),
                    ),
              const Center(
                child: Text(
                  "Picture is required field",
                  style: TextStyle(color: Colors.red),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(50),
                child: Form(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                    children: [
                      buildInputField(
                        _firstNameController,
                        "First name",
                      ),
                      buildInputField(
                        _lastNameController,
                        "Last name",
                      ),
                      buildInputField(
                        _emailController,
                        "Email",
                      ),
                      buildInputField(
                        _userNameController,
                        "Username",
                      ),
                      buildInputField(
                        _passwordController,
                        "Password",
                        isPassword: true,
                      ),
                      buildInputField(
                        _passwordConfirmationController,
                        "Password confirmation",
                        isPassword: true,
                      ),
                      const SizedBox(height: 20),
                      Container(
                        height: 50,
                        margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          gradient: const LinearGradient(
                            colors: [Colors.cyan, Colors.blue],
                          ),
                        ),
                        child: InkWell(
                          onTap: () async {
                            if (_formKey.currentState!.validate()) {
                              register();
                            }
                          },
                          child: const Center(
                            child: Text("Register"),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
