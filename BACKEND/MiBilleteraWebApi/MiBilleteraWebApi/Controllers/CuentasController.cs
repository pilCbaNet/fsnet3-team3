using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        // GET: api/<CuentasController>
        [HttpGet]
        public List<Cuenta> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Cuentas.ToList();
            }
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CuentasController>
        [HttpPost]
        public void Post([FromBody] Cuenta oCuenta)
        {
            using (var db = new BilleteraContext())
            {
                db.Cuentas.Add(oCuenta);
                db.SaveChanges();
            }
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
