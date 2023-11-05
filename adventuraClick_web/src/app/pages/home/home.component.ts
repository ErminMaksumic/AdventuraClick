import { Component } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { Travel } from 'src/app/models/travel.model';
import { User } from 'src/app/models/user.model';
import { ReservationService } from 'src/app/services/reservation.service';
import { TravelService } from 'src/app/services/travel.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  data: any;
  reservations: Reservation[] = [];
  travels: Travel[] = [];
  users: User[] = [];
  months: string[] = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  monthlyOrders: number[] = new Array(12).fill(0);
  travelTypeCounts: { [key: string]: number } = {};
  travelChartData: any;

  constructor(
    private reservationService: ReservationService,
    private travelService: TravelService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.loadReservations();
    this.loadTravels();
    this.loadUsers();
  this.userService.updateUsername('');
    this.userService.changeActiveMenu('Home');
  }

  loadReservations() {
    this.reservationService.getAll().subscribe({
      next: (result: Reservation[]) => {
        this.reservations = result;
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  loadTravels() {
    this.travelService
      .getAll({
        IncludeTravelType: true,
      })
      .subscribe({
        next: (result: Travel[]) => {
          this.travels = result;
          this.processData();
          this.setupChart();
          this.processTravelData();
          this.setupTravelChart();
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  loadUsers() {
    this.userService.getAll({}).subscribe({
      next: (result: User[]) => {
        this.users = result;
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  processData() {
    const currentDate = new Date();
    const currentYear = currentDate.getFullYear();

    this.reservations.forEach((reservation: Reservation) => {
      if (reservation.date) {
        const date = new Date(reservation.date);
        if (date.getFullYear() === currentYear) {
          this.monthlyOrders[date.getMonth()]++;
        }
      }
    });
  }

  setupChart() {
    this.data = {
      labels: this.months,
      datasets: [
        {
          label: 'Number of reservations',
          data: this.monthlyOrders,
          fill: false,
          borderColor: '#47C7F0',
        },
      ],
    };
  }

  processTravelData() {
    this.travels.forEach((travel: Travel) => {
      if (travel.travelType && travel.travelType.name) {
        const typeName = travel.travelType.name;
        if (!this.travelTypeCounts[typeName]) {
          this.travelTypeCounts[typeName] = 1;
        } else {
          this.travelTypeCounts[typeName]++;
        }
      }
    });
  }

  setupTravelChart() {
    this.travelChartData = {
      labels: Object.keys(this.travelTypeCounts),
      datasets: [
        {
          data: Object.values(this.travelTypeCounts),
          backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
          hoverBackgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
        },
      ],
    };
  }
}
