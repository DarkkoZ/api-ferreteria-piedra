using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioListar
    {
        private readonly ConexionDB _conexionDB;

        public csUsuarioListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public DataSet listarUsuarios()
        {
            DataSet dsi = new DataSet();
            SqlConnection con = _conexionDB.ObtenerConexion();
            con.Open();

            try
            {
                string cadena = "SELECT * FROM Usuario";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";
                return dsi;
            }
            catch (Exception ex)
            {

                return null;

            }

        }
    }
}
