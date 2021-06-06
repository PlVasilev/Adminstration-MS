import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { CreateContractComponent } from './create-contract/create-contract.component';
import { ContractService } from './services/contract.service';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptor } from './services/token-interceptor.service';
import { ListContractsComponent } from './list-contracts/list-contracts.component';
import { DetailsContractsComponent } from './details-contracts/details-contracts.component';
import { EditContractComponent } from './edit-contract/edit-contract.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreateContractComponent,
    ListContractsComponent,
    DetailsContractsComponent,
    EditContractComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService, 
    ContractService, 
    AuthGuardService, 
    {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  schemas: [NO_ERRORS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
