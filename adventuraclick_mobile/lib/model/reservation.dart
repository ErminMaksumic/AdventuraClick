import 'package:adventuraclick_mobile/model/additional_services.dart';
import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:json_annotation/json_annotation.dart';
part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  int? reservationId;
  int? userId;
  int? travelId;
  int? paymentId;
  String? status;
  DateTime? date;
  Travel? travel;

  Reservation();

  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  /// Connect the generated [_$RatingToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}