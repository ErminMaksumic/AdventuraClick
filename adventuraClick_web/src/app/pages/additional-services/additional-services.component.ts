import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdditionalService } from 'src/app/models/additionalService.model';
import { AdditionalServices } from 'src/app/services/additionalService.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';

@Component({
  selector: 'app-additional-services',
  templateUrl: './additional-services.component.html',
  styleUrls: ['./additional-services.component.css'],
})
export class AdditionalServicesComponent {
  additionalServices: AdditionalService[] = [];
  selectedAdditionalService: AdditionalService = {};
  searchQuery: string = '';
  groupData!: FormGroup;
  formData = new FormData();
  addServicesModal: boolean = false;

  constructor(
    private additionalService: AdditionalServices,
    private messageNotifications: MessageNotifications
  ) {}

  ngOnInit() {
    this.loadAdditionalServices();
  }

  loadAdditionalServices(search: string = '') {
    this.additionalService.getAll({ name: search }).subscribe({
      next: (result: AdditionalService[]) => {
        this.additionalServices = result;
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }

  search(input: string) {
    this.loadAdditionalServices(input);
  }

  saveAddService(addService: AdditionalService = {}) {
    if (
      this.additionalServices.some(
        (service) => service.addServiceId === addService.addServiceId
      )
    ) {
      this.additionalService
        .update(addService.addServiceId || 0, addService)
        .subscribe({
          next: (result: AdditionalService) => {
            this.addServicesModal = false;
            this.selectedAdditionalService = {};
            this.loadAdditionalServices();
            this.messageNotifications.showSuccess(
              'Additional service updated',
              'Additional service updated successfully'
            );
          },
          error: (error: any) => {
            console.log('error', error);
          },
        });
    }
    else{
      this.additionalService
        .create(addService)
        .subscribe({
          next: (result: AdditionalService) => {
            this.addServicesModal = false;
            this.selectedAdditionalService = {};
            this.loadAdditionalServices();
            this.messageNotifications.showSuccess(
              'Additional service created',
              'Additional service created successfully'
            );
          },
          error: (error: any) => {
            console.log('error', error);
          },
        });
    }
  }

  selectAdditionalService(additionalService: AdditionalService = {}) {
    this.selectedAdditionalService = additionalService;
    this.addServicesModal = true;
  }
}
