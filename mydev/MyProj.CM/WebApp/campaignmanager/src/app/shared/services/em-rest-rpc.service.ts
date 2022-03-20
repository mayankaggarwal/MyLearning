import { Observable, throwError, of } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

type RequestInterceptor = (request: any) => any;
@Injectable()
export class EmRestRpcService {
    private requestInterceptors: Array<RequestInterceptor> = [];
    constructor(private httpClient: HttpClient, private router: Router, private cookieService: CookieService) {}

    get<T>(title: string, url: string, isFullResponse?: boolean,
           headerList?: Array<{ key: string, value: string}>, showLoader: boolean = true): Observable<T> {
               let headerValue = new HttpHeaders();
               if (headerList != null) {
                   headerList.forEach(x => {
                        headerValue = headerValue.append(x.key, x.value);
                   });
               }

               if (showLoader) {
                   headerValue = headerValue.append('showLoader', 'true');
               }

               let request = null;

               if (isFullResponse) {
                   request = this.httpClient.get<T>(url, { headers: headerValue, withCredentials: true,
                        observe: 'response'}).pipe(catchError(
                       error => this.handleError(error)
                   ));
               } else {
                request = this.httpClient.get<T>(url, { headers: headerValue, withCredentials: true}).pipe(catchError(
                    error => {
                        return this.handleError(error);
                    }
                ));
               }
               return request;
    }

    post<A, T>(title: string, url: string, data: A, isFullResponse?: boolean,
               headerList?: Array<{ key: string, value: string}>, showLoader: boolean = true): Observable<T> {
            if (!url) { return this.observableData<T>(null); }
            const newData = this.prepareData(data);
            console.info('POST (' + title + ')', url);

            let headerValue = new HttpHeaders();
            if (headerList != null) {
           headerList.forEach(x => {
                headerValue = headerValue.append(x.key, x.value);
           });
       }

            if (showLoader) {
           headerValue = headerValue.append('showLoader', 'true');
       }

            let request = null;

            if (isFullResponse) {
           request = this.httpClient.post(url, newData, { headers: headerValue, withCredentials: true,
                observe: 'response'}).pipe(catchError(
               error => {
                   return this.handleError(error);
               }
           ));
       } else {
        request = this.httpClient.post(url, newData, { headers: headerValue, withCredentials: true}).pipe(catchError(
            error => {
                return this.handleError(error);
            }
        ));
       }
            return request;
}

    put<A, T>(title: string, url: string, data: A, isFullResponse?: boolean,
              headerList?: Array<{ key: string, value: string}>, showLoader: boolean = true): Observable<T> {
                 if (!url) { return this.observableData<T>(null); }
                 const newData = this.prepareData(data);
                 console.info('PUT (' + title + ')', url);

                 let headerValue = new HttpHeaders();
                 if (headerList != null) {
                headerList.forEach(x => {
                     headerValue = headerValue.append(x.key, x.value);
                });
            }

                 if (showLoader) {
                headerValue = headerValue.append('showLoader', 'true');
            }

                 let request = null;

                 if (isFullResponse) {
                request = this.httpClient.put(url, newData, { headers: headerValue, withCredentials: true,
                     observe: 'response'}).pipe(catchError(
                    error => {
                        return this.handleError(error);
                    }
                ));
            } else {
             request = this.httpClient.put(url, newData, { headers: headerValue, withCredentials: true}).pipe(catchError(
                 error => {
                     return this.handleError(error);
                 }
             ));
            }
                 return request;
    }

    delete<T>(title: string, url: string, isFullResponse?: boolean,
              showLoader: boolean = true): Observable<T> {

                if (!url) { return this.observableData<T>(null); }
                console.info('DELETE (' + title + ')', url);
                let headerValue = new HttpHeaders();

                if (showLoader) {
                headerValue = headerValue.append('showLoader', 'true');
            }

                let request = null;

                if (isFullResponse) {
                request = this.httpClient.delete(url, { headers: headerValue, withCredentials: true,
                     observe: 'response'}).pipe(catchError(
                    error => this.handleError(error)
                ));
            } else {
             request = this.httpClient.delete(url, { headers: headerValue, withCredentials: true}).pipe(catchError(
                 error => {
                     return this.handleError(error);
                 }
             ));
            }
                return request;
    }

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            console.log('An error occured:', error.error.message);
        } else {
            console.log(
                `Backend retured code ${error.status}, ` +
                `body was: ${error.error}`);
        }

        if (error.status === 401) {
            if (localStorage.getItem('mcHelpData')) {
                localStorage.removeItem('mcHelpData');
            }

            if (localStorage.getItem('mcUserData')) {
                localStorage.removeItem('mcUserData');
            }

            this.cookieService.deleteAll();
            if (this.router.url !== '/cmpwebapp') {
                this.router.navigate(['cmpwebapp']);
            }
        }

        if (error.status === 403) {
            this.router.navigate(['cmpwebapp']);
        }

        return throwError(error);
    }

    private observableData<T>(data: T): Observable<T> {
        return of(data).pipe(delay(1000));
    }

    private prepareData(data: any): string {
        return this.requestInterceptors.reduce((acc, interceptor) => interceptor(acc), data);
    }
}
