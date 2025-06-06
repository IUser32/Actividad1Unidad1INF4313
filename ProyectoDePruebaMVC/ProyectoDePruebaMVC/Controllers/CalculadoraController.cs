using Microsoft.AspNetCore.Mvc;

namespace ProyectoDePruebaMVC.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sumar(int a, int b)
        {
            return View(a+b);
        }

    }
}
