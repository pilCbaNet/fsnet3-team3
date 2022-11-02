import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuienesSomosComponent } from './quienes-somos/quienes-somos.component';
import { MovimientosComponent } from './movimientos/movimientos.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { DetallesMovimientosComponent } from './detalles-movimientos/detalles-movimientos.component';
import { RetiroDineroComponent } from './retiro-dinero/retiro-dinero.component';
import { DepositoDineroComponent } from './deposito-dinero/deposito-dinero.component';


@NgModule({
  declarations: [
    QuienesSomosComponent,
    MovimientosComponent,
    LoginComponent,
    SignupComponent,
    DetallesMovimientosComponent,
    RetiroDineroComponent,
    DepositoDineroComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule
  ],
  exports: [
    QuienesSomosComponent,
    MovimientosComponent,
    LoginComponent
  ]
})
export class PagesModule { }