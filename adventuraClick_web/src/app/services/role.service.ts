import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Role } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class RoleService extends BaseService<Role> {
  constructor(protected override http: HttpClient) {
    super(http, 'role');
  }
}
