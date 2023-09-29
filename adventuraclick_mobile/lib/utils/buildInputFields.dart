import 'package:adventuraclick_mobile/utils/icons.enum.dart';
import 'package:flutter/material.dart';

Widget buildInputField(
    TextEditingController controller,
    String labelText, {
    bool isPassword = false,
    bool optional = false,
  }) {
    return Container(
      padding: const EdgeInsets.all(10),
      child: TextFormField(
        obscureText: isPassword,
        validator: (value) {
          if (value!.isEmpty && !optional) {
            return "Required field!";
          }
          return null;
        },
        controller: controller,
        decoration: InputDecoration(
          prefixIcon: IconResolver(fieldText: labelText.toLowerCase().replaceAll(' ', '')),
          prefixIconColor: Colors.deepPurple,
          enabledBorder: const OutlineInputBorder(
        borderSide: BorderSide(color: Colors.deepPurple), // Change the border color here
      ),
          labelText: labelText,
          labelStyle: const TextStyle(color: Colors.deepPurple),
          errorStyle: const TextStyle(color: Colors.red),
        ),
      ),
    );
  }