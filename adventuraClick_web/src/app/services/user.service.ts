import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { getQueryString } from '../utils/queryString';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Authorization } from '../utils/auth.interceptor';

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

  login(username: string, password: string): Observable<Authorization> {
    const queryString = getQueryString({
      username: username,
      password: password,
    });
    const url = `${this.url}/${this.endpoint}/login`;
    const uri = `${url}?${queryString}`;
    
    return this.http.get<Authorization>(uri).pipe(
      tap(result => {
        console.log('result', result);
        localStorage.setItem('JWT', JSON.stringify(result));
      }),
      catchError(error => {
        console.error(error);
        throw { status: 500, message: error };
      })
    );
  }
}
