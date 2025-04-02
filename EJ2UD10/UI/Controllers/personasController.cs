using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using UI.Models.VM;

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
<<<<<<< Updated upstream
            ClsListadoPersonaNombreDepartamento listadoPersonas = new ClsListadoPersonaNombreDepartamento();
=======
            List<ClsPersona> listadoPersonas = ClsListadoPersonasBL.obtenerListadoBD();
>>>>>>> Stashed changes

            return View(listadoPersonas);
        }

        public IActionResult edit(int id)
        {
            // TODO: Buscar persona con ese ID y devolverlo a la vista
            return View();
        }

    }
}
