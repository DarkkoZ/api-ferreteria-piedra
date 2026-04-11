using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFactura
    {
        [Required]
        public int IdDetalleFacturacion { get; set; }
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public string IdProducto { get; set; } = string.Empty;
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public float Precio_Unitario { get; set; }

        public class ResponseDetalleFactura  
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
    }
}
