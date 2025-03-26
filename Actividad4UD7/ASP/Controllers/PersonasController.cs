using Microsoft.AspNetCore.Mvc;
using ASP.Models.VM;
using ENT;
using BL;

namespace ASP.Controllers;

public class PersonasController : Controller
{
    ClsPersona personaAleatoria = ClsListadoPersonasBL.obtenerPersonaAleatoria();
    /// <summary>
    /// Devuelve una persona aleatoria cada vez que entramos
    /// </summary>
    /// <returns></returns>
    public IActionResult Actualizar()
    {
        ClsPersonaConListadoDepartamentoVM personaVM = new ClsPersonaConListadoDepartamentoVM(personaAleatoria);
        return View(personaVM);
    }

    public IActionResult Editar()
    {
        ClsPersonaConListadoDepartamentoVM personaVM = new ClsPersonaConListadoDepartamentoVM(personaAleatoria);
        return View(personaVM);
    }

    public IActionResult Index()
    {
        return View();
    }

}
