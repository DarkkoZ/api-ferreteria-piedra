using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using System.Data;
using static api_ferreteriapieda.Models.Empleado.csEmpleado;

namespace api_ferreteriapieda.Models.Empleado
{
    public class csEmpleadoListar
    {
        private readonly ConexionDB _conexionDB;

        public csEmpleadoListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public DataSet listarEmpleados()
        {
            DataSet dsi = new DataSet();
            SqlConnection con = _conexionDB.ObtenerConexion();
            con.Open();

            try
            {
                string cadena = "SELECT * FROM Empleado";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";
                return dsi;
            }
            catch (Exception ex) {

                return null;
            
            }

        }
    }
}
