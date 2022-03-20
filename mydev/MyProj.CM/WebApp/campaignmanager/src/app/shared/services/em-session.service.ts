import { Application } from 'src/app/shared/enum/em-application.enum';
import { Market } from './../models/em-market.model';
import { IMarketField } from './../models/market-field.model';
import { CookieService } from 'ngx-cookie-service';
import { GlobalSession, Locale, User } from './../models/em-global-session.model';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDetail } from '../models/em-login-detail.model';
import { Subject, BehaviorSubject, Observable } from 'rxjs';
import { AppRole } from '../models/em-app-role.model';

@Injectable({
  providedIn: 'root'
})
export class EmSessionService {

  private _isLoggedIn: Subject<LoginDetail> = new BehaviorSubject<LoginDetail>(new LoginDetail());
  private _route: Subject<string> = new BehaviorSubject<string>('');
  constructor(private readonly globalSession: GlobalSession, private router: Router, private cookieSersive: CookieService) { }

  public removeSessionApplicationName() {
    if (this.globalSession) {
      this.globalSession.applicationName = null;
    }
  }

  public beginLoginSession() {
    this.loadUserData();
    this.loadHelpToken();
    this.loadMarketInfo();
    this.loadBlankPermissions();
  }
  loadBlankPermissions() {
    this.globalSession.currentPermissionSet = [];
  }
  loadMarketInfo() {
    const data = JSON.parse(localStorage.getItem('mcMarketData')) as IMarketField;
    if (data) {
      const localmarket = new Market();
      localmarket.marketCode = data.code;
      localmarket.markets = data;
      localmarket.marketName = data.name;
      localmarket.returnMarketCode = data.id;
      localmarket.primaryLanguage = data.primaryLanguage;
      localmarket.secondaryLanguage = data.secondaryLanguage;
      this.globalSession.market = localmarket;
      this.globalSession.locale = new Locale(data.countryCode, data.currencyCode, data.cultureCode);
    }
  }
  loadHelpToken() {
    const data = JSON.parse(localStorage.getItem('mcHelpData'));
    if (data) {
      this.globalSession.help = { site: data.site, market: data.market };
    }

    if (!this.globalSession.help.site) {
      this.globalSession.help = { site: '', market: ''};
    }
  }
  loadUserData() {
    const data = JSON.parse(localStorage.getItem('mcUserData'));
    if (data) {
      this.globalSession.user = data;
    }
  }

  public setLogIn(setValue: LoginDetail) {
    this._isLoggedIn.next(setValue);
  }

  public setApplicationName(applicationName: string): void {
    if (this.globalSession) {
      this.globalSession.applicationName = applicationName;
    }

  }

  public getApplicationName(): string {
    if (this.globalSession && this.globalSession.applicationName) {
      return this.globalSession.applicationName;
    }

    if (location && location.href && location.href.toLowerCase().includes(Application.eventManager)) {
      this.setApplicationName(Application.eventManager);
      return Application.eventManager;
    }

    if (location && location.href && location.href.toLowerCase().includes(Application.offerManager)) {
      this.setApplicationName(Application.offerManager);
      return Application.offerManager;
    }
  }

  public getUserData(): User {
    if (this.globalSession.user && this.globalSession.user.fullName) {
      return this.globalSession.user;
    } else {
      const user = JSON.parse(localStorage.getItem('mcUserData')) as User;
      return user;
    }
  }

  public setUserPermissionAndLanguage(userInfo: User): void {
    if (userInfo && userInfo.appRoles && userInfo.appRoles.length > 0 && this.globalSession.user) {
      console.log('setting user global session');
      console.log('user app roles are :' + userInfo.appRoles.length);
      this.globalSession.user.appRoles = userInfo.appRoles;
      this.globalSession.user.preferredLanguage = userInfo.preferredLanguage;
      this.globalSession.user.preferredLanguageId = userInfo.preferredLanguageId;
    }
  }

  public getUserRoles(): Array<AppRole> {
    let appRoles: Array<AppRole> = null;
    if (this.globalSession && this.globalSession.user) {
      console.log('get user roles');
      console.log(this.globalSession);
      appRoles = this.globalSession.user.appRoles;
    } else {
      console.log("no global session");
      console.log(this.globalSession);
    }

    return appRoles;
  }

  public redirectToLogin(): void {
    let marketcode = localStorage.getItem('mcMarketData') != null ? JSON.parse(localStorage.getItem('mcMarketData')).code : '';
    console.log('redirecting to login');
    location.href = location.href.slice(0, location.href.indexOf(this.router.url)) + '/login?marketcode=' + marketcode;
  }

  public isLoggedInObservable(): Observable<LoginDetail> {
    return this._isLoggedIn.asObservable();
  }

  public isLoggedIn(): boolean {
    if (localStorage.getItem('mcUserData')) {
      return true;
    }
    return false;
  }

  public getRoute(): Observable<string> {
    return this._route.asObservable();
  }

  public setRoute(setValue: string): void {
    this._route.next(setValue);
  }

  logout(isRedirection: boolean = true): void {
    
  }
}
