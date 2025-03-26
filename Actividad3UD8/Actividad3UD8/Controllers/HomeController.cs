using Actividad3UD8.Models.VM;
using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3UD8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Editar()
        {
            ClsPersona personaAleatoria = ClsListadoPersonasBL.obtenerPersonaAleatoria();
            ClsPersonaConListadoDepartamentoVM personaVM = new ClsPersonaConListadoDepartamentoVM(personaAleatoria);
            return View(personaVM);
        }

        [HttpPost]
        public ActionResult Modificada(ClsPersona personaModificada)
        {
            ClsPersonaConListadoDepartamentoVM personaVM = new ClsPersonaConListadoDepartamentoVM(personaModificada);
            return View(personaVM);
        }

    }
}
