using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaActualizar
    {
        public ResponseDetalleFactura actualizarDetalleFactura(int IdDetalleFacturacion, int IdFactura, string IdProducto, int Cantidad, float Precio_Unitario)
        {
            ResponseDetalleFactura result = new ResponseDetalleFactura();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
                con = new SqlConnection(conexion);
                con.Open();

                string PrecioUnitarioStr = Precio_Unitario.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string cadena = "UPDATE DetalledeFacturacion SET " +
                    "IdFactura = " + IdFactura + ", " +
                    "IdProducto = '" + IdProducto + "', " +
                    "Cantidad = " + Cantidad + ", " +
                    "Precio_Unitario = " + PrecioUnitarioStr + " " +
                    "WHERE IdDetalleFacturacion = " + IdDetalleFacturacion + " ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Detalle de Factura Actualizado Exitosamente";
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
