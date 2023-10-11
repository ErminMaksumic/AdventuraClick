import { inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateChildFn,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { SecurityService } from '../services/security.service';

export const canActivate: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const securityService = inject(SecurityService);
  const router = inject(Router);
  if (securityService.isAuthenticated()) {
    return true;
  }

  router.navigate(['login']);
  return false;
};

export const canActivateChild: CanActivateChildFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => canActivate(route, state);
