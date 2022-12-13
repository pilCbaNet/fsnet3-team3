using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBC
    {

        public Cliente agregarCliente(BilleteraContext db, Cliente oClienteNuevo)
        {
            oClienteNuevo.Contrasenia = Encriptar(oClienteNuevo.Contrasenia);
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
                    oClienteViejoViejo.Contrasenia = Encriptar(Password);
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


        public Cliente accederConPassword(BilleteraContext db, string usuario, string password)
        {

            Cliente clienteChequear = (Cliente)db.Clientes.FirstOrDefault(x => x.Usuario == usuario);
            if (clienteChequear != null && DesEncriptar(clienteChequear.Contrasenia) == password)
            {
                clienteChequear.Contrasenia = DesEncriptar(clienteChequear.Contrasenia);
                return clienteChequear;
            }
            return null;
            
        

        }

        /// Encripta una cadena
        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Desencripta una cadena
        public static string DesEncriptar( string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


    }
}
