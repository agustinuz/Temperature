using Dapper;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTemperature.Model
{
    internal class ModelDetail
    {
        
        public ModelDetail(string _serialNumber,double _temperature)
        {
            SerialNumber = _serialNumber;
            TemperatureData = _temperature;
        }
        public string SerialNumber { get; set; }
        public double TemperatureData { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.Now;

        // Metode untuk menyimpan data suhu ke database
        public static void SaveDataDetail(string SerialNumber, double temperature)
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataDetail (SerialNumber, TemperatureData, RecordedAt) " +
                               "VALUES (@SerialNumber, @TemperatureData @recordedAt)";
                // Assuming you want to record the time in RecordedAt field
                connection.Execute(query, new { SerialNumber, temperature, recordedAt = DateTime.Now });
            }
        }
        public void SaveDataDetail()
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataDetail (SerialNumber, TemperatureData, RecordedAt) " +
                               "VALUES (@SerialNumber, @TemperatureData @recordedAt)";
                // Assuming you want to record the time in RecordedAt field
                connection.Execute(query, this);
            }
        }
    }
}
