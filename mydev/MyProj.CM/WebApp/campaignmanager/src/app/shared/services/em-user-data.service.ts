import { environment } from './../../../environments/environment';
import { Observable, of } from 'rxjs';
import { EmSessionService } from './em-session.service';
import { GlobalSession, User } from './../models/em-global-session.model';
import { EmRestRpcService } from './em-rest-rpc.service';
import { Injectable } from '@angular/core';
import { KeyValuePair } from '../models/em-key-value-pair.model';
import { String } from 'typescript-string-operations';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmUserDataService {

  constructor(private emRestRpcService: EmRestRpcService, private globalSession: GlobalSession,
              private sessionService: EmSessionService) { }

  public getDataAuthorizedUserAccounts(): Observable<KeyValuePair<number, string>[]> {
    const endpoint = String.Format(EmUserDataServiceEndpoints.dataAuthorizedUserAccounts, this.sessionService.getApplicationName());
    const url = String.Format("{0}{1}", environment.api, endpoint);
    const title = `DataAuthorizedUserAccounts`;
    return this.emRestRpcService.get(title, url);
  }

  public saveUserPreferredLanguage(languageId: number): Observable<Response> {
    const endpoint = String.Format(EmUserDataServiceEndpoints.saveUserPreferredLanguage, languageId);
    const url = String.Format("{0}{1}", environment.api, endpoint);
    const title = `saveUserPreferredLanguage`;
    return this.emRestRpcService.put<null, Response>(title, url, null, true);
  }

  public getUserDetails(): Observable<User> {
    const endpoint = EmUserDataServiceEndpoints.getUserDetails;
    const url = String.Format("{0}{1}", environment.api, endpoint);
    const title = `getUserDetails`;
    return this.emRestRpcService.get(title, url);
  }

  public loadUserRoleAndLanguage(): Observable<void> {
    const userData = this.sessionService.getUserData();
    if (userData && userData.appRoles && userData.appRoles.length > 0) {
      return of();
    }

    return this.getUserDetails().pipe(map(data => {
      this.sessionService.setUserPermissionAndLanguage(data);
    }));
  }
}

export class EmUserDataServiceEndpoints {
  private static readonly baseUrl: string = '/users';
  public static readonly dataAuthorizedUserAccounts = EmUserDataServiceEndpoints.getThis().baseUrl + '/DataAthorizedUserAccounts/{0}';
  public static readonly saveUserPreferredLanguage = EmUserDataServiceEndpoints.getThis().baseUrl + '/SaveLanguage/{0}';
  public static readonly getUserDetails = EmUserDataServiceEndpoints.getThis().baseUrl + '/UserDetailsWithRolePermission';
  private static getThis() {
    return this;
  }
}