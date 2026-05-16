using api_ferreteriapieda.Config;
using Microsoft.Data.SqlClient;
using static api_ferreteriapieda.Models.DetalleFactura.csDetalleFactura;

namespace api_ferreteriapieda.Models.DetalleFactura
{
    public class csDetalleFacturaEliminar
    {
        private readonly ConexionDB _conexionDB;

        public csDetalleFacturaEliminar(ConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }
        public ResponseDetalleFactura eliminarDetalleFactura(int IdDetalleFacturacion)
        {
            ResponseDetalleFactura result = new ResponseDetalleFactura();
            SqlConnection con = null;

            try
            {
                con = _conexionDB.ObtenerConexion();
                con.Open();

                string cadena = "DELETE FROM DetalledeFacturacion WHERE IdDetalleFacturacion = " + IdDetalleFacturacion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Detalle de Factura eliminado correctamente";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "No se encontró el Detalle de Factura";
                }
            }
            catch (Exception ex)
            {
                result.respuesta = -1;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return result;
        }
    }
}
