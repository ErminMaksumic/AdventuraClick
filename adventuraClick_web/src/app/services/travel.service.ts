import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

export interface Travel {
  travelId: number;
  date: Date;
  description: string;
  image: string;
  name: string;
  numberOfNights: string;
  price: number;
}

@Injectable({
  providedIn: 'root',
})
export class TravelService extends BaseService<Travel> {
  constructor(protected override http: HttpClient) {
    super(http, 'travel');
  }
}
