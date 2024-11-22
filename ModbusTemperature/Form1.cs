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
        private string[] GetSerialNumbersFromTextboxes()
        {
            return [
                textBox4.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text,
                textBox11.Text,
                textBox12.Text,
            ];
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
            //chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:sss";
            //chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            //chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            //chart1.Titles[0].Text = "Temperature Data, Serial Number: " + (details.Any() ? details.First().SerialNumber + " " + details.First().RecordedAt.ToString("yyyy") : "None");
            //chart1.Series[0].Points.Clear();
            //for (int i = 0; i < details.Count; i++)
            //{
            //    DataPoint point = new DataPoint();
            //    chart1.Series[0].Points.AddXY(details[i].RecordedAt, details[i].TemperatureData);
            //    chart1.Series[0].Points.Last().Label = details[i].TemperatureData + " *C - " + details[i].RecordedAt.ToString("HH:mm:ss");
            //}
        }
        private void TemperatureTimer_Tick(object? sender, EventArgs e)
        {
            //            ReadTemperature();
            string[] pathNames = new string[masterModels.Count];
            //Stop reading after 1 minute
            if (startTime.AddMinutes(1) <= DateTime.Now)
            {
                temperatureTimer.Stop();
                isReading = false;
                MessageBox.Show("Temperature reading has been automatically stopped after 1 minute.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //string imgPath = Path.Combine(AppContext.BaseDirectory, "chart1.jpg");
                //if (File.Exists(imgPath))
                //    File.Delete(imgPath);
                //chart1.SaveImage(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), ChartImageFormat.Jpeg);
                //PDFUtility.ImageToPdf(Path.Combine(AppContext.BaseDirectory, "chart1.jpg"), "pdf1.pdf");
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            string[] serials = GetSerialNumbersFromTextboxes();
            for (int i = 0; i < serials.Length; i++)
            {
                if (serials[i] != "")
                {
                    var masterModel = new ModelMaster();
                    masterModel.SerialNumber = serials[i];
                    masterModel.badgeId = badgeId;
                    masterModels.Add(masterModel);
                }
            }
            Form2 frm = new Form2(masterModels.ToArray(), badgeId,true);
            frm.Show();
            masterModels.Clear();
            badgeId = "";
            ClearTextboxes();
        }

        private void serialInputDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            Control ctrl = (Control)sender;
            int nextControls = ctrl.TabIndex >= 9 ? 2 : ctrl.TabIndex + 1;
            panel3.Controls.OfType<TextBox>().Where(x => x.TabIndex == nextControls).First().Focus();
            e.SuppressKeyPress = true;
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                badgeId = textBox13.Text;
                // Validasi apakah badgeId sudah ada di database
                if (!ModelMaster.IsBadgeIdExists(badgeId))
                {
                    // Tampilkan pesan peringatan jika Badge ID tidak ditemukan
                    MessageBox.Show(
                        "Badge ID tidak ditemukan. Silakan periksa kembali.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    // Kosongkan textbox Badge ID untuk input ulang
                    textBox13.Clear();
                    return;
                }
                panel3.Controls.OfType<TextBox>().Where(x => x.TabIndex == 2).First().Focus();
                e.SuppressKeyPress = true;
            }

        }
        private void ClearTextboxes()
        {
            // Kosongkan Badge ID textbox
            textBox13.Text = "";

            // Kosongkan semua textboxes untuk serial numbers (TabIndex terkait)
            foreach (var textBox in panel3.Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lastMasterData = ModelMaster.GetLastMasterDataByScanCodeTime();
            if (lastMasterData is null)
            {
                MessageBox.Show("No Data Found");
                return;
            }
            Form2 frm = new Form2([lastMasterData], lastMasterData?.badgeId ?? "",false);
            frm.Show();
            
        }
    }

}
