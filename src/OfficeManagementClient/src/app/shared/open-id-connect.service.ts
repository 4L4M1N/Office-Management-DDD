import { Injectable } from '@angular/core';
import { UserManager, User} from 'oidc-client';
import { environment } from 'src/environments/environment';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {

  private userManager: UserManager = new UserManager(environment.openIdConnectSettings);
  private currentUser: User;
  // A reply subject is a variant of subject we can use to wait until a value is actually produced.
  userLoaded$ = new ReplaySubject<boolean>(1);
  get userAvailable(): boolean {
    return this.currentUser != null;
  }

  get user(): User {
    return this.currentUser;
  }
  constructor() {
    this.userManager.clearStaleState();

    this.userManager.events.addUserLoaded(user => {
      if(!environment.production) {
        console.log('User Loaded', user);
      }
      this.currentUser = user;
      this.userLoaded$.next(true);
    });
    // unload user

    this.userManager.events.addUserUnloaded( () => {
      if(!environment.production) {
        console.log('User unloaded');
      }
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
   }
   // signin
  signIn()
  {
    this.userManager.signinRedirect().then(function () {
      if (!environment.production) {
        console.log('Redirection to sign in redirect');
      }
    });
  }
  signOut()
  {
    this.userManager.signoutRedirect().then(function (resp) {
      if(!environment.production) {
        console.log('Redirection to sign out triggered', resp)
      }
    })
  }
  // token must be fetched form the uri and validated
  handleCallBack()
  {
    this.userManager.signinRedirectCallback().then(function (user) {
      if (!environment.production) {
        console.log('Call back after signin handles.', user);
      }
    });
  }
}
