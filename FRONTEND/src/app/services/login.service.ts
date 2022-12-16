import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/login';
import { SignUp } from '../models/signup';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  iniciarSesion(login:Login):Observable<any>{
    return this.http.post('https://localhost:7195/api/login', login)
  }

  signUp(signup:SignUp):Observable<any>{
    return this.http.post('https://localhost:7195/api/Clientes', signup)
  }
}
