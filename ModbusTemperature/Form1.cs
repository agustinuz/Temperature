using Modbus.Device;
using ModbusTemperature.Model;
using System.IO.Ports;


namespace ModbusTemperature
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer temperatureTimer;
        private bool isReading = false;
        private ModelMaster masterModel = new ModelMaster();
        public Form1()
        {
            InitializeComponent();
            temperatureTimer = new System.Windows.Forms.Timer();
            temperatureTimer.Interval = 1000;
            temperatureTimer.Tick += TemperatureTimer_Tick;
              
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TemperatureTimer_Tick(object? sender, EventArgs e)
        {
            ReadTemperature();
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

                    var master = ModbusSerialMaster.CreateRtu(port);
                    byte slaveAddress = 1; // ID Modbus perangkat PT100
                    ushort startAddress = 0; // Alamat register pertama untuk suhu
                    ushort numberOfPoints = 1;

                    ushort[] response = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                    double temperature = ConvertRegisterToTemperature(response[0]);

                    //Tampilkan suhu di kontrol TextBox atau Label
                   ModelDetail detail = new ModelDetail(masterModel.SerialNumber, temperature);
                    detail.SaveDataDetail();
                    textBox3.Text = $"Temperature : {temperature} °C";
                    //ModelTemperature.SaveTemperature(temperature);
                }
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
            return registerValue * 0.1; // Misalnya skala nilai register dengan faktor 0.1 menjadi °C
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!isReading)
            {
                // Mulai pembacaan suhu setiap detik
                isReading = true;
                temperatureTimer.Start();
                button1.Text = "Stop Reading";
            }
            else
            {
                // Berhenti membaca suhu
                isReading = false;
                temperatureTimer.Stop();
                button1.Text = "Start Reading";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                masterModel.SerialNumber = textBox2.Text;
                masterModel.SaveMaster();
                temperatureTimer.Start();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                masterModel.badgeId = textBox1.Text;
                textBox2.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
