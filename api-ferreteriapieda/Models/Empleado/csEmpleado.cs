using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csEmpleado
    {
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Correo { get; set; } = string.Empty;


        public class ResponseEmpleado
        {
            public int respuesta {get; set; }
            public string descripcion_respuesta { get; set; }
        }
    }

    
}
