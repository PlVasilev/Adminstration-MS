import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Contract } from '../models/contract';
import { ContractService } from '../services/contract.service';

@Component({
  selector: 'app-edit-contract',
  templateUrl: './edit-contract.component.html',
  styleUrls: ['./edit-contract.component.css']
})
export class EditContractComponent implements OnInit {
  editForm: FormGroup;
  contractId: string | undefined;
  contract: Contract | undefined;

  constructor(
    private fb: FormBuilder,
    private contractService: ContractService,
    private route: ActivatedRoute) {
    this.editForm = this.fb.group({
      'type': [``, Validators.required],
      'contractor': [``, Validators.required],
      'description': [``, Validators.required]
    })
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.contractId = params['id']
      this.contractService.details(this.contractId).subscribe(res => {
        this.contract = res;
        this.editForm = this.fb.group({
          'type': [`${this.contract.type}`, Validators.required],
          'contractor': [`${this.contract.contractor}`, Validators.required],
          'description': [`${this.contract.description}`, Validators.required]
        })
      })
    })
  }

  edit() {
    let value = {
      'id': this.contractId,
      'type': this.editForm.value['type'],
      'contractor': this.editForm.value['contractor'],
      'description': this.editForm.value['description']
    }
    this.contractService.edit(value).subscribe(data => {
      console.log(data)
    })
  }

  get type() {
    return this.editForm.get('type');
  }

  get contractor() {
    return this.editForm.get('contractor');
  }

  get description() {
    return this.editForm.get('description');
  }
}
