import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';
import { UserService } from 'src/app/services/user.service';
import { displayDates } from 'src/app/utils/displayDates';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { parseWebAPiErrors } from 'src/app/utils/parseWebApiErrors';
import { transformImage } from 'src/app/utils/transformImage';

@Component({
  templateUrl: 'travels.component.html',
  styleUrls: ['travels.component.css'],
  providers: [MessageService, ConfirmationService],
})
export class TravelsComponent implements OnInit {
  travelDialog: boolean = false;
  travels!: Travel[];
  travel!: Travel;
  submitted: boolean = false;
  joinedDates: string = '';
  searchQuery: string = '';
  errors: string[] = [];

  constructor(
    private travelService: TravelService,
    private messageNotifications: MessageNotifications,
    private router: Router,
    private userService: UserService,
  ) {}

  ngOnInit() {
    this.userService.changeActiveMenu('travels');
    this.loadTravels();
  }

  openNew() {
    this.travel = {};
    this.submitted = false;
    this.travelDialog = true;
  }

  editTravel(travel: Travel) {
    this.travel = { ...travel };
    this.travelDialog = true;
  }

  deleteTravel(travelId: number) {
    this.travelService.delete(travelId).subscribe({
      next: () => {
        this.messageNotifications.showSuccess(
          'Travel deleted',
          'Travel deleted successfully'
        );
        this.loadTravels()
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
        console.log('error', error);
      },
    });
  }

  hideDialog() {
    this.travelDialog = false;
    this.submitted = false;
  }

  saveTravel(travelValue: Travel) {
    this.submitted = true;
    this.travelService
      .update(this.travel.travelId || 0, travelValue)
      .subscribe({
        next: (result: Travel) => {
          this.travel = result;
          this.loadTravels();
          this.messageNotifications.showSuccess(
            'Travel edited',
            'Travel edited successfully'
          );
        },
        error: (error: any) => {
          this.errors = parseWebAPiErrors(error);
          console.log('error', error);
        },
      });
    this.travels = [...this.travels];
    this.travelDialog = false;
    this.travel = {};
    this.router.navigate(['travels']);
  }

  loadTravels(search: string = '') {
    this.travelService
      .getAll({ IncludeTravelType: true, IncludeTravelInformation: true, 'Name': search })
      .subscribe({
        next: (result: Travel[]) => {
          this.travels = result;
        },
        error: (error: any) => {
          this.errors = parseWebAPiErrors(error);
          console.log('error', error);
        },
      });
  }

  displayDatesWrapper(travelInformations: any) {
    return displayDates(travelInformations);
  }

  transformImageWrapper(image: string){
    return transformImage(image);
  }

  search(input: string)
  {
    this.loadTravels(input);
  }

  showModal(){
    this.userService.changeActiveMenu('Create Travel');
    this.router.navigate(['travels/create']);
  }
}
