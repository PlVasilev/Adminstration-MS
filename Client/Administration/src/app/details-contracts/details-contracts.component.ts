import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Contract } from '../models/contract';
import { ContractService } from '../services/contract.service';

@Component({
  selector: 'app-details-contracts',
  templateUrl: './details-contracts.component.html',
  styleUrls: ['./details-contracts.component.css']
})
export class DetailsContractsComponent implements OnInit {
  id: string | undefined;
  contract: Contract | undefined;

  constructor(private raute: ActivatedRoute, private contractService: ContractService) {
    this.raute.params.subscribe(res => {
      this.id = res['id'];
      this.contractService.details(this.id).subscribe(res =>{
        this.contract = res;
      })
    })
   }

  ngOnInit(): void {
  }

}
