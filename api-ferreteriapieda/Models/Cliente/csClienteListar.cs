using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Cliente
{
    public class csClienteListar
    {
        public DataSet listarClientes()
        {
            DataSet dsi = new DataSet();
            string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(conexion);
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
