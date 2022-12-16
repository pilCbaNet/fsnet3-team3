import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  estaAutenticado = false;

  constructor(private formBuilder: FormBuilder, private loginService: LoginService, private router: Router) {
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
      this.loginService.iniciarSesion(login).subscribe({
        next: (data) => {
          console.log(data);
          if (data != null) {
            this.form.reset();
            this.estaAutenticado = true;
            this.router.navigate(['dashboard']);
          }
          else {
            this.estaAutenticado = false;
            alert('Ups. Usuario y/o contraseña incorrectos');
          }

        }
      })
    };

  }
}
  


