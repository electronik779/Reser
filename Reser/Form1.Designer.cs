namespace Reser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openData = new OpenFileDialog();
            saveData = new SaveFileDialog();
            saveResults = new SaveFileDialog();
            toolStrip = new ToolStrip();
            saveButton = new ToolStripButton();
            openButton = new ToolStripButton();
            executeButton = new ToolStripButton();
            saveResultsButton = new ToolStripButton();
            helpButton = new ToolStripButton();
            groupBox1 = new GroupBox();
            knt = new TextBox();
            label6 = new Label();
            label3 = new Label();
            Fdt = new TextBox();
            label4 = new Label();
            label2 = new Label();
            Ldt = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            krt = new TextBox();
            label10 = new Label();
            label7 = new Label();
            Frt = new TextBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            label5 = new Label();
            Trast = new TextBox();
            label9 = new Label();
            label11 = new Label();
            dtt = new TextBox();
            label12 = new Label();
            groupBox4 = new GroupBox();
            dataGridView_discharge = new DataGridView();
            label14 = new Label();
            label16 = new Label();
            formsPlot_L = new ScottPlot.WinForms.FormsPlot();
            formsPlot_Q = new ScottPlot.WinForms.FormsPlot();
            groupBox5 = new GroupBox();
            Hd_min = new Label();
            Hd_max = new Label();
            label17 = new Label();
            Zmin = new Label();
            Zmax = new Label();
            Hd2 = new Label();
            Hd1 = new Label();
            label15 = new Label();
            Hd_extrem = new Label();
            toolStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_discharge).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { saveButton, openButton, executeButton, saveResultsButton, helpButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(684, 27);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // saveButton
            // 
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveButton.Image = Properties.Resources.save;
            saveButton.ImageTransparentColor = Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(24, 24);
            saveButton.Text = "Сохранить исходные данные";
            saveButton.Click += saveButton_Click;
            // 
            // openButton
            // 
            openButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openButton.Image = Properties.Resources.open;
            openButton.ImageTransparentColor = Color.Magenta;
            openButton.Name = "openButton";
            openButton.Size = new Size(24, 24);
            openButton.Text = "Загрузить исходные данные";
            openButton.Click += openButton_Click;
            // 
            // executeButton
            // 
            executeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            executeButton.Image = Properties.Resources.execute;
            executeButton.ImageTransparentColor = Color.Magenta;
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(24, 24);
            executeButton.Text = "Выполнить расчет";
            executeButton.Click += executeButton_Click;
            // 
            // saveResultsButton
            // 
            saveResultsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveResultsButton.Image = Properties.Resources.SaveResults;
            saveResultsButton.ImageTransparentColor = Color.Magenta;
            saveResultsButton.Name = "saveResultsButton";
            saveResultsButton.Size = new Size(24, 24);
            saveResultsButton.Text = "Сохранить результаты расчета";
            saveResultsButton.Click += saveResultsButton_Click;
            // 
            // helpButton
            // 
            helpButton.Alignment = ToolStripItemAlignment.Right;
            helpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpButton.Image = Properties.Resources.Help;
            helpButton.ImageTransparentColor = Color.Magenta;
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(24, 24);
            helpButton.Text = "ПАМАГИТЕ!!!";
            helpButton.Click += helpButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(knt);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Fdt);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Ldt);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 22);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(211, 126);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Деривация";
            // 
            // knt
            // 
            knt.Location = new Point(127, 89);
            knt.Margin = new Padding(3, 2, 3, 2);
            knt.Name = "knt";
            knt.Size = new Size(50, 23);
            knt.TabIndex = 3;
            knt.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 80);
            label6.Name = "label6";
            label6.Size = new Size(103, 30);
            label6.TabIndex = 6;
            label6.Text = "Коэффициент\r\nшероховатости n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 53);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 5;
            label3.Text = "м²";
            // 
            // Fdt
            // 
            Fdt.Location = new Point(127, 51);
            Fdt.Margin = new Padding(3, 2, 3, 2);
            Fdt.Name = "Fdt";
            Fdt.Size = new Size(50, 23);
            Fdt.TabIndex = 2;
            Fdt.TextAlign = HorizontalAlignment.Right;
            Fdt.TextChanged += Fd_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 53);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 3;
            label4.Text = "Площадь Fд";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 27);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 2;
            label2.Text = "м";
            // 
            // Ldt
            // 
            Ldt.Location = new Point(127, 25);
            Ldt.Margin = new Padding(3, 2, 3, 2);
            Ldt.Name = "Ldt";
            Ldt.Size = new Size(50, 23);
            Ldt.TabIndex = 1;
            Ldt.TextAlign = HorizontalAlignment.Right;
            Ldt.TextChanged += Ld_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 27);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Длина Lд";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(krt);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(Frt);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(10, 153);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(211, 110);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Резервуар";
            // 
            // krt
            // 
            krt.Location = new Point(127, 75);
            krt.Margin = new Padding(3, 2, 3, 2);
            krt.Name = "krt";
            krt.Size = new Size(50, 23);
            krt.TabIndex = 5;
            krt.TextAlign = HorizontalAlignment.Right;
            krt.TextChanged += kr_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(5, 50);
            label10.Name = "label10";
            label10.Size = new Size(105, 45);
            label10.TabIndex = 6;
            label10.Text = "Коэффициент\r\nдополнительного\r\nсопротивления ζ\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(182, 26);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 2;
            label7.Text = "м²";
            // 
            // Frt
            // 
            Frt.Location = new Point(127, 23);
            Frt.Margin = new Padding(3, 2, 3, 2);
            Frt.Name = "Frt";
            Frt.Size = new Size(50, 23);
            Frt.TabIndex = 4;
            Frt.TextAlign = HorizontalAlignment.Right;
            Frt.TextChanged += Fr_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 26);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 0;
            label8.Text = "Площадь Fр";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(Trast);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(dtt);
            groupBox3.Controls.Add(label12);
            groupBox3.Location = new Point(10, 268);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(211, 79);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Параметры расчета";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(182, 53);
            label5.Name = "label5";
            label5.Size = new Size(13, 15);
            label5.TabIndex = 5;
            label5.Text = "c";
            // 
            // Trast
            // 
            Trast.Location = new Point(127, 51);
            Trast.Margin = new Padding(3, 2, 3, 2);
            Trast.Name = "Trast";
            Trast.Size = new Size(50, 23);
            Trast.TabIndex = 7;
            Trast.TextAlign = HorizontalAlignment.Right;
            Trast.TextChanged += Tras_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 53);
            label9.Name = "label9";
            label9.Size = new Size(97, 15);
            label9.TabIndex = 3;
            label9.Text = "Время расчета T";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(182, 27);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 2;
            label11.Text = "c";
            // 
            // dtt
            // 
            dtt.Location = new Point(127, 25);
            dtt.Margin = new Padding(3, 2, 3, 2);
            dtt.Name = "dtt";
            dtt.Size = new Size(50, 23);
            dtt.TabIndex = 6;
            dtt.TextAlign = HorizontalAlignment.Right;
            dtt.TextChanged += dt_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(5, 27);
            label12.Name = "label12";
            label12.Size = new Size(89, 15);
            label12.TabIndex = 0;
            label12.Text = "Шаг расчета dt";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridView_discharge);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label16);
            groupBox4.Location = new Point(10, 351);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(413, 80);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Закон изменения расхода";
            // 
            // dataGridView_discharge
            // 
            dataGridView_discharge.AllowUserToAddRows = false;
            dataGridView_discharge.AllowUserToDeleteRows = false;
            dataGridView_discharge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_discharge.Location = new Point(88, 20);
            dataGridView_discharge.Margin = new Padding(3, 2, 3, 2);
            dataGridView_discharge.Name = "dataGridView_discharge";
            dataGridView_discharge.RowHeadersWidth = 51;
            dataGridView_discharge.Size = new Size(320, 56);
            dataGridView_discharge.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(5, 53);
            label14.Name = "label14";
            label14.Size = new Size(75, 15);
            label14.TabIndex = 3;
            label14.Text = "Расход, м³/с";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(5, 27);
            label16.Name = "label16";
            label16.Size = new Size(54, 15);
            label16.TabIndex = 0;
            label16.Text = "Время, с";
            // 
            // formsPlot_L
            // 
            formsPlot_L.DisplayScale = 1.25F;
            formsPlot_L.Location = new Point(227, 22);
            formsPlot_L.Margin = new Padding(3, 2, 3, 2);
            formsPlot_L.Name = "formsPlot_L";
            formsPlot_L.Size = new Size(447, 158);
            formsPlot_L.TabIndex = 5;
            // 
            // formsPlot_Q
            // 
            formsPlot_Q.DisplayScale = 1.25F;
            formsPlot_Q.Location = new Point(227, 189);
            formsPlot_Q.Margin = new Padding(3, 2, 3, 2);
            formsPlot_Q.Name = "formsPlot_Q";
            formsPlot_Q.Size = new Size(447, 158);
            formsPlot_Q.TabIndex = 6;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(Hd_min);
            groupBox5.Controls.Add(Hd_max);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(Zmin);
            groupBox5.Controls.Add(Zmax);
            groupBox5.Controls.Add(Hd2);
            groupBox5.Controls.Add(Hd1);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(Hd_extrem);
            groupBox5.Location = new Point(429, 351);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(248, 80);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Экстремумы";
            // 
            // Hd_min
            // 
            Hd_min.AutoSize = true;
            Hd_min.Location = new Point(166, 58);
            Hd_min.Name = "Hd_min";
            Hd_min.Size = new Size(30, 15);
            Hd_min.TabIndex = 8;
            Hd_min.Text = "      -";
            // 
            // Hd_max
            // 
            Hd_max.AutoSize = true;
            Hd_max.Location = new Point(166, 40);
            Hd_max.Name = "Hd_max";
            Hd_max.Size = new Size(30, 15);
            Hd_max.TabIndex = 7;
            Hd_max.Text = "      -";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label17.Location = new Point(172, 17);
            label17.Name = "label17";
            label17.Size = new Size(38, 15);
            label17.TabIndex = 6;
            label17.Text = "Hд, м";
            // 
            // Zmin
            // 
            Zmin.AutoSize = true;
            Zmin.Location = new Point(88, 58);
            Zmin.Name = "Zmin";
            Zmin.Size = new Size(30, 15);
            Zmin.TabIndex = 5;
            Zmin.Text = "      -";
            // 
            // Zmax
            // 
            Zmax.AutoSize = true;
            Zmax.Location = new Point(88, 40);
            Zmax.Name = "Zmax";
            Zmax.Size = new Size(30, 15);
            Zmax.TabIndex = 4;
            Zmax.Text = "      -";
            // 
            // Hd2
            // 
            Hd2.AutoSize = true;
            Hd2.Location = new Point(5, 58);
            Hd2.Name = "Hd2";
            Hd2.Size = new Size(30, 15);
            Hd2.TabIndex = 3;
            Hd2.Text = "      -";
            // 
            // Hd1
            // 
            Hd1.AutoSize = true;
            Hd1.Location = new Point(5, 40);
            Hd1.Name = "Hd1";
            Hd1.Size = new Size(30, 15);
            Hd1.TabIndex = 2;
            Hd1.Text = "      -";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(104, 17);
            label15.Name = "label15";
            label15.Size = new Size(29, 15);
            label15.TabIndex = 1;
            label15.Text = "Z, м";
            // 
            // Hd_extrem
            // 
            Hd_extrem.AutoSize = true;
            Hd_extrem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Hd_extrem.Location = new Point(5, 17);
            Hd_extrem.Name = "Hd_extrem";
            Hd_extrem.Size = new Size(77, 15);
            Hd_extrem.TabIndex = 0;
            Hd_extrem.Text = "Нд (макс), м";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 437);
            Controls.Add(groupBox5);
            Controls.Add(formsPlot_Q);
            Controls.Add(formsPlot_L);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Уравнительный резервуар с дополнительным сопротивлением";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_discharge).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openData;
        private SaveFileDialog saveData;
        private SaveFileDialog saveResults;
        private ToolStrip toolStrip;
        private ToolStripButton saveButton;
        private ToolStripButton openButton;
        private ToolStripButton executeButton;
        private ToolStripButton saveResultsButton;
        private ToolStripButton helpButton;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox Ldt;
        private Label label1;
        private Label label3;
        private TextBox Fdt;
        private Label label4;
        private GroupBox groupBox2;
        private Label label7;
        private TextBox Frt;
        private Label label8;
        private TextBox krt;
        private Label label10;
        private GroupBox groupBox3;
        private Label label5;
        private TextBox Trast;
        private Label label9;
        private Label label11;
        private TextBox dtt;
        private Label label12;
        private GroupBox groupBox4;
        private DataGridView dataGridView_discharge;
        private Label label14;
        private Label label16;
        private ScottPlot.WinForms.FormsPlot formsPlot_L;
        private ScottPlot.WinForms.FormsPlot formsPlot_Q;
        private GroupBox groupBox5;
        private Label Zmin;
        private Label Zmax;
        private Label Hd2;
        private Label Hd1;
        private Label label15;
        private Label Hd_extrem;
        private TextBox knt;
        private Label label6;
        private Label Hd_min;
        private Label Hd_max;
        private Label label17;
    }
}
