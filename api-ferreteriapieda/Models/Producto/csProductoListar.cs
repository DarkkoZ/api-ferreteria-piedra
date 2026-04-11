using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoListar
    {
        public DataSet listarProducto()
        {
            DataSet dsi = new DataSet();
            string conexion = "Server=tcp:ferreteriaserver.database.windows.net,1433;" +"Initial Catalog=FerreteriaPiedra;" +"Persist Security Info=False;" +"User ID=adminFerreteria;" +"Password=prograFerreteria09;" +"MultipleActiveResultSets=False;" +"Encrypt=True;" +"TrustServerCertificate=False;" +"Connection Timeout=300;";
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "SELECT * FROM Producto";
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
