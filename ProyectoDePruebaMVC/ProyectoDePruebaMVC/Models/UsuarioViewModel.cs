using System.ComponentModel.DataAnnotations;
namespace ProyectoDePruebaMVC.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Debe tener entre 3 y 20 caracteres")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Debe tener al menos 6 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Confirmar contraseña es obligatorio")]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmarContrasena { get; set; }
    }

}
