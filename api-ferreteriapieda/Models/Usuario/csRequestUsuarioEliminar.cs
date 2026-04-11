using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csRequestUsuarioEliminar
    {
        [Required]
        public string IdUsuario { get; set; }
    }
}
