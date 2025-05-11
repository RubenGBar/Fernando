using Microsoft.AspNetCore.Mvc;
using ASP.Models.VM;
using ENT;
using BL;

namespace ASP.Controllers
{
    public class InvernaderosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SeleccionarInvernadero()
        {
            try
            {
                SeleccionarInvernadero vm = new SeleccionarInvernadero();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult SeleccionarInvernadero(SeleccionarInvernadero vm)
        {
            try
            {
                int idInvernadero = ManejadoraBL.obtenerIdInvernaderoPorNombreDAL(vm.NombreInvernaderoSeleccionado);

                Temperaturas temperaturasEnviar = ManejadoraBL.obtenerTemperaturasInvernaderoBL(idInvernadero, vm.FechaSeleccionada);
                TemperaturasConNombreInvernadero temperaturasVM = new TemperaturasConNombreInvernadero(temperaturasEnviar, vm.NombreInvernaderoSeleccionado);

                return View("MostrarDatos", temperaturasVM);
            }
            catch (Exception ex) 
            {
                return View("Error");
            }
        }

        public IActionResult MostrarDatos(TemperaturasConNombreInvernadero vm)
        {
            try
            {
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}
