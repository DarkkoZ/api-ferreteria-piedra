using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csRequestEmpleadoEliminar
    {
        [Required]
        public int IdEmpleado { get; set; }
    }
}
