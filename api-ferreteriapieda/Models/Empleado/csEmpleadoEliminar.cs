using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Empleado.csEmpleado;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csEmpleadoEliminar
    {
        public ResponseEmpleado eliminarEmpleado(int idEmpleado)
        {
            ResponseEmpleado result = new ResponseEmpleado();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM Empleado WHERE IdEmpleado = " + idEmpleado;

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Empleado eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el empleado";
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
