using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class FormChartsView : Form
    {
        private bool isPanelExpanded = false;
        public FormChartsView()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChartsView_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.SPECIALITY". При необходимости она может быть перемещена или удалена.
            this.sPECIALITYTableAdapter.Fill(this.user2DataSet.SPECIALITY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT_MATERIALS". При необходимости она может быть перемещена или удалена.
            this.eVENT_MATERIALSTableAdapter.Fill(this.user2DataSet.EVENT_MATERIALS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT". При необходимости она может быть перемещена или удалена.
            this.eVENTTableAdapter.Fill(this.user2DataSet.EVENT);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EDUCATION_FORM". При необходимости она может быть перемещена или удалена.
            this.eDUCATION_FORMTableAdapter.Fill(this.user2DataSet.EDUCATION_FORM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.DISCIPLINE". При необходимости она может быть перемещена или удалена.
            this.dISCIPLINETableAdapter.Fill(this.user2DataSet.DISCIPLINE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACTIVITY_EMPLOYEE". При необходимости она может быть перемещена или удалена.
            this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACCESS_LEVEL". При необходимости она может быть перемещена или удалена.
            this.aCCESS_LEVELTableAdapter.Fill(this.user2DataSet.ACCESS_LEVEL);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
            string connectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True;";
            string query = "SELECT DATENAME(MONTH, [Event_Data]) AS [Месяц], COUNT(*) AS Количество FROM EVENT GROUP BY DATENAME(MONTH, [Event_Data]) ORDER BY DATENAME(MONTH, [Event_Data]);";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable(); // Создание таблицы
            dataAdapter.Fill(table); // Заполнение таблицы данными из запроса


            chart2.DataSource = table; // Установка источника данных для графика
            chart2.Series["Series1"].XValueMember = "Месяц";
            chart2.Series["Series1"].YValueMembers = "Количество";
            chart2.Titles.Add("Количество методических активностей по месяцам");
            chart2.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series["Series1"].Color = Color.MediumPurple;
            chart2.Series["Series1"].IsVisibleInLegend = false;
            chart2.DataBind();

            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EDUCATION_FORM". При необходимости она может быть перемещена или удалена.
            this.eDUCATION_FORMTableAdapter.Fill(this.user2DataSet.EDUCATION_FORM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACTIVITY_EMPLOYEE". При необходимости она может быть перемещена или удалена.
            this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "usersAuthDataSet.USERS". При необходимости она может быть перемещена или удалена.


            //var series1 = new Series();
            //series1.ChartType = SeriesChartType.Pie;

            //var mansPoint = new DataPoint(1, mans.Length);
            //mansPoint.Color = Color.Blue;
            //mansPoint.Label = "Мужчин: - " + mans.Length;
            //mansPoint.LabelForeColor = Color.White;
            //series1.Points.Add(mansPoint);

            //var womansPoint = new DataPoint(1, woman.Length);
            //womansPoint.Color = Color.LightPink;
            //womansPoint.Label = "Женщин: - " + woman.Length;
            //womansPoint.LabelForeColor = Color.White;
            //series1.Points.Add(womansPoint);

            //chartForEdForm.Series.Add(series1);

            var f1 = user2DataSet.ACTIVITY_EMPLOYEE.Select("EducationForm_ID = 5");
            var f2 = user2DataSet.ACTIVITY_EMPLOYEE.Select("EducationForm_ID = 6");
            var f3 = user2DataSet.ACTIVITY_EMPLOYEE.Select("EducationForm_ID = 7");
            var f4 = user2DataSet.ACTIVITY_EMPLOYEE.Select("EducationForm_ID = 8");
            var series2 = new Series();
            series2.ChartType = SeriesChartType.Pie;

            var f1Point = new DataPoint(1, f1.Length);
            f1Point.Color = Color.Blue;
            f1Point.Label = "Очная - " + f1.Length;
            f1Point.LabelForeColor = Color.White;
            series2.Points.Add(f1Point);

            var f2Point = new DataPoint(1, f2.Length);
            f2Point.Color = Color.Lavender;
            f2Point.Label = "Заочная - " + f2.Length;
            f2Point.LabelForeColor = Color.Black;
            series2.Points.Add(f2Point);

            var f3Point = new DataPoint(1, f3.Length);
            f3Point.Color = Color.Green;
            f3Point.Label = "Дистанционная - " + f3.Length;
            f3Point.LabelForeColor = Color.Black;
            series2.Points.Add(f3Point);

            var f4Point = new DataPoint(1, f4.Length);
            f4Point.Color = Color.LightPink;
            f4Point.Label = "Вечерняя - " + f4.Length;
            f4Point.LabelForeColor = Color.Black;
            series2.Points.Add(f4Point);
            chart1.Series.Add(series2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartForEdForm.DataBind();
            //panel1.Width = +200;
            TogglePanel();
        }
        private void TogglePanel()
        {
            if (isPanelExpanded)
            {
                panel1.Width = 0;
                isPanelExpanded = false;
                this.Width = 710;
            }
            else
            {
                panel1.Width = 380;
                isPanelExpanded = true;
                this.Width = 1090;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Изображения (*.png)|*.png|Все файлы (*.*)|*.*";
            saveDialog.FilterIndex = 1; // Выберите первый фильтр (изображения)

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите выбранный путь и имя файла
                string filePath = saveDialog.FileName;

                // Сохраните график в выбранное место
                chartForEdForm.SaveImage(filePath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                MessageBox.Show("График сохранен по пути: " + filePath, "Сохранение графика", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Изображения (*.png)|*.png|Все файлы (*.*)|*.*";
            saveDialog.FilterIndex = 1; // Выберите первый фильтр (изображения)

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите выбранный путь и имя файла
                string filePath = saveDialog.FileName;

                // Сохраните график в выбранное место
                chart2.SaveImage(filePath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                MessageBox.Show("График сохранен по пути: " + filePath, "Сохранение графика", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Изображения (*.png)|*.png|Все файлы (*.*)|*.*";
            saveDialog.FilterIndex = 1; // Выберите первый фильтр (изображения)

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Получите выбранный путь и имя файла
                string filePath = saveDialog.FileName;

                // Сохраните график в выбранное место
                chart1.SaveImage(filePath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                MessageBox.Show("График сохранен по пути: " + filePath, "Сохранение графика", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dbConnectionString = "Server=PR59\\SQLEXPRESS;Database=user2;User Id=user2;Password=212345;"; // Замените на фактическую строку подключения

            //TestClass.MethodicalCodeValidator.TeacherCounter teacherCounter = new MethodicalCodeValidator.TeacherCounter(dbConnectionString);
            //int teacherCount = teacherCounter.GetTeacherCount();
        }


        private void wORKERDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            chartForEdForm.DataBind();
            //panel1.Width = +200;
            TogglePanel();
        }
    }
}
