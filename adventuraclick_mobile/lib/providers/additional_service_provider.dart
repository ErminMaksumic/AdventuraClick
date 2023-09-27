import 'package:adventuraclick_mobile/model/additional_services.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class AdditionalServiceProvider extends BaseProvider<AdditionalServices> {
  AdditionalServiceProvider() : super("AdditionalServices");

  @override
  AdditionalServices fromJson(data) {
    return AdditionalServices.fromJson(data);
  }
}