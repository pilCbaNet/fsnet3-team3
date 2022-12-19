export interface UsuarioEnLinea{
    idCliente:string;
    nombre: string;
    apellido: string;
    cuil: string;
    fechaNacimiento: string;
    usuario: string;
    contrasenia: string;
    fechaAlta: string;
    fechaBaja: string;
    idLocalidad: number;
    idLocalidadNavigation: string;
    cuenta: [];
}