import 'package:adventuraclick_mobile/model/additional_services.dart';
import 'package:json_annotation/json_annotation.dart';
part 'travel.g.dart';

@JsonSerializable()
class Travel {
  int? travelId;
  String? name;
  String? status;
  String? image;
  String? description;
  double? price;
  DateTime? date;
  int? locationId;
  int? travelTypeId;
  List<AdditionalServices>? additionalServices;

  Travel();

  factory Travel.fromJson(Map<String, dynamic> json) => _$TravelFromJson(json);

  /// Connect the generated [_$TravelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TravelToJson(this);
}