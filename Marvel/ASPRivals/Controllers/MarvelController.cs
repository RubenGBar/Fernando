using ENT;
using DTO;
using BL;
using Microsoft.AspNetCore.Mvc;
using ASPRivals.Models.VM;

namespace ASPRivals.Controllers
{
    public class MarvelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaPersonajesConPuntos()
        {
            List<PersonajeConPuntuacionTotal> listadoPersonajeConPuntuacion = ManejadoraBL.obtenerListadoPersonajesConPuntuacionTotalBL();
            ListadoPersonajeConPuntuacion VM = new ListadoPersonajeConPuntuacion();
            return View(VM);
        }

        [HttpGet]
        public IActionResult PuntuarCombate()
        {
            CombateConListadoDePersonajes VM = new CombateConListadoDePersonajes();
            return View(VM);
        }

        [HttpPost]
        public IActionResult PuntuarCombate(Combate combate)
        {
            ViewBag.exito = "false";
            CombateConListadoDePersonajes VM;
            if (combate.IdCombatiente1 == 0 || combate.IdCombatiente2 == 0)
            {
                ViewBag.mensaje = "Tienes que seleccionar a los dos combatientes espabila coño.";
            }
            else
            {
                if (combate.IdCombatiente1 != combate.IdCombatiente2)
                {
                    try
                    {
                        if (ManejadoraBL.guardarCombateBL(combate))
                        {
                            ViewBag.mensaje = "Has puntuado correctamente el combate.";
                            ViewBag.exito = "true";
                        }
                        else
                        {
                            ViewBag.mensaje = "Ha ocurrido un error al guardar la puntuación. Vuelve a intentarlo más tarde.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.mensaje = ex.Message;
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.mensaje = "Deben de ser 2 personajes diferentes";
                }
            }

            VM = new CombateConListadoDePersonajes(combate);
            return View(VM);
        }

    }
}
