using Microsoft.Data.SqlClient;

namespace ModbusTemperature
{
    internal class ConfigDB
    {
        private static readonly string connectionString = "Server=localhost;Database=temperature;Integrated Security=true;TrustServerCertificate=false;Encrypt=false";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
    
};
