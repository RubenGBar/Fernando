using Microsoft.AspNetCore.Mvc;
using ASP.Models.VM;
using ENT;
using BL;

namespace ASP.Controllers;

public class PersonasController : Controller
{
    /// <summary>
    /// Devuelve una persona aleatoria cada vez que entramos
    /// </summary>
    /// <returns></returns>
    public IActionResult Actualizar()
    {
        ClsPersona personaAleatoria = ClsListadoPersonasBL.obtenerPersonaAleatoria();
        ClsPersonaConListadoDepartamentoVM personaVM = new ClsPersonaConListadoDepartamentoVM(personaAleatoria);
        return View(personaVM);
    }

}
