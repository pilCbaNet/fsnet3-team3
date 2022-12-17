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




        public List<Operacion> listarOperaciones(BilleteraContext db,int idCliente, int moneda) 
        {
            List<Operacion> operaciones = new List<Operacion>();

            var idCuenta = (from x in db.Cuentas where x.IdCliente == idCliente && x.IdMoneda == moneda && x.EstaHabilitada == true && x.FechaBaja == null select x.IdCuenta).FirstOrDefault();

            operaciones = (from o in db.OperacionesDepositoOExtraccions where o.IdCuenta == idCuenta select o).ToList();
            return operaciones;

        }

        public int debitoCredito(BilleteraContext db, int idCLiente, int moneda, int monto, bool esDeposito)
        {
            //Obtiene entidad cuenta
            Cuenta cuenta = db.Cuentas.FirstOrDefault(x => x.IdCliente == idCLiente && x.IdMoneda == moneda && x.EstaHabilitada == true && x.FechaBaja == null);

            //Si es deposito suma el dinero, si no controla que se pueda extraer y extrae
            if (esDeposito)
            {
                cuenta.Saldo += monto;
                db.SaveChanges();

            }else if(cuenta.Saldo - monto < 0)
            {
                return -1;
            }
            else
            {
                cuenta.Saldo -= monto;
                db.SaveChanges();
            }

            //Crea y agrega nueva operacion
            Operacion oOperNueva = new Operacion();

            oOperNueva.EsDeposito = esDeposito;
            oOperNueva.Fecha = DateTime.Now;
            oOperNueva.Monto = monto;
            oOperNueva.FechaBaja = null; 
            oOperNueva.IdCuenta = cuenta.IdCuenta;

            db.OperacionesDepositoOExtraccions.Add(oOperNueva);
            db.SaveChanges();
            return 1;
        }
    }
}
