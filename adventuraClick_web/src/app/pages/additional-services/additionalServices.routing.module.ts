import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdditionalServicesComponent } from './additional-services.component';

const appRoutes: Routes = [
  { path: 'additionalServices', component: AdditionalServicesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AdditionalServicesRoutingModule {}
