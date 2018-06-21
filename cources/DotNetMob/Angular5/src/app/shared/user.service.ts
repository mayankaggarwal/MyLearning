import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:52713'
  constructor(private http:HttpClient) { }

  public registerUser(user:User,roles:string[]){
    const body:User = {
      UserName : user.UserName,
      Password : user.Password,
      Email : user.Email,
      FirstName : user.FirstName,
      LastName : user.LastName,
      Roles:roles
    };
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/User/Register',body,{headers:reqHeader});
  }

  public userAuthentication(userName,password){
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded','No-Auth':'True'});
    
    return this.http.post(this.rootUrl + '/token',data,{headers:reqHeader});
  }

  public getUserClaims(){
    return this.http.get(this.rootUrl+'/api/getUserClaims');
  }

  public getAllRoles(){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(this.rootUrl + '/api/roles',{headers:reqHeader});
  }
}
