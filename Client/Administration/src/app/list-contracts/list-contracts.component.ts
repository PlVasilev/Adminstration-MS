import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contract } from '../models/contract';
import { ContractService } from '../services/contract.service';

@Component({
  selector: 'app-list-contracts',
  templateUrl: './list-contracts.component.html',
  styleUrls: ['./list-contracts.component.css']
})
export class ListContractsComponent implements OnInit {
  contracts: Array<Contract> = [];

  constructor(private contractService: ContractService, private router: Router) { }

  ngOnInit(): void {
    this.getCats();
  }
  getCats(){
    this.contractService.mine().subscribe(contracts => {
      this.contracts = contracts;
      console.log(this.contracts);
    })
  }
 

  delete(id: any) {
    this.contractService.delete(id).subscribe(res => {
      console.log(res);
      this.getCats();
    })
  }

  edit(id: any) {
      this.router.navigate(["/contracts/" + id + "/edit"])
    } 

}
