import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Contract } from '../models/contract';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ContractService {

  private createPath = environment.apiUrl + "/Contracts/Create"


  constructor(private http: HttpClient, private authService: AuthService) { }

  createContract(data: any): Observable<Contract>{
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${ this.authService.getToken()}`)
    return this.http.post<Contract>(this.createPath,data , {headers})
  }
}
