using Microsoft.Data.SqlClient;
using ModbusTemperature.Model;
using ModbusTemperature.Utility;
using NModbus;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ModbusTemperature
{
    public partial class Form2 : Form
    {

        private System.Windows.Forms.Timer temperatureTimer;
        private ModelMaster[] masterModels;
        private ModbusFactory factory = new ModbusFactory();
        string badgeId = string.Empty;
        bool isReading = false;
        bool _startRunning = false;
        int interval = 1000;

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
        void setChartSerialNumberTitle(ModelMaster master)
        {
            chart1.Titles[0].Text = "Temperature Data, Serial Number: " + (master.SerialNumber + " " + master.RecordedAt.ToString("yyyy"));
            chart1.Invalidate();
        }
        void loadChartByMasterModel(ModelMaster _masterModel)
        {
            var details = ModelDetail.GetModelDetailsBySerialNumber(_masterModel.SerialNumber);
            startTime = details.First().RecordedAt;
            endTime = details.Last().RecordedAt;
            label10.Text = $"date :  {startTime.ToString("yyyy MMM dd")}";
            label11.Text = $"Start Running : {startTime.ToString("HH:mm:ss")}";
            label12.Text = $"Estimation Stop  : {endTime.ToString("HH:mm:ss")}";
            setupChart(details, masterModels[0]);
            LoadChartPoints(details);
            
        }
        void LoadChartPoints(List<ModelDetail> details)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < details.Count; i++)
            {
                DataPoint point = new DataPoint();
                chart1.Series[0].Points.AddXY(details[i].RecordedAt, details[i].TemperatureData);
                if ((details.Count < 60) || (details.Count >= 60 && details.Count < 3600 && details[i].RecordedAt.Second == 0) || (details.Count >= 3600 && details[i].RecordedAt.Minute == 0 && details[i].RecordedAt.Second == 0))
                    chart1.Series[0].Points.Last().Label = details[i].TemperatureData.ToString("0.00") + " *C - " + details[i].RecordedAt.ToString("HH:mm:ss");
            }
        }
        public Form2(ModelMaster[] _masterModels, string _badgeId,int _interval, bool startRunning)
        {
            interval = _interval;
            _startRunning  = startRunning;
            temperatureTimer = new System.Windows.Forms.Timer();
            badgeId = _badgeId;
            masterModels = _masterModels;
            InitializeComponent();
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            label3.Text = $"User Id :  {badgeId}";
            var serialLabels = getSerialLables();
            for (int i = 0; i < serialLabels.Length; i++)
            {
                serialLabels[i].Text = masterModels.Length > i ? masterModels[i].SerialNumber : "";
            }
            if (!startRunning)
            {
                loadChartByMasterModel(masterModels[0]);
                return;
            }
            temperatureTimer.Interval = interval;
            temperatureTimer.Tick += TemperatureTimer_Tick;
            startTime = DateTime.Now;
            endTime = startTime.AddMinutes(2);
            StartReadingTemperature();
            label10.Text = $"date :  {startTime.ToString("yyyy MMM dd")}";
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
                //                details = details.TakeLast(10).ToList();
                LoadDataDetailToChart(details,masterModels.First());
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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            temperatureTimer.Stop();
            base.OnFormClosed(e);
        }
        // Fungsi konversi nilai register ke suhu
        private double ConvertRegisterToTemperature(ushort registerValue)
        {
            // Contoh konversi, disesuaikan dengan format data perangkat
            return registerValue * 0.1; // Misalnya skala nilai register dengan faktor 0.1 menjadi °C
        }
        void setupChart(List<ModelDetail> details,ModelMaster master)
        {

            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0.00} °C";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:sss";
            chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Titles[0].Text = "Temperature Data, Serial Number: " + (master.SerialNumber + " " + master.RecordedAt.ToString("yyyy"));
            if (details.Count > 60)
            {
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart1.ChartAreas[0].AxisX.Interval = 1;
                //               chart1.ChartAreas[0].AxisX.Minimum = startTime.ToOADate();
                //               chart1.ChartAreas[0].AxisX.Maximum = startTime.AddHours(8).ToOADate();
            }
            else
            {
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
                chart1.ChartAreas[0].AxisX.Interval = 1;
                //                chart1.ChartAreas[0].AxisX.Minimum = startTime.ToOADate();
                //                chart1.ChartAreas[0].AxisX.Maximum = startTime.AddMinutes(60).ToOADate();
            }
        }
        private void LoadDataDetailToChart(List<ModelDetail> dataDetails,ModelMaster master)
        {
            var details = dataDetails;
            setupChart(details,master);
            LoadChartPoints(details);
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


                var dt = ModelDetail.GetModelDetailsBySerialNumber(masterModels[0].SerialNumber);
                SaveDataPDF(dt);
            }
        }
        List<List<ModelDetail>> GroupingDataByTime(List<ModelDetail> dataDetails)
        {
            string dateFormat = dataDetails.Count <= 60 ? "yyyy-MM-dd HH:mm:00" : "yyyy-MM-dd HH:00:00";
            var dataGroup = dataDetails.GroupBy(x => x.RecordedAt.ToString(dateFormat));
            return dataGroup.Select(x=>x.ToList()).ToList();
        }
        void SaveDataPDF(List<ModelDetail> _dt)
        {
            setChartSerialNumberTitle(masterModels[0]);
            var groupedData = GroupingDataByTime(_dt);
            string[] sourceImages = new string[groupedData.Count];
            for (int i = 0; i < groupedData.Count; i++)
            {
                string imgPath = sourceImages[i] = Path.Combine(AppContext.BaseDirectory, $"{masterModels[0].SerialNumber}-{i}.jpg");
                setupChart(groupedData[i], masterModels[0]);
                LoadChartPoints(groupedData[i]);
                if (File.Exists(imgPath))
                    File.Delete(imgPath);

                chart1.SaveImage(Path.Combine(AppContext.BaseDirectory, $"{masterModels[0].SerialNumber}-{i}.jpg"), ChartImageFormat.Jpeg);

            }
            PDFUtility.MasterModelToPDF(sourceImages, Path.Combine(AppContext.BaseDirectory, $"{masterModels[0].badgeId}_{masterModels[0].RecordedAt.ToString("yyyy-MM-dd")}.pdf"));
            for (int i = 0; i < sourceImages.Length; i++)
                File.Delete(sourceImages[i]);
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = ModelDetail.GetModelDetailsBySerialNumber(masterModels[0].SerialNumber);
            setChartSerialNumberTitle(masterModels[0]);
            SaveDataPDF(dt);
            loadChartByMasterModel(masterModels[0]);

        }
    }
}
