export class SignUp{
    Nombre:string;
    Apellido:string;
    Cuil:string;
    FechaNacimiento:any;
    Usuario:string;
    Contrasenia:string;

    constructor(Nombre:string, Apellido:string, Cuil:string, FechaNacimiento:any, Usuario:string, Contrasenia:string){
        this.Nombre=Nombre;
        this.Apellido=Apellido;
       this.Cuil=Cuil;
        this.FechaNacimiento=FechaNacimiento;
        this.Usuario=Usuario;
        this.Contrasenia=Contrasenia;
    }
}