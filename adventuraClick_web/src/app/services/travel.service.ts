import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Travel } from '../models/travel.model';

@Injectable({
  providedIn: 'root',
})
export class TravelService extends BaseService<Travel> {
  constructor(protected override http: HttpClient) {
    super(http, 'travel');
  }
}
