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

  login(username: string, password: string) {
    let result;
    try {
      const encodedCredentials = 'Basic ' + btoa(`${username}:${password}`);
      result = this.http.get<User>(`${this.url}/${this.endpoint}/login`, {
        headers: { Authorization: encodedCredentials },
      });
      localStorage.setItem('user', JSON.stringify(encodedCredentials));
      return result;
    } catch (error) {
      throw {
        status: 500,
        message: error,
      };
    }
  }
}
