import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'adventuraClick_web';
  showSidebar: boolean = true;
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      const activeRoute = this.activatedRoute.root;
      if (activeRoute.snapshot.children.length) {
        const routeSnapshot = activeRoute.snapshot.children[0];
        this.showSidebar = routeSnapshot.routeConfig?.path !== 'login';
      }
    });
  }
}
