import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./Components/home.component";

const appRoutes: Routes = [
    { path: "", redirectTo: "Home", pathMatch: "full" },
    { path: "home", component: HomeComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);