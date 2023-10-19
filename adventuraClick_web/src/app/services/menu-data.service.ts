import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

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

@Injectable({
  providedIn: 'root',
})
/**
 * menu data service
 */
export class MenuDataService {
  public toggleMenuBar: BehaviorSubject<any> = new BehaviorSubject<any>(
    'initial-value'
  );

  getMenuList(): CustomMenuItem[] {
    console.log('toggle', this.toggleMenuBar);
    return [
      {
        Label: 'Home',
        Icon: 'fa-home',
        RouterLink: '/home',
        Childs: null,
        IsChildVisible: false,
      },
      {
        Label: 'Travels',
        Icon: 'fa-home',
        RouterLink: '/travels',
        Childs: [
          {
            Label: 'View Travels',
            RouterLink: '/travels',
            Childs: null,
            IsChildVisible: true,
          },
          {
            Label: 'Create Travel',
            RouterLink: '/travels/create',
            Childs: null,
            IsChildVisible: true,
          },
        ],
        IsChildVisible: false,
      },
      {
        Label: 'Reservations',
        Icon: 'fa-calendar',
        RouterLink: '/reservations',
        Childs: null,
        IsChildVisible: false,
      },
      {
        Label: 'Additional Services',
        Icon: 'fa-plus',
        RouterLink: '/additionalServices',
        Childs: null,
        IsChildVisible: false,
      },
      {
        Label: 'Logout',
        Icon: 'fa-exclamation-triangle',
        RouterLink: '/logout',
        Childs: null,
        IsChildVisible: false,
      },
      // {
      //   Label: 'Menu Level 1',
      //   Icon: 'fa-cart-plus',
      //   RouterLink: '',
      //   Childs: [
      //     {
      //       Label: 'Menu Level 1.1',
      //       RouterLink: '',
      //       Childs: null,
      //       IsChildVisible: false,
      //     },
      //     {
      //       Label: 'Menu Level 1.2',
      //       RouterLink: '',
      //       IsChildVisible: false,
      //       Childs: [
      //         {
      //           Label: 'Menu Level 1.2.1',
      //           RouterLink: '',
      //           Childs: null,
      //           IsChildVisible: false,
      //         },
      //         {
      //           Label: 'Menu Level 1.2.2',
      //           RouterLink: '',
      //           Childs: null,
      //           IsChildVisible: false,
      //         },
      //       ],
      //     },
      //   ],
      //   IsChildVisible: false,
      // },
    ];
  }
}
