using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Usuario.csUsuario;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioInsertar
    {
        public ResponseUsuario insertarUsuario(string IdUsuario, string IdNit, int IdEmpleado, string Password, string Direccion, string Telefono, string Correo)
        {
            ResponseUsuario result = new ResponseUsuario();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
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
