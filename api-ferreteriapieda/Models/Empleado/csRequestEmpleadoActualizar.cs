using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csRequestEmpleadoActualizar
    {
        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;
    }
}
