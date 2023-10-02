import 'package:intl/intl.dart';

String formatNumber(dynamic)
{
  if(dynamic == null)
  {
    return '';
  }
  var f = NumberFormat('###.00');
  return f.format(dynamic);
}