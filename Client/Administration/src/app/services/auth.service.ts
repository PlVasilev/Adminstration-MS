import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
private loginPath = environment.apiUrl + "/identity/login"
private registerPath = environment.apiUrl + "/identity/register"

  constructor(private http: HttpClient) { }

  login(data: any): Observable<any>{
    return this.http.post(this.loginPath,data)
  }

  register(data: any): Observable<any>{
    return this.http.post(this.registerPath,data)
  }

  saveToken(token: string){
    localStorage.setItem('token', token)
  }

  getToken(){
    let token  = localStorage.getItem('token');
    if(token == null){
     return "";
    }
    return token;
  }

  isAdmin(){
    let token = this.getToken();
    let roles = JSON.parse(window.atob(token.split('.')[1])).role;
    return roles.includes('Admin');
  }

  isAutheticated(){
    if(this.getToken()){
      return true;
    }
    return false;
  }
}
