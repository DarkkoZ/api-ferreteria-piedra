using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csRequestEliminarCliente
    {
        [Required]
        public string IdNit { get; set; }
    }
}
