import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

  constructor(private http:HttpClient) { }
  
  obtenerUltimosMovimientosEnARS():Observable<any>
{
  return this.http.get('http://localhost:3000/movimientosEnARS')
}

obtenerUltimosMovimientosEnBTC():Observable<any>
{
  return this.http.get('http://localhost:3000/movimientosEnBTC')
}

obtenerSaldo():Observable<any>
{
  return this.http.get('http://localhost:3000/saldos')
}

 
}
