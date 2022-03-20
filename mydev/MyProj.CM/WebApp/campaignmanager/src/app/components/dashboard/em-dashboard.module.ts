import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmDashboardRoutingModule } from './em-dashboard-routing.module';
import { EmDashboardComponent } from './em-dashboard.component';
import { EmSharedComponentModule } from 'src/app/shared/components/em-shared-component.module';


@NgModule({
  declarations: [EmDashboardComponent],
  imports: [
    CommonModule,
    EmDashboardRoutingModule,
    EmSharedComponentModule
  ]
})
export class EmDashboardModule { }
