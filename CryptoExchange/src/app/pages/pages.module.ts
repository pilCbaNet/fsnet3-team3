import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuienesSomosComponent } from './quienes-somos/quienes-somos.component';
import { MovimientosComponent } from './movimientos/movimientos.component';



@NgModule({
  declarations: [
    QuienesSomosComponent,
    MovimientosComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    QuienesSomosComponent,
    MovimientosComponent
  ]
})
export class PagesModule { }