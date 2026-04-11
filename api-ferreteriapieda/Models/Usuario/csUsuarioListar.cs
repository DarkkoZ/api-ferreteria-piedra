using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Usuario
{
    public class csUsuarioListar
    {
        public DataSet listarUsuarios()
        {
            DataSet dsi = new DataSet();
            string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(conexion);
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
