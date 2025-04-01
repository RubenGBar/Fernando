using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class personasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult listado()
        {
            List<ClsPersona> listadoPersonas = ClsListadoPersonasBL.obtenerListadoPersonasBL();

            return View(listadoPersonas);
        }

    }
}
