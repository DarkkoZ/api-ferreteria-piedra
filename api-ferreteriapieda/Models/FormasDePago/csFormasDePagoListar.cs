using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePagoListar
    {
        public DataSet listarFormasDePago()
        {
            DataSet dsi = new DataSet();
            string conexion = "Server=.\\SQLEXPRESS;Database=FerreteriaPiedra;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "SELECT * FROM FormasdePago";
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
