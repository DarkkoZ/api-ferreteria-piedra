using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePago
    {
        public int IdPago { get; set; }
        [Required]
        public string Tipo_Tarjeta { get; set; } = string.Empty;
        [Required]
        public string Visa_Cuotas { get; set; } = string.Empty;
        [Required]
        public string Tarjeta_Debito_Credito { get; set; } = string.Empty;

        public class ResponseFormasDePago
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }
    }
}
