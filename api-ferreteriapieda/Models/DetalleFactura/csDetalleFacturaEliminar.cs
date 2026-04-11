using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaEliminar
    {
        public ResponseDetalleFactura eliminarDetalleFactura(int IdDetalleFacturacion)
        {
            ResponseDetalleFactura result = new ResponseDetalleFactura();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM DetalledeFacturacion WHERE IdDetalleFacturacion = " + IdDetalleFacturacion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Detalle de Factura eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el Detalle de Factura";
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
