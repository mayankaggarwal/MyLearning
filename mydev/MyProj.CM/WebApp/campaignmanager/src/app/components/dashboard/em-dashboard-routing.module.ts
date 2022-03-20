import { EmDashboardComponent } from './em-dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: EmDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmDashboardRoutingModule {
  constructor() {
    console.log('EmDashboard routing module')
  }
 }
