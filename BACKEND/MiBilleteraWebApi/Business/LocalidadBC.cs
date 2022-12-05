using Entities;
using MEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Business
{
    public class LocalidadBC
    {

        public Localidad agregarLocalidad(BilleteraContext db, Localidad oNuevaLocalidad)
        {
            db.Localidades.Add(oNuevaLocalidad);
            db.SaveChanges();
            return oNuevaLocalidad;
        }

        public Localidad modificarLocaliad(BilleteraContext db, int id, string Nombre,int IdProvincia)
        {
            Localidad oLocalidadVieja = db.Localidades.FirstOrDefault(a => a.IdLocalidad == id);
            oLocalidadVieja.Nombre = Nombre;
            oLocalidadVieja.IdProvincia = IdProvincia;
            db.SaveChanges();
            return oLocalidadVieja;
        }

        public void eliminarLocalidad(BilleteraContext db, int id)
        {
            Localidad? oLocalidad = db.Localidades.FirstOrDefault(x => x.IdLocalidad == id);
            db.Remove(oLocalidad);
            db.SaveChanges();

        }


        public Localidad? obtenerLocalidad(BilleteraContext db, int id)
        {
            return db.Localidades.FirstOrDefault(a => a.IdLocalidad == id);
        }

    }
}
