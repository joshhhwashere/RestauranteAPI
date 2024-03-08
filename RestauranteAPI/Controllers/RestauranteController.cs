using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestauranteAPI.DATA;
using RestauranteAPI.MODELS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly APIDbContext dbContext;

        public RestauranteController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<RestauranteController>
        [HttpGet]
        public IEnumerable<Platos> GetPlatos()
        {
            return dbContext.Platos;
        }
        //Get Tipo de comida
        //[HttpGet]
        //public IEnumerable<TipoComida> GetTipoDeComida()
        //{
        //    return dbContext.TipoComida.ToList();
        //}
        //Get By ID vamos a hacer por cada uno de ellos

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(dbContext.Platos.Find(id));
        }



        // POST api/<RestauranteController>
        [HttpPost]
        public IActionResult Post([FromBody] Platos value)
        {
            var plato = new Platos()
            {
                Nombre = value.Nombre,
                Precio = value.Precio,
                TipoComidaID = value.TipoComidaID
            };
            dbContext.Platos.Add(plato);
            dbContext.SaveChanges();
            return Ok("Se agregaron los cambios satisfactoriamente");
        }

        // PUT api/<RestauranteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Platos newPlato)
        {
            var platoByID = dbContext.Platos.Find(id);
            platoByID.Nombre = newPlato.Nombre;
            platoByID.Precio = newPlato.Precio;
            platoByID.TipoComidaID = newPlato.TipoComidaID;
            return Ok("Se actualizaron los datos");
        }

        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingID = dbContext.Platos.Find(id);
            dbContext.Platos.Remove(existingID);
            dbContext.SaveChanges();
            return Ok("Se eliminó de manera satifactoriamente..... ya no hay marcha atrás");
        }
    }
}
