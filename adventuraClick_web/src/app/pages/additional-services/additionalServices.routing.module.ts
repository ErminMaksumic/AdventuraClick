import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdditionalServicesComponent } from './additional-services.component';
import { canActivateChild } from 'src/app/guards/auth-guard';

const appRoutes: Routes = [
  { path: 'additionalServices', component: AdditionalServicesComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AdditionalServicesRoutingModule {}
