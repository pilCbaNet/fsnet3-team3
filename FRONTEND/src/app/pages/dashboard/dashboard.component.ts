import { Component, OnInit } from '@angular/core';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  saldos:any;
  constructor(private cuenta: MovimientosService) { }

  ngOnInit(): void {
    this.cuenta.obtenerSaldo().subscribe(data => {
      console.log(data);
      this.saldos = data;
    })
  }

}
