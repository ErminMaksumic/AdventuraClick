import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdditionalService } from 'src/app/models/additionalService.model';
import { AdditionalServices } from 'src/app/services/additionalService.service';
import { UserService } from 'src/app/services/user.service';
import { MessageNotifications } from 'src/app/utils/messageNotifications';
import { parseWebAPiErrors } from 'src/app/utils/parseWebApiErrors';

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
  errors: string[] = [];

  constructor(
    private additionalService: AdditionalServices,
    private messageNotifications: MessageNotifications,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.changeActiveMenu('Additional Services');
    this.loadAdditionalServices();
  }

  loadAdditionalServices(search: string = '') {
    this.additionalService.getAll({ name: search }).subscribe({
      next: (result: AdditionalService[]) => {
        this.additionalServices = result;
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
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
          next: () => {
            this.addServicesModal = false;
            this.selectedAdditionalService = {};
            this.loadAdditionalServices();
            this.messageNotifications.showSuccess(
              'Additional service updated',
              'Additional service updated successfully'
            );
          },
          error: (error: any) => {
            this.errors = parseWebAPiErrors(error);
            console.log('error', error);
          },
        });
    } else {
      this.additionalService.create(addService).subscribe({
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
          this.errors = parseWebAPiErrors(error);
          console.log('error', error);
        },
      });
    }
  }

  selectAdditionalService(additionalService: AdditionalService = {}) {
    this.selectedAdditionalService = additionalService;
    this.addServicesModal = true;
  }

  deleteAddService(addServiceId: number) {
    this.additionalService.delete(addServiceId).subscribe({
      next: () => {
        this.messageNotifications.showSuccess(
          'Additional service deleted',
          'Additional service deleted successfully'
        );
        this.loadAdditionalServices();
      },
      error: (error: any) => {
        this.errors = parseWebAPiErrors(error);
        console.log('error', error);
      },
    });
  }
}
