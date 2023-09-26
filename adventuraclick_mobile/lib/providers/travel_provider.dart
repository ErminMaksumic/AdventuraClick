import 'package:adventuraclick_mobile/model/travel.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class TravelProvider extends BaseProvider<Travel> {
  TravelProvider() : super("Travel");

  @override
  Travel fromJson(data) {
    return Travel.fromJson(data);
  }
}