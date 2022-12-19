import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignUp } from 'src/app/models/signup';
import { LoginService } from 'src/app/services/login.service';
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
  constructor(private formBuilder:FormBuilder, private loginService:LoginService, private router:Router) {
    this.form = this.formBuilder.group({
      name:['', Validators.required],
      lastname:['', Validators.required],
      birthdate:['', Validators.required ], //fecha nacimiento
      cuil:['', Validators.required],
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
  get cuil(){
    return this.form.get("cuil")
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
    if (this.form.valid){
      let Nombre:string=this.form.get('name')?.value;
      let Apellido:string=this.form.get('lastname')?.value;
      let Cuil:string=this.form.get('cuil')?.value;
      let FechaNacimiento:any=this.form.get('birthdate')?.value;
      let Usuario:string=this.form.get('email')?.value;
      let Contrasenia:string=this.form.get('password')?.value;
      let signup:SignUp = new SignUp(Nombre, Apellido, Cuil, FechaNacimiento, Usuario, Contrasenia)
     this.loginService.signUp(signup).subscribe(respuestaOk=>{
      alert("Registro exitoso. Hacé click en Aceptar para iniciar sesión.")
      console.log(this.form.value.name)
      this.router.navigate(['login']);
     })
    }


  }
}
