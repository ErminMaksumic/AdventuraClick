import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { IncludedItem } from 'src/app/models/included-item.model';
import { TravelType } from 'src/app/models/travel-type.model';
import { Travel } from 'src/app/models/travel.model';
import { IncludedItemService } from 'src/app/services/includedItems.service';
import { TravelService } from 'src/app/services/travel.service';
import { TravelTypeService } from 'src/app/services/travelType.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { parseWebAPiErrors } from 'src/app/utils/parseWebApiErrors';
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
  sourceItems!: IncludedItem[];
  targetItems: IncludedItem[] = [];
  travelTypes: TravelType[] = [];
  createIncludedItemModal: boolean = false;
  includedItemName: string = '';
  errors: string[] = [];

  constructor(
    private builder: FormBuilder,
    private travelService: TravelService,
    private travelTypeService: TravelTypeService,
    private includedItemService: IncludedItemService,
    private messageNotifications: MessageNotifications,
    private cdr: ChangeDetectorRef,
    private router: Router
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
      includedItemIds: [[]],
      travelTypeId: [{}, { validators: [Validators.required] }],
      travelInformations: [[], { validators: [Validators.required] }],
    });

    this.getIncludedItems();
    this.getTravelTypes();
  }

  submit() {
    this.prepareGroupData();
    this.travelService.create(this.groupData.value).subscribe({
      next: (result: Travel) => {
        this.messageNotifications.showSuccess(
          'Travel created',
          'Travel created successfully'
        );
        this.router.navigate(['travels']);
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
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

  async getIncludedItems() {
    this.includedItemService.getAll().subscribe({
      next: (result: IncludedItem[]) => {
        this.sourceItems = result;
        this.cdr.markForCheck();
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
        console.log('error', error);
      },
    });
  }

  async getTravelTypes() {
    this.travelTypeService.getAll().subscribe({
      next: (result: TravelType[]) => {
        this.travelTypes = result;
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
        console.log('error', error);
      },
    });
  }

  createNewIncludedItem() {
    this.includedItemService.create({ name: this.includedItemName }).subscribe({
      next: () => {
        this.messageNotifications.showSuccess(
          'Incl. item created',
          'Incl. item created successfully'
        );
        this.getIncludedItems();
        this.createIncludedItemModal = false;
        this.includedItemName = '';
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
        console.log('error', error);
      },
    });
  }

  prepareGroupData() {
    // Set Included Items IDs
    const includedItemIds = this.targetItems.map((item) => item.includedItemId);
    this.groupData.value.includedItemIds = includedItemIds;
    // Set Travel Type IDs
    this.groupData.value.travelTypeId =
      this.groupData.value.travelTypeId.travelTypeId;
    // Set dates
    this.groupData.value.travelInformations =
      this.groupData.value.travelInformations.map((x: string) => {
        return {
          departureTime: new Date(x),
          createdBy: 'Admin',
        };
      });
  }
}
