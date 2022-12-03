using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        // GET: api/<OperacionesController>
        [HttpGet]
        public List<Operacion> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.OperacionesDepositoOExtraccions.ToList();
            }
        }

        // GET api/<OperacionesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OperacionesController>
        [HttpPost]
        public void Post([FromBody] Operacion oOperacion)
        {
            using (var db = new BilleteraContext())
            {
                db.OperacionesDepositoOExtraccions.Add(oOperacion);
                db.SaveChanges();
            }
        }

        // PUT api/<OperacionesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        

        // DELETE api/<OperacionesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
