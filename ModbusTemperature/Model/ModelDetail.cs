using Dapper;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTemperature.Model
{
    public class ModelDetail
    {
        
        public ModelDetail(string _serialNumber,double _temperature)
        {
            SerialNumber = _serialNumber;
            TemperatureData = _temperature;
        }
        public ModelDetail() { }
        public string SerialNumber { get; set; }
        public double TemperatureData { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.Now;

        // Metode untuk menyimpan data suhu ke database
        public static void SaveDataDetail(List<ModelDetail> details)
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataDetail (SerialNumber, TemperatureData, RecordedAt) " +
                               "VALUES (@SerialNumber, @TemperatureData, @RecordedAt)";
                connection.Execute(query, details);
            }
        }

        public static List<ModelDetail> GetModelDetailsBySerialNumber(string serialNumber)
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = @"SELECT SerialNumber,TemperatureData,RecordedAt FROM TemperatureDataDetail where SerialNumber=@SerialNumber";
                return connection.Query<ModelDetail>(query, new { SerialNumber = serialNumber }).ToList();
            }
        }
        public void SaveDataDetail()
        {
            using (var connection = ConfigDB.GetConnection())
            {
                string query = "INSERT INTO TemperatureDataDetail (SerialNumber, TemperatureData, RecordedAt) " +
                               "VALUES (@SerialNumber, @TemperatureData, @RecordedAt)";
                connection.Execute(query, this);
            }
        }
    }
}
