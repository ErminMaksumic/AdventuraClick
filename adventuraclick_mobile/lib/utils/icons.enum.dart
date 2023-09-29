import 'package:flutter/material.dart';

enum FieldIcon {
  firstname,
  lastname,
  email,
  username,
  password,
  passwordconfirmation,
}

Map<FieldIcon, IconData> iconMap = {
  FieldIcon.firstname: Icons.person,
  FieldIcon.lastname: Icons.person_outline,
  FieldIcon.email: Icons.email,
  FieldIcon.username: Icons.account_circle,
  FieldIcon.password: Icons.lock,
  FieldIcon.passwordconfirmation: Icons.lock,
};

class IconResolver extends StatelessWidget {
  final String fieldText;

  const IconResolver({Key? key, required this.fieldText}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    FieldIcon? field;
    
    for (var key in iconMap.keys) {
      if (key.toString().split('.').last == fieldText) {
        field = key;
        break;
      }
    }

    IconData iconData = field != null ? iconMap[field] ?? Icons.error : Icons.error; // Default icon if not found
    return Icon(iconData);
  }
}
