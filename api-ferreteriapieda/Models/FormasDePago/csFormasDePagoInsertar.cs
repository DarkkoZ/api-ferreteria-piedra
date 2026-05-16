using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.FormasDePago.csFormasDePago;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePagoInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csFormasDePagoInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseFormasDePago insertarFormaDePago(string Tipo_Tarjeta, string Visa_Cuotas, string Tarjeta_Debito_Credito)
        {
            ResponseFormasDePago result = new ResponseFormasDePago();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();



                string cadena = "INSERT INTO FormasdePago(Tipo_Tarjeta,Visa_Cuotas,Tarjeta_Debito_Credito) VALUES " +
                    "('" + Tipo_Tarjeta + "', '" + Visa_Cuotas + "', '" + Tarjeta_Debito_Credito + "') ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Forma de Pago Insertada Correctamente";
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
