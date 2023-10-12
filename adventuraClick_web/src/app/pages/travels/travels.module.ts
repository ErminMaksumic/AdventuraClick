import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'primeng/api';
import { LoginModule } from '../login/login.module';
import { TravelsComponent } from './travels.component';
import { TravelRouteModule } from './travels.routing.module';

@NgModule({
  declarations: [TravelsComponent],
  imports: [
    CommonModule,
    SharedModule,
    LoginModule,
    TravelRouteModule
  ],
  exports:[
  ]
})
export class TravelsModule { }
