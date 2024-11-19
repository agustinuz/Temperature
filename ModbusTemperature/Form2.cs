using Microsoft.Data.SqlClient;
using ModbusTemperature.Model;
using ModbusTemperature.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModbusTemperature
{
    public partial class Form2 : Form
    {

        private System.Windows.Forms.Timer temperatureTimer;
        private ModelMaster[] masterModels;
        string badgeId = string.Empty;
        bool isReading = false;
        private DateTime startTime;
        private DateTime endTime;
        private Label[] getSerialLables() => [
            label1,
            label2,
            label4,
            label5,
            label6,
            label7,
            label8,
            label9
        ];
        public Form2(ModelMaster[] _masterModels, string _badgeId)
        {
            badgeId = _badgeId;
            masterModels = _masterModels;
            InitializeComponent();
            label3.Text = $"User Id :  {badgeId}";
            var serialLabels = getSerialLables();
            for (int i = 0; i < serialLabels.Length; i++)
            {
                serialLabels[i].Text = masterModels.Length > i ? masterModels[i].SerialNumber : "";
            }
            temperatureTimer = new System.Windows.Forms.Timer();
            temperatureTimer.Interval = 1000;
            temperatureTimer.Tick += TemperatureTimer_Tick;
            startTime = DateTime.Now;
            endTime = startTime.AddHours(8);
            StartReadingTemperature();
            label10.Text = $"DATE {startTime.ToString("yyyy MMM dd")}";
            label11.Text = $"Start Running : {startTime.ToString("HH:mm:ss")}";
            label12.Text = $"Estimation Stop  : {endTime.ToString("HH:mm:ss")}";

        }

        private void StartReadingTemperature()
        {
            if (!isReading)
            {
                for (int i = 0; i < masterModels.Length; i++)
                    masterModels[i].SaveMaster();
                isReading = true;
                startTime = DateTime.Now;
                temperatureTimer.Start();
            }
        }
        private void ReadTemperature()
        {
            try
            {
                //using (SerialPort port = new("COM4"))
                //{
                //    port.BaudRate = 9600; // Sesuaikan dengan baud rate perangkat kamu
                //    port.DataBits = 8;
                //    port.Parity = Parity.None;
                //    port.StopBits = StopBits.One;
                //    port.Open();

                //    var master = factory.CreateRtuMaster(port);
                //    byte slaveAddress = 1; // ID Modbus perangkat PT100
                //    ushort startAddress = 0; // Alamat register pertama untuk suhu
                //    ushort numberOfPoints = 1;
                //    ushort[] response = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                //    double temperature = ConvertRegisterToTemperature(response[0]);


                //foreach (var serialNumber in masterModels)
                //{
                //    ModelDetail detail = new ModelDetail(serialNumber.SerialNumber, temperature);
                //    detail.SaveDataDetail();
                //}
                //var details = ModelDetail.GetModelDetailsBySerialNumber(masterModels.First().SerialNumber);
                //details = details.TakeLast(10).ToList();
                //LoadDataDetailToChart(details);
                //textBox3.Text = $"{temperature} °C";

                //    //Tampilkan suhu di kontrol TextBox atau Label
                //   ModelDetail detail = new ModelDetail(masterModel.SerialNumber, temperature);
                //    detail.SaveDataDetail();
                //    textBox3.Text = $"Temperature : {temperature} °C";
                //    //ModelTemperature.SaveTemperature(temperature);
                //}
                Random rnd = new Random();
                double temperature = rnd.NextDouble();
                temperature = temperature * 100;
                //Save temperature for each scanned SerialNumber

                foreach (var serialNumber in masterModels)
                {
                    ModelDetail detail = new ModelDetail(serialNumber.SerialNumber, temperature);
                    detail.SaveDataDetail();
                }
                var details = ModelDetail.GetModelDetailsBySerialNumber(masterModels.First().SerialNumber);
                details = details.TakeLast(10).ToList();
                LoadDataDetailToChart(details);
                //textBox3.Text = $"{temperature} °C";


                // Load the latest temperature data for the first SerialNumber
                //var details = ModelDetail.GetModelDetailsBySerialNumber(masterModels.First().SerialNumber);
                //details = details.TakeLast(10).ToList();
                //LoadDataDetailToChart(details);
                //textBox3.Text = $"{temperature} °C";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading temperature: {ex.Message}");
            }
        }
        // Fungsi konversi nilai register ke suhu
        private double ConvertRegisterToTemperature(ushort registerValue)
        {
            // Contoh konversi, disesuaikan dengan format data perangkat
            return (((double)registerValue) - 65400); // Misalnya skala nilai register dengan faktor 0.1 menjadi °C
        }
        private void LoadDataDetailToChart(List<ModelDetail> details)
        {
            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:sss";
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Titles[0].Text = "Temperature Data, Serial Number: " + (details.Any() ? details.First().SerialNumber + " " + details.First().RecordedAt.ToString("yyyy") : "None");
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < details.Count; i++)
            {
                DataPoint point = new DataPoint();
                chart1.Series[0].Points.AddXY(details[i].RecordedAt, details[i].TemperatureData);
                chart1.Series[0].Points.Last().Label = details[i].TemperatureData + " *C - " + details[i].RecordedAt.ToString("HH:mm:ss");
            }
        }

        private void TemperatureTimer_Tick(object? sender, EventArgs e)
        {
            ReadTemperature();
            string[] pathNames = new string[masterModels.Length];
            //Stop reading after 1 minute
            if (endTime <= DateTime.Now)
            {
                temperatureTimer.Stop();
                isReading = false;
                MessageBox.Show("Temperature reading has been automatically stopped after 1 minute.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string imgPath = Path.Combine(AppContext.BaseDirectory, "chart1.jpg");
                if (File.Exists(imgPath))
                    File.Delete(imgPath);
                chart1.SaveImage(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), ChartImageFormat.Jpeg);
                PDFUtility.ImageToPdf(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), "pdf1.pdf");
                this.Close();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
