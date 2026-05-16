using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csDetalleFacturaInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseDetalleFactura insertarDetalleFactura(int IdFactura, string IdProducto, int Cantidad, float Precio_Unitario)
        {
            ResponseDetalleFactura result = new ResponseDetalleFactura();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();


                string PrecioUnitario = Precio_Unitario.ToString(System.Globalization.CultureInfo.InvariantCulture);


                string cadena = "INSERT INTO DetalledeFacturacion(IdFactura,IdProducto,Cantidad,Precio_Unitario) VALUES " +
                    "(" + IdFactura + ", '" + IdProducto + "', " + Cantidad + ", " + PrecioUnitario + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Detalle de Factura Insertado Correctamente";
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
