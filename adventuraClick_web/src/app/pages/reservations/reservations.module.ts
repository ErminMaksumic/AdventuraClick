import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/utils/shared.module';
import { ReservationsComponent } from './reservations.component';
import { ReservationsRouteModule } from './reservations.routing.module';

@NgModule({
  declarations: [ReservationsComponent],
  imports: [CommonModule, SharedModule],
  exports: [ReservationsRouteModule],
})
export class ReservationsModule {}
