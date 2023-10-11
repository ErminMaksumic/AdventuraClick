import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getQueryString } from '../utils/queryString';
import { BaseService } from './base.service';
import { Observable, catchError, tap } from 'rxjs';
import { AuthResponse, LoginCredentials, User } from '../models/user.model';
import { AuthorizationResponse } from '../models/auth-response.model';

@Injectable({
  providedIn: 'root',
})
export class SecurityService extends BaseService<User> {
  private tokenKey: string = 'JWT';
  constructor(protected override http: HttpClient) {
    super(http, 'user');
  }

  isAuthenticated() {
    // Get token
    const token = localStorage.getItem(this.tokenKey);
    if (!token) return false;
    // Decode token
    const decodedToken = this.decodeToken(token);
    const expirationDate = new Date(decodedToken.exp * 1000);
    // Check token expiration date
    if (expirationDate <= new Date()) {
      this.logout();
      return false;
    }
    return true;
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }

  getFieldFromJWT(field: string) {
    const token = localStorage.getItem(this.tokenKey);

    if (!token) return '';
    const dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[field];
  }

  login(loginCredentials: LoginCredentials): Observable<AuthorizationResponse> {
    const queryString = getQueryString({
      username: loginCredentials.username,
      password: loginCredentials.password,
    });
    const url = `${this.url}/${this.endpoint}/login`;
    const uri = `${url}?${queryString}`;

    return this.http.get<AuthorizationResponse>(uri).pipe(
      tap((result) => {
        localStorage.setItem('JWT', JSON.stringify(result));
      }),
      catchError((error) => {
        console.error(error);
        throw { status: 500, message: error };
      })
    );
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }

  decodeToken(token: string): any {
    try {
      const payload = token.split('.')[1];
      const base64 = payload.replace('-', '+').replace('_', '/');
      return JSON.parse(window.atob(base64));
    } catch (err) {
      return null;
    }
  }
}
