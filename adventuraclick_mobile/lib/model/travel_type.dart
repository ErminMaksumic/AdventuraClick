import 'package:json_annotation/json_annotation.dart';
part 'travel_type.g.dart';

@JsonSerializable()
class TravelType {
  int? travelTypeId;
  String? name;
  String? description;

  TravelType();

  factory TravelType.fromJson(Map<String, dynamic> json) => _$TravelTypeFromJson(json);

  /// Connect the generated [_$TravelTypeToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TravelTypeToJson(this);
}