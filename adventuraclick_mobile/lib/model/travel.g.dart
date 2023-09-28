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
  ..numberOfNights = json['numberOfNights'] as int
  ..date = json['date'] == null ? null : DateTime.parse(json['date'] as String)
  ..locationId = json['locationId'] as int?
  ..travelTypeId = json['travelTypeId'] as int?
  ..travelType = json['travelType'] == null
      ? null
      : TravelType.fromJson(json['travelType'] as Map<String, dynamic>)
  ..location = json['location'] == null
      ? null
      : Location.fromJson(json['location'] as Map<String, dynamic>)
  ..includedItems = (json['includedItems'] as List<dynamic>?)
      ?.map((e) => IncludedItem.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$TravelToJson(Travel instance) => <String, dynamic>{
      'travelId': instance.travelId,
      'name': instance.name,
      'status': instance.status,
      'image': instance.image,
      'description': instance.description,
      'price': instance.price,
      'numberOfNights': instance.numberOfNights,
      'date': instance.date?.toIso8601String(),
      'locationId': instance.locationId,
      'travelTypeId': instance.travelTypeId,
      'travelType': instance.travelType,
      'location': instance.location,
      'includedItems': instance.includedItems,
    };
