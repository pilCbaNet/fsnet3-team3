using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MonedaBC
    {
        public Moneda agregarMoneda(BilleteraContext db, Moneda oMonedaNueva)
        {
            db.Monedas.Add(oMonedaNueva);
            db.SaveChanges();
            return oMonedaNueva;
        }

        public Moneda modificarMoneda(BilleteraContext db, int id, string Nombre)
        {
            Moneda? oMonedaVieja = db.Monedas.FirstOrDefault(a => a.IdMoneda == id);
            oMonedaVieja.Nombre = Nombre;
            db.SaveChanges();
            return oMonedaVieja;
        }

        public void eliminarMoneda(BilleteraContext db, int id)
        {
            Moneda? oMoneda = db.Monedas.FirstOrDefault(x => x.IdMoneda == id);
            db.Remove(oMoneda);
            db.SaveChanges();

        }

        public Moneda? buscarMoneda(BilleteraContext db, int id)
        {
            return db.Monedas.FirstOrDefault(a => a.IdMoneda == id);

        }

        public void listarMonedas(BilleteraContext db)
        {
            db.Monedas.ToList();

        }

    }
}
