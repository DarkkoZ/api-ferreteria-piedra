using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Factura.csFactura;

namespace api_ferreteriapieda.Models.Factura
{
    public class csFacturaEliminar
    {
        public ResponseFactura eliminarFactura(int IdFactura)
        {
            ResponseFactura result = new ResponseFactura();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";

                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM Factura WHERE IdFactura = " + IdFactura;
                
                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Factura eliminada correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró la Factura";
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
