import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';
import { UserService } from './services/user.service';
import { getUserId } from './utils/jwt-decoder';
import { User } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class AppComponent {
  currentRoutePath: string = '';
  title = 'adventuraClick_web';
  showSidebar: boolean = true;
  userId: number = 0;
  user: User = {};

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        const activeRoute = this.activatedRoute.root;
        if (activeRoute.snapshot.children.length) {
          const routeSnapshot = activeRoute.snapshot.children[0];
          this.showSidebar = routeSnapshot.routeConfig?.path !== 'login';
          this.currentRoutePath = `ADVENTURACLICK / ${routeSnapshot.routeConfig?.path
            ?.replace('/', ' / ')
            ?.toUpperCase()}`;
        }
      });
    this.userId = getUserId();
    this.loadUser();
  }

  loadUser(search: string = '') {
    this.userService.getById(this.userId).subscribe({
      next: (result: User) => {
        this.user = result;
      },
      error: (error: any) => {
        console.log('error', error);
      },
    });
  }
}
