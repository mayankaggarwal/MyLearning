import { ApplicationModule, ApplicationModuleTabs } from './../../enum/em-application-module.enum';
import { Claim } from './../../models/em-claim.model';
import { EmSessionService } from './../../services/em-session.service';
import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { AppRole } from '../../models/em-app-role.model';

@Component({
  selector: 'app-em-menu',
  templateUrl: './em-menu.component.html',
  styleUrls: ['./em-menu.component.css']
})
export class EmMenuComponent implements OnInit {

  constructor(private router: Router, private sessionService: EmSessionService) {
    this.emMenuModel = new Array<EmMenuModel>();
   }

  emMenuModel: Array<EmMenuModel>;
  public applicationName: string;
  public activePageName: string;
  // tslint:disable-next-line: no-input-rename
  @Input('current-tab') currentTab: { 'name': string};
  public activePage: string;
  public menuPageModel = new EmMenuPageModel();

  ngOnInit() {
    this.loadMenu();
  }

  private loadMenu() {
    const appRoles: Array<AppRole> = this.sessionService.getUserRoles();
    if (appRoles && appRoles.length > 0) {
      this.createMenu(appRoles);
    }

    this.sessionService.getRoute().subscribe(route => {
      this.activePage = route;
      console.log(this.activePage);
      if (this.currentTab) {
        this.currentTab.name = route ? route.toLowerCase() : '';
      }
    });
  }

  private createMenu(appRoles: Array<AppRole>) {
    let claims = new Array<Claim>();
    this.applicationName = this.sessionService.getApplicationName();
    if (this.applicationName) {
      appRoles.forEach(appRole => {
        if (appRole.claims && appRole.application && this.applicationName.toLowerCase() === appRole.application.toLowerCase()) {
          claims = claims.concat(appRole.claims).filter(claim => claim.isGrant = true);
        }
      });
      let module = new Array<string>();
      module = Array.from(new Set(claims.map((claim) => claim.module))) ? Array.from(new Set(claims.map((claim) => claim.module))) : null;
      if (!module || module.length == 0) {
        console.log("module length:" + module.length);
        this.sessionService.redirectToLogin();
      }
      this.emMenuModel = this.createMenuItems(module, this.applicationName);
    }
  }

  private createMenuItems( module1: Array<string>, applicationName: string) {
    const emMenuTabs = new Array<EmMenuModel>();
    module1.forEach((module, index) => {
      if (module) {
        const menuTab = new EmMenuModel();
        menuTab.state = module;
        menuTab.activePageName = module;
        menuTab.action = module.toLocaleLowerCase();
        switch (module.toLowerCase()) {
          case ApplicationModule.audiences:
            menuTab.id = ApplicationModuleTabs.audiences;
            menuTab.title = this.menuPageModel.audieceTabTitle;
            break;
          case ApplicationModule.nominations:
            menuTab.id = ApplicationModuleTabs.nominations;
            menuTab.title = this.menuPageModel.nominationTabTitle;
            break;
          case ApplicationModule.events:
            menuTab.id = ApplicationModuleTabs.events;
            menuTab.title = this.menuPageModel.eventTabTitle;
            break;
          case ApplicationModule.admin:
            menuTab.id = ApplicationModuleTabs.admin;
            menuTab.title = this.menuPageModel.adminTabTitle;
            break;
          case ApplicationModule.dashboard:
            menuTab.id = ApplicationModuleTabs.dashboard;
            menuTab.title = this.menuPageModel.dashboardTabTitle;
        }
        emMenuTabs.push(menuTab);
      }
    });
    emMenuTabs.sort(function(a, b) {
      return a.id - b.id;
    });
    return emMenuTabs;
  }
}

export class EmMenuPageModel {
  public audieceTabTitle = 'Audiences';
  public nominationTabTitle = 'Nominations';
  public eventTabTitle = 'Events';
  public adminTabTitle = 'Admin';
  public dashboardTabTitle = 'Dashboard';
}

export class EmMenuModel {
  id: number;
  title: string;
  state: string;
  activePageName: string;
  action: string;
}
