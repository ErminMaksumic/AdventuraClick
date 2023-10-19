import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
} from '@angular/common/http';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const tokenData = JSON.parse(localStorage.getItem('JWT') || '{}');
    const tokenValue = tokenData.token;
    if (tokenValue) {
      req = req.clone({
        setHeaders: {
          Authorization: 'Bearer ' + tokenValue,
          'Content-Type': 'application/json',
        },
      });
    }
    return next.handle(req);
  }
}
