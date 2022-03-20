
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'cmpwebapp',loadChildren:'./connect-media/connect-media.module#ConnectMediaModule'},
  {path:'**',redirectTo:'/cmpwebapp'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
