import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuienesSomosComponent } from './quienes-somos/quienes-somos.component';
import { MovimientosComponent } from './movimientos/movimientos.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { DetallesMovimientosComponent } from './detalles-movimientos/detalles-movimientos.component';
<<<<<<< HEAD
import { RetiroDineroComponent } from './retiro-dinero/retiro-dinero.component';
import { DepositoDineroComponent } from './deposito-dinero/deposito-dinero.component';
=======
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './not-found/not-found.component';
>>>>>>> 213f056f5ea37b822946f897eb586711a7f51793


@NgModule({
  declarations: [
    QuienesSomosComponent,
    MovimientosComponent,
    LoginComponent,
    SignupComponent,
    DetallesMovimientosComponent,
<<<<<<< HEAD
    RetiroDineroComponent,
    DepositoDineroComponent
=======
    DashboardComponent,
    NotFoundComponent
>>>>>>> 213f056f5ea37b822946f897eb586711a7f51793
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