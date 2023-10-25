import 'dart:convert';

import 'package:adventuraclick_mobile/model/user.dart';
import 'package:adventuraclick_mobile/providers/base_provider.dart';
import 'package:adventuraclick_mobile/utils/auth_helper.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<User> login(String username, String password) async {
    var url = "$fullUrl/login";
    String queryString =
        getQueryString({'username': username, 'password': password});
    url = "$url?$queryString";
    var uri = Uri.parse(url);

    var response = await http!.get(uri);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      Authorization.jwt = JWT()..token = data['token'];
      var user = await get({
        "userName": username,
      });
      return user[0];
    } else {
      throw Exception("An error occured!");
    }
  }

  Future<User?> register(dynamic request) async {
    var url = Uri.parse("$fullUrl");

    Map<String, String> headers = {"Content-Type": "application/json"};
    var jsonRequest = jsonEncode(request);
    var response = await http!.post(url, headers: headers, body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }

  Future<User?> updateProfile(dynamic request) async {
    var url = Uri.parse("$fullUrl/profileUpdate/${Authorization.user!.userId}");

    Map<String, String> headers = createHeaders();
    var response =
        await http!.put(url, headers: headers, body: jsonEncode(request));

    if (response.statusCode == 400) {
      var body = jsonDecode(response.body);
      var errMsg = body['errors'];
      throw Exception(errMsg.toString().replaceAll(RegExp(r'[\[\]{}]'), ''));
    }

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }

  Future<bool> isReserved(String travelId) async {
    var url = Uri.parse(
        "$fullUrl/isReserved/${Authorization.user?.userId}/$travelId");
    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      return response.body.toLowerCase() == 'true';
    } else {
      throw Exception("An error occured!");
    }
  }
}
