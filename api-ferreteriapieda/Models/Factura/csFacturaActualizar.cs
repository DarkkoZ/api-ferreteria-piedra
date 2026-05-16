using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Factura.csFactura;

namespace api_ferreteriapieda.Models.Factura
{
    public class csFacturaActualizar
    {
        public ResponseFactura actualizarFactura(int IdFactura, int IdEmpleado, string IdNit, int IdPago, float Monto_Total)
        {
            ResponseFactura result = new ResponseFactura();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
                con.Open();

                string MontoTotal = Monto_Total.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string cadena = "UPDATE Factura SET " +
                    "IdEmpleado = " + IdEmpleado + ", " +
                    "IdNit = '" + IdNit + "', " +
                    "IdPago = " + IdPago + ", " +
                    "Monto_Total = " + MontoTotal + " " +
                    "WHERE IdFactura = " + IdFactura + " ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Factura Actualizada Exitosamente";
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
