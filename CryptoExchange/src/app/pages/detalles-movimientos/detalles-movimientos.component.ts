import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params} from '@angular/router';
import { MovimientosService } from 'src/app/services/movimientos.service';

@Component({
  selector: 'app-detalles-movimientos',
  templateUrl: './detalles-movimientos.component.html',
  styleUrls: ['./detalles-movimientos.component.css']
})
export class DetallesMovimientosComponent implements OnInit {
  movimiento!: { numeroDeMovimiento:any };
  movimientos:any;
  hoy = new Date();

  constructor(private rutaActiva: ActivatedRoute, private cuenta: MovimientosService ) { }

  ngOnInit(): void {
    this.rutaActiva.params.subscribe(
      (params: Params) => {
        this.movimiento = params['movimiento'];
      }
    );
    this.cuenta.obtenerUltimosMovimientos().subscribe(data => {
      console.log(data);
      this.movimientos = data;
    })

}
}
