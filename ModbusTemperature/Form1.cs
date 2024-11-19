using NModbus.Device;
using ModbusTemperature.Model;
using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ModbusTemperature.Utility;

namespace ModbusTemperature
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer temperatureTimer;
        private bool isReading = false;
        private DateTime startTime;
        private List<ModelMaster> masterModels = new();
        private string badgeId = string.Empty;
        private ModbusFactory factory = new ModbusFactory();
        public Form1()
        {
            InitializeComponent();
            temperatureTimer = new System.Windows.Forms.Timer();
            temperatureTimer.Interval = 1000;
            temperatureTimer.Tick += TemperatureTimer_Tick;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLastTemperatureDataByScanCode();
        }
        void LoadLastTemperatureDataByScanCode()
        {
            var detail = ModelMaster.GetLastTemperatureDataByScanCodeTime();
            LoadDataDetailToChart(detail);
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
                chart1.Series[0].Points.AddXY(details[i].RecordedAt, details[i].TemperatureData );
                chart1.Series[0].Points.Last().Label = details[i].TemperatureData + " *C - " + details[i].RecordedAt.ToString("HH:mm:ss");
            }
        }
        private void TemperatureTimer_Tick(object? sender, EventArgs e)
        {
            ReadTemperature();
            //Stop reading after 1 minute
            if (startTime.AddSeconds(10) <= DateTime.Now)
            { 
                if (temperatureTimer.Interval >= 50000)
                {
                    temperatureTimer.Stop();
                    isReading = false;
                    MessageBox.Show("Temperature reading has been automatically stopped after 1 minute.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string imgPath = Path.Combine(AppContext.BaseDirectory, "chart1.jpg");
                    if (File.Exists(imgPath))
                        File.Delete(imgPath);
                    chart1.SaveImage(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), ChartImageFormat.Jpeg);
                    PDFUtility.ImageToPdf(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), "pdf1.pdf");
                }
                else
                {

                    temperatureTimer.Stop();
                    isReading = false;
                    string imgPath = Path.Combine(AppContext.BaseDirectory, "chart1.jpg");
                    if (File.Exists(imgPath))
                        File.Delete(imgPath);
                    chart1.SaveImage(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), ChartImageFormat.Jpeg);
                    PDFUtility.ImageToPdf(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), "pdf1.pdf");
                }
            }

        }
        private void StartReadingTemperature()
        {
            if (!isReading)
            {
                isReading = true;
                startTime = DateTime.Now;
                temperatureTimer.Start();
            }
        }

        private void ReadTemperature()
        {
            try
            {
                using (SerialPort port = new("COM4"))
                {
                    port.BaudRate = 9600; // Sesuaikan dengan baud rate perangkat kamu
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.Open();

                    var master = factory.CreateRtuMaster(port);
                    byte slaveAddress = 1; // ID Modbus perangkat PT100
                    ushort startAddress = 0; // Alamat register pertama untuk suhu
                    ushort numberOfPoints = 1;
                    ushort[] response = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                    double temperature = ConvertRegisterToTemperature(response[0]);


                    foreach (var serialNumber in masterModels)
                    {
                        ModelDetail detail = new ModelDetail(serialNumber.SerialNumber, temperature);
                        detail.SaveDataDetail();
                    }
                    var details = ModelDetail.GetModelDetailsBySerialNumber(masterModels.First().SerialNumber);
                    details = details.TakeLast(10).ToList();
                    LoadDataDetailToChart(details);
                    textBox3.Text = $"{temperature} °C";

                    //    //Tampilkan suhu di kontrol TextBox atau Label
                    //   ModelDetail detail = new ModelDetail(masterModel.SerialNumber, temperature);
                    //    detail.SaveDataDetail();
                    //    textBox3.Text = $"Temperature : {temperature} °C";
                    //    //ModelTemperature.SaveTemperature(temperature);
                }
                //    Random rnd = new Random();
                //double temperature = rnd.NextDouble();
                //temperature = temperature * 100;
                // Save temperature for each scanned SerialNumber
                
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
            return (double)(Convert.ToDouble((registerValue).ToString())/2180) ; // Misalnya skala nilai register dengan faktor 0.1 menjadi °C
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (!isReading)
        //    {
        //        // Mulai pembacaan suhu setiap detik
        //        isReading = false;
        //        temperatureTimer.Start();
        //        button1.Text = "Stop Reading";
        //    }
        //    else
        //    {

        //    }
        //}


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (masterModels.Count < 8)
                {
                    // When Serial Number is scanned, add it to the list and save the master data
                    ModelMaster masterModel = new ModelMaster();
                    masterModel.SerialNumber = textBox2.Text;
                    masterModel.badgeId = badgeId;
                    masterModels.Add(masterModel);
                    textBox2.Clear();
                    label1.Text = "Badge ID: " + "\n -"+ badgeId + "\n Serial Numbers: " + "\n -" + string.Join("\n -", masterModels.Select(x => x.SerialNumber).ToList());

                    // If the limit of 8 serial numbers is reached, stop reading the temperature
                    var result = MessageBox.Show("Tambah Serial Number lagi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        foreach (var _masterModel in masterModels)
                        {
                            _masterModel.SaveMaster();
                        }
                        StartReadingTemperature();
                    }
                }
                else
                {
                    MessageBox.Show("Harap input minimal 1 Serial Number.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                temperatureTimer.Stop();
                badgeId = textBox1.Text;
                textBox2.Focus();
                textBox1.Clear();
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
