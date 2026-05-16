using System;
using System.Linq.Expressions;
using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.Empleado.csEmpleado;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csEmpleadoActualizar
    {
        private readonly ConexionDB _conexionDB;

        public csEmpleadoActualizar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public ResponseEmpleado actualizarEmpleado(int idEmpleado, string Nombre, string Direccion, string Telefono, string Correo)
        {
            ResponseEmpleado result = new ResponseEmpleado();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                
                con.Open();

                string cadena = "UPDATE Empleado SET " +
                "Nombre = '" + Nombre + "', " +
                "Direccion = '" + Direccion + "', " +
                "Telefono = '" + Telefono + "', " +
                "Correo = '" + Correo + "' " +
                "WHERE IdEmpleado = " + idEmpleado + " ";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Empleado Actualizado Exitosamente";
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
