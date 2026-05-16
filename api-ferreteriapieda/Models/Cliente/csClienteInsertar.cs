using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Cliente.csCliente;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteInsertar
    {
        private readonly ConexionDB _conexionDB;

        public csClienteInsertar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseCliente insertarCliente(string IdNit,string Nombre, string Direccion, string Telefono, string Correo)
        {
            ResponseCliente result = new ResponseCliente();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "INSERT INTO Cliente(IdNit,Nombre,Direccion,Telefono,Correo) VALUES " +
                    "('" + IdNit + "', '" + Nombre + "', '" + Direccion + "', '" + Telefono + "', '" + Correo + "') ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Cliente Insertado Correctamente";
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
