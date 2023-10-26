import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TravelsComponent } from './travels.component';
import { TravelsCreateComponent } from './travels-create/travels-create.component';
import { canActivateChild } from 'src/app/guards/auth-guard';

const travelRoutes: Routes = [
  { path: 'travels', component: TravelsComponent, canActivate: [canActivateChild] },
  { path: 'travels/create', component: TravelsCreateComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class TravelRouteModule { }