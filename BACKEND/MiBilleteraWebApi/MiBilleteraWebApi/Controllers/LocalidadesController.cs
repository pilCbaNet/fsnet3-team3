using Business;
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
        //funcionando pero hay que modificar y llevar a bc
        [HttpGet]
        public List<Localidad> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Localidades.ToList();
            }
        }

        // GET api/<LocalidadesController>/5
        //funcionando ok
        [HttpGet("{id}")]
        public Localidad? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new LocalidadBC().obtenerLocalidad(db, id);
            }

        }

        // POST api/<LocalidadesController>
        //funcionando ok
        [HttpPost]
        public void Post([FromBody] Localidad oLocalidad)
        {
            using (var db = new BilleteraContext())
            {
                new LocalidadBC().agregarLocalidad(db, oLocalidad);
            }
        }

        // PUT api/<LocalidadesController>/5
        //problema de nullPointerException preguntar
        [HttpPut("{id}")]
        public void Put([FromBody] int id,string Nombre, int IdProvincia)
        {
            using (var db = new BilleteraContext())
            {
                new LocalidadBC().modificarLocaliad(db, id, Nombre,IdProvincia);
            }
        }

        // DELETE api/<LocalidadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
     

        }
    }

}

