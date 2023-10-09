import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
} from '@angular/common/http';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const encodedCredentials = localStorage.getItem('userInfo');
    console.log('encoded', encodedCredentials);
    if (encodedCredentials) {
      req = req.clone({
        setHeaders: {
          Authorization: 'Basic ' + encodedCredentials,
          'Content-Type': 'application/json',
        },
      });
    }
    return next.handle(req);
  }
}

export class Authorization {
  static password: string;
  static username: string;
}
