import 'dart:io';
import 'package:adventuraclick_mobile/screens/travel_screens/travel_list.dart';
import 'package:adventuraclick_mobile/utils/app_colors.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import '../../../providers/user_provider.dart';
import '../../utils/buildInputFields.dart';

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
      if (kDebugMode) {
        print("Failed to pick an image: ${e.toString()}");
      }
    }
  }

  Future<void> register() async {
    try {
      var user = await _userProvider.register({
        'firstName': _firstNameController.text,
        'lastName': _lastNameController.text,
        'username': _userNameController.text,
        'email': _emailController.text,
        'password': _passwordController.text,
        'passwordConfirmation': _passwordConfirmationController.text,
        'image': imageString,
      });
      if (!mounted) return;
      // Login the user
      Authorization.user = await _userProvider.login(_userNameController.text, _passwordController.text);
      Authorization.user = user;
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) => AlertDialog(
          title: const Text("Success"),
          content: Text("You are registered as ${_userNameController.text}"),
          actions: [
            TextButton(
              onPressed: () async => await Navigator.popAndPushNamed(
                context,
                TravelListScreen.routeName,
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
      appBar: AppBar(
          backgroundColor: const Color.fromARGB(156, 126, 97, 101),
          title: const Text("AdventuraClick")),
      body: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: 200,
                margin: const EdgeInsets.only(bottom: 20),
                decoration: const BoxDecoration(
                  image: DecorationImage(
                    image: AssetImage('assets/images/background.jpg'),
                    fit: BoxFit.fill,
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
                  colors: AppColors.selectPictureButton,
                        ),
                      ),
                      child: InkWell(
                        onTap: () async {
                          pickImage();
                        },
                        child: const Center(
                          child: Text(
                            "Select the picture",
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                    ),
              Padding(
                padding: const EdgeInsets.fromLTRB(20, 20, 20, 3),
                child: Card(
                  elevation: 5,
                  child: Padding(
                    padding: const EdgeInsets.all(20),
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
                        ],
                      ),
                    ),
                  ),
                ),
              ),
              Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: const LinearGradient(
                  colors: [Color.fromRGBO(175, 113, 122, 0.612), Color.fromARGB(255, 94, 151, 170)],
                  ),
                ),
                child: InkWell(
                  onTap: () async {
                    if (_formKey.currentState!.validate() &&
                        imageString != null) {
                      register();
                    } else {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Registration failed"),
                                content: const Text(
                                    "Check field inputs and/or select the image!"),
                                actions: [
                                  TextButton(
                                    child: const Text("Ok"),
                                    onPressed: () => Navigator.pop(context),
                                  )
                                ],
                              ));
                    }
                  },
                  child: const Center(
                    child: Text(
                      "Register",
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ),
              ),
              const SizedBox(height: 20),
            ],
          ),
        ),
      ),
    );
  }
}
