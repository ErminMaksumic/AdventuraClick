import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { UpdateAccount, User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService<User> {
  constructor(protected override http: HttpClient) {
    super(http, 'user');
  }

  updateUserAccount(id: number, data: UpdateAccount): Observable<User> {
    return this.http.put<User>(
      `${this.url}/${this.endpoint}/accountUpdate/${id}`,
      data
    );
  }
}
