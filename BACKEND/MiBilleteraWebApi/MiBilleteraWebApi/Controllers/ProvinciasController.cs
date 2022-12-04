using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        // GET: api/<Provincias>
        [HttpGet]
        public List<Provincia> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Provincias.Include(a=>a.Localidades).ToList();
            }
        }

        // GET api/<Provincias>/5
        [HttpGet("{id}")]
        public Provincia? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return db.Provincias.Include(a => a.Localidades).FirstOrDefault(a=>a.IdProvincia==id);
            }
        }

        // POST api/<Provincias>
        [HttpPost]
        public void Post([FromBody] Provincia oProvincia)
        {
            using (var db = new BilleteraContext())
            {
                db.Provincias.Add(oProvincia);
                db.SaveChanges();
            }
        }

        // PUT api/<Provincias>
        [HttpPut]
        public void Put([FromBody] Provincia oProvincia)
        {
            using (var db = new BilleteraContext())
            {
                Provincia? provinciaVieja = db.Provincias.FirstOrDefault(a=>a.IdProvincia==oProvincia.IdProvincia);
                provinciaVieja.Nombre = oProvincia.Nombre;
                db.SaveChanges();
            }
        }

        // PUT api/<Provincias>/5
        [HttpPut("{id}")]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraContext())
            {
                Provincia? provinciaVieja = db.Provincias.FirstOrDefault(a => a.IdProvincia == id);
                provinciaVieja.Nombre = nombre;
                db.SaveChanges();
            }
        }

        // DELETE api/<Provincias>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraContext())
                {
                    Provincia? oProvincia = db.Provincias.FirstOrDefault(x => x.IdProvincia == id);
                    db.Remove(oProvincia);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
