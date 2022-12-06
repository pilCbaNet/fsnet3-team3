using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OperacionesBC
    {
        public Operacion agregarOperacion(BilleteraContext db, Operacion oOperNueva)
        {
            db.OperacionesDepositoOExtraccions.Add(oOperNueva);
            db.SaveChanges();
            return oOperNueva;
        }

        public Operacion modificarOperacion(BilleteraContext db, int id, int Monto, bool EsDeposito)
        {
            Operacion OperacVieja = db.OperacionesDepositoOExtraccions.FirstOrDefault(a => a.IdOperacion == id);
            OperacVieja.Monto = Monto;
            OperacVieja.EsDeposito = EsDeposito;
            db.SaveChanges();
            return OperacVieja;
        }

        public void eliminarOperacion(BilleteraContext db, int id)
        {
            Operacion? oOperac = db.OperacionesDepositoOExtraccions.FirstOrDefault(x => x.IdOperacion == id);
            db.Remove(oOperac);
            db.SaveChanges();

        }
        public Operacion? obtenerProvinvia(BilleteraContext db, int id)
        {
            return db.OperacionesDepositoOExtraccions.FirstOrDefault(a => a.IdOperacion == id);
        }




        public List<Operacion> listarOperaciones(BilleteraContext db) 
        {
            return db.OperacionesDepositoOExtraccions.ToList();

        }

    }
}
