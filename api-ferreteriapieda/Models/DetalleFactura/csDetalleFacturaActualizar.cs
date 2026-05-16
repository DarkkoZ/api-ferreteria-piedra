using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csDetalleFacturaActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseDetalleFactura actualizarDetalleFactura(int IdDetalleFacturacion, int IdFactura, string IdProducto, int Cantidad, float Precio_Unitario)
        {
            ResponseDetalleFactura result = new ResponseDetalleFactura();
            SqlConnection con = null;

            //Implementacion de Azure
            try
            {
                con = _conexionDB.ObtenerConexion();
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
