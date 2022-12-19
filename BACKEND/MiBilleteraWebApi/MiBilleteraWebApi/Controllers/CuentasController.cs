using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        // GET: api/<CuentasController>
        // modificar y llevar a bc
        [HttpGet]
        public List<Cuenta> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Cuentas.ToList();
            }
        }

        // GET api/<CuentasController>/5
        //funcionando ok
        [HttpGet("{id}")]
        public Cuenta Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new CuentaBC().obtenerCuenta(db, id);
            }
        }

        // POST api/<CuentasController>
        //funcionando ok
        [HttpPost]
        public void Post([FromBody] Cuenta oCuenta)
        {
            using (var db = new BilleteraContext())
            {
                new CuentaBC().agregarCuenta(db, oCuenta);
            }
        }

        // PUT api/<CuentasController>/5
        // null pointer, revisar, falta agregar algun valor requerido por el objeto
        [HttpPut("{id}")]
        public void Put([FromBody]int id, int Saldo, int CBU)
        {
            using (var db = new BilleteraContext())
            {
                new CuentaBC().modificarCuenta(db, id, Saldo, CBU);
            }
        }

        // DELETE api/<CuentasController>/5
        //no usar
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("/api/obtenerSaldos")]
        public Saldos GetSaldos([FromBody] int idCliente)
        {
            using (var db = new BilleteraContext())
            {
                return new CuentaBC().obtenerSaldos(db, idCliente);
            }
        }
    }
}
