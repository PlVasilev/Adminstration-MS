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
  private minePath = environment.apiUrl + "/Contracts/Mine"
  private dtailsPath = environment.apiUrl + "/Contracts"


  constructor(private http: HttpClient, private authService: AuthService) { }

  createContract(data: any): Observable<Contract>{
    return this.http.post<Contract>(this.createPath,data)
  }

  mineContracts(): Observable<Array<Contract>>{
    return this.http.get<Array<Contract>>(this.minePath)
  }

  details(id: any): Observable<Contract>{
    return this.http.get<Contract>(this.dtailsPath + `/${id}`)
  }

  delete(id: any): Observable<any>{
    return this.http.delete(this.dtailsPath + `/${id}`)
  }
}
