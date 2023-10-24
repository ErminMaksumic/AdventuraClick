import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';

const travelRoutes: Routes = [
  { path: 'users', component: UserComponent },
];

@NgModule({
  imports: [RouterModule.forChild(travelRoutes)],
  exports: [RouterModule]
})
export class UsersRouteModule { }