using Microsoft.Data.SqlClient;
using System.Data;
using api_ferreteriapieda.Config;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaListar
    {
        private readonly ConexionDB _conexionDB;

        public csDetalleFacturaListar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public DataSet listarDetalleFacturas()
        {
            DataSet dsi = new DataSet();

            SqlConnection con = _conexionDB.ObtenerConexion();
            con.Open();

            try
            {
                string cadena = "SELECT * FROM DetalledeFacturacion";
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