using System.ComponentModel.DataAnnotations;

namespace api_ferreteriapieda.Models.Producto
{
    public class csRequestProductoActualizar
    {
        [Required]
        public string IdProducto { get; set; } = string.Empty;
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public float Precio { get; set; }
        [Required]
        public int Inventario { get; set; }
    }
}
