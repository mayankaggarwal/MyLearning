import { AppRole } from './../models/em-app-role.model';
import { LoginDetail } from './../models/em-login-detail.model';
import 'rxjs/add/operator/map';
import { of, Observable } from 'rxjs';
import { EmUserDataService } from './../services/em-user-data.service';
import { EmSessionService } from './../services/em-session.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute, Router } from '@angular/router';
import { Claim } from '../models/em-claim.model';

@Injectable()
export class EmApplicationSessionGuard implements CanActivate {

    constructor(private emSessionService: EmSessionService, private userDataService: EmUserDataService
        ,       private router: Router, private route: ActivatedRoute) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        let authenticatedFlag = of(false);
        let authorizedFlag = of(false);

        authenticatedFlag = this.verifyAuthenticity();
        if (route && route.data) {
            authorizedFlag = this.verifyApplicationAuthorization(route.data);
        }

        return (authenticatedFlag && authorizedFlag);
    }

    private verifyAuthenticity(): Observable<boolean> {
        if (this.emSessionService.isLoggedIn()) {
            return of(true);
        }

        this.emSessionService.logout();
        return of(false);
    }

    private verifyApplicationAuthorization(data): Observable<boolean> {
        let applicationName = '';
        applicationName = this.emSessionService.getApplicationName();
        const appRoles = this.emSessionService.getUserRoles();
        if (!(appRoles && appRoles.length > 0)) {
            const userData = this.emSessionService.getUserData();
            if (userData && userData.fullName) {
                return this.userDataService.getUserDetails().map(userDetails => {
                    if (userDetails && applicationName) {
                        this.emSessionService.beginLoginSession();
                        this.emSessionService.setUserPermissionAndLanguage(userDetails);
                        const loginDetail: LoginDetail = {
                            logInFlag: true,
                            setApplicationFlag: true
                        };
                        this.emSessionService.setLogIn(loginDetail);
                        return this.checkApplicationPermissionExists(data, applicationName, userDetails.appRoles);
                    } else {
                        this.router.navigate(['cmpwebapp']);
                        return false;
                    }
                });
            } else {
                return of(false);
            }
        } else {
            return of(this.checkApplicationPermissionExists(data, applicationName, appRoles));
        }
    }

    private checkApplicationPermissionExists(data, applicationName: string, appRoles: AppRole[]): boolean {
        let result = false;
        let claims = new Array<Claim>();
        appRoles.forEach(appRole => {
            // tslint:disable-next-line: max-line-length
            if (appRole.claims && appRole.application && applicationName && applicationName.toLowerCase() === appRole.application.toLowerCase()) {
                claims = claims.concat(appRole.claims).filter(claim => claim.isGrant === true);
            }
        });
        if (claims && claims.length > 0) {
            result = true;
        }

        if (!result) {
            this.router.navigate(['cmpwebapp']);
        }
        return result;
    }

}