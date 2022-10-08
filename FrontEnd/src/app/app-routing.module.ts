
import { AuthGuard } from './Helpers/AuthGuard';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { LoginComponent } from './Components/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmpolyeeComponent } from './Components/add-empolyee/add-empolyee.component';

const routes: Routes = [
   {path : 'Login' , component : LoginComponent },
   {path : 'Dashboard' , component : DashboardComponent , canActivate:[AuthGuard]} ,
   {path : 'addEmpolyee' , component : AddEmpolyeeComponent , canActivate : [AuthGuard]},
   {path : '**' , redirectTo : 'Login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
