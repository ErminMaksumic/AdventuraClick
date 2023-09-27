import 'package:adventuraclick_mobile/model/reservation.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class ReservationProvider extends BaseProvider<Reservation> {
  ReservationProvider() : super("Rating");

  @override
  Reservation fromJson(data) {
    return Reservation.fromJson(data);
  }
}