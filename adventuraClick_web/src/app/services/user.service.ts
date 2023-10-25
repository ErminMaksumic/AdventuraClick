import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { UpdateAccount, User } from '../models/user.model';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService<User> {
  private userImageSubject = new BehaviorSubject<string>('');
  private activeMenuSubject = new BehaviorSubject<string>('');
  private usernameSubject = new BehaviorSubject<string>('');
  userImage$ = this.userImageSubject.asObservable();
  activeMenu$ = this.activeMenuSubject.asObservable();
  username$ = this.usernameSubject.asObservable();

  constructor(protected override http: HttpClient) {
    super(http, 'user');
  }

  updateUserAccount(id: number, data: UpdateAccount): Observable<User> {
    return this.http.put<User>(
      `${this.url}/${this.endpoint}/accountUpdate/${id}`,
      data
    );
  }

  profileUpdate(id: number, data: UpdateAccount): Observable<User> {
    return this.http.put<User>(
      `${this.url}/${this.endpoint}/profileUpdate/${id}`,
      data
    );
  }

  updateUserImage(newImageUrl: string) {
    this.userImageSubject.next(newImageUrl);
  }

  updateUsername(newImageUrl: string) {
    this.usernameSubject.next(newImageUrl);
  }

  changeActiveMenu(activeMenu: string) {
    this.activeMenuSubject.next(activeMenu);
  }
}
