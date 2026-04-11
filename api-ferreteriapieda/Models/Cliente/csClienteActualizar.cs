using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteActualizar
    {
        public ResponseCliente actualizarCliente(string IdNit, string Nombre, string Direccion, string Telefono, string Correo)
        {
            ResponseCliente result = new ResponseCliente();
            SqlConnection con = null;

            try
            {
                string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
                con = new SqlConnection(conexion);
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
