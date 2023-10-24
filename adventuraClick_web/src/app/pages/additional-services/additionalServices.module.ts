import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/utils/shared.module';
import { AdditionalServicesComponent } from './additional-services.component';
import { AdditionalServicesRoutingModule } from './additionalServices.routing.module';
import { AdditionalServicesModalComponent } from './additional-services-modal/additional-services-modal.component';

@NgModule({
  declarations: [AdditionalServicesComponent, AdditionalServicesModalComponent],
  imports: [CommonModule, SharedModule],
  exports: [AdditionalServicesRoutingModule],
})
export class AdditionalServicesModule {}
