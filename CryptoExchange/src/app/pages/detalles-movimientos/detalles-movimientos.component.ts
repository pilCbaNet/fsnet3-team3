import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params} from '@angular/router';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-detalles-movimientos',
  templateUrl: './detalles-movimientos.component.html',
  styleUrls: ['./detalles-movimientos.component.css']
})
export class DetallesMovimientosComponent implements OnInit {
  movimiento!:any;
  movimientosEnARS:any;
  movimientosEnBTC:any;
  hoy = new Date();

  constructor(private rutaActiva: ActivatedRoute, private cuenta: MovimientosService ) { }

  ngOnInit(): void {
    this.rutaActiva.params.subscribe(
      params=> {
        this.movimiento = params['movimiento'];
      }
    );
    this.cuenta.obtenerUltimosMovimientosEnARS().subscribe(data => {
      console.log(data);
      this.movimientosEnARS = data;
    })

    this.cuenta.obtenerUltimosMovimientosEnBTC().subscribe(data => {
      console.log(data);
      this.movimientosEnBTC = data;
    })

}
}
