import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/utils/shared.module';
import { RatingsComponent } from './ratings.component';
import { RatingsRouteModule } from './ratings.routing.module';
import { RatingModule } from 'primeng/rating';


@NgModule({
  declarations: [RatingsComponent],
  imports: [CommonModule, SharedModule, RatingModule],
  exports: [RatingsRouteModule],
})
export class RatingsModule {}
