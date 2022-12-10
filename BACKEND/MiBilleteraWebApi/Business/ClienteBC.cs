using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBC
    {

        public Cliente agregarCliente(BilleteraContext db, Cliente oClienteNuevo)
        {
            db.Clientes.Add(oClienteNuevo);
            db.SaveChanges();
            return oClienteNuevo;
        }

        public Cliente modificarCliente(BilleteraContext db, int id, string Nombre, string Apellido, String Cuil, DateTime FechaNac, String Usuario, string Password, int IdLocalidad)
        {
            try
            {

                Cliente? oClienteViejoViejo = db.Clientes.FirstOrDefault(a => a.IdCliente == id);

                if (oClienteViejoViejo is not null)
                {
                    oClienteViejoViejo.Nombre = Nombre;
                    oClienteViejoViejo.Apellido = Apellido;
                    oClienteViejoViejo.Cuil = Cuil;
                    oClienteViejoViejo.FechaNacimiento = FechaNac;
                    oClienteViejoViejo.Usuario = Usuario;
                    oClienteViejoViejo.Contrasenia = Password;
                    oClienteViejoViejo.IdLocalidad = IdLocalidad;
                    db.SaveChanges();


                }
                return oClienteViejoViejo;

            }
            catch (Exception ex)
            {

                throw ex;
            }






        }

        public void eliminarCliente(BilleteraContext db, int id)
        {
            Cliente? oCliente = db.Clientes.FirstOrDefault(x => x.IdCliente == id);
            db.Remove(oCliente);
            db.SaveChanges();

        }




        public Cliente? obtenerCliente(BilleteraContext db, int id)
        {
            return db.Clientes.FirstOrDefault(a => a.IdCliente == id);
        }

        public void listarClientes(BilleteraContext db)
        {
            db.Clientes.ToList();

        }
    }
}
