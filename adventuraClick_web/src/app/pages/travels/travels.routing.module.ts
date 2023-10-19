import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TravelsComponent } from './travels.component';
import { TravelsCreateComponent } from './travels-create/travels-create.component';

const travelRoutes: Routes = [
  { path: 'travels', component: TravelsComponent },
  { path: 'travels/create', component: TravelsCreateComponent },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class TravelRouteModule { }