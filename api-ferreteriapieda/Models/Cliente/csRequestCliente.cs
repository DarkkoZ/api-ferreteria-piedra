using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csRequestCliente
    {
        [Required]
        public string IdNit  { get; set; } = string.Empty;
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
