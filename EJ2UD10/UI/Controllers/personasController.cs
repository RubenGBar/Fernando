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
            ClsListadoPersonaNombreDepartamento listadoPersonas = new ClsListadoPersonaNombreDepartamento();

            return View(listadoPersonas);
        }

        public IActionResult edit(int id)
        {
            // TODO: Buscar persona con ese ID y devolverlo a la vista
            return View();
        }

    }
}
