using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Mensaje"] = "Usuario registrado correctamente.";
                return RedirectToAction("Registrar");
            }

            return View(model);
        }
    }
}
