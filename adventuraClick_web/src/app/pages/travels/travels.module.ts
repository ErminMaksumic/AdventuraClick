import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginModule } from '../login/login.module';
import { TravelsComponent } from './travels.component';
import { TravelRouteModule } from './travels.routing.module';
import { SharedModule } from 'src/app/utils/shared.module';
import { TravelModalComponent } from './travel-modal/travel-modal.component';

@NgModule({
  declarations: [TravelsComponent, TravelModalComponent],
  imports: [CommonModule, SharedModule, LoginModule, TravelRouteModule],
  exports: [],
})
export class TravelsModule {}
