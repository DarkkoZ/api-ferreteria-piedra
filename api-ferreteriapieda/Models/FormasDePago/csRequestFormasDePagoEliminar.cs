using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csRequestFormasDePagoEliminar
    {
        [Required]
        public int IdPago { get; set; }
    }
}
