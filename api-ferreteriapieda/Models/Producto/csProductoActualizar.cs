using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Producto.csProducto;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoActualizar
    {
        public ResponseProducto actualizarProducto(string IdProducto, string Nombre, string Descripcion, float Precio, int Inventario)
        {
            ResponseProducto result = new ResponseProducto();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
                con.Open();

                string precioStr = Precio.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string cadena = "UPDATE Producto SET " +
                "Nombre = '" + Nombre + "', " +
                "Descripcion = '" + Descripcion + "', " +
                "Precio = " + precioStr + ", " +
                "Inventario = " + Inventario + " " +
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
