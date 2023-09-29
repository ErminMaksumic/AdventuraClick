import 'package:adventuraclick_mobile/data/mockResponse.dart';
import 'package:adventuraclick_mobile/model/included_item.dart';
import 'package:adventuraclick_mobile/model/location.dart';
import 'package:adventuraclick_mobile/model/travel_information.dart';
import 'package:adventuraclick_mobile/model/travel_type.dart';
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
  int? numberOfNights;
  DateTime? date;
  int? locationId;
  int? travelTypeId;
  TravelType? travelType;
  Location? location;
  List<IncludedItem>? includedItems;
  List<TravelInformation>? travelInformations;

  Travel();

  factory Travel.fromJson(Map<String, dynamic> json) => _$TravelFromJson(json);

  /// Connect the generated [_$TravelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TravelToJson(this);
}