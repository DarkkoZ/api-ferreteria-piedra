using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.Producto
{
    public class csProductoListar
    {
        private readonly ConexionDB _conexionDB;

        public csProductoListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public DataSet listarProducto()
        {
            DataSet dsi = new DataSet();
            SqlConnection con = _conexionDB.ObtenerConexion();
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
