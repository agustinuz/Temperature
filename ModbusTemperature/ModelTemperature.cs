using Dapper;

namespace ModbusTemperature
{
    public class ModelTemperature
    {
        public double TemperatureValue { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.Now;

        // Metode untuk menyimpan data suhu ke database
        public static void SaveTemperature(double temperature)
        {
            using (var connection = ConfigDB.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO TemperatureData (TemperatureValue) VALUES (@TemperatureValue)";
                connection.Execute(query, new { TemperatureValue = temperature });
            }
        }
    }
}