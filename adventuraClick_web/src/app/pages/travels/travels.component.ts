import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';
import { displayDates } from 'src/app/utils/displayDates';
import { MessageNotifications } from 'src/app/utils/messageNotifications';

@Component({
  selector: 'table-products-demo',
  templateUrl: 'travels.component.html',
  styleUrls: ['travels.component.css'],
  providers: [MessageService, ConfirmationService],
})
export class TravelsComponent implements OnInit {
  travelDialog: boolean = false;
  travels!: Travel[];
  travel!: Travel;
  selectedProducts!: Travel[] | null;
  submitted: boolean = false;
  joinedDates: string = '';

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

  editProduct(product: Travel) {
    this.travel = { ...product };
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

  loadTravels() {
    this.travelService
      .getAll({ IncludeTravelType: true, IncludeTravelInformation: true })
      .subscribe({
        next: (result: Travel[]) => {
          this.travels = result;
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  transformImage(image: string) {
    return 'data:image/jpeg;base64,' + image;
  }

  displayDatesWrapper(travelInformations: any) {
    return displayDates(travelInformations);
  }
}
