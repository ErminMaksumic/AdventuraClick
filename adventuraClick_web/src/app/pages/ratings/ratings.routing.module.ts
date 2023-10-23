import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RatingsComponent } from './ratings.component';

const travelRoutes: Routes = [
  { path: 'ratings', component: RatingsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class RatingsRouteModule { }