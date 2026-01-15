using Reser.Properties;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace Reser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView_discharge.ColumnHeadersVisible = false;
            dataGridView_discharge.RowHeadersVisible = false;
            dataGridView_discharge.AllowUserToAddRows = false;
            dataGridView_discharge.AllowUserToDeleteRows = false;
            dataGridView_discharge.AllowUserToOrderColumns = false;
            dataGridView_discharge.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView_discharge.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView_discharge.AllowUserToResizeRows = true;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem copyItem = new ToolStripMenuItem("Размножить вправо →");
            copyItem.Click += CopyItem_Click;
            contextMenu.Items.Add(copyItem);

            // Привязываем меню к DataGridView
            dataGridView_discharge.ContextMenuStrip = contextMenu;


            DataTable discharge = new DataTable();

            List<string> colNames = new List<string>() { "0", "1", "2", "3", "4", "5" };

            foreach (string str in colNames)
            {
                discharge.Columns.Add(str);
            }
            for (int i = 0; i < 2; i++)
            {
                DataRow dr = discharge.NewRow();
                discharge.Rows.Add(dr);
            }

            dataGridView_discharge.DataSource = discharge;

            int dgvWidth = dataGridView_discharge.Width;
            int dgvHeight = dataGridView_discharge.Height;
            int cellWidth = (dgvWidth / 6) - 1;
            int cellHeight = (dgvHeight / 2) - 2;
            dataGridView_discharge.Width = (cellWidth * 6) + 3;
            dataGridView_discharge.Height = (cellHeight * 2) + 3;
            //Debug.WriteLine("W= {0}, H= {1}, cW= {2}, cH= {3}",
            //dgvWidth, dgvHeight, colWidth, colHeight);

            foreach (DataGridViewColumn col in dataGridView_discharge.Columns)
            {
                col.Width = cellWidth;
            }
            dataGridView_discharge.RowTemplate.Height = cellHeight; // Это работает.
            // Закоменченый код ниже - не работает.
            //foreach (DataGridViewRow row in dataGridView_discharge.Rows)
            //{
            //    row.MinimumHeight = cellHeight;
            //    row.Height = cellHeight;
            //}

            openData.Filter = "CSV файлы (*.csv)|*.csv";

            saveData.Filter = "CSV файлы (*.csv)|*.csv";
            saveData.DefaultExt = "csv";
            saveData.AddExtension = true;

            saveResults.Filter = "CSV файлы (*.csv)|*.csv";
            saveResults.DefaultExt = "csv";
            saveResults.AddExtension = true;

            this.FormClosing += (sender, e) => { TryDeleteFile(tempFilePath); };
        }

        // Генерация уникального имени файла
        string tempFilePath = Path.Combine(Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".pdf");


        double[,] Table = new double[32768, 8];

        double t2 = 0;

        int count;

        private void executeButton_Click(object sender, EventArgs e)
        {
            count = 0;

            int IK = 6;

            double[] UT = new double[6];
            double[] UQST = new double[6];

            double Ld = 0;
            double Fd = 0;
            double Fr = 0;
            double kn = 0;
            double kr = 0;
            double dt = 0;
            double Tras = 0;
            double kwd;
            double kwr;
            double Dd;
            double R;
            double Qst;
            double Qd;
            double Qr;
            double Hwd;
            double Hwr;
            double Z;
            double Hd;
            double Shesi;
            double DZDT;
            double DQdDT;
            double First;
            double Second;
            double T = 0;

            try { Ld = GetDouble(Ldt.Text, 0d); }
            catch { ErrorMsg(Ldt, "длину деривации"); }
            try { Fd = GetDouble(Fdt.Text, 0d); }
            catch { ErrorMsg(Fdt, "площадь деривации"); }
            try { Fr = GetDouble(Frt.Text, 0d); }
            catch { ErrorMsg(Frt, "площадь резервуара"); }
            try { kn = GetDouble(knt.Text, 0d); }
            catch { ErrorMsg(knt, "коэффициент шероховатости"); }
            try { kr = GetDouble(krt.Text, 0d); }
            catch { ErrorMsg(krt, "коэффициент дополнительного сопротивления"); }
            try { dt = GetDouble(dtt.Text, 0d); }
            catch { ErrorMsg(dtt, "шаг расчета"); }
            try { Tras = GetDouble(Trast.Text, 0d); }
            catch { ErrorMsg(Trast, "время расчета"); }

            for (int i = 0; i < 6; i++)
            {
                try
                {
                    UT[i] = GetDouble((string)dataGridView_discharge.Rows[0].Cells[i].Value, 0d);
                    UQST[i] = GetDouble((string)dataGridView_discharge.Rows[1].Cells[i].Value, 0d);
                }
                catch
                {
                    MessageBox.Show("Ошибка в законе изменения расхода.", "Внимание!",
                            MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }

            t2 = UT[1];

            if (kn < 0) kn = 0;

            if (dt > 10)
            {
                dtt.BackColor = Color.Red;
                MessageBox.Show("Шаг расчета не должен превышать 10 с", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                return;
            }

            try
            {
                Dd = Math.Pow(4 * Fd / 3.1415, 0.5);
                R = Dd / 4;

                if (kn > 0)
                {
                    Shesi = 1 / kn * Math.Pow(R, 1 / 6);
                    kwd = Ld / (Math.Pow(Shesi, 2) * R * Math.Pow(Fd, 2));
                }
                else { kwd = 0; }

                kwr = kr / (19.62 * Math.Pow(Fd, 2));

                Qst = Int11(T, IK, UT, UQST);
                Qd = Qst;
                Qr = 0;
                Hwd = kwd * Qd * Math.Abs(Qd);
                Hwr = Math.Pow(Qd, 2) / (19.62 * Math.Pow(Fd, 2));
                Z = -Hwd - Hwr;
                Hd = Z + Hwr;

                Table[0, 0] = T;
                Table[0, 1] = Qst;
                Table[0, 2] = Qd;
                Table[0, 3] = Qr;
                Table[0, 4] = Hwd;
                Table[0, 5] = Hwr;
                Table[0, 6] = Z;
                Table[0, 7] = Hd;

                while (T <= Tras)
                {
                    T += dt;
                    count++;
                    if (count >= 32768)
                    {
                        MessageBox.Show("Слишком много значений. Увеличьте шаг расчета", "Внимание!",
                        MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        break;
                    }

                    Qst = Int11(T, IK, UT, UQST);
                    DZDT = (Qd - Qst) / Fr;
                    Z += DZDT * dt;
                    DQdDT = -(Z + Hwd + Hwr) * Fd * 9.81 / Ld;
                    Qd += DQdDT * dt;
                    Hwd = kwd * Qd * Math.Abs(Qd);
                    Qr = Qd - Qst;
                    Hwr = kwr * Qr * Math.Abs(Qr) + Math.Pow(Qd, 2) / (19.62 * Math.Pow(Fd, 2));
                    Hd = Z + Hwr;
                    Table[count, 0] = T;
                    Table[count, 1] = Qst;
                    Table[count, 2] = Qd;
                    Table[count, 3] = Qr;
                    Table[count, 4] = Hwd;
                    Table[count, 5] = Hwr;
                    Table[count, 6] = Z;
                    Table[count, 7] = Hd;
                    //Debug.WriteLine("T= {0}, Z= {1}, Hd= {2}", T, Z, Hd);
                }

                // Строим графики
                int Lmax = -1000000;
                int Lmin = 1000000;
                int Qmax = Lmax;
                int Qmin = Lmin;

                for (int i = 0; i < count; i++)
                {
                    if (Table[i, 6] < Lmin) { Lmin = (int)Table[i, 6]; }
                    if (Table[i, 6] > Lmax) { Lmax = (int)Table[i, 6]; }
                    if (Table[i, 1] < Qmin) { Qmin = (int)Table[i, 1]; }
                    if (Table[i, 1] > Qmax) { Qmax = (int)Table[i, 1]; }
                }
                for (int i = 0; i < count; i++)
                {
                    if (Table[i, 7] < Lmin) { Lmin = (int)Table[i, 7]; }
                    if (Table[i, 7] > Lmax) { Lmax = (int)Table[i, 7]; }
                    if (Table[i, 2] < Qmin) { Qmin = (int)Table[i, 2]; }
                    if (Table[i, 2] > Qmax) { Qmax = (int)Table[i, 2]; }
                }
                Lmin -= 1;
                Lmax += 1;
                Qmin -= 1;
                Qmax += 1;

                double[] DataX = new double[count];
                double[] DataY1 = new double[count];
                double[] DataY2 = new double[count];

                formsPlot_L.Plot.Clear();
                formsPlot_Q.Plot.Clear();

                for (int i = 0; i < count; i++)
                {
                    DataX[i] = Table[i, 0];
                    DataY1[i] = Table[i, 6];
                    DataY2[i] = Table[i, 7];
                }
                BuildChart_2lines(formsPlot_L, DataX, DataY1, DataY2,
                    "Уровень в УР, Z", "Давление в деривации, Нд", 2, 0,
                    "Время, с", 0, Tras,
                    "м", Lmin, Lmax);

                for (int i = 0; i < count; i++)
                {
                    DataY1[i] = Table[i, 2];
                    DataY2[i] = Table[i, 1];
                }
                BuildChart_2lines(formsPlot_Q, DataX, DataY1, DataY2,
                    "Расход деривации, Qд", "Расход турбинных водоводов, Qт", 2, 0,
                    "Время, с", 0, Tras,
                    "м³/c", Qmin, Qmax);

                First = Table[0, 6];
                Second = Table[0, 6];
                // Определяем минимальный и максимальный уровень
                for (int i = 0; i < count; i++)
                {
                    if (Table[i, 6] < First) First = Table[i, 6];
                    if (Table[i, 6] > Second) Second = Table[i, 6];
                }
                Zmax.Text = "Макс.: " + Math.Round(Second, 2);
                Zmin.Text = "Мин.: " + Math.Round(First, 2);

                First = Table[0, 7];
                Second = Table[0, 7];
                // Определяем минимальное и максимальное давление
                for (int i = 0; i < count; i++)
                {
                    if (Table[i, 7] < First) First = Table[i, 7];
                    if (Table[i, 7] > Second) Second = Table[i, 7];
                }
                Hd_max.Text = "Макс.: " + Math.Round(Second, 2);
                Hd_min.Text = "Мин.: " + Math.Round(First, 2);

                // Определяем максимумы давления для верхового УР
                if ((UQST[0] > 0) && (UQST[0] > UQST[1]))
                {
                    double[] DYDX = new double[count];
                    First = 0;
                    Second = 0;
                    int SecondPosition = 0;

                    double Min = Table[0, 7];
                    int Imin = 0;
                    int t2Pos = (int)(t2 / dt);

                    // Ищем первый максимум
                    for (int i = 1; i < count; i++)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}, {3}", i, Imin, Min, Table[i, 7]);
                        if (Table[i, 7] < Min)
                        {
                            Min = Table[i, 7];
                            Imin = i;
                            //Debug.WriteLine("{0}, {1}, {2}", i, Imin, Min);
                        }
                    }
                    if (Imin == 0) Imin = count;
                    Second = Table[Imin, 7];
                    //Debug.WriteLine("{0}, {1}", Imin, count);

                    // Ищем второй максимум
                    for (int i = Imin; i > t2Pos; i--)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}, {3}, {4}",
                        //    i, Second, SecondPosition, Table[i, 7], Table[i - 1, 7]);
                        if (Table[i, 7] > Second)
                        {
                            Second = Table[i, 7];
                            SecondPosition = i;
                        }
                        if (Table[i - 1, 7] < Second) break;
                    }

                    // Ищем первый максимум
                    //Debug.WriteLine("{0}", t2Pos);
                    for (int i = 1; i < t2Pos + 1; i++)
                    {
                        DYDX[i] = (Table[i, 7] - Table[i - 1, 7]) / dt;
                    }

                    for (int i = 1; i < t2Pos + 2; i++)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}", i, DYDX[i - 1], DYDX[i]);
                        if (DYDX[i - 1] > 1.5 * DYDX[i])
                        {
                            First = Table[i - 1, 7];
                        }
                        if (DYDX[i - 1] > 0 && DYDX[i] < 0)
                        {
                            First = Table[i - 1, 7];
                            //Debug.WriteLine("break");
                            break;
                        }
                    }
                    Hd_extrem.Text = "Нд (макс), м";
                    Hd1.Text = "Перв.: " + Math.Round(First, 2);
                    Hd2.Text = "Втор.: " + Math.Round(Second, 2);
                }

                // Определяем максимумы давления низового УР
                else if ((UQST[0] < 0) && (UQST[0] < UQST[1]))
                {
                    double[] DYDX = new double[count];
                    First = 0;
                    Second = 0;
                    int SecondPosition = 0;

                    double Max = Table[0, 7];
                    int Imax = 0;
                    int t2Pos = (int)(t2 / dt);

                    // Ищем первый полупериод
                    for (int i = 1; i < count; i++)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}, {3}", i, Imin, Min, Table[i, 7]);
                        if (Table[i, 7] > Max)
                        {
                            Max = Table[i, 7];
                            Imax = i;
                            //Debug.WriteLine("{0}, {1}, {2}", i, Imin, Min);
                        }
                    }
                    if (Imax == 0) Imax = count;
                    Second = Table[Imax, 7];
                    //Debug.WriteLine("{0}, {1}", Imin, count);

                    // Ищем второй максимум
                    for (int i = Imax; i > t2Pos; i--)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}, {3}, {4}",
                        //    i, Second, SecondPosition, Table[i, 7], Table[i - 1, 7]);
                        if (Table[i, 7] < Second)
                        {
                            Second = Table[i, 7];
                            SecondPosition = i;
                        }
                        if (Table[i - 1, 7] > Second) break;
                    }

                    // Ищем первый максимум
                    //Debug.WriteLine("{0}", t2Pos);
                    for (int i = 1; i < t2Pos + 1; i++)
                    {
                        DYDX[i] = (Table[i, 7] - Table[i - 1, 7]) / dt;
                    }

                    for (int i = 1; i < t2Pos + 2; i++)
                    {
                        //Debug.WriteLine("{0}, {1}, {2}", i, DYDX[i - 1], DYDX[i]);
                        if (DYDX[i - 1] < 1.5 * DYDX[i])
                        {
                            First = Table[i - 1, 7];
                        }
                        if (DYDX[i - 1] < 0 && DYDX[i] > 0)
                        {
                            First = Table[i - 1, 7];
                            //Debug.WriteLine("break");
                            break;
                        }
                    }
                    Hd_extrem.Text = "Нд (мин), м";
                    Hd1.Text = "Перв.: " + Math.Round(First, 2);
                    Hd2.Text = "Втор.: " + Math.Round(Second, 2);
                }
                else { Hd1.Text = "     -"; Hd2.Text = "     -"; }
            }
            catch
            {
                MessageBox.Show("Ошибка расчета. Проверьте корректность введенных данных",
                    "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void BuildChart_2lines(ScottPlot.WinForms.FormsPlot chartName,
            double[] dataX, double[] dataY1, double[] dataY2,
            string line1_Name, string line2_Name,
            float lineWidth, float markerSize,
            string axisX_Name, double minX, double maxX,
            string axisY_Name, double minY, double maxY)
        {
            ScottPlot.Color semitransparent = ScottPlot.Colors.White.WithAlpha(0.3);
            chartName.Plot.Axes.SetLimitsX(minX, maxX);
            chartName.Plot.Axes.SetLimitsY(minY, maxY);
            chartName.Plot.Axes.Left.Label.Text = axisY_Name;
            chartName.Plot.Axes.Left.Label.Bold = false;
            chartName.Plot.Axes.Left.Label.FontSize = 14;
            chartName.Plot.Axes.Bottom.Label.Text = axisX_Name;
            chartName.Plot.Axes.Bottom.Label.Bold = false;
            chartName.Plot.Axes.Bottom.Label.FontSize = 14;
            chartName.Plot.Legend.BackgroundColor = semitransparent;
            chartName.Plot.Legend.FontName = "Segoe UI";
            chartName.Plot.Legend.FontSize = 12;
            chartName.Plot.ShowLegend(ScottPlot.Alignment.LowerRight, ScottPlot.Orientation.Vertical);

            var line1 = chartName.Plot.Add.Scatter(dataX, dataY1);
            var line2 = chartName.Plot.Add.Scatter(dataX, dataY2);
            line1.LegendText = line1_Name;
            line2.LegendText = line2_Name;
            line1.MarkerSize = markerSize;
            line2.MarkerSize = markerSize;
            line1.LineWidth = lineWidth;
            line2.LineWidth = lineWidth;
            chartName.Refresh();
        }

        private double Int11(double D, int N, double[] X, double[] Y)
        {
            double V = -1;
            int i;
            for (i = 1; i < N; i++)
            {
                if (D - X[i] <= 0)
                {
                    int i1 = i - 1;
                    V = (Y[i] * (D - X[i1]) - Y[i1] * (D - X[i])) / (X[i] - X[i1]);
                    break;
                }
            }
            if (V == -1)
            {
                V = (Y[2] * (D - X[1]) - Y[1] * (D - X[2])) / (X[2] - X[1]);
            }
            return V;
        }

        private double GetDouble(string str, double defaultValue)
        {
            double result;
            //Try parsing in the current culture
            if (!double.TryParse(str, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(str, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
                throw new ArgumentNullException();
            }

            return result;
        }

        private void ErrorMsg(TextBox textBox, string str)
        {
            textBox.BackColor = Color.Red;
            MessageBox.Show("Необходимо ввести " + str + ".", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            return;
        }

        private static void TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch { /* Игнорируем ошибки удаления */ }
        }

        private void Ld_TextChanged(object sender, EventArgs e)
        {
            if (Ldt.BackColor == Color.Red) { Ldt.BackColor = SystemColors.Window; }
        }

        private void Fd_TextChanged(object sender, EventArgs e)
        {
            if (Fdt.BackColor == Color.Red) { Fdt.BackColor = SystemColors.Window; }
        }

        private void Fr_TextChanged(object sender, EventArgs e)
        {
            if (Frt.BackColor == Color.Red) { Frt.BackColor = SystemColors.Window; }
        }

        private void kn_TextChanged(object sender, EventArgs e)
        {
            if (knt.BackColor == Color.Red) { knt.BackColor = SystemColors.Window; }
        }

        private void kr_TextChanged(object sender, EventArgs e)
        {
            if (krt.BackColor == Color.Red) { krt.BackColor = SystemColors.Window; }
        }

        private void dt_TextChanged(object sender, EventArgs e)
        {
            if (dtt.BackColor == Color.Red) { dtt.BackColor = SystemColors.Window; }
        }

        private void Tras_TextChanged(object sender, EventArgs e)
        {
            if (Trast.BackColor == Color.Red) { Trast.BackColor = SystemColors.Window; }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = saveData.FileName;

                //если существует - удаляем
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                List<string>? block1 = new List<string>();
                List<string>? block2 = new List<string>();
                List<string>? block3 = new List<string>();
                List<string>? block4 = new List<string>();

                block1.Add(Ldt.Text);
                block1.Add(Fdt.Text);
                block1.Add(knt.Text);
                block2.Add(Frt.Text);
                block2.Add(krt.Text);

                for (int i = 0; i < 6; i++)
                {
                    block3.Add((string)dataGridView_discharge.Rows[0].Cells[i].Value);
                }
                for (int i = 0; i < 6; i++)
                {
                    block3.Add((string)dataGridView_discharge.Rows[1].Cells[i].Value);
                }

                block4.Add(dtt.Text);
                block4.Add(Trast.Text);

                using (StreamWriter writer = new StreamWriter(filename, true, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(string.Join(";", block1));
                    writer.WriteLine(string.Join(";", block2));
                    writer.WriteLine(string.Join(";", block3));
                    writer.WriteLine(string.Join(";", block4));
                }

            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openData.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = openData.FileName;

                List<List<string>> blocks = new List<List<string>>();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<string> row = line.Split(';').ToList();
                        blocks.Add(row);
                    }
                }

                List<string>? block1 = blocks.ElementAtOrDefault(0);
                List<string>? block2 = blocks.ElementAtOrDefault(1);
                List<string>? block3 = blocks.ElementAtOrDefault(2);
                List<string>? block4 = blocks.ElementAtOrDefault(3);

                try
                {
                    Ldt.Text = block1?.ElementAtOrDefault(0) ?? string.Empty;
                    Fdt.Text = block1?.ElementAtOrDefault(1) ?? string.Empty;
                    knt.Text = block1?.ElementAtOrDefault(2) ?? string.Empty;
                    Frt.Text = block2?.ElementAtOrDefault(0) ?? string.Empty;
                    krt.Text = block2?.ElementAtOrDefault(1) ?? string.Empty;

                    for (int i = 0; i < 6; i++)
                    {
                        dataGridView_discharge.Rows[0].Cells[i].Value =
                            block3?.ElementAtOrDefault(i) ?? string.Empty;
                    }
                    for (int i = 6; i < 12; i++)
                    {
                        dataGridView_discharge.Rows[1].Cells[i - 6].Value =
                            block3?.ElementAtOrDefault(i) ?? string.Empty;
                    }

                    dtt.Text = block4?.ElementAtOrDefault(0) ?? string.Empty;
                    Trast.Text = block4?.ElementAtOrDefault(1) ?? string.Empty;
                }
                catch
                {
                    MessageBox.Show("Неверный формат файла исходных данных " +
                        "/ файл исходных данных повреждён.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }

        }

        private void saveResultsButton_Click(object sender, EventArgs e)
        {
            if (saveResults.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = saveResults.FileName;

                //если существует - удаляем
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                using (StreamWriter writer = new StreamWriter(filename, true, System.Text.Encoding.UTF8))
                {
                    List<string> columnsNames = new List<string>()
                   { "Время, с", "Расход турбинного водовода, м3/с", "Расход деривации, м3/с",
                        "Расход резервуара, м3/с", "Потери в деривации, м",
                        "Потери в резервуаре, м", "Уровень в резервуаре, м",
                        "Давление в деривации, м"};
                    writer.WriteLine(string.Join(";", columnsNames));

                    //Debug.WriteLine("count= {0}", count);
                    for (int j = 0; j < count; j++)
                    {
                        List<string> list = new List<string>();
                        for (int i = 0; i < 8; i++)
                        {
                            double tmp;
                            tmp = Table[j, i];
                            //Debug.WriteLine("{0}, {1}, {2}", j, i, tmp);
                            list.Add(tmp.ToString());
                        }
                        writer.WriteLine(string.Join(";", list));
                    }
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            byte[] fileData = Resources.Reser_help;

            try
            {
                // Сохранение ресурса во временный файл
                File.WriteAllBytes(tempFilePath, fileData);

                // Запуск приложения по умолчанию
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = tempFilePath,
                    UseShellExecute = true // Ключевой параметр для использования ассоциаций ОС
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия справки: {ex.Message}");
                // Удаление файла в случае ошибки
                TryDeleteFile(tempFilePath);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Проверяем, что нажата правая кнопка и мы находимся внутри таблицы (не на заголовках)
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView_discharge.ClearSelection();
                dataGridView_discharge.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                // Устанавливаем текущую ячейку (фокус)
                dataGridView_discharge.CurrentCell = dataGridView_discharge.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void CopyItem_Click(object sender, EventArgs e)
        {
            var currentCell = dataGridView_discharge.CurrentCell;

            if (currentCell != null && currentCell.ColumnIndex < dataGridView_discharge.ColumnCount - 1)
            {
                int counter = currentCell.ColumnIndex;

                // Получаем значение текущей ячейки
                object? value = currentCell.Value;

                while (counter < dataGridView_discharge.ColumnCount - 1)
                {
                    // Записываем в соседнюю справа (ColumnIndex + 1)
                    dataGridView_discharge.Rows[currentCell.RowIndex].Cells[counter + 1].Value = value;
                    counter++;
                }
            }
        }
    }
}
