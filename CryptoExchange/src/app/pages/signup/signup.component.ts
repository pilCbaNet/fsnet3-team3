import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { dateValidator } from 'src/app/validators/dateMaxVal';
import { passwordMatch } from 'src/app/validators/passMatch';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  public maxDate!:String;

  form!:FormGroup;
  constructor(private formBuilder:FormBuilder) {
    this.form = this.formBuilder.group({
      name:['', Validators.required],
      lastname:['', Validators.required],
      birthdate:['', Validators.required ], //fecha nacimiento
      email:['', [Validators.required, Validators.email]],
      password:['', [Validators.required, Validators.minLength(8)]],
      password2:['', [Validators.required, Validators.minLength(8)]],
    },
    {
      //cuando hay mas de una validacion 'custom' o armada aparte, deben ir entre corchetes
      validators: [passwordMatch('password','password2'), dateValidator('birthdate')]
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
  get password2(){
    return this.form.get("password2")
  }

  ngOnInit(): void {
    //al iniciar el componente se fija como maxima la fecha del día
    this.maxDate = new Date().toISOString().split('T')[0]
    
  }

  signUp(){
    alert(`Hola ${this.form.value.name}, Bienvenido!`)
    console.log(this.form.value.name)
  }
}
