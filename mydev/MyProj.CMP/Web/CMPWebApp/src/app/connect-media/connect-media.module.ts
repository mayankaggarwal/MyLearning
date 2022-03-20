import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConnectMediaRoutingModule } from './connect-media-routing.module';
import { AppSelectorComponent } from './../components/connectmedia/app-selector.component';

@NgModule({
  declarations: [AppSelectorComponent],
  imports: [
    CommonModule,
    ConnectMediaRoutingModule
  ]
})
export class ConnectMediaModule { }
