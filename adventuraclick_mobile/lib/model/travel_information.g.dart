// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'travel_information.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TravelInformation _$TravelInformationFromJson(Map<String, dynamic> json) =>
    TravelInformation()
      ..travelInformationId = json['travelInformationId'] as int?
      ..departureTime = json['departureTime'] == null
          ? null
          : DateTime.parse(json['departureTime'] as String);

Map<String, dynamic> _$TravelInformationToJson(TravelInformation instance) =>
    <String, dynamic>{
      'travelInformationId': instance.travelInformationId,
      'departureTime': instance.departureTime?.toIso8601String(),
    };
