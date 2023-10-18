import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuItem, MessageService } from 'primeng/api';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { getSteps } from 'src/app/utils/steps';

@Component({
  selector: 'app-travels-create',
  templateUrl: 'travels-create.component.html',
  styleUrls: ['travels-create.component.css'],
})
export class TravelsCreateComponent implements OnInit {
  items: MenuItem[] | undefined;
  groupData!: FormGroup;
  formData = new FormData();
  activeIndex: number = 0;

  constructor(
    private builder: FormBuilder,
    private travelService: TravelService,
    private messageNotifications: MessageNotifications
  ) {}

  onActiveIndexChange(event: number) {
    this.activeIndex = event;
  }

  ngOnInit() {
    this.items = getSteps();

    this.groupData = this.builder.group({
      name: [
        '',
        { validators: [Validators.required, Validators.minLength(3)] },
      ],
      price: [0, { validators: [Validators.required] }],
    });
  }

  save() {
    this.travelService.create(this.groupData.value).subscribe({
      next: (result: Travel) => {
        this.messageNotifications.showSuccess(
          'Travel created',
          'Travel created successfully'
        );
        console.log("result", result);
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }
}
