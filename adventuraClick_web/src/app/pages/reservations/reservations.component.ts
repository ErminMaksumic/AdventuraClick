import { Component } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { TravelInformation } from 'src/app/models/travel-information.model';
import { ReservationService } from 'src/app/services/reservation.service';
import { UserService } from 'src/app/services/user.service';
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
  additionalServicesInfoModal: boolean = false;
  additionalServicesOptions: { label: string }[] = [];
  reservationDetails: Reservation | undefined = {};
  includedItems: { label: string }[] = [];

  constructor(
    private reservationService: ReservationService,
    private messageNotifications: MessageNotifications,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.changeActiveMenu('Reservations');
    this.loadReservations();
  }

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
          console.log('reservations', this.reservations);
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  search(input: string) {
    this.loadReservations(input);
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

  showModalData(reservation: Reservation) {
    this.additionalServicesInfoModal = true;
    this.reservationDetails = reservation;
    this.additionalServicesOptions = reservation.additionalServices?.map(
      (service) => {
        return { label: `${service.name} - ${service.price}%` };
      }
    ) || [{ label: 'No data' }];
    this.showIncludedItems(reservation);
  }

  showIncludedItems(reservation: Reservation) {
    this.includedItems = reservation.travel?.includedItems?.map((item) => {
      return { label: item.name || 'No data' };
    }) || [{ label: 'No data' }];
  }
}
