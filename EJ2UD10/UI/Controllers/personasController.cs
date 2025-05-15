using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using UI.Models.VM;

namespace UI.Controllers
{
    public class personasController : Controller
    {
        /// <summary>
        /// Método que devuelve la vista inicial
        /// </summary>
        /// <returns> Devuelve el Index </returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método que devuelve la vista de listado de personas
        /// </summary>
        /// <returns> La vista de listado de personas </returns>
        public IActionResult listado()
        {
            try
            {
                List<ClsPersona> listadoPersonas = ClsListadoPersonasBL.obtenerListadoBD();
                List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
                List<ClsListadoPersonaNombreDepartamento> listadoVM = new List<ClsListadoPersonaNombreDepartamento>();

                foreach (ClsPersona persona in listadoPersonas)
                {
                    ClsListadoPersonaNombreDepartamento personaVM = new ClsListadoPersonaNombreDepartamento(persona, listadoDepartamentos);
                    listadoVM.Add(personaVM);
                }

                return View(listadoVM);
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que devuelve la vista de editar persona
        /// </summary>
        /// <param name="id"> ID de la persona a editar </param>
        /// <returns> Devuelve a la vista el VM de la persona a editar o si hubo un error devuelve una vista error </returns>
        [HttpGet]
        public IActionResult edit(int id)
        {
            try
            {
                ClsPersona oPersona = ClsManejadoraBL.obtenerPersonaPorID(id);
                List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
                ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(oPersona, listadoDepartamentos);
                return View(personaVM);
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que recibe el objeto persona editado y lo guarda en la base de datos
        /// </summary>
        /// <param name="personaDeLaVista"> Persona recibido de la vista a guardar </param>
        /// <returns> Vuelve a la vista editar o la vista error si hubo algún error </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(ClsPersona personaDeLaVista, int idAntiguo)
        {
            try
            {
                bool resultado = ClsManejadoraBL.actualizarPersonaBL(personaDeLaVista, idAntiguo);

                if (!resultado)
                {
                    ModelState.AddModelError("Error", "No se pudo guardar la persona.");
                }

                return RedirectToAction(nameof(edit));
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que devuelve la vista de eliminar persona
        /// </summary>
        /// <param name="id"> ID de la persona a eliminar </param>
        /// <returns> Devuelve a la vista el VM de la persona a eliminar o si hubo un error devuelve una vista error </returns>
        [HttpGet]
        public IActionResult eliminar(int id)
        {
            try
            {
                ClsPersona personaAGuardar = ClsManejadoraBL.obtenerPersonaPorID(id);
                List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
                ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(personaAGuardar, listadoDepartamentos);
                return View(personaVM);
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que recibe la persona a eliminar y lo elimina de la base de datos
        /// </summary>
        /// <param name="personaDeLaVista"> Persona recibida de la vista que se va a eliminar </param>
        /// <returns> Vuelve al listado si se ha podido eliminar o va a una vista error si hubo algún error </returns>
        [HttpPost]
        public IActionResult eliminar(ClsPersona personaDeLaVista)
        {
            try
            {
                ClsPersona personAEliminar = ClsManejadoraBL.obtenerPersonaPorID(personaDeLaVista.Id);
                int resultado = ClsManejadoraBL.eliminarPersonaBL(personAEliminar.Id);
                return RedirectToAction(nameof(listado));
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que devuelve la vista de crear persona
        /// </summary>
        /// <returns> Devuelve a la vista el VM de la persona a crear o si hubo un error devuelve una vista error </returns>
        [HttpGet]
        public IActionResult crear()
        {
            try
            {
                List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
                ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(listadoDepartamentos);
                return View(personaVM);
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

        /// <summary>
        /// Método que recibe la persona a crear y lo guarda en la base de datos
        /// </summary>
        /// <param name="personaDeLaVista"> La persona recibida de la vista que se guardará en la BD </param>
        /// <returns> Vuelve al listado o a una vista error si hubo algún error </returns>
        [HttpPost]
        public IActionResult crear(ClsPersona personaDeLaVista)
        {
            try 
            {
                bool resultado = ClsManejadoraBL.crearPersonaBL(personaDeLaVista);

                if (!resultado)
                {
                    ModelState.AddModelError("Error", "No se pudo crear la persona.");
                }

                return RedirectToAction(nameof(listado));
            }catch(Exception ex)
            {
                return View("Error");
            }

        }

        /// <summary>
        /// Método que devuelve la vista de detalles de una persona
        /// </summary>
        /// <param name="id"> ID de la persona a mostrar sus detalles </param>
        /// <returns> Devuelve a la vista el VM de la persona a ver los detalles o si hubo un error devuelve una vista error </returns>
        public IActionResult detalles(int id)
        {
            try
            {
                ClsPersona oPersona = ClsManejadoraBL.obtenerPersonaPorID(id);
                List<ClsDepartamento> listadoDepartamentos = ClsListadoDepartamentosBL.obtenerListadoBD();
                ClsPersonaConListaDepartamento personaVM = new ClsPersonaConListaDepartamento(oPersona, listadoDepartamentos);
                return View(personaVM);
            }
            catch (Exception ex)
            {
                return View("Error");

            }
        }

    }
}
