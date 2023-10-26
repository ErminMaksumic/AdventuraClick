import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RatingsComponent } from './ratings.component';
import { canActivateChild } from 'src/app/guards/auth-guard';

const travelRoutes: Routes = [
  { path: 'ratings', component: RatingsComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class RatingsRouteModule { }