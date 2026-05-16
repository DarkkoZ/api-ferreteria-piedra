using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteListar
    {
        private readonly ConexionDB _conexionDB;

        public csClienteListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public DataSet listarClientes()
        {
            DataSet dsi = new DataSet();
            SqlConnection con = _conexionDB.ObtenerConexion();
            con.Open();

            try
            {
                string cadena = "SELECT * FROM Cliente";
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
