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
            List<ClsPersona> listadoPersonas = ClsListadoPersonasBL.obtenerListadoBD();
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            List<ClsListadoPersonaNombreDepartamento> listadoVM = new List<ClsListadoPersonaNombreDepartamento>();
            
            foreach(ClsPersona persona in listadoPersonas)
            {
                ClsListadoPersonaNombreDepartamento personaVM = new ClsListadoPersonaNombreDepartamento(persona, listadoDepartamentos);
                listadoVM.Add(personaVM);
            }

            return View(listadoVM);
        }

        public IActionResult edit(int id)
        {
            // TODO: Buscar persona con ese ID y devolverlo a la vista
            return View();
        }

    }
}
