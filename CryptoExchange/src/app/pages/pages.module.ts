import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuienesSomosComponent } from './quienes-somos/quienes-somos.component';
import { MovimientosComponent } from './movimientos/movimientos.component';
import { LoginComponent } from './login/login.component';



@NgModule({
  declarations: [
    QuienesSomosComponent,
    MovimientosComponent,
    LoginComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    QuienesSomosComponent,
    MovimientosComponent,
    LoginComponent
  ]
})
export class PagesModule { }