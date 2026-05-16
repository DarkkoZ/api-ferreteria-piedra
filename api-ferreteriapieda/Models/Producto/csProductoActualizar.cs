using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Producto.csProducto;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csProductoActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseProducto actualizarProducto(string IdProducto, string Nombre, string Descripcion, float Precio, int Inventario, int Oferta)
        {
            ResponseProducto result = new ResponseProducto();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string precioStr = Precio.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string cadena = "UPDATE Producto SET " +
                "Nombre = '" + Nombre + "', " +
                "Descripcion = '" + Descripcion + "', " +
                "Precio = " + precioStr + ", " +
                "Inventario = " + Inventario + ", " +
                "Oferta = " + Oferta + " " +
                "WHERE IdProducto = '" + IdProducto + "' ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Producto Actualizado Exitosamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


            con.Close();

            return result;
        }
    }
}
