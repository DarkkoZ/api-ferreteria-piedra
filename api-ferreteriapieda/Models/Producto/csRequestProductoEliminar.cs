using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Producto
{
    public class csRequestProductoEliminar
    {
        [Required]
        public string IdProducto { get; set; } = string.Empty;
    }
}
