using Microsoft.Data.SqlClient;

namespace api_ferreteriapieda.Config
{
    public class ConexionDB
    {
        private readonly string _connectionString;

        public ConexionDB(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexionSQL");
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}