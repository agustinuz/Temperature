namespace ModbusTemperature
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            button1 = new Button();
            panel5 = new Panel();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel6 = new Panel();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(0, 0);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Data Temperature";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series.Add(series1);
            chart1.Size = new Size(964, 616);
            chart1.TabIndex = 6;
            chart1.Text = "Chart Temperature Data";
            chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            title1.Name = "Title1";
            title1.Text = "Temperature Chart";
            chart1.Titles.Add(title1);
            chart1.Click += chart1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1248, 668);
            panel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(chart1);
            panel3.Location = new Point(243, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(964, 616);
            panel3.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel6);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(222, 668);
            panel2.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MistyRose;
            panel4.Controls.Add(label3);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(222, 83);
            panel4.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 35);
            label3.Name = "label3";
            label3.Size = new Size(131, 17);
            label3.TabIndex = 5;
            label3.Text = "User Id :  x x x x";
            // 
            // button1
            // 
            button1.Location = new Point(55, 562);
            button1.Name = "button1";
            button1.Size = new Size(91, 40);
            button1.TabIndex = 10;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.PeachPuff;
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label1);
            panel5.Location = new Point(0, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(222, 241);
            panel5.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(69, 201);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 13;
            label9.Text = "Serial 8";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(69, 173);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 12;
            label8.Text = "Serial 7";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(69, 146);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 11;
            label7.Text = "Serial 6";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(69, 120);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 10;
            label6.Text = "Serial 5";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(69, 93);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 9;
            label5.Text = "Serial 4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(69, 68);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 8;
            label4.Text = "Serial 3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 42);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 7;
            label2.Text = "Serial 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 18);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 6;
            label1.Text = "Serial 1";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Aqua;
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(label10);
            panel6.Location = new Point(0, 322);
            panel6.Name = "panel6";
            panel6.Size = new Size(222, 201);
            panel6.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Lucida Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(33, 126);
            label12.Name = "label12";
            label12.Size = new Size(157, 18);
            label12.TabIndex = 16;
            label12.Text = "Estimation Stop  : ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(55, 68);
            label11.Name = "label11";
            label11.Size = new Size(126, 17);
            label11.TabIndex = 15;
            label11.Text = "Start Running : ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(79, 13);
            label10.Name = "label10";
            label10.Size = new Size(64, 17);
            label10.TabIndex = 14;
            label10.Text = "DATE : ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 668);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Panel panel1;
        private Panel panel4;
        private Label label3;
        private Panel panel3;
        private Panel panel2;
        private Button button1;
        private Panel panel5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Panel panel6;
        private Label label12;
        private Label label11;
        private Label label10;
    }
}