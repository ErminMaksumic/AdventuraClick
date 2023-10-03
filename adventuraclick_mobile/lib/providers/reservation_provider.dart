import 'dart:convert';

import 'package:adventuraclick_mobile/model/reservation.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class ReservationProvider extends BaseProvider<Reservation> {
  ReservationProvider() : super("Reservation");

  @override
  Reservation fromJson(data) {
    return Reservation.fromJson(data);
  }

  Future<void> sendConfirmationEmail(dynamic request) async {
    var url = Uri.parse("$fullUrl/sendConfirmationEmail");

    Map<String, String> headers = createHeaders();

    var jsonRequest = jsonEncode(request);
    await http!.post(url, headers: headers, body: jsonRequest);
  }
}