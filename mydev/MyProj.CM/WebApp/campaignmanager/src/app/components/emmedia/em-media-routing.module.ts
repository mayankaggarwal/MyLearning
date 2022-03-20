import { EmMediaComponent } from './em-media/em-media.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: EmMediaComponent,
  children: [
    {path: 'dashboard', data: { module: 'dashboard'}, loadChildren: '../../components/dashboard/em-dashboard.module#EmDashboardModule'}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmMediaRoutingModule {
  constructor() {
    console.log('EM-Media Routing constructor');
  }
 }
