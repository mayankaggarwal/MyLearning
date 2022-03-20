import { Router } from '@angular/router';
import { EmSessionService } from './em-session.service';
import { Injectable } from '@angular/core';
import { Claim } from '../models/em-claim.model';
import { AppRole } from '../models/em-app-role.model';
import { Permission } from '../enum/em-permission-enum';
import { ApplicationModule, ApplicationModuleTabs } from '../enum/em-application-module.enum';

@Injectable({
  providedIn: 'root'
})
export class EmAuthorzationService {

  constructor(private sessionService: EmSessionService, private router: Router) { }

  getApplicationName(): string {
    return this.sessionService.getApplicationName();
  }

  getClaimsForModule(module: string): Array<Claim> {
    const appRoles: Array<AppRole> = this.sessionService.getUserRoles();
    let claims = new Array<Claim>();
    if (appRoles && appRoles.length > 0) {
      appRoles.forEach(appRole => {
        if (appRole.claims && appRole.application && appRole.application.toLowerCase() === this.getApplicationName()) {
          claims = claims.concat(appRole.claims.filter(x => x.module.toLowerCase() === module.toLowerCase() && x.isGrant === true));
        }
      });
    }

    return claims;
  }

  getFeaturesFromModule(module: string): Array<string> {
    let features = new Array<string>();
    const claims = this.getClaimsForModule(module);
    if (claims && claims.length > 0) {
      features = Array.from(new Set(claims.map((claim) => claim.feature)));
    }

    return features;
  }

  checkApplicationAuthorization(applicationName: string): boolean {
    let appRoles = new Array<AppRole>();
    appRoles = this.sessionService.getUserRoles();
    if (appRoles && appRoles.length > 0) {
      let claims = new Array<Claim>();
      appRoles.forEach(appRole => {
        if (appRole.claims && applicationName && appRole.application.toLowerCase() === applicationName.toLowerCase()) {
          claims = claims.concat(appRole.claims).filter(x => x.isGrant === true);
        }
      });
      if (!claims || claims.length === 0) {
        return false;
      }
    } else {
      return false;
    }

    return true;
  }

  getFirstModuleTab(applicationName: string): string {
    let claims = new Array<Claim>();
    let selectedTab = '';
    let appRoles = new Array<AppRole>();
    appRoles = this.sessionService.getUserRoles();
    if (appRoles && appRoles.length > 0 && applicationName) {
      appRoles.forEach(appRole => {
        if (appRole.claims && appRole.application.toLowerCase() === applicationName.toLowerCase()) {
          claims = claims.concat(appRole.claims).filter(x => x.isGrant === true);
        }
      });
      if (!claims || claims.length === 0) {
        console.log("No claims");
        this.sessionService.redirectToLogin();
      }
      const applicationModules = Object.keys(ApplicationModuleTabs).filter((type) => isNaN(type as any) && type !== 'values');
      if (applicationModules && applicationModules.length > 0) {
        applicationModules.every(appModule => {
          if (claims.find(x => x.module.toLowerCase() === appModule.toLowerCase())) {
            selectedTab = appModule.toLowerCase();
            return false;
          }
          return true;
        });
      }
    } else {
      console.log("no user roles");
      //this.sessionService.redirectToLogin();
    }

    return selectedTab;
  }

  checkManageAccessForClient(): boolean {
    let manageAccess = false;
    const claims = this.getClaimsForModule(ApplicationModule.admin);
    if (claims && claims.length > 0) {
      // tslint:disable-next-line: max-line-length
      manageAccess = claims.find(x => (x.feature.toLowerCase() === 'client' && x.permission && x.permission.toLowerCase() === Permission.manage)) != null;
    }

    return manageAccess;
  }
}
