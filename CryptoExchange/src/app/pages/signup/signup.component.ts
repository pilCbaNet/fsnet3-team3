import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  form!:FormGroup;
  constructor(private formBuilder:FormBuilder) {
    this.form = this.formBuilder.group({
      name:['', Validators.required],
      lastname:['', Validators.required],
      birthdate:['', Validators.required],
      email:['', [Validators.required, Validators.email]],
      password:['', [Validators.required, Validators.minLength(8)]],
    })
  }

  get name(){
    return this.form.get("name")
  }
  get lastname(){
    return this.form.get("lastname")
  }
  get birthdate(){
    return this.form.get("birthdate")
  }
  get email(){
    return this.form.get("email")
  }
  get password(){
    return this.form.get("password")
  }

  ngOnInit(): void {
  }

  signUp(){
    alert(`Hola ${this.form.value.name}, Bienvenido!`)
    console.log(this.form.value.name)
  }
}
