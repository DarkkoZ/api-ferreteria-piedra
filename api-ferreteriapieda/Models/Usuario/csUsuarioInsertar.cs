using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Usuario.csUsuario;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csUsuarioInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseUsuario insertarUsuario(string IdUsuario, string IdNit, int IdEmpleado, string Password, string Direccion, string Telefono, string Correo)
        {
            ResponseUsuario result = new ResponseUsuario();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "INSERT INTO Usuario(IdUsuario,IdNit,IdEmpleado,Password,Direccion,Telefono,Correo) VALUES " +
                    "('" + IdUsuario + "', '" + IdNit + "', " + IdEmpleado + ", '" + Password + "', '" + Direccion + "', '" + Telefono + "', '" + Correo + "') ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario Insertado Correctamente";
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
