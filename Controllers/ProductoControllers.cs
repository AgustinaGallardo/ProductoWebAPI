using Microsoft.AspNetCore.Mvc;
using ProductosWebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoControllers : ControllerBase
    {
        private static ProductoControllers Instancia;

        private static readonly List<Producto> lstProductos = new List<Producto>(); 


        public static ProductoControllers ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new ProductoControllers();
            }
            return Instancia;
        }


        // GET: api/Producto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lstProductos);    
        }

        // GET api/Producto/
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach(Producto p in lstProductos)
            {
                if(p.NombreProducto.Equals(nombre))
                {
                    return Ok(p);
                }
            }
            return NotFound("No existe ese producto");
        }

        // POST api/Producto
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            if (value == null || string.IsNullOrEmpty(value.NombreProducto))
                return BadRequest("Error datos incorrectos");
            lstProductos.Add(value);
            return Ok("Se agrego el producto con exito");
        }

        // PUT api/<Producto>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Producto>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
