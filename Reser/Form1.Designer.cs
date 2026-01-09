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
            Zmin = new Label();
            Zmax = new Label();
            Hd2 = new Label();
            Hd1 = new Label();
            label15 = new Label();
            label13 = new Label();
            knt = new TextBox();
            label6 = new Label();
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
            toolStrip.Size = new Size(782, 27);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // saveButton
            // 
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveButton.Image = Properties.Resources.save;
            saveButton.ImageTransparentColor = Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(29, 24);
            saveButton.Text = "Сохранить исходные данные";
            saveButton.Click += saveButton_Click;
            // 
            // openButton
            // 
            openButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openButton.Image = Properties.Resources.open;
            openButton.ImageTransparentColor = Color.Magenta;
            openButton.Name = "openButton";
            openButton.Size = new Size(29, 24);
            openButton.Text = "Загрузить исходные данные";
            openButton.Click += openButton_Click;
            // 
            // executeButton
            // 
            executeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            executeButton.Image = Properties.Resources.execute;
            executeButton.ImageTransparentColor = Color.Magenta;
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(29, 24);
            executeButton.Text = "Выполнить расчет";
            executeButton.Click += executeButton_Click;
            // 
            // saveResultsButton
            // 
            saveResultsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveResultsButton.Image = Properties.Resources.SaveResults;
            saveResultsButton.ImageTransparentColor = Color.Magenta;
            saveResultsButton.Name = "saveResultsButton";
            saveResultsButton.Size = new Size(29, 24);
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
            helpButton.Size = new Size(29, 24);
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
            groupBox1.Location = new Point(12, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(241, 168);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Деривация";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(208, 71);
            label3.Name = "label3";
            label3.Size = new Size(26, 20);
            label3.TabIndex = 5;
            label3.Text = "м²";
            // 
            // Fdt
            // 
            Fdt.Location = new Point(145, 68);
            Fdt.Name = "Fdt";
            Fdt.Size = new Size(57, 27);
            Fdt.TabIndex = 2;
            Fdt.TextAlign = HorizontalAlignment.Right;
            Fdt.TextChanged += Fd_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 71);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 3;
            label4.Text = "Площадь Fд";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 36);
            label2.Name = "label2";
            label2.Size = new Size(20, 20);
            label2.TabIndex = 2;
            label2.Text = "м";
            // 
            // Ldt
            // 
            Ldt.Location = new Point(145, 33);
            Ldt.Name = "Ldt";
            Ldt.Size = new Size(57, 27);
            Ldt.TabIndex = 1;
            Ldt.TextAlign = HorizontalAlignment.Right;
            Ldt.TextChanged += Ld_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
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
            groupBox2.Location = new Point(12, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 147);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Резервуар";
            // 
            // krt
            // 
            krt.Location = new Point(145, 100);
            krt.Name = "krt";
            krt.Size = new Size(57, 27);
            krt.TabIndex = 5;
            krt.TextAlign = HorizontalAlignment.Right;
            krt.TextChanged += kr_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 67);
            label10.Name = "label10";
            label10.Size = new Size(133, 60);
            label10.TabIndex = 6;
            label10.Text = "Коэффициент\r\nдополнительного\r\nсопротивления ζ\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(208, 34);
            label7.Name = "label7";
            label7.Size = new Size(26, 20);
            label7.TabIndex = 2;
            label7.Text = "м²";
            // 
            // Frt
            // 
            Frt.Location = new Point(145, 31);
            Frt.Name = "Frt";
            Frt.Size = new Size(57, 27);
            Frt.TabIndex = 3;
            Frt.TextAlign = HorizontalAlignment.Right;
            Frt.TextChanged += Fr_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 34);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
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
            groupBox3.Location = new Point(12, 357);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(241, 105);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Параметры расчета";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(208, 71);
            label5.Name = "label5";
            label5.Size = new Size(16, 20);
            label5.TabIndex = 5;
            label5.Text = "c";
            // 
            // Trast
            // 
            Trast.Location = new Point(145, 68);
            Trast.Name = "Trast";
            Trast.Size = new Size(57, 27);
            Trast.TabIndex = 7;
            Trast.TextAlign = HorizontalAlignment.Right;
            Trast.TextChanged += Tras_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 71);
            label9.Name = "label9";
            label9.Size = new Size(124, 20);
            label9.TabIndex = 3;
            label9.Text = "Время расчета T";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(208, 36);
            label11.Name = "label11";
            label11.Size = new Size(16, 20);
            label11.TabIndex = 2;
            label11.Text = "c";
            // 
            // dtt
            // 
            dtt.Location = new Point(145, 33);
            dtt.Name = "dtt";
            dtt.Size = new Size(57, 27);
            dtt.TabIndex = 6;
            dtt.TextAlign = HorizontalAlignment.Right;
            dtt.TextChanged += dt_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 36);
            label12.Name = "label12";
            label12.Size = new Size(113, 20);
            label12.TabIndex = 0;
            label12.Text = "Шаг расчета dt";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridView_discharge);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label16);
            groupBox4.Location = new Point(12, 468);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(520, 107);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Закон изменения расхода";
            // 
            // dataGridView_discharge
            // 
            dataGridView_discharge.AllowUserToAddRows = false;
            dataGridView_discharge.AllowUserToDeleteRows = false;
            dataGridView_discharge.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_discharge.Location = new Point(145, 36);
            dataGridView_discharge.Name = "dataGridView_discharge";
            dataGridView_discharge.RowHeadersWidth = 51;
            dataGridView_discharge.Size = new Size(366, 61);
            dataGridView_discharge.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 71);
            label14.Name = "label14";
            label14.Size = new Size(93, 20);
            label14.TabIndex = 3;
            label14.Text = "Расход, м³/с";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 36);
            label16.Name = "label16";
            label16.Size = new Size(68, 20);
            label16.TabIndex = 0;
            label16.Text = "Время, с";
            // 
            // formsPlot_L
            // 
            formsPlot_L.DisplayScale = 1.25F;
            formsPlot_L.Location = new Point(259, 30);
            formsPlot_L.Name = "formsPlot_L";
            formsPlot_L.Size = new Size(511, 210);
            formsPlot_L.TabIndex = 5;
            // 
            // formsPlot_Q
            // 
            formsPlot_Q.DisplayScale = 1.25F;
            formsPlot_Q.Location = new Point(259, 252);
            formsPlot_Q.Name = "formsPlot_Q";
            formsPlot_Q.Size = new Size(511, 210);
            formsPlot_Q.TabIndex = 6;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(Zmin);
            groupBox5.Controls.Add(Zmax);
            groupBox5.Controls.Add(Hd2);
            groupBox5.Controls.Add(Hd1);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(label13);
            groupBox5.Location = new Point(538, 468);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(232, 107);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Экстремумы";
            // 
            // Zmin
            // 
            Zmin.AutoSize = true;
            Zmin.Location = new Point(119, 77);
            Zmin.Name = "Zmin";
            Zmin.Size = new Size(39, 20);
            Zmin.TabIndex = 5;
            Zmin.Text = "      -";
            // 
            // Zmax
            // 
            Zmax.AutoSize = true;
            Zmax.Location = new Point(119, 54);
            Zmax.Name = "Zmax";
            Zmax.Size = new Size(39, 20);
            Zmax.TabIndex = 4;
            Zmax.Text = "      -";
            // 
            // Hd2
            // 
            Hd2.AutoSize = true;
            Hd2.Location = new Point(6, 77);
            Hd2.Name = "Hd2";
            Hd2.Size = new Size(39, 20);
            Hd2.TabIndex = 3;
            Hd2.Text = "      -";
            // 
            // Hd1
            // 
            Hd1.AutoSize = true;
            Hd1.Location = new Point(6, 54);
            Hd1.Name = "Hd1";
            Hd1.Size = new Size(39, 20);
            Hd1.TabIndex = 2;
            Hd1.Text = "      -";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(119, 23);
            label15.Name = "label15";
            label15.Size = new Size(114, 20);
            label15.TabIndex = 1;
            label15.Text = "Z (уровень), м";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(6, 23);
            label13.Name = "label13";
            label13.Size = new Size(104, 20);
            label13.TabIndex = 0;
            label13.Text = "Нд (макс.), м";
            // 
            // knt
            // 
            knt.Location = new Point(145, 119);
            knt.Name = "knt";
            knt.Size = new Size(57, 27);
            knt.TabIndex = 7;
            knt.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 106);
            label6.Name = "label6";
            label6.Size = new Size(128, 40);
            label6.TabIndex = 6;
            label6.Text = "Коэффициент\r\nшероховатости n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 583);
            Controls.Add(groupBox5);
            Controls.Add(formsPlot_Q);
            Controls.Add(formsPlot_L);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Label label13;
        private TextBox knt;
        private Label label6;
    }
}
