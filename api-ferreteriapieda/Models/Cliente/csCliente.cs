using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csCliente
    {
        [Required]
        public string IdNit { get; set; } = string.Empty;
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Correo { get; set; } = string.Empty;


        public class ResponseCliente
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
    }
}
