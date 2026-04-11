using System.ComponentModel.DataAnnotations;
namespace api_ferreteriapieda.Models.Factura
{
    public class csRequestFacturaResponse
    {
        
        public int IdFactura { get; set; }
        public int IdEmpleado { get; set; }
        public string IdNit { get; set; } = string.Empty;
        public string IdPago { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public float Monto_Total { get; set; }
    }
}
