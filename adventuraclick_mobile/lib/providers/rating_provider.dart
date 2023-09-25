import 'package:adventuraclick_mobile/providers/base_provider.dart';
import '../model/rating.dart';

class RatingProvider extends BaseProvider<Rating> {
  RatingProvider() : super("Rating");

  @override
  Rating fromJson(data) {
    return Rating.fromJson(data);
  }
}