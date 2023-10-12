import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TravelsComponent } from './travels.component';

const travelRoutes: Routes = [
  { path: 'travels', component: TravelsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class TravelRouteModule { }