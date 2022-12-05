using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        // GET: api/<MonedasController>
        //pasar el listar al bc
        [HttpGet]
        public List<Moneda> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Monedas.ToList();
            }
        }

        // GET api/<MonedasController>/5 
        //probado ok.
        [HttpGet("{id}")]
        public Moneda? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new MonedaBC().buscarMoneda(db, id);
            }

        }


        // POST api/<MonedasController>
        //probado ok
        [HttpPost]
        public void Post([FromBody] Moneda oMonedaNueva)
        {
            using (var db = new BilleteraContext())
            {
                new MonedaBC().agregarMoneda(db, oMonedaNueva);

            }

        }


        // PUT api/<MonedasController>/5
        //probado ok
        [HttpPut("{id}")]
        public void Put(int id, string Nombre)
        {
            using (var db = new BilleteraContext())
            {
                new MonedaBC().modificarMoneda(db, id, Nombre);
            }

        }

        // DELETE api/<MonedasController>/5
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
                    new MonedaBC().eliminarMoneda(db, id);

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
