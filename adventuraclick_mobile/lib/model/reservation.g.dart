// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation()
  ..reservationId = json['reservationId'] as int?
  ..userId = json['userId'] as int?
  ..travelId = json['travelId'] as int?
  ..paymentId = json['paymentId'] as int?
  ..status = json['status'] as String?
  ..date = json['date'] == null ? null : DateTime.parse(json['date'] as String)
  ..travel = json['travel'] == null
      ? null
      : Travel.fromJson(json['travel'] as Map<String, dynamic>);

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'reservationId': instance.reservationId,
      'userId': instance.userId,
      'travelId': instance.travelId,
      'paymentId': instance.paymentId,
      'status': instance.status,
      'date': instance.date?.toIso8601String(),
      'travel': instance.travel,
    };
