using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csRequestDetalleFacturaInsertar
    {
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public string IdProducto { get; set; } = string.Empty;
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public float Precio_Unitario { get; set; }
    }
}
