import { HttpInterceptor,HttpRequest, HttpHandler, HttpSentEvent, HttpHeaderResponse, HttpProgressEvent,HttpResponse, HttpUserEvent } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/do';
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private router:Router){

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
        if(req.headers.get('No-Auth') == "True"){
            return next.handle(req.clone());
        };

        if(localStorage.getItem('userToken')!=null){
            const clonedReq = req.clone({
                headers:req.headers.set('Authorization',"Bearer " + localStorage.getItem('userToken'))
            });

            return next.handle(clonedReq)
                .do(
                    succ =>{return succ},
                    err=>{
                        debugger;
                        if(err.status === 401){
                            this.router.navigateByUrl('/login');
                        }
                    }
                );
        } else{
            this.router.navigateByUrl('/login');
        }
    }
}