using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.FormasDePago.csFormasDePago;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePagoEliminar
    {
        public ResponseFormasDePago eliminarFormasDePago(int IdPago)
        {
            ResponseFormasDePago result = new ResponseFormasDePago();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM FormasdePago WHERE IdPago = " + IdPago;

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Forma de Pago eliminada correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró la Forma de Pago";
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
