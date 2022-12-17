import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Operacion } from 'src/app/models/operacion';
import { OperacionesService } from 'src/app/services/operaciones.service';

@Component({
  selector: 'app-retiro-dinero',
  templateUrl: './retiro-dinero.component.html',
  styleUrls: ['./retiro-dinero.component.css']
})
export class RetiroDineroComponent implements OnInit {
  public selectOP:any;
  fecha = new Date()
  form!:FormGroup
  constructor(private formBuilder:FormBuilder, private operacionesService:OperacionesService) {
    this.form = this.formBuilder.group({
      selectCuenta:['', Validators.required],
      amountCash:['', Validators.required],
    })
  }

  get selectCuenta(){
    return this.form.get("selectOp")
  }
  get amountCash(){
    return this.form.get("amountCash")
  }

  ngOnInit(): void {
  }

  realizarOperacion(){
    if(this.form.valid){
      let Monto:number=this.form.get('amountCash')?.value;
      let EsDeposito:boolean=false;
      let operacion:Operacion= new Operacion(EsDeposito, Monto);
      this.operacionesService.realizarOperacion(operacion).subscribe(respuestaOk=>{
        alert('Operación realizada con éxito!')
      })
    }
  }

}
