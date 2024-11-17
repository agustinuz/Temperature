﻿using Dapper;


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
        public static List<ModelDetail> GetLastTemperatureDataByScanCodeTime()
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = @"SELECT badgeId,SerialNumber,RecordedAt
                                    FROM [TemperatureDataMaster] order by recordedAt Desc";
                // Assuming you want to record the time in RecordedAt field
                var dataMaster = connection.Query<ModelMaster>(query).FirstOrDefault();
                if (dataMaster is null)
                    return new List<ModelDetail>();
                query = @"SELECT SerialNumber,TemperatureData,RecordedAt FROM TemperatureDataDetail where SerialNumber=@SerialNumber";
                return connection.Query<ModelDetail>(query,new { SerialNumber=dataMaster.SerialNumber}).ToList();
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
