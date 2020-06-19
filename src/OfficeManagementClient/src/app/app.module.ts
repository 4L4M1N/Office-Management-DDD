import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OpenIdConnectService } from './shared/open-id-connect.service';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';
import { TasksComponent } from './tasks/tasks.component';
import { RouteGuardService } from './shared/route-guard.service';
import { TestService } from './services/test.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthorizationHeaderInterceptor } from './shared/AuthorizationHeaderInterceptor';

@NgModule({
   declarations: [
      AppComponent,
      SigninOidcComponent,
      TasksComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule
   ],
   providers: [
      {
         provide: HTTP_INTERCEPTORS,
         useClass: AuthorizationHeaderInterceptor,
         multi: true
      },
      OpenIdConnectService,
      RouteGuardService,
      TestService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
