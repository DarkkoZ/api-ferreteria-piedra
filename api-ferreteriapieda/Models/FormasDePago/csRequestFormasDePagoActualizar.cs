using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csRequestFormasDePagoActualizar
    {
        [Required]
        public int IdPago { get; set; }
        [Required]
        public string Tipo_Tarjeta { get; set; } = string.Empty;
        [Required]
        public string Visa_Cuotas { get; set; } = string.Empty;
        [Required]
        public string Tarjeta_Debito_Credito { get; set; } = string.Empty;
    }
}
