import { Component, OnInit } from '@angular/core';
import { Saldos } from 'src/app/models/Saldos';
import { UsuarioEnLinea } from 'src/app/models/UsuarioEnLinea';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  saldos!:any;
  constructor(private cuenta: MovimientosService) { }

  ngOnInit(): void {
    this.cuenta.obtenerSaldo().subscribe(data => {
      this.saldos = data;
      console.log(this.saldos);
    })
  }

}
