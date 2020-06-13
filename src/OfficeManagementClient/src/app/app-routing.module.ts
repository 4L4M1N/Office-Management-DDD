import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';
import { TasksComponent } from './tasks/tasks.component';


const routes: Routes = [
  { path: '',redirectTo: 'tasks' , pathMatch: 'full'},
  { path: 'signin-oidc', component: SigninOidcComponent},
  { path: 'tasks', component: TasksComponent},
  { path: '**', redirectTo: 'tasks'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
