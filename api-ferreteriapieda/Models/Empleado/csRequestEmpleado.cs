using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csRequestEmpleado
    {   
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

