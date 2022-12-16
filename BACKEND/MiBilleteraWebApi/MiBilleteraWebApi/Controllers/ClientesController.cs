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



        [HttpPost("/api/login")]
        public Cliente post([FromBody] Login login)
        {
            Cliente nuevoacceso;
            using (var db = new BilleteraContext())
            {
                nuevoacceso = new ClienteBC().accederConPassword(db, login.email, login.password); 

            }
            return nuevoacceso;
        }
    }
}
