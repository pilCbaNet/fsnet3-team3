import { Component, OnInit } from '@angular/core';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-movimientos-btc',
  templateUrl: './movimientos-btc.component.html',
  styleUrls: ['./movimientos-btc.component.css']
})
export class MovimientosBtcComponent implements OnInit {
  movimientos: any;
  constructor(private cuenta:MovimientosService) { }

  ngOnInit(): void {
    this.cuenta.obtenerUltimosMovimientos().subscribe(data => {
      console.log(data);
      this.movimientos = data;
    })
  }

}
