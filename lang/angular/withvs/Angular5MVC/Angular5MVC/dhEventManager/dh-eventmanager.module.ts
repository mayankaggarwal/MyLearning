import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { APP_BASE_HREF } from "@angular/common";
import { routing } from "./app/app.routing";
import { AppComponent } from "./app/app.component";
import { HomeComponent } from "./app/Components/home.component";
import { UserService } from "./app/Service/user.service";

@NgModule({
    imports: [BrowserModule, routing],
    declarations: [AppComponent, HomeComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: "/" }, UserService],
    bootstrap: [AppComponent]
})
export class dhEventManagerModule { }
