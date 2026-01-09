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

            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

            dataGridView_discharge.ColumnHeadersVisible = false;
            dataGridView_discharge.RowHeadersVisible = false;
            dataGridView_discharge.AllowUserToAddRows = false;
            dataGridView_discharge.AllowUserToDeleteRows = false;
            dataGridView_discharge.AllowUserToOrderColumns = false;
            dataGridView_discharge.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

            for (int i = 0; i < dataGridView_discharge.Columns.Count; i++)
            {
                dataGridView_discharge.Columns[i].Width = 60;
            }

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


        decimal[,] Table = new decimal[32768, 8];

        decimal t2 = 0;

        int count;

        private void executeButton_Click(object sender, EventArgs e)
        {
            count = 0;

            int IK = 6;

            decimal[] UT = new decimal[6];
            decimal[] UQST = new decimal[6];

            decimal Ld = 0;
            decimal Fd = 0;
            decimal Fr = 0;
            decimal kn = 0;
            decimal kr = 0;
            decimal dt = 0;
            decimal Tras = 0;
            decimal kwd;
            decimal kwr;
            decimal Dd;
            decimal R;
            decimal Qst;
            decimal Qd;
            decimal Qr;
            decimal Hwd;
            decimal Hwr;
            decimal Z;
            decimal Hd;
            decimal Shesi;
            decimal DZDT;
            decimal DQdDT;
            decimal First;
            decimal Second;
            decimal T = 0;

            try { Ld = GetDecimal(Ldt.Text, 0m); }
            catch { ErrorMsg(Ldt, "длину деривации"); }
            try { Fd = GetDecimal(Fdt.Text, 0m); }
            catch { ErrorMsg(Fdt, "площадь деривации"); }
            try { Fr = GetDecimal(Frt.Text, 0m); }
            catch { ErrorMsg(Frt, "площадь резервуара"); }
            try { kn = GetDecimal(knt.Text, 0m); }
            catch { ErrorMsg(knt, "коэффициент шероховатости"); }
            try { kr = GetDecimal(krt.Text, 0m); }
            catch { ErrorMsg(krt, "коэффициент дополнительного сопротивления"); }
            try { dt = GetDecimal(dtt.Text, 0m); }
            catch { ErrorMsg(dtt, "шаг расчета"); }
            try { Tras = GetDecimal(Trast.Text, 0m); }
            catch { ErrorMsg(Trast, "время расчета"); }

            for (int i = 0; i < 6; i++)
            {
                try
                {
                    UT[i] = GetDecimal((string)dataGridView_discharge.Rows[0].Cells[i].Value, 0m);
                    UQST[i] = GetDecimal((string)dataGridView_discharge.Rows[1].Cells[i].Value, 0m);
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
                Dd = (decimal)Math.Pow(4 * (double)Fd / 3.1415, 0.5);
                R = Dd / 4;

                if (kn > 0)
                {
                    Shesi = 1 / kn * (decimal)Math.Pow((double)R, 1 / 6);
                    kwd = Ld / ((decimal)Math.Pow((double)Shesi, 2) * R * (decimal)Math.Pow((double)Fd, 2));
                }
                else { kwd = 0; }

                kwr = kr / ((decimal)19.62 * (decimal)Math.Pow((double)Fd, 2));

                Qst = Int11(T, IK, UT, UQST);
                Qd = Qst;
                Qr = 0;
                Hwd = kwd * Qd * Math.Abs(Qd);
                Hwr = (decimal)Math.Pow((double)Qd, 2) / ((decimal)19.62 * (decimal)Math.Pow((double)Fd, 2));
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
                    DQdDT = -(Z + Hwd + Hwr) * Fd * (decimal)9.81 / Ld;
                    Qd += DQdDT * dt;
                    Hwd = kwd * Qd * Math.Abs(Qd);
                    Qr = Qd - Qst;
                    Hwr = kwr * Qr * Math.Abs(Qr) + (decimal)Math.Pow((double)Qd, 2) /
                        ((decimal)19.62 * (decimal)Math.Pow((double)Fd, 2));
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
                    DataX[i] = (double)Table[i, 0];
                    DataY1[i] = (double)Table[i, 6];
                    DataY2[i] = (double)Table[i, 7];
                }
                var z = formsPlot_L.Plot.Add.Scatter(DataX, DataY1);
                var hd = formsPlot_L.Plot.Add.Scatter(DataX, DataY2);
                z.LegendText = "Уровень в УР, Z";
                hd.LegendText = "Давление в деривации, Нд";
                z.MarkerSize = 0;
                hd.MarkerSize = 0;
                z.LineWidth = 2;
                hd.LineWidth = 2;

                ScottPlot.Color semitransparent = ScottPlot.Colors.White.WithAlpha(0.3);

                formsPlot_L.Plot.Axes.SetLimitsX(0, (double)Tras);
                formsPlot_L.Plot.Axes.SetLimitsY(Lmin, Lmax);
                formsPlot_L.Plot.Axes.Left.Label.Text = "м";
                formsPlot_L.Plot.Axes.Left.Label.Bold = false;
                formsPlot_L.Plot.Axes.Bottom.Label.Text = "Время, с";
                formsPlot_L.Plot.Axes.Bottom.Label.Bold = false;
                formsPlot_L.Plot.Legend.BackgroundColor = semitransparent;
                formsPlot_L.Plot.ShowLegend(ScottPlot.Alignment.LowerRight, ScottPlot.Orientation.Vertical);
                formsPlot_L.Refresh();

                for (int i = 0; i < count; i++)
                {
                    DataY1[i] = (double)Table[i, 2];
                    DataY2[i] = (double)Table[i, 1];
                }
                var qd = formsPlot_Q.Plot.Add.Scatter(DataX, DataY1);
                var qt = formsPlot_Q.Plot.Add.Scatter(DataX, DataY2);
                qd.LegendText = "Расход деривации, Qд";
                qt.LegendText = "Расход турбинных водоводов, Qт";
                qd.MarkerSize = 0;
                qt.MarkerSize = 0;
                qd.LineWidth = 2;
                qt.LineWidth = 2;

                formsPlot_Q.Plot.Axes.SetLimitsX(0, (double)Tras);
                formsPlot_Q.Plot.Axes.SetLimitsY(Qmin, Qmax);
                formsPlot_Q.Plot.Axes.Left.Label.Text = "м³/c";
                formsPlot_Q.Plot.Axes.Left.Label.Bold = false;
                formsPlot_Q.Plot.Axes.Bottom.Label.Text = "Время, с";
                formsPlot_Q.Plot.Axes.Bottom.Label.Bold = false;
                formsPlot_Q.Plot.Legend.BackgroundColor = semitransparent;
                formsPlot_Q.Plot.ShowLegend(ScottPlot.Alignment.LowerRight, ScottPlot.Orientation.Vertical);
                formsPlot_Q.Refresh();
            
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

            // Определяем максимумы давления
            if ((UQST[0] > UQST[1]) || (UQST[1] > UQST[2]))
            {
                decimal[] DYDX = new decimal[count];
                First = 0;
                Second = 0;
                int SecondPosition = 0;

                decimal Min = Table[0, 7];
                int Imin = 0;
                int t2Pos = (int)(t2 / dt);

                // Ищем первый полупериод
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
                    if (DYDX[i - 1] > (decimal)1.5 * DYDX[i])
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
                Hd1.Text = "Первый: " + Math.Round(First, 2);
                Hd2.Text = "Второй: " + Math.Round(Second, 2);
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

        private decimal Int11(decimal D, int N, decimal[] X, decimal[] Y)
        {
            decimal V = -1;
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

        private decimal GetDecimal(string str, decimal defaultValue)
        {
            decimal result;
            //Try parsing in the current culture
            if (!decimal.TryParse(str, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !decimal.TryParse(str, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
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
                            tmp = (double)Table[j, i];
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
        private void Form1_FormClosed (object sender, EventArgs e)
        {
            TryDeleteFile(tempFilePath);
        }
    }
}
