import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmHeaderComponent } from './em-header/em-header.component';
import { EmFooterComponent } from './em-footer/em-footer.component';
import { EmMenuComponent } from './em-menu/em-menu.component';
import { DhMessageComponent } from './dh-message/dh-message.component';
import { EmCalenderComponent } from './em-calender/em-calender.component';



@NgModule({
  declarations: [EmHeaderComponent, EmFooterComponent, EmMenuComponent, DhMessageComponent, EmCalenderComponent],
  imports: [
    CommonModule
  ],
  exports: [EmHeaderComponent, EmFooterComponent, EmMenuComponent, DhMessageComponent]
})
export class EmSharedComponentModule { }
