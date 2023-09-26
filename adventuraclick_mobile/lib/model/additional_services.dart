import 'package:json_annotation/json_annotation.dart';
part 'additional_services.g.dart';

@JsonSerializable()
class AdditionalServices {
  int? addServiceId;
  String? name;
  double? price;

  AdditionalServices();

  factory AdditionalServices.fromJson(Map<String, dynamic> json) => _$AdditionalServicesFromJson(json);

  /// Connect the generated [_$AdditionalServicesToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$AdditionalServicesToJson(this);
}