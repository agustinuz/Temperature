using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusTemperature
{
    public partial class Form3 : Form
    {
        private int interval = 1000;

        // Properti untuk akses global
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }
        public Form3()
        {
            InitializeComponent();
            comboBox3.Items.AddRange(new object[]
        {
            "1 Second",
            "1 Minute",
            "5 Minutes",
            "30 Minutes",
            "1 Hour"
        });
            int savedInterval = Properties.Settings.Default.TimerIntervalSetting;
            SetComboBoxSelection(savedInterval);
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //comboBox3.SelectedIndex = -1;
            // Memastikan ComboBox memiliki indeks yang dipilih sesuai setting yang disimpan
            int savedInterval = Properties.Settings.Default.TimerIntervalSetting;
            SetComboBoxSelection(savedInterval);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem?.ToString())
            {
                case "1 Second":
                    interval = 1000;
                    break;
                case "1 Minute":
                    interval = 1 * 60 * 1000;
                    break;
                case "5 Minutes":
                    interval = 5 * 60 * 1000;
                    break;
                case "30 Minutes":
                    interval = 30 * 60 * 1000;
                    break;
                case "1 Hour":
                    interval = 60 * 60 * 1000;
                    break;
                case "2 Hours":
                    interval = 2 * 60 * 60 * 1000;
                    break;
                default:
                    interval = 1000;
                    break;
            }
            // Simpan pengaturan interval ke Settings
            Properties.Settings.Default.TimerIntervalSetting = Interval;
            Properties.Settings.Default.Save();
            MessageBox.Show(
                            $"Timer interval set to {comboBox3.SelectedItem}",
                            "Timer Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
        }
        private void SetComboBoxSelection(int interval)
        {
            // Menyusun interval yang disimpan ke dalam ComboBox yang sesuai
            if (interval == 1000) comboBox3.SelectedIndex = 0;
            else if (interval == 1 * 60 * 1000) comboBox3.SelectedIndex = 1;
            else if (interval == 5 * 60 * 1000) comboBox3.SelectedIndex = 2;
            else if (interval == 30 * 60 * 1000) comboBox3.SelectedIndex = 3;
            else if (interval == 60 * 60 * 1000) comboBox3.SelectedIndex = 4;
            else if (interval == 2 * 60 * 60 * 1000) comboBox3.SelectedIndex = 5;
            else comboBox3.SelectedIndex = -1; // default if no match
        }
    }
}
