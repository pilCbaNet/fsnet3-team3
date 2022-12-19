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

        public void listarCuentas(BilleteraContext db)
        {
            db.Cuentas.ToList();

        }

        //Obtiene los saldos, el cliente tiene como maximo 2 cuentas activas, una en $ y la otra en btc
        //La funcion controla que la cuenta este activa y habilitada y crea el objeto con los saldos correspondientes
        public Saldos obtenerSaldos(BilleteraContext db, int id)
        {

            List<Cuenta> cuentas = new List<Cuenta>();
            cuentas = (from c in db.Cuentas where c.IdCliente == id select c).ToList();

            int saldoPesos = 0;
            int saldoBtc = 0;
            foreach(Cuenta saldo in cuentas)
            {
                if(saldo.EstaHabilitada == true && saldo.FechaBaja == null)
                {
                    if (saldo.IdMoneda == 1)
                    {
                        saldoPesos = saldo.Saldo;
                    }
                    else
                    {
                        saldoBtc = saldo.Saldo;
                    }
                }
            }
            Saldos saldos = new Saldos();
            saldos.valorPesos = saldoPesos;
            saldos.valorBTC = saldoBtc;
            return saldos;
        }
    }
}
