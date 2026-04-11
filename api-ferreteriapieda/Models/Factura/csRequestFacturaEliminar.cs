using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Factura
{
    public class csRequestFacturaEliminar
    {

        [Required]
        public int IdFactura { get; set; } 
    }
}
