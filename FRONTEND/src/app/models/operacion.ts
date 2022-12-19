export class Operacion{
    
    EsDeposito:boolean;
    Monto:number;
    IdCuenta:number;


    constructor(EsDeposito:boolean, Monto:number, IdCuenta:number){
        this.EsDeposito=EsDeposito;
        this.Monto=Monto;
        this.IdCuenta=IdCuenta;

    }

}