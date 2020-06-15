import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { OpenIdConnectService } from './open-id-connect.service';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardService implements CanActivate {

  constructor(private openIdConnectService: OpenIdConnectService,
              private router: Router) { }
  canActivate() {
    if (this.openIdConnectService.userAvailable) {
      return true;
    }
    else {
      this.openIdConnectService.signIn();
      return false;
    }
  }
}
