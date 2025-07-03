using Microsoft.AspNetCore.Mvc;
using ProyectoDePruebaMVC.Models;

namespace ProyectoDePruebaMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private Prueba4313Context _context;

        public UsuarioController(Prueba4313Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista()
        {
            var listaUsuarios = _context.Usuarios.Select(e => new UsuarioViewModel()
            {
                NombreUsuario = e.Username,
                Contrasena = e.CurrentPassword,
                Correo = e.Email,
                ConfirmarContrasena = e.CurrentPassword
            }).ToList();

            return View(listaUsuarios);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["MensajeError"] = "El nombre de usuario pasado no existe.";

                return RedirectToAction("Lista");
            }

            var usuarioActual = _context.Usuarios.FirstOrDefault(e => e.Username.Equals(id));

            if (usuarioActual == null)
            {
                TempData["MensajeError"] = "No existe el usuario indicado";

                return RedirectToAction("Lista");
            }

            var usuarioDto = new UsuarioViewModel() { 
                NombreUsuario = usuarioActual.Username,
                Contrasena = usuarioActual.CurrentPassword,
                Correo = usuarioActual.Email,
                ConfirmarContrasena = usuarioActual.CurrentPassword
            };

            return View(usuarioDto);
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Username = model.NombreUsuario,
                    Email = model.Correo,
                    CurrentPassword = model.Contrasena
                };

                _context.Usuarios.Add(usuario);

                var rowsCount = _context.SaveChanges();

                if (rowsCount > 0)
                {
                    TempData["Mensaje"] = "Usuario registrado correctamente.";
                }
                else
                {
                    TempData["Mensaje"] = "Usuario no fue registrado correctamente.";
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioActual = _context.Usuarios.FirstOrDefault(e => e.Username.Equals(model.NombreUsuario));

                if (usuarioActual == null)
                {
                    TempData["MensajeError"] = "No existe el usuario indicado";

                    return RedirectToAction("Lista");
                }

                usuarioActual.Username = model.NombreUsuario;
                usuarioActual.Email = model.Correo;
                usuarioActual.CurrentPassword = model.Contrasena;

                var rowsCount = _context.SaveChanges();

                if (rowsCount > 0)
                {
                    TempData["Mensaje"] = "Usuario editado correctamente.";
                }
                else
                {
                    TempData["Mensaje"] = "Usuario no fue editado correctamente.";
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
