// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'travel_type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TravelType _$TravelTypeFromJson(Map<String, dynamic> json) => TravelType()
  ..travelTypeId = json['travelTypeId'] as int?
  ..name = json['name'] as String?
  ..description = json['description'] as String?;

Map<String, dynamic> _$TravelTypeToJson(TravelType instance) =>
    <String, dynamic>{
      'travelTypeId': instance.travelTypeId,
      'name': instance.name,
      'description': instance.description,
    };
