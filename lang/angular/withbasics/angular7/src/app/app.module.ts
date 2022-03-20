import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HerolistComponent } from './herolist/herolist.component';

@NgModule({
  declarations: [
    AppComponent,
    HerolistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
