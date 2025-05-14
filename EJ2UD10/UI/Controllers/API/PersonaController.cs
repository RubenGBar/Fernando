using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/Persona
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsPersona> listadoCompleto = new List<ClsPersona>();
            try
            {
                listadoCompleto = ClsListadoPersonasBL.obtenerListadoBD();
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

        // GET api/Persona/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsPersona persona;
            try
            {
                persona = ClsManejadoraBL.obtenerPersonaPorID(id);
                if (persona == null)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public IActionResult Post(ClsPersona personaInsertar)
        {
            IActionResult salida;
            bool resultado;

            try
            {
                resultado = ClsManejadoraBL.crearPersonaBL(personaInsertar);
                if (resultado)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(resultado);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClsPersona personaActualizar)
        {
            IActionResult salida;
            bool resultado;

            try
            {
                resultado = ClsManejadoraBL.actualizarPersonaBL(personaActualizar);
                if (resultado)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(resultado);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int resultado;

            try
            {
                resultado = ClsManejadoraBL.eliminarPersonaBL(id);
                if (resultado == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(resultado);
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
