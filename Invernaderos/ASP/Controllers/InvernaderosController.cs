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
                bool? fechaCorrecta = false;
                TemperaturasConNombreInvernadero temperaturasVM;
                Temperaturas temperaturasEnviar;
                int idInvernadero = ManejadoraBL.obtenerIdInvernaderoPorNombreBL(vm.NombreInvernaderoSeleccionado);

                // Compruebo que la fecha sea correcta
                List<DateTime> fechas = new List<DateTime>();
                fechas = ListadosBL.obtenerListadoFechasBL(idInvernadero);
                fechaCorrecta = fechas.Contains(vm.FechaSeleccionada.Date);

                // Según si la fecha es correcta envío a la vista datos o no para que los muestre
                if (fechaCorrecta != null && fechaCorrecta == true)
                {
                    temperaturasEnviar = ManejadoraBL.obtenerTemperaturasInvernaderoBL(idInvernadero, vm.FechaSeleccionada);
                    temperaturasVM = new TemperaturasConNombreInvernadero(temperaturasEnviar, vm.NombreInvernaderoSeleccionado);
                }
                else
                {
                    temperaturasVM = new TemperaturasConNombreInvernadero(false, vm.FechaSeleccionada);
                }

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
