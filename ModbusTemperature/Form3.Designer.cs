namespace ModbusTemperature
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            button1 = new Button();
            textBox2 = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(78, 31);
            label1.TabIndex = 0;
            label1.Text = "SETTING";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 42);
            label2.Name = "label2";
            label2.Size = new Size(82, 16);
            label2.TabIndex = 1;
            label2.Text = "Serial Port";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(12, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 245);
            panel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 180);
            label6.Name = "label6";
            label6.Size = new Size(89, 16);
            label6.TabIndex = 7;
            label6.Text = "Timer Tick";
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.Gainsboro;
            comboBox3.FlatStyle = FlatStyle.Popup;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(208, 173);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(145, 23);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 137);
            label4.Name = "label4";
            label4.Size = new Size(99, 16);
            label4.TabIndex = 5;
            label4.Text = "Temp Timer";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.Gainsboro;
            comboBox2.FlatStyle = FlatStyle.Popup;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(208, 130);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(145, 23);
            comboBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 89);
            label3.Name = "label3";
            label3.Size = new Size(41, 16);
            label3.TabIndex = 3;
            label3.Text = "Link";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLightLight;
            textBox1.Font = new Font("Simplex_IV25", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(208, 79);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 26);
            textBox1.TabIndex = 1;
            textBox1.Tag = "";
            textBox1.Text = "Masukan Link";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Gainsboro;
            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(208, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(145, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(587, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(445, 134);
            panel2.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(34, 42);
            button1.Name = "button1";
            button1.Size = new Size(96, 43);
            button1.TabIndex = 7;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlLightLight;
            textBox2.Font = new Font("Simplex_IV25", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(166, 51);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 26);
            textBox2.TabIndex = 6;
            textBox2.Tag = "";
            textBox2.Text = "Masukan BagdeId";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Agency FB", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(587, 69);
            label5.Name = "label5";
            label5.Size = new Size(154, 31);
            label5.TabIndex = 4;
            label5.Text = "CREATE EMPLOYEE";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 402);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox2;
        private Panel panel2;
        private Button button1;
        private TextBox textBox2;
        private Label label5;
        private Label label6;
        private ComboBox comboBox3;
    }
}