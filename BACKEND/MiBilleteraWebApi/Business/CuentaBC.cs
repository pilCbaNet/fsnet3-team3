using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CuentaBC
    {
        public Cuenta agregarCuenta(BilleteraContext db, Cuenta oCuenta)
        {
            db.Cuentas.Add(oCuenta);
            db.SaveChanges();
            return oCuenta;
        }

        public Cuenta modificarCuenta(BilleteraContext db, int id, int Saldo, int CBU)
        {
            Cuenta? oCuentaVieja = db.Cuentas.FirstOrDefault(a => a.IdCuenta == id);
            oCuentaVieja.Saldo = Saldo;
            oCuentaVieja.Cvu = CBU;
            db.SaveChanges();
            return oCuentaVieja;
        }

        public void eliminarCuenta(BilleteraContext db, int id)
        {
            Cuenta? oCuenta = db.Cuentas.FirstOrDefault(x => x.IdCuenta == id);
            db.Remove(oCuenta);
            db.SaveChanges();

        }


        public Cuenta? obtenerCuenta(BilleteraContext db, int id)
        {
            return db.Cuentas.FirstOrDefault(a => a.IdCuenta == id);
        }

        public void listarCunetas(BilleteraContext db)
        {
            db.Cuentas.ToList();

        }
    }
}
