import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { canActivateChild } from './guards/auth-guard';
import { HomeComponent } from './pages/home/home.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [canActivateChild] },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
