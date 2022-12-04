using Entities;
using MEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        // GET: api/<LocalidadesController>
        [HttpGet]
        public List<Localidad> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Localidades.ToList();
            }
        }

        // GET api/<LocalidadesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocalidadesController>
        [HttpPost]
        public void Post([FromBody] Localidad oLocalidad)
        {
            using (var db = new BilleteraContext())
            {
                db.Localidades.Add(oLocalidad);
                db.SaveChanges();
            }
        }

        // PUT api/<LocalidadesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocalidadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
