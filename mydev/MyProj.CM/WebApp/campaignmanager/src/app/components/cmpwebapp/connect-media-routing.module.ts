import { AppSelectorComponent } from './app-selector/app-selector.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: AppSelectorComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConnectMediaRoutingModule {
  constructor() {
    console.log('Inside Connect Media routing');
  }
 }
