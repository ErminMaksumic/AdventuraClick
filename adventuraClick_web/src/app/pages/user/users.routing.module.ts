import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';

const travelRoutes: Routes = [
  { path: 'users', component: UserComponent },
  { path: 'profile', component: ProfileEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class UsersRouteModule { }