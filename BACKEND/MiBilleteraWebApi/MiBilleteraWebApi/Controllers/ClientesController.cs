using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public List<Cliente> Get()
        {
            using (var db = new BilleteraContext())
            {
                return db.Clientes.ToList();
            }
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public Cliente? Get(int id)
        {
            using (var db = new BilleteraContext())
            {
                return new ClienteBC().obtenerCliente(db, id);
            }

        }

        // POST api/<ClientesController>
        // listo 
        [HttpPost]
        public void Post([FromBody] Cliente oCliente)
        {
            using (var db = new BilleteraContext())
            {
                new ClienteBC().agregarCliente(db, oCliente);
            }
        }

        // PUT api/<ClientesController>/5
        //probado

        [HttpPut("{id}")]
        public void Put(int id, string Nombre, string Apellido, String Cuil, DateTime FechaNac, String Usuario, string Password, int IdLocalidad)
        {
            using (var db = new BilleteraContext())
            {
                new ClienteBC().modificarCliente(db, id, Nombre, Apellido, Cuil, FechaNac, Usuario, Password, IdLocalidad);
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {

        }



        [HttpPost("{Usuario}")]
        //hacer en post
        public void get([FromBody] string Usuario, string password)
        {
            using (var db = new BilleteraContext())
            {
                new ClienteBC().accederConPassword(db, Usuario, password);

            }
        }
    }
}
