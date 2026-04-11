using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csRequestDetalleFacturaEliminar
    {
        [Required]
        public int IdDetalleFacturacion { get; set; }
    }
}
