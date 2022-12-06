import { Component, OnInit } from '@angular/core';
import { MovimientosService } from 'src/app/services/movimientos.service';
import { ActivatedRoute, Params} from '@angular/router';
import { HttpParams } from '@angular/common/http';


@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  hoy = new Date();
  movimientosEnARS: any;
  movimientosEnBTC:any;
  tipoDeMoneda!:any;
  constructor(private cuenta: MovimientosService, private ruta:ActivatedRoute) { }

  ngOnInit(): void {
    this.cuenta.obtenerUltimosMovimientosEnARS().subscribe(data => {
      console.log(data);
      this.movimientosEnARS = data;
    })

    this.cuenta.obtenerUltimosMovimientosEnBTC().subscribe(data => {
      console.log(data);
      this.movimientosEnBTC = data;
    })

    this.ruta.params.subscribe((params:Params) =>{
      console.log(params['moneda'])
      this.tipoDeMoneda = params['moneda'];
    })


  }
}
