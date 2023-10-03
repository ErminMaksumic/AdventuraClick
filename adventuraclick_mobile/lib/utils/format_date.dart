import 'package:intl/intl.dart';

String formatDate(String inputDate) {
  DateTime parsedDate = DateTime.parse(inputDate);
  return DateFormat('dd-MM-yyyy').format(parsedDate);
}

