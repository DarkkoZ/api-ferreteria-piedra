using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csClienteActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public ResponseCliente actualizarCliente(string IdNit, string Nombre, string Direccion, string Telefono, string Correo)
        {


            ResponseCliente result = new ResponseCliente();
            SqlConnection con = null;

            try
            {
                
                con = _conexionDB.ObtenerConexion(); ;
                con.Open();

                string cadena = "UPDATE Cliente SET " +
                "Nombre = '" + Nombre + "', " +
                "Direccion = '" + Direccion + "', " +
                "Telefono = '" + Telefono + "', " +
                "Correo = '" + Correo + "' " +
                "WHERE IdNit = '" + IdNit + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Cliente Actualizado Exitosamente";
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
