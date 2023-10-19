import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';
import { displayDates } from 'src/app/utils/displayDates';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
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

  constructor(
    private travelService: TravelService,
    private messageNotifications: MessageNotifications
  ) {}

  ngOnInit() {
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
        console.log('error', error);
      },
    });
  }

  hideDialog() {
    this.travelDialog = false;
    this.submitted = false;
  }

  saveTravel(travelValue: Travel) {
    console.log('edited', travelValue);
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
          console.log('error', error);
        },
      });
    this.travels = [...this.travels];
    this.travelDialog = false;
    this.travel = {};
  }

  loadTravels(search: string = '') {
    this.travelService
      .getAll({ IncludeTravelType: true, IncludeTravelInformation: true, 'Name': search })
      .subscribe({
        next: (result: Travel[]) => {
          this.travels = result;
        },
        error: (error: any) => {
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
}
