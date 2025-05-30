using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="El nombre de usuario es obligatorio completarlo.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe de estar entre 3 y 20 caracteres.")]
        [Display(Name ="Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage ="El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [Display(Name ="Correo Electrónico")]
        public string CorreoElectronico { get; set; }
        [Display(Name ="Contraseña")]
        public string Contrasena { get; set; }
        [Display(Name ="Confirmar Contraseña")]
        public string ConfirmarContrasena { get; set; }
    }
}
