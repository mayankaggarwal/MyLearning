import { environment } from './../../../environments/environment';
import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { EmRestRpcService } from './em-rest-rpc.service';

@Injectable({
  providedIn: 'root'
})
export class EmLoginService {

  constructor(private utilityService: EmRestRpcService) { }

  marketChangeEvent = new EventEmitter<string>();

  public setSession(selectedMarket: string): Observable<any> {
    return this.utilityService.get<any>('Set user session', environment.api + '/Users/login-session/' + selectedMarket);
  }

  public getProfile(): Observable<any> {
    return this.utilityService.get<any>('Login user profile', environment.api + '/Users/login-user-profile');
  }

  public postLastAccepted(): Observable<any> {
    const endpoint = '/Users/UpdateLastAcceptedDate';
    const url = environment.api + endpoint;
    const title = 'Last Accepted';
    return this.utilityService.put<any, any>(title, url, {}, null);
  }
}
