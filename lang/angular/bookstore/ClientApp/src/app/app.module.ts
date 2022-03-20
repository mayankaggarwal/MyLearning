import { BookstoreService } from './services/bookstore.service';
import { BookstoreListComponent } from './bookstore-list/bookstore-list.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BookstoreFormComponent } from './bookstore-form/bookstore-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BookstoreFormComponent,
    BookstoreListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path:'bootstore/new',component:BookstoreFormComponent},
      { path:'bootstore/:id',component:BookstoreFormComponent},
      { path:'bookstore',component:BookstoreListComponent}
    ])
  ],
  providers: [BookstoreService],
  bootstrap: [AppComponent]
})
export class AppModule { }
