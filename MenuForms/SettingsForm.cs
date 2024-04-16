using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OperDocxForm operDocxForm = new OperDocxForm();
            operDocxForm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DatabaseConnectionCheckForm databaseConnectionCheckForm = new DatabaseConnectionCheckForm();
            databaseConnectionCheckForm.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ConnectionStringDialog dialog = new ConnectionStringDialog();
            dialog.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckBoxAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            string appPath = Application.ExecutablePath;
            string runKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string runKeyName = "MyApp";
            if (CheckBoxAutoRun.Checked)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKeyPath, true))
                {
                    key.SetValue(runKeyName, appPath);
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKeyPath, true))
                {
                    key.DeleteValue(runKeyName, false);
                }
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            chart1.Series.Clear();
            chart1.Series.Add("Занимает памяти:");
            chart1.Series["Занимает памяти:"].BorderWidth = 3;
            chart1.Series["Занимает памяти:"].ChartType = SeriesChartType.Line;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 10; // Отображать только последние 10 значений
            chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;

            // Запуск таймера для обновления данных
            timer1.Interval = 1000; // Обновлять данные каждую секунду
            timer1.Start();

            Process process = Process.GetCurrentProcess();
            long memoryUsage = process.WorkingSet64;
            //MessageBox.Show($"Память программы: {memoryUsage} байт");
            double memoryUsageInMegabytes = memoryUsage / 1048576.0;
            label6.Text = $"ПАМЯТЬ ПРОГРАММЫ: {memoryUsageInMegabytes:F2} МБ";

            chart2.Series.Clear();
            chart2.Series.Add("Выделено:");
            chart2.Series["Выделено:"].ChartType = SeriesChartType.Bubble;
            chart2.Series["Выделено:"].Points.AddY(memoryUsage);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process process = Process.GetCurrentProcess();
            // Получение информации о памяти
            long memoryUsage = process.WorkingSet64; // Занимаемая память в байтах
            double memoryUsageInMegabytes = memoryUsage / 1048576.0;
            // Добавление нового значения в диаграмму
            chart1.Series["Занимает памяти:"].Points.AddY(memoryUsageInMegabytes);

            // Удаление старых значений из диаграммы
            if (chart1.Series["Занимает памяти:"].Points.Count > 10)
            {
                chart1.Series["Занимает памяти:"].Points.RemoveAt(0);
            }

            chart2.Series.Clear();
            chart2.Series.Add("Выделено:");
            chart2.Series["Выделено:"].Points.AddY(memoryUsage);

            // Генерация случайного цвета
            Color randomColor = GenerateRandomColor();
            // Применение случайного цвета к точкам
            foreach (DataPoint point in chart1.Series["Занимает памяти:"].Points)
            {
                point.Color = randomColor;
            }

            label6.Text = $"ПАМЯТЬ ПРОГРАММЫ: {memoryUsageInMegabytes:F2} МБ";

        }
        private Color GenerateRandomColor()
        {
            Random random = new Random();
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            return Color.FromArgb(r, g, b);
        }

    }
}
