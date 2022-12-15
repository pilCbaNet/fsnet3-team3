import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuienesSomosComponent } from './pages/quienes-somos/quienes-somos.component';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';
import { MovimientosComponent } from './pages/movimientos/movimientos.component';
import { SignupComponent } from './pages/signup/signup.component';
import { DetallesMovimientosComponent } from './pages/detalles-movimientos/detalles-movimientos.component';
import { RetiroDineroComponent } from './pages/retiro-dinero/retiro-dinero.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { DepositoDineroComponent } from './pages/deposito-dinero/deposito-dinero.component';
import { MovimientosBtcComponent } from './pages/movimientos-btc/movimientos-btc.component';





const routes: Routes = [
  { path: 'home', component: LandingComponent },
  { path: 'quienes-somos', component: QuienesSomosComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'movimientos-ars', component: MovimientosComponent },
  { path: 'movimientos-btc', component: MovimientosBtcComponent},
  { path: 'retiro', component: RetiroDineroComponent },
  { path: 'deposito', component: DepositoDineroComponent},
  { path: 'detalles/:movimiento', component: DetallesMovimientosComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
