using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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

        [HttpGet]
        public IActionResult edit(int id)
        {
            ClsPersona oPersona = ClsManejadoraBL.obtenerPersonaPorID(id);
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(oPersona, listadoDepartamentos);
            return View(personaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(ClsPersonaConListaDepartamento model)
        {
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            int idDepartamentoSeleccionado = 0;
            
            foreach (ClsDepartamento departamento in listadoDepartamentos)
            {
                if (departamento.Id == model.IdDepartamento)
                {
                    idDepartamentoSeleccionado = departamento.Id;
                    break;
                }
            }
            var persona = new ClsPersona
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                Telefono = model.Telefono,
                Dni = model.Dni,
                Sexo = model.Sexo,
                IdDepartamento = idDepartamentoSeleccionado
            };

            bool resultado = ClsManejadoraBL.actualizarPersonaBL(persona);

            if (!resultado)
            {
                ModelState.AddModelError("Error", "No se pudo guardar la persona.");
            }
           
            return RedirectToAction(nameof(edit));   
        }

        [HttpGet]
        public IActionResult eliminar(int id)
        {
            ClsPersona personaAGuardar = ClsManejadoraBL.obtenerPersonaPorID(id);
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(personaAGuardar, listadoDepartamentos);
            return View(personaVM);
        }

        [HttpPost]
        public IActionResult eliminar(ClsPersonaConListaDepartamento model)
        {
            ClsPersona personAEliminar = ClsManejadoraBL.obtenerPersonaPorID(model.Id);
            int resultado = ClsManejadoraBL.eliminarPersonaBL(personAEliminar.Id);
            return RedirectToAction(nameof(listado));
        }

        [HttpGet]
        public IActionResult crear()
        {
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            ClsCrearPersonaConListaDepartamentos personaVM = new ClsCrearPersonaConListaDepartamentos(listadoDepartamentos);
            return View(personaVM);
        }

        [HttpPost]
        public IActionResult crear(ClsCrearPersonaConListaDepartamentos model)
        {
            var personaAAñadir = new ClsPersona
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                Telefono = model.Telefono,
                Dni = model.Dni,
                Sexo = model.Sexo,
                IdDepartamento = model.IdDepartamento
            };

            bool resultado = ClsManejadoraBL.crearPersonaBL(personaAAñadir);

            if (!resultado)
            {
                ModelState.AddModelError("Error", "No se pudo crear la persona.");
            }

            return RedirectToAction(nameof(listado));
        }

        public IActionResult detalles(int id)
        {
            ClsPersona oPersona = ClsManejadoraBL.obtenerPersonaPorID(id);
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
            ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(oPersona, listadoDepartamentos);
            return View(personaVM);
        }

    }
}
