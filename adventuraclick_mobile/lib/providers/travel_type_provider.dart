import 'package:adventuraclick_mobile/model/travel_type.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class TravelTypeProvider extends BaseProvider<TravelType> {
  TravelTypeProvider() : super("TravelType");

  @override
  TravelType fromJson(data) {
    return TravelType.fromJson(data);
  }
}