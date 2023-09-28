import 'package:json_annotation/json_annotation.dart';
part 'travel_information.g.dart';

@JsonSerializable()
class TravelInformation {
  int? travelInformationId;
  String? departureTime;

  TravelInformation();

  factory TravelInformation.fromJson(Map<String, dynamic> json) => _$TravelInformationFromJson(json);

  /// Connect the generated [_$TravelInformationToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TravelInformationToJson(this);
}