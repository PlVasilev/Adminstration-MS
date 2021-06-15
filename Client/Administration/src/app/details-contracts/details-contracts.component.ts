import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Contract } from '../models/contract';
import { AuthService } from '../services/auth.service';
import { ContractService } from '../services/contract.service';

@Component({
  selector: 'app-details-contracts',
  templateUrl: './details-contracts.component.html',
  styleUrls: ['./details-contracts.component.css']
})
export class DetailsContractsComponent implements OnInit {
  id: string | undefined;
  contract: Contract | undefined;
  token: string | undefined;
  roles: Array<string>;
  constructor(private raute: ActivatedRoute, private contractService: ContractService, private authervise: AuthService) {
    this.roles = [];
    this.raute.params.subscribe(res => {
      this.id = res['id'];
      this.contractService.details(this.id).subscribe(res => {
        this.contract = res;
      })
    })
  }

  ngOnInit(): void {
    this.token = this.authervise.getToken();
    let roles = JSON.parse(window.atob(this.token.split('.')[1])).role;

    console.log(roles);
    console.log(roles.includes('Admin'));
  }

}
