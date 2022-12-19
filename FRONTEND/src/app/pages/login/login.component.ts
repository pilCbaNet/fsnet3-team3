import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { UsuarioEnLinea } from 'src/app/models/UsuarioEnLinea';
import { LoginService } from 'src/app/services/login.service';
import { MovimientosService } from 'src/app/services/movimientos.service';
import { OperacionesService } from 'src/app/services/operaciones.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  usuarioEnLinea!:UsuarioEnLinea

  constructor(private formBuilder: FormBuilder, private loginService: LoginService, private router: Router, private movimientosService: MovimientosService, private operacionesService: OperacionesService) {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]], //cuando hay mas de un "validators" deben ir dentro de un array
      password: ['', Validators.required]
    })
  }

  get email() {
    return this.form.get("email")
  }
  get password() {
    return this.form.get("password")
  }

  ngOnInit(): void {
  }
  login() {
    if (this.form.valid) {
      let email: string = this.form.get('email')?.value;
      let password: string = this.form.get('password')?.value;
      let login: Login = new Login(email, password);
      this.loginService.iniciarSesion(login).subscribe((data) =>{
        if(data){
            this.form.reset();
            // alert(`Hola ${data.nombre}, Bienvenido!`);
            this.usuarioEnLinea = data;
            this.movimientosService.userId = this.usuarioEnLinea.idCliente
            this.operacionesService.operacionNumero = parseInt(this.usuarioEnLinea.idCliente)
            console.log(this.usuarioEnLinea)
            this.router.navigate(['dashboard']);
          }
          else {
            alert('Ups. Usuario y/o contraseña incorrectos');
          }
     })
    };

  }
}



