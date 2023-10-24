import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/utils/shared.module';
import { UserComponent } from './user.component';
import { UsersRouteModule } from './users.routing.module';
import { UserModalComponent } from './travel-modal/user-modal.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';


@NgModule({
  declarations: [UserComponent, UserModalComponent, ProfileEditComponent],
  imports: [CommonModule, SharedModule],
  exports: [UsersRouteModule],
})
export class UsersModule {}
