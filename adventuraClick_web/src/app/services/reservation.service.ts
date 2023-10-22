import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Reservation } from '../models/reservation.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ReservationService extends BaseService<Reservation> {
  constructor(protected override http: HttpClient) {
    super(http, 'reservation');
  }

  changeReservationStatus(id: number, newStatus: string): Observable<Reservation> {
    return super.changeStatus(id, newStatus);
  }
}
