import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Rating } from '../models/rating.model';

@Injectable({
  providedIn: 'root',
})
export class RatingService extends BaseService<Rating> {
  constructor(protected override http: HttpClient) {
    super(http, 'rating');
  }
}
