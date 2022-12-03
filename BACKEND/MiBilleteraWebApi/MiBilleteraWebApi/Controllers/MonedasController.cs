using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        // GET: api/<MonedasController>
        [HttpGet]
        public List<Moneda> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Monedas.ToList();
            }
        }

        // GET api/<MonedasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MonedasController>
        [HttpPost]
        public void Post([FromBody] Moneda oMoneda)
        {
            using (var db = new BilleteraContext())
            {
                db.Monedas.Add(oMoneda);
                db.SaveChanges();
            }
        }

        // PUT api/<MonedasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MonedasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
