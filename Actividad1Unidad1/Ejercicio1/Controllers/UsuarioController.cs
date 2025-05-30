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
                ViewBag.Message = "El usuario ha sido registrado.";
                return View(model);
            }

            return View(model);
        }
    }
}
