using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteEliminar
    {
        private readonly ConexionDB _conexionDB;

        public csClienteEliminar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseCliente eliminarCliente(string IdNit)
        {
            ResponseCliente result = new ResponseCliente();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
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
