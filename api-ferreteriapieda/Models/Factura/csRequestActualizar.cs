using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Factura
{
    public class csRequestActualizar
    {
        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public string IdNit { get; set; } = string.Empty;

        [Required]
        public int IdPago { get; set; }

        [Required]
        public float Monto_Total { get; set; }
    }
}
