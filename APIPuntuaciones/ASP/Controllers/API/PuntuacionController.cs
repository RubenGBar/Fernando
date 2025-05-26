using ENT;
using BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntuacionController : ControllerBase
    {
        // GET: api/Puntuacion
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Puntuacion> listadoCompleto = new List<Puntuacion>();
            try
            {
                listadoCompleto = ManejadoraBL.obtenerListadoPuntuacionBL();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/Puntuacion
        [HttpPost]
        public IActionResult Post([FromBody]Puntuacion puntuacionInsertar)
        {
            IActionResult salida;
            int resultado;

            try
            {
                resultado = ManejadoraBL.crearPuntuacionBL(puntuacionInsertar);
                if (resultado > 0)
                {
                    salida = Ok(resultado);
                }
                else
                {
                    salida = NotFound();
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
