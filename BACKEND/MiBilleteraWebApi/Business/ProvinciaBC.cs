using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProvinciaBC
    {
        public Provincia agregarProvincia(BilleteraContext db, Provincia oprovnueva)
        {
            db.Provincias.Add(oprovnueva);
            db.SaveChanges();
            return oprovnueva;
        }

        public Provincia modificarProvincia(BilleteraContext db, int id, string Nombre)
        {
            Provincia? oProvVieja = db.Provincias.FirstOrDefault(a => a.IdProvincia == id);
            oProvVieja.Nombre = Nombre;
            db.SaveChanges();
            return oProvVieja;
        }

        public void eliminarProvincia(BilleteraContext db, int id)
        {
            Provincia? oProvincia = db.Provincias.FirstOrDefault(x => x.IdProvincia == id);
            db.Remove(oProvincia);
            db.SaveChanges();

        }




        public Provincia? obtenerProvinvia(BilleteraContext db, int id)
        {
            return db.Provincias.Include(a => a.Localidades).FirstOrDefault(a => a.IdProvincia == id);
        }

        public void listarProvincias(BilleteraContext db)
        {
            db.Provincias.ToList();

        }


    }
}
