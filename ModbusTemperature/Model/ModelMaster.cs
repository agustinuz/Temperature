using Dapper;


namespace ModbusTemperature.Model
{
    public class ModelMaster

    {
        // Assuming badgeId and SerialNumber are strings, but change this as needed
        public string badgeId { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public DateTime RecordedAt { get; set; } = DateTime.Now;

        // Metode untuk menyimpan data suhu ke database
        public static void SaveDataMaster(string badgeId, string SerialNumber)
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataMaster (badgeId, SerialNumber, RecordedAt) " +
                               "VALUES (@badgeId, @SerialNumber, @recordedAt)";
                // Assuming you want to record the time in RecordedAt field
                connection.Execute(query, new { badgeId, SerialNumber, recordedAt = DateTime.Now });
            }
        }
        public void SaveMaster()
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataMaster (badgeId, SerialNumber, RecordedAt) " +
                               "VALUES (@badgeId, @SerialNumber, @recordedAt)";
                // Assuming you want to record the time in RecordedAt field
                connection.Execute(query, this);
            }
        }
    }
}
