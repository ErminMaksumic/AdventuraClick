// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User()
  ..userId = json['userId'] as int?
  ..firstName = json['firstName'] as String?
  ..lastName = json['lastName'] as String?
  ..username = json['username'] as String?
  ..email = json['email'] as String?
  ..roleId = json['roleId'] as int?
  ..fullName = json['fullName'] as String?
  ..image = json['image'] as String?;

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'userId': instance.userId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'username': instance.username,
      'email': instance.email,
      'roleId': instance.roleId,
      'fullName': instance.fullName,
      'image': instance.image,
    };
