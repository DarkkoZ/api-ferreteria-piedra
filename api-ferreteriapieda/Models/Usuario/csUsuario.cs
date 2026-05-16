using System.ComponentModel.DataAnnotations;
using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuario
    {
        [Required]
        public string IdUsuario { get; set; } = string.Empty;
        [Required]
        public string IdNit { get; set; } = string.Empty;
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Correo { get; set; } = string.Empty;


        public class ResponseUsuario
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class ConexionWrapper
        {
            private readonly ConexionDB _conexionDB;

            public ConexionWrapper(ConexionDB conexionDB)
            {
                _conexionDB = conexionDB;
            }

            public SqlConnection Obtener()
            {
                return _conexionDB.ObtenerConexion();
            }
        }
    }
}
