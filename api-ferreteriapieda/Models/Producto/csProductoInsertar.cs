using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Producto.csProducto;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csProductoInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseProducto insertarProducto(string IdProducto, string Nombre, string Descripcion, float Precio, int Inventario, int Oferta)
        {
            ResponseProducto result = new ResponseProducto();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();


                string precioStr = Precio.ToString(System.Globalization.CultureInfo.InvariantCulture);
                Nombre = Nombre.Replace("'", "''");
                Descripcion = Descripcion.Replace("'", "''");
                IdProducto = IdProducto.Replace("'", "''");

                string cadena = "INSERT INTO Producto(IdProducto,Nombre,Descripcion,Precio,Inventario,Oferta) VALUES " +
                    "('" + IdProducto + "', '" + Nombre + "', '" + Descripcion + "', " + precioStr + ", " + Inventario + ", " + Oferta + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Producto Insertado Correctamente";
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
