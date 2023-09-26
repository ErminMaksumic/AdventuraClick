import 'dart:io';
import 'dart:typed_data';
import 'package:adventuraclick_mobile/model/user.dart';
import 'package:adventuraclick_mobile/screens/login_screen.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';
import 'package:adventuraclick_mobile/utils/buildInputFields.dart';
import 'package:adventuraclick_mobile/utils/image_util.dart';
import 'package:adventuraclick_mobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import '../../providers/user_provider.dart';

class ProfileScreen extends StatefulWidget {
  static const String routeName = "/profile";
  const ProfileScreen({Key? key}) : super(key: key);

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  final TextEditingController _newPasswordController = TextEditingController();
  final TextEditingController _newPasswordConfirmationController =
      TextEditingController();
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  late UserProvider _userProvider;
  final _formKey = GlobalKey<FormState>();
  String? currentPicture = Authorization.user!.image;
  String? imageString;
  File? image;

  @override
  Widget build(BuildContext context) {
    _firstNameController.text = Authorization.user?.firstName ?? '';
    _lastNameController.text = Authorization.user?.lastName ?? '';
    _userProvider = Provider.of(context, listen: false);

    return MasterScreenWidget(
        index: 2,
        child: SingleChildScrollView(
            child: Column(
          children: [
            Container(
              padding: const EdgeInsets.all(10),
              color: Colors.deepPurple[50],
              child: const Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    "Edit your profile",
                    style: TextStyle(
                      color: Colors.deepPurple,
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ],
              ),
            ),
            Container(
              width: 300,
              margin: const EdgeInsets.only(top: 10),
              child: Stack(
                children: [
                  SizedBox(
                    height: 250,
                    width: 500,
                    child: Column(
                      children: [
                        SizedBox(
                            height: 250,
                            width: 300,
                            child: (image == null && currentPicture == null)
      ? Image.asset('assets/images/404.png') // Zamijenjate 'treca_slika.png' sa stvarnim putem do vaše treće slike u assetima
      : (image == null
          ? imageFromBase64String(currentPicture!)
          : Image.file(image!))),
                      ],
                    ),
                  ),
                ],
              ),
            ),
            Container(
              height: 40,
              margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: const LinearGradient(
                      colors: [Colors.red, Colors.deepPurple])),
              child: InkWell(
                onTap: () async {
                  pickImage();
                },
                child: const Center(
                    child: Text(
                  "Select new picture",
                  style: TextStyle(color: Colors.white),
                )),
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
                        buildInputField(_firstNameController, "First name",
                            optional: true),
                        buildInputField(
                          _lastNameController,
                          "Last name",
                          optional: true,
                        ),
                        buildInputField(
                          _newPasswordController,
                          "Password",
                          optional: true,
                          isPassword: true,
                        ),
                        buildInputField(_newPasswordConfirmationController,
                            "Password confirmation",
                            isPassword: true, optional: true),
                      ],
                    ),
                  ),
                ),
              ),
            ),
            const SizedBox(height: 20),
            Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(45, 0, 45, 0),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: const LinearGradient(
                        colors: [Colors.deepPurple, Colors.red])),
                child: InkWell(
                  onTap: () async {
                    User? result;
                    try {
                      result = await _userProvider.updateProfile({
                        'firstName': _firstNameController.text,
                        'lastName': _lastNameController.text,
                        'password': _newPasswordController.text,
                        'passwordConfirmation':
                            _newPasswordConfirmationController.text,
                        'image': imageString,
                      });
                      if (result != null) {
                        Authorization.password = _newPasswordController.text;
                        if (!mounted) return;
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: const Text("Success"),
                                  content: const Text(
                                      "Profile successfully edited!"),
                                  actions: [
                                    TextButton(
                                        onPressed: () async => {
                                              await Navigator.popAndPushNamed(
                                                  context,
                                                  LoginScreen.routeName)
                                            },
                                        child: const Text("Ok"))
                                  ],
                                ));
                      }
                    } on Exception {
                      if (!mounted) return;
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Profile change failed"),
                                content: const Text("Check field inputs"),
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
                    child:
                        Text("Change", style: TextStyle(color: Colors.white)),
                  ),
                )),
            const SizedBox(height: 20),
          ],
        )));
  }

  Future pickImage() async {
    try {
      final image = await ImagePicker().pickImage(source: ImageSource.gallery);

      debugPrint(image.toString());

      if (image == null) return;

      final imageTemp = File(image.path);
      Uint8List bytes = await image.readAsBytes();
      ByteData.view(bytes.buffer);
      var x = base64String(bytes);

      setState(() {
        this.image = imageTemp;
        imageString = x;
      });
    } on Exception catch (e) {
      print("failed to pick an image: ${e.toString()}");
    }
  }
}
