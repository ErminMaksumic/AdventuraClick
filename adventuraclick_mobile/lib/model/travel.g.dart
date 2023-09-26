// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'travel.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Travel _$TravelFromJson(Map<String, dynamic> json) => Travel()
  ..travelId = json['travelId'] as int?
  ..name = json['name'] as String?
  ..status = json['status'] as String?
  ..image = json['image'] as String?
  ..description = json['description'] as String?
  ..price = (json['price'] as num?)?.toDouble()
  ..date = json['date'] == null ? null : DateTime.parse(json['date'] as String)
  ..locationId = json['locationId'] as int?
  ..travelTypeId = json['travelTypeId'] as int?
  ..additionalServices = (json['additionalServices'] as List<dynamic>?)
      ?.map((e) => AdditionalServices.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$TravelToJson(Travel instance) => <String, dynamic>{
      'travelId': instance.travelId,
      'name': instance.name,
      'status': instance.status,
      'image': instance.image,
      'description': instance.description,
      'price': instance.price,
      'date': instance.date?.toIso8601String(),
      'locationId': instance.locationId,
      'travelTypeId': instance.travelTypeId,
      'additionalServices': instance.additionalServices,
    };
