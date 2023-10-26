import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { canActivateChild } from 'src/app/guards/auth-guard';

const travelRoutes: Routes = [
  { path: 'users', component: UserComponent, canActivate: [canActivateChild] },
  { path: 'profile', component: ProfileEditComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class UsersRouteModule { }