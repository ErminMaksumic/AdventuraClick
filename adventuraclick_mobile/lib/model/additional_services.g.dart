// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'additional_services.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AdditionalServices _$AdditionalServicesFromJson(Map<String, dynamic> json) =>
    AdditionalServices()
      ..addServiceId = json['addServiceId'] as int?
      ..name = json['name'] as String?
      ..price = (json['price'] as num?)?.toDouble();

Map<String, dynamic> _$AdditionalServicesToJson(AdditionalServices instance) =>
    <String, dynamic>{
      'addServiceId': instance.addServiceId,
      'name': instance.name,
      'price': instance.price,
    };
