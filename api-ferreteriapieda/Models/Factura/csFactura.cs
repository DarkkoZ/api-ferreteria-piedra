using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Factura
{
    public class csFactura
    {
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string IdNit { get; set; } = string.Empty;
        [Required]
        public string IdPago { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        [Required]
        public float Monto_Total { get; set; }

        public class ResponseFactura
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
    }
}
