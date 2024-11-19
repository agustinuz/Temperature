namespace ModbusTemperature
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel3 = new Panel();
            textBox10 = new TextBox();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            label6 = new Label();
            label7 = new Label();
            textBox13 = new TextBox();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(textBox10);
            panel3.Controls.Add(textBox9);
            panel3.Controls.Add(textBox8);
            panel3.Controls.Add(textBox7);
            panel3.Controls.Add(textBox6);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox11);
            panel3.Controls.Add(textBox12);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(textBox13);
            panel3.Location = new Point(453, 36);
            panel3.Name = "panel3";
            panel3.Size = new Size(351, 552);
            panel3.TabIndex = 11;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(30, 389);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(288, 29);
            textBox10.TabIndex = 9;
            textBox10.Tag = "8";
            textBox10.KeyDown += serialInputDown;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(30, 354);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(288, 29);
            textBox9.TabIndex = 8;
            textBox9.Tag = "7";
            textBox9.KeyDown += serialInputDown;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(30, 319);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(288, 29);
            textBox8.TabIndex = 7;
            textBox8.Tag = "6";
            textBox8.KeyDown += serialInputDown;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(30, 283);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(288, 29);
            textBox7.TabIndex = 6;
            textBox7.Tag = "5";
            textBox7.KeyDown += serialInputDown;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(30, 249);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(288, 29);
            textBox6.TabIndex = 5;
            textBox6.Tag = "4";
            textBox6.KeyDown += serialInputDown;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(30, 249);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(288, 29);
            textBox5.TabIndex = 7;
            textBox5.KeyDown += serialInputDown;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(30, 214);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(288, 29);
            textBox4.TabIndex = 4;
            textBox4.Tag = "3";
            textBox4.KeyDown += serialInputDown;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(30, 179);
            textBox11.Multiline = true;
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(288, 29);
            textBox11.TabIndex = 3;
            textBox11.Tag = "2";
            textBox11.KeyDown += serialInputDown;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(30, 142);
            textBox12.Multiline = true;
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(288, 29);
            textBox12.TabIndex = 2;
            textBox12.Tag = "1";
            textBox12.KeyDown += serialInputDown;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Silver;
            button2.Location = new Point(201, 462);
            button2.Name = "button2";
            button2.Size = new Size(117, 53);
            button2.TabIndex = 11;
            button2.Text = "OPEN";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Silver;
            button3.Location = new Point(30, 462);
            button3.Name = "button3";
            button3.Size = new Size(117, 53);
            button3.TabIndex = 10;
            button3.Text = "START";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 28);
            label6.Name = "label6";
            label6.Size = new Size(67, 18);
            label6.TabIndex = 4;
            label6.Text = "User Id";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(117, 100);
            label7.Name = "label7";
            label7.Size = new Size(85, 18);
            label7.TabIndex = 3;
            label7.Text = "Serial No.";
            // 
            // textBox13
            // 
            textBox13.Location = new Point(131, 21);
            textBox13.Multiline = true;
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(156, 31);
            textBox13.TabIndex = 1;
            textBox13.KeyDown += textBox13_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 619);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel3;
        private Button button2;
        private Button button3;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox11;
        private Label label6;
        private Label label7;
        private TextBox textBox12;
        private TextBox textBox13;
    }
}
