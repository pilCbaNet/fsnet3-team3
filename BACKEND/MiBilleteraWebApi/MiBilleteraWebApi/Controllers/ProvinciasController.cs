using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entities;
using Microsoft.EntityFrameworkCore;
using Business;

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        // GET: api/<Provincias>
        // probado funcionando, falta consultar como generar un metodo con una lista
        [HttpGet]
        public List<Provincia> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Provincias.Include(a=>a.Localidades).ToList();
            }
        }

        // GET api/<Provincias>/5
        //Probado ok.
        [HttpGet("{id}")]
        public Provincia? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new ProvinciaBC().obtenerProvinvia(db, id);
            }

        }

        // POST api/<Provincias>
        //Probado ok.
        [HttpPost]
        public void Post([FromBody] Provincia oprovnueva)
        {
            using (var db = new BilleteraContext())
            {
                new ProvinciaBC().agregarProvincia(db, oprovnueva);

            }

        }

        // PUT api/<Provincias>
        //Probado ok.
        [HttpPut]
        public void Put(int id, string Nombre)
        {
            using (var db = new BilleteraContext())
            {
                new ProvinciaBC().modificarProvincia(db, id, Nombre);
            }

        }



        // DELETE api/<Provincias>/5
        //no usar
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraContext())
                {
                    //Provincia? oProvincia = db.Provincias.FirstOrDefault(x => x.IdProvincia == id);
                    //db.Remove(oProvincia);
                    //db.SaveChanges();
                    new ProvinciaBC().eliminarProvincia(db, id);

                }

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
