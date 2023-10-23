import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationsComponent } from './reservations.component';

const travelRoutes: Routes = [
  { path: 'reservations', component: ReservationsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class ReservationsRouteModule { }