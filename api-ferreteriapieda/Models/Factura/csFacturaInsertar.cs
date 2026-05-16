using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Factura.csFactura;

namespace api_ferreteriapieda.Models.Factura
{
    public class csFacturaInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csFacturaInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseFactura insertarFactura(int IdEmpleado, string IdNit, int IdPago, float Monto_Total)
        {
            ResponseFactura result = new ResponseFactura();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();


                string MontoTotalStr = Monto_Total.ToString(System.Globalization.CultureInfo.InvariantCulture);
                

                string cadena = "INSERT INTO Factura(IdEmpleado,IdNit,IdPago,Monto_Total) VALUES " +
                    "(" + IdEmpleado + ", '" + IdNit + "', " + IdPago + ", " + MontoTotalStr + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Factura Insertada Correctamente";
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
