import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuItem } from 'primeng/api';
import { Travel } from 'src/app/models/travel.model';
import { TravelService } from 'src/app/services/travel.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { getSteps } from 'src/app/utils/steps';
import { imgToByte } from 'src/app/utils/transformImage';

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
  uploadedImage: any;

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
      numberOfNights: [
        0,
        { validators: [Validators.required, Validators.min(1)] },
      ],
      description: ['', { validators: [Validators.maxLength(250)] }],
      imageString: [''],
      location: this.builder.group({
        cityName: ['', { validators: [Validators.required] }],
        countryName: ['', { validators: [Validators.required] }],
      }),
    });
  }

  submit() {
    console.log(this.groupData.value);
    this.travelService.create(this.groupData.value).subscribe({
      next: (result: Travel) => {
        this.messageNotifications.showSuccess(
          'Travel created',
          'Travel created successfully'
        );
        console.log('result', result);
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  incrementActiveIndex() {
    this.activeIndex += 1;
  }

  async onUpload(event: any) {
    const byteArray = await imgToByte(
      event.files[0].objectURL.changingThisBreaksApplicationSecurity
    );
    const base64EncodedImage = btoa(
      String.fromCharCode(...new Uint8Array(byteArray))
    );
    this.groupData.patchValue({ imageString: base64EncodedImage });
  }
}
