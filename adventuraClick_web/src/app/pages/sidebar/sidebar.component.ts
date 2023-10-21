import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { MenuDataService } from 'src/app/services/menu-data.service';
import { RouteStateService } from 'src/app/services/route-state.service';
import { SecurityService } from 'src/app/services/security.service';
import { SessionService } from 'src/app/services/session.service';

export class CustomMenuItem {
  constructor() {
    this.Label = '';
    this.Icon = '';
    this.RouterLink = '';
    this.Childs = null;
    this.IsChildVisible = false;
  }
  Label: string;
  Icon?: string;
  RouterLink: string;
  Childs: CustomMenuItem[] | null;
  IsChildVisible: boolean;
}

@Component({
  selector: 'app-sidebar',
  templateUrl: 'sidebar.component.html',
  styleUrls: ['sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
  items: CustomMenuItem[];
  selectedItem: string;
  visible: boolean;

  constructor(
    private routeStateService: RouteStateService,
    private sessionService: SessionService,
    private menuDataService: MenuDataService,
    private securityService: SecurityService,
    private router: Router
  ) {
    this.items = [];
    this.selectedItem = '';
    this.visible = false;
  }

  ngOnInit() {
    this.items = this.menuDataService.getMenuList();
    var that = this;
    this.menuDataService.toggleMenuBar.subscribe(function (data: any) {
      if (data && data != null) {
        that.visible = !that.visible;
      }
    });

    var activeMenu = this.sessionService.getItem('active-menu');
    if (activeMenu) {
      this.selectedItem = activeMenu;
    } else {
      this.selectedItem = 'Home';
    }
  }

  ngOnDestroy() {
    this.menuDataService.toggleMenuBar.observers.forEach(function (element) {
      element.complete();
    });
  }

  // on menu click event
  onMenuClick(menu: CustomMenuItem) {
    if (menu.Label === 'Logout') {
      this.sessionService.setItem('active-menu', null);
      this.logout();
      return;
    }
    // if child are available then open child
    if (menu.Childs != undefined || menu.Childs != null) {
      this.toggleSubMenu(menu);
      return;
    }
    if (
      menu.RouterLink == undefined ||
      menu.RouterLink == null ||
      menu.RouterLink == ''
    ) {
      this.routeStateService.add('Error 404', '/error', null, false);
      return;
    }
    this.selectedItem = menu.Label;
    console.log(this.selectedItem);
    console.log('routerLink', menu.RouterLink);
    this.sessionService.setItem('active-menu', menu.Label);
    this.routeStateService.add(menu.Label, menu.RouterLink, null, true);
  }

  // toggle sub menu on click
  toggleSubMenu(menu: CustomMenuItem) {
    menu.IsChildVisible = !menu.IsChildVisible;
  }

  logout() {
    this.securityService.logout();
    this.router.navigate(['login']);
  }
}
