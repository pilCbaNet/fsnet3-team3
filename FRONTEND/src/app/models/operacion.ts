export class Operacion{
    
    Fecha:any;
    EsDeposito:boolean;
    Monto:number;
    Cuenta:string;

    constructor(Fecha:any, EsDeposito:boolean, Monto:number, Cuenta:string){
        this.Fecha=Fecha;
        this.EsDeposito=EsDeposito;
        this.Monto=Monto;
        this.Cuenta=Cuenta;
    }

}