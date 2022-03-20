import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmMediaRoutingModule } from './em-media-routing.module';
import { EmMediaComponent } from './em-media/em-media.component';
import { EmSharedComponentModule } from 'src/app/shared/components/em-shared-component.module';


@NgModule({
  declarations: [EmMediaComponent],
  imports: [
    CommonModule,
    EmMediaRoutingModule,
    EmSharedComponentModule
  ]
})
export class EmMediaModule { }
