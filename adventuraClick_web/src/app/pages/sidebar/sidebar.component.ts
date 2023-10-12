import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from 'src/app/services/security.service';
import { NAV_BAR_ITEMS } from './navbar-items';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class SidebarComponent {
  sidebarVisible: boolean = false;
  navBarItems = NAV_BAR_ITEMS;
  constructor(
    private securityService: SecurityService,
    private router: Router
  ) {}

  logout() {
    this.securityService.logout();
    this.router.navigate(['']);
  }
}
