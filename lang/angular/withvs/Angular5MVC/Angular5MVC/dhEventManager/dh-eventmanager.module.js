"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var common_1 = require("@angular/common");
var app_routing_1 = require("./app/app.routing");
var app_component_1 = require("./app/app.component");
var home_component_1 = require("./app/Components/home.component");
var user_service_1 = require("./app/Service/user.service");
var dhEventManagerModule = /** @class */ (function () {
    function dhEventManagerModule() {
    }
    dhEventManagerModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule, app_routing_1.routing],
            declarations: [app_component_1.AppComponent, home_component_1.HomeComponent],
            providers: [{ provide: common_1.APP_BASE_HREF, useValue: "/" }, user_service_1.UserService],
            bootstrap: [app_component_1.AppComponent]
        })
    ], dhEventManagerModule);
    return dhEventManagerModule;
}());
exports.dhEventManagerModule = dhEventManagerModule;
//# sourceMappingURL=dh-eventmanager.module.js.map