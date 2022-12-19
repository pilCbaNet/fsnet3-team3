import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Operacion } from '../models/operacion';

@Injectable({
  providedIn: 'root'
})
export class OperacionesService {
  operacionNumero!:number
  constructor(private http:HttpClient) { }

  realizarOperacion(operacion:Operacion):Observable<any>{
  operacion.IdCuenta = this.operacionNumero;
  return this.http.post('https://localhost:7195/api/Operaciones', operacion)
  }
}
