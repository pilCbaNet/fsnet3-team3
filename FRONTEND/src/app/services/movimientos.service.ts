import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioEnLinea } from '../models/UsuarioEnLinea';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {
  userId!:string;

  constructor(private http:HttpClient) { }
  
obtenerUltimosMovimientos():Observable<any>
{
  return this.http.post('https://localhost:7195/api/api/obtenerOperaciones', this.userId)
}

obtenerUltimosMovimientosBTC():Observable<any>
{
  return this.http.post('https://localhost:7195/api/api/obtenerOperacionesBTC', this.userId)
}

obtenerSaldo():Observable<any>
{
  return this.http.post('https://localhost:7195/api/obtenerSaldos',this.userId)
}

 
}