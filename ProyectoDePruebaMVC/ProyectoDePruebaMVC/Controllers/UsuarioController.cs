using Microsoft.AspNetCore.Mvc;
using ProyectoDePruebaMVC.Models;

namespace ProyectoDePruebaMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private static List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>() 
        { 
            new UsuarioViewModel() { NombreUsuario = "lfortuna", Correo = "lfortuna@ufhec.edu.do", Contrasena = "123456" },
            new UsuarioViewModel() { NombreUsuario = "jdejesus", Correo = "jdejesus@ufhec.edu.do", Contrasena = "123456" },
            new UsuarioViewModel() { NombreUsuario = "lmorales", Correo = "lmorales@ufhec.edu.do", Contrasena = "123456" },
            new UsuarioViewModel() { NombreUsuario = "wacosta", Correo = "wacosta@ufhec.edu.do", Contrasena = "123456" },
            new UsuarioViewModel() { NombreUsuario = "dmontero", Correo = "dmontero@ufhec.edu.do", Contrasena = "123456" }
        };
        public UsuarioController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(usuarios);
        }


        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["MensajeError"] = "El nombre de usuario pasado no existe.";

                return RedirectToAction("Lista");
            }

            UsuarioViewModel usuarioActual = usuarios.FirstOrDefault(e => e.NombreUsuario.Equals(id));

            if (usuarioActual == null)
            {
                TempData["MensajeError"] = "No existe el usuario indicado";

                return RedirectToAction("Lista");
            }

            return View(usuarioActual);
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                usuarios.Add(model);
                TempData["Mensaje"] = "Usuario registrado correctamente.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioViewModel usuarioActual = usuarios.FirstOrDefault(e => e.NombreUsuario.Equals(model.NombreUsuario));

                if (usuarioActual == null)
                {
                    TempData["MensajeError"] = "No existe el usuario indicado";

                    return RedirectToAction("Lista");
                }

                usuarioActual.NombreUsuario = model.NombreUsuario;
                usuarioActual.ConfirmarContrasena = model.ConfirmarContrasena;
                usuarioActual.Correo = model.Correo;
                usuarioActual.Contrasena = model.Contrasena;

                TempData["Mensaje"] = "Usuario editado correctamente.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
