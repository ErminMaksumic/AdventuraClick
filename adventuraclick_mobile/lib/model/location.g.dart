// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'location.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Location _$LocationFromJson(Map<String, dynamic> json) => Location()
  ..locationId = json['locationId'] as int?
  ..cityName = json['cityName'] as String?
  ..countryName = json['countryName'] as String?;

Map<String, dynamic> _$LocationToJson(Location instance) => <String, dynamic>{
      'locationId': instance.locationId,
      'cityName': instance.cityName,
      'countryName': instance.countryName,
    };
