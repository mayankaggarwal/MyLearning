import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoutegaurdService implements CanActivate {

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
    ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
      if ( localStorage.getItem('currentUser')) {
        // logged in
        return true;
      }

      this.router.navigate(['/login'], {queryParams: { returnUrl: state.url}});
      return false;
  }

  constructor(private router: Router) { }
}
