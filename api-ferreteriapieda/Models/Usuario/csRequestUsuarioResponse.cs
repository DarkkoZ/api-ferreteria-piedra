using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csRequestUsuarioResponse
    {
        [Required]
        public string IdUsuario { get; set; } = string.Empty;
        [Required]
        public string IdNit { get; set; } = string.Empty;
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Correo { get; set; } = string.Empty;
    }
}
