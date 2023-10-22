import { Component } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { TravelInformation } from 'src/app/models/travel-information.model';
import { ReservationService } from 'src/app/services/reservation.service';
import { displayDates } from 'src/app/utils/displayDates';
import { MessageNotifications } from 'src/app/utils/messageNotifications';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css'],
})
export class ReservationsComponent {
  reservations: Reservation[] = [];
  searchQuery: string = '';

  constructor(
    private reservationService: ReservationService,
    private messageNotifications: MessageNotifications
  ) {}

  loadReservations(search: string = '') {
    this.reservationService
      .getAll({
        IncludeUser: true,
        IncludeTravelInformation: true,
        IncludePayment: true,
        IncludeAdditionalServices: true,
        IncludeTravel: true,
        name: search,
        username: search,
      })
      .subscribe({
        next: (result: Reservation[]) => {
          this.reservations = result;
          console.log("reservations", this.reservations);
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  search(input: string)
  {
    this.loadReservations(input);
  }

  ngOnInit() {
    this.loadReservations();
  }

  formatDateWrapper(travelInformation: TravelInformation) {
    return displayDates([travelInformation]);
  }

  cancelReservation(reservationId: number) {
    this.reservationService
      .changeReservationStatus(reservationId, 'Canceled')
      .subscribe({
        next: () => {
          this.messageNotifications.showSuccess(
            'Status changed',
            'Status changed successfully'
          );
          this.loadReservations();
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }
}
