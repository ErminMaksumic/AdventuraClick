import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

export interface User {
  userId: number;
  firstName: string;
  lastName: string;
  username: string;
  image: string;
  fullName: string;
  price: number;
}

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService<User> {
  constructor(protected override http: HttpClient) {
    super(http, 'user');
  }
}
