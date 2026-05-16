using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Usuario.csUsuario;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csUsuarioActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseUsuario actualizarUsuario(string IdUsuario, string IdNit, int IdEmpleado, string Password, string Direccion, string Telefono, string Correo)
        {
            ResponseUsuario result = new ResponseUsuario();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "UPDATE Usuario SET " +
                    "IdNit = '" + IdNit + "', " +
                    "IdEmpleado = " + IdEmpleado + ", " +
                    "Password = '" + Password + "', " +
                    "Direccion = '" + Direccion + "', " +
                    "Telefono = '" + Telefono + "', " +
                    "Correo = '" + Correo + "' " +
                    "WHERE IdUsuario = '" + IdUsuario + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario Actualizado Exitosamente";
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
