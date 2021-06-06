import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { ContractService } from '../services/contract.service';

@Component({
  selector: 'app-create-contract',
  templateUrl: './create-contract.component.html',
  styleUrls: ['./create-contract.component.css']
})
export class CreateContractComponent implements OnInit {

  contractForm: FormGroup;

  constructor(private fb: FormBuilder, private contractService: ContractService) { 
    this.contractForm = this.fb.group({
      'type': ['',Validators.required],
      'contractor': ['',Validators.required],
      'description': ['',Validators.required]
    })
   
  }

  ngOnInit(): void {
  }

  create(){
    console.log(this.contractForm.value);
    this.contractService.create(this.contractForm.value).subscribe( data =>{
      console.log(data)
    })
  }

  get type() {
    return this.contractForm.get('type');
  }

  get contractor() {
    return this.contractForm.get('contractor');
  }

  get description() {
    return this.contractForm.get('description');
  }

}
