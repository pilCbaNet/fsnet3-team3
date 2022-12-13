import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!:FormGroup;

  constructor(private formBuilder:FormBuilder) {
    this.form = this.formBuilder.group({
      email:['', [Validators.required, Validators.email]], //cuando hay mas de un "validators" deben ir dentro de un array
      password:['', Validators.required]
    })
  }

  get email(){
    return this.form.get("email")
  }
  get password(){
    return this.form.get("password")
  }

  ngOnInit(): void {
  }
  login(){
    console.log('logged!')
  }

}
