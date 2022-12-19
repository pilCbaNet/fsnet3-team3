import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Operacion } from 'src/app/models/operacion';
import { OperacionesService } from 'src/app/services/operaciones.service';

@Component({
  selector: 'app-deposito-dinero',
  templateUrl: './deposito-dinero.component.html',
  styleUrls: ['./deposito-dinero.component.css']
})
export class DepositoDineroComponent implements OnInit {
  fecha = new Date()
  form!:FormGroup
  constructor(private formBuilder:FormBuilder, private operacionesService:OperacionesService) { 
    this.form = this.formBuilder.group({
      selectCuenta:['', Validators.required],
      amountCash:['', Validators.required],
    })
  }
  get selectCuenta(){
    return this.form.get("selectCuenta")
  }
  get amountCash(){
    return this.form.get("amountCash")
  }
  ngOnInit(): void {
  }
  realizarOperacion(){
    if(this.form.valid){
      let Monto:number=this.form.get('amountCash')?.value;
      let EsDeposito:boolean=true;
      let IdCuenta:number=this.form.get('selectCuenta')?.value;
      let operacion:Operacion= new Operacion(EsDeposito, Monto, IdCuenta);
      this.operacionesService.realizarOperacion(operacion).subscribe(respuestaOk=>{
        alert('Operación realizada con éxito.')
      })
    }
  }
}
