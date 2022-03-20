import { EmSessionService } from './shared/services/em-session.service';
import { EmRestRpcService } from './shared/services/em-rest-rpc.service';
import { Market } from './shared/models/em-market.model';
import { GlobalSession } from './shared/models/em-global-session.model';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppComponent } from './components/app/app.component';

import { CookieService } from 'ngx-cookie-service';

import { EmSharedComponentModule } from './shared/components/em-shared-component.module';
import { PermissionDeniedComponent } from './permission-denied/permission-denied.component';
import { EmApplicationSessionGuard } from './shared/guard/em-application-session.guard';

@NgModule({
  declarations: [
    AppComponent,
    PermissionDeniedComponent
  ],
  imports: [
    BrowserModule,
    EmSharedComponentModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'cmpwebapp' , loadChildren: './components/cmpwebapp/connect-media.module#ConnectMediaModule'},
      { path: 'offermanager' , canActivate : [EmApplicationSessionGuard], data: { applicationName: 'offermanager'}
        , loadChildren: './components/emmedia/em-media.module#EmMediaModule'},
      { path: 'eventmanager' , canActivate : [EmApplicationSessionGuard], data: { applicationName: 'eventmanager'}
        , loadChildren: './components/emmedia/em-media.module#EmMediaModule'},
      { path: '**', redirectTo: '/cmpwebapp'}
    ], {onSameUrlNavigation : 'reload'})
  ],
  providers: [
    CookieService,
    GlobalSession,
    Market,
    EmRestRpcService,
    EmSessionService,
    EmApplicationSessionGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
