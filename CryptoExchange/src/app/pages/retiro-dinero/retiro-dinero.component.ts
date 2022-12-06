import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-retiro-dinero',
  templateUrl: './retiro-dinero.component.html',
  styleUrls: ['./retiro-dinero.component.css']
})
export class RetiroDineroComponent implements OnInit {
  public selectOP:any;
  
  form!:FormGroup
  constructor(private formBuilder:FormBuilder) {
    this.form = this.formBuilder.group({
      selectOp:['', Validators.required],
      amountCash:['', Validators.required],
      bankAccount:['', Validators.required],
      //paypalAccount:['', Validators.required]
    })
  }

  get selectOp(){
    return this.form.get("selectOp")
  }
  get amountCash(){
    return this.form.get("amountCash")
  }
  get bankAccount(){
    return this.form.get("bankAccount")
  }
  get paypalAccount(){
    return this.form.get("paypalAccount")
  }

  ngOnInit(): void {
  }

}
