import { Component, OnInit } from '@angular/core';
import { MovimientosService } from 'src/app/services/movimientos.service';


@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  hoy = new Date();
  movimientos: any;

  constructor(private cuenta: MovimientosService) { }

  ngOnInit(): void {
    this.cuenta.obtenerUltimosMovimientos().subscribe(data => {
      console.log(data);
      this.movimientos = data;
    })
  }
}
