import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationsComponent } from './reservations.component';
import { canActivateChild } from 'src/app/guards/auth-guard';

const travelRoutes: Routes = [
  { path: 'reservations', component: ReservationsComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class ReservationsRouteModule { }