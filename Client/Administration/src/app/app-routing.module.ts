import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateContractComponent } from './create-contract/create-contract.component';
import { DetailsContractsComponent } from './details-contracts/details-contracts.component';
import { ListContractsComponent } from './list-contracts/list-contracts.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "create", component: CreateContractComponent, canActivate: [AuthGuardService]},
  {path: "contracts", component: ListContractsComponent, canActivate: [AuthGuardService]},
  {path: "contracts/:id", component: DetailsContractsComponent, canActivate: [AuthGuardService]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
