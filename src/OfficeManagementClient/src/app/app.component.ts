import { Component } from '@angular/core';
import { OpenIdConnectService } from './shared/open-id-connect.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OfficeManagementClient';
  navbarOpen = false;
  /**
   *
   */
  constructor(public openIdConnectService: OpenIdConnectService) {
  }
  ngOnInit() {
    var path = window.location.pathname;
    if (path != "/signin-oidc") {
      if (!this.openIdConnectService.userAvailable) {
        this.openIdConnectService.signIn();
      }
    }
  }


  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }

}
