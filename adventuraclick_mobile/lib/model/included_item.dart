import 'package:json_annotation/json_annotation.dart';
part 'included_item.g.dart';

@JsonSerializable()
class IncludedItem {
  int? includedItemId;
  String? name;

  IncludedItem();

  factory IncludedItem.fromJson(Map<String, dynamic> json) => _$IncludedItemFromJson(json);

  /// Connect the generated [_$IncludedItemToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$IncludedItemToJson(this);
}