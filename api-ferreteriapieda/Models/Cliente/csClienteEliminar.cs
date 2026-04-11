using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteEliminar
    {
        public ResponseCliente eliminarCliente(string IdNit)
        {
            ResponseCliente result = new ResponseCliente();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM Cliente WHERE IdNit = '" + IdNit + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Cliente eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el Cliente";
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
