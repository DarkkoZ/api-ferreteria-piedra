using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Usuario.csUsuario;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioEliminar
    {
        public ResponseUsuario eliminarUsuario(string IdUsuario)
        {
            ResponseUsuario result = new ResponseUsuario();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM Usuario WHERE IdUsuario = '" + IdUsuario + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Usuario eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el Usuario";
                }
            }
            catch (Exception ex)
            {
                result.respuesta = -1;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return result;
        }
    }
}
