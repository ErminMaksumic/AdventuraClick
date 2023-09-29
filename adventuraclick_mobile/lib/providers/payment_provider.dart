import 'package:adventuraclick_mobile/model/payment.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';

class PaymentProvider extends BaseProvider<Payment> {
  PaymentProvider() : super("Payment");

  @override
  Payment fromJson(data) {
    return Payment.fromJson(data);
  }
}