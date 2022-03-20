import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { InputUserForm } from './components/inputuserform.component';
import { InputUserForm2 } from './components/inputuserform2.component';
import { KeyUpComponent_V1 } from './components/userinputExample.component';
import { HeroFormComponent } from './hero-form/hero-form.component';
import { EventFormComponent } from './components/eventformcomponent';
import { EventService } from "./services/eventservice";

@NgModule({
  declarations: [
    AppComponent,
	InputUserForm,
	InputUserForm2,
	KeyUpComponent_V1,
	HeroFormComponent,
	EventFormComponent
  ],
  imports: [
    BrowserModule,
	FormsModule,
	ReactiveFormsModule
  ],
  providers: [EventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
