import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuienesSomosComponent } from './pages/quienes-somos/quienes-somos.component';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';
import { MovimientosComponent } from './pages/movimientos/movimientos.component';
import { SignupComponent } from './pages/signup/signup.component';



const routes: Routes = [
  { path: 'home', component: LandingComponent },
  { path: 'quienes-somos', component: QuienesSomosComponent },
  { path: 'login', component: LoginComponent},
  { path: 'signup', component: SignupComponent},
  { path: 'movimientos', component: MovimientosComponent},
  { path: '', redirectTo:'/home', pathMatch:'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
