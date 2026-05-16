using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Producto.csProducto;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoEliminar
    {
        private readonly ConexionDB _conexionDB;

        public csProductoEliminar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseProducto eliminarProducto(string IdProducto)
        {
            ResponseProducto result = new ResponseProducto();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "DELETE FROM Producto WHERE IdProducto = '" + IdProducto + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Producto eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el Producto";
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
