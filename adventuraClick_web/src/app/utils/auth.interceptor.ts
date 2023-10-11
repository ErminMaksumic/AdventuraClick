import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
} from '@angular/common/http';

export interface Authorization
{
  JWT: string;
}

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const encodedCredentials = localStorage.getItem('JWT');
    console.log('encoded', encodedCredentials);
    if (encodedCredentials) {
      req = req.clone({
        setHeaders: {
          Authorization: 'Bearer ' + encodedCredentials,
          'Content-Type': 'application/json',
        },
      });
    }
    return next.handle(req);
  }
}