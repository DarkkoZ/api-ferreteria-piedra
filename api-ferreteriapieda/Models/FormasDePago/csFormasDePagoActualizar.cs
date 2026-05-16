using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.FormasDePago.csFormasDePago;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePagoActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csFormasDePagoActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public ResponseFormasDePago actualizarFormasDePago(int IdPago, string Tipo_Tarjeta, string Visa_Cuotas, string Tarjeta_Debito_Credito)
        {
            ResponseFormasDePago result = new ResponseFormasDePago();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "UPDATE FormasdePago SET " +
                "Tipo_Tarjeta = '" + Tipo_Tarjeta + "', " +
                "Visa_Cuotas = '" + Visa_Cuotas + "', " +
                "Tarjeta_Debito_Credito = '" + Tarjeta_Debito_Credito + "' " +
                "WHERE IdPago = " + IdPago + " ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Forma de Pago Actualizada Exitosamente";
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
