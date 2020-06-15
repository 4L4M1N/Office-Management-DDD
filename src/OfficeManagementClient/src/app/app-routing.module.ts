import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';
import { TasksComponent } from './tasks/tasks.component';
import { RouteGuardService } from './shared/route-guard.service';


const routes: Routes = [
  { path: '', redirectTo: 'tasks' , pathMatch: 'full', canActivate: [RouteGuardService]},
  { path: 'signin-oidc', component: SigninOidcComponent},
  { path: 'tasks', component: TasksComponent, canActivate: [RouteGuardService]},
  { path: '**', redirectTo: 'tasks'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
