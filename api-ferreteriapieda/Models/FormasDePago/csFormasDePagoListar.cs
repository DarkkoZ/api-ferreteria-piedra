using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api_ferreteriapieda.Models.FormasDePago
{
    public class csFormasDePagoListar
    {
        private readonly ConexionDB _conexionDB;

        public csFormasDePagoListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public DataSet listarFormasDePago()
        {
            DataSet dsi = new DataSet();
            SqlConnection con = _conexionDB.ObtenerConexion();
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
