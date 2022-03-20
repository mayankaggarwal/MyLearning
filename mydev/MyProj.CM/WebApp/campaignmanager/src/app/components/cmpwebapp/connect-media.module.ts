import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConnectMediaRoutingModule } from './connect-media-routing.module';
import { AppSelectorComponent } from './app-selector/app-selector.component';
import { EmSharedComponentModule } from 'src/app/shared/components/em-shared-component.module';


@NgModule({
  declarations: [AppSelectorComponent],
  imports: [
    CommonModule,
    ConnectMediaRoutingModule,
    EmSharedComponentModule
  ]
})
export class ConnectMediaModule {
  constructor() {
    console.log("In Connect Media Module");
  }
 }
