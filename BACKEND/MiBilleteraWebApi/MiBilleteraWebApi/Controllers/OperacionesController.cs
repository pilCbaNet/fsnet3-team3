using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        // GET: api/<OperacionesController>
        // probado funcionando, falta pasarlo al bc
        [HttpGet]
        public List<Operacion> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.OperacionesDepositoOExtraccions.ToList();
            }

        }

        //Funcionando ok
        [HttpGet("{id}")]
        public Operacion? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new OperacionesBC().obtenerProvinvia(db, id);
            }

        }



        // POST api/<OperacionesController>
        // funcionado ok
        [HttpPost]
        public void Post([FromBody] Operacion oOpernueva)
        {
            using (var db = new BilleteraContext())
            {
                new OperacionesBC().agregarOperacion(db, oOpernueva);

            }

        }

        // PUT api/<OperacionesController>/5
        //problemas en este, consultar en clase CS8602
        [HttpPut("{id}")]
        public void Put([FromBody] int id, int Monto, bool EsDeposito)
        {
            using (var db = new BilleteraContext())
            {
                Operacion? OperacVieja = db.OperacionesDepositoOExtraccions.FirstOrDefault(a => a.IdOperacion == id);
                OperacVieja.Monto = Monto;
                OperacVieja.EsDeposito = EsDeposito;
                db.SaveChanges();

            }
        }


        // DELETE api/<OperacionesController>/5
        //no usar
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new BilleteraContext())
            {
                new OperacionesBC().eliminarOperacion(db, id);
            }

        }

        [HttpGet("/api/obtenerOperaciones")]

        public List<Operacion> obtenerOperaciones(int idCliente, int moneda)
        {
            using (var db = new BilleteraContext())
            {
                return new OperacionesBC().listarOperaciones(db, idCliente, moneda);
            }

        }

        [HttpGet("/api/debitoCredito")]
        public int debitoCredito(int idCliente, int moneda, int monto, bool esDeposito)
        {
            using (var db = new BilleteraContext())
            {
                return new OperacionesBC().debitoCredito(db, idCliente, moneda, monto, esDeposito);
            }

        }

    }
}
