using KoinovDiplom_ActEmpKPK.QueryForms;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using LicenseContext = OfficeOpenXml.LicenseContext;



namespace KoinovDiplom_ActEmpKPK
{

    public partial class MoreMenuForm : Form
    {
        public MoreMenuForm()
        {
            InitializeComponent();
        }

        private void wORKERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wORKERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.user2DataSet);

        }

        private void MoreMenuForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACCESS_LEVEL". При необходимости она может быть перемещена или удалена.
            this.aCCESS_LEVELTableAdapter.Fill(this.user2DataSet.ACCESS_LEVEL);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EDUCATION_FORM". При необходимости она может быть перемещена или удалена.
            this.eDUCATION_FORMTableAdapter.Fill(this.user2DataSet.EDUCATION_FORM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.DISCIPLINE". При необходимости она может быть перемещена или удалена.
            this.dISCIPLINETableAdapter.Fill(this.user2DataSet.DISCIPLINE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.SPECIALITY". При необходимости она может быть перемещена или удалена.
            this.sPECIALITYTableAdapter.Fill(this.user2DataSet.SPECIALITY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT_MATERIALS". При необходимости она может быть перемещена или удалена.
            this.eVENT_MATERIALSTableAdapter.Fill(this.user2DataSet.EVENT_MATERIALS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT". При необходимости она может быть перемещена или удалена.
            this.eVENTTableAdapter.Fill(this.user2DataSet.EVENT);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True";
            connection.Open();
            SqlCommand sql = new SqlCommand("SELECT Worker.Worker_ID, Worker.Name, Worker.Surname, Worker.Lastname, Post.Name FROM Post INNER JOIN Worker ON Post.Post_ID = Worker.Post_ID WHERE Post.Name = 'Преподаватель';", connection);
            SqlDataAdapter da = new SqlDataAdapter();
            System.Data.DataTable DataSqlTable = new System.Data.DataTable();
            da.SelectCommand = sql;
            da.Fill(DataSqlTable);
            connection.Close();
            WorkersGridViewForm workersGridViewForm = new WorkersGridViewForm();
            workersGridViewForm.guna2DataGridView1.DataSource = DataSqlTable;
            workersGridViewForm.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AllTablesForm allTablesForm = new AllTablesForm();
            allTablesForm.ShowDialog();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True";
            connection.Open();
            SqlCommand sql = new SqlCommand("SELECT ACTIVITY_EMPLOYEE.ActEmp_ID, " +
                "DISCIPLINE.Name, " +
                "WORKER.Name, " +
                "WORKER.Surname, " +
                "WORKER.Lastname, " +
                "EDUCATION_FORM.Education_Form, " +
                "SPECIALITY.Name, " +
                "EVENT.Name, " +
                "ACTIVITY_EMPLOYEE.Description, " +
                "EVENT.Event_Data " +
                "FROM WORKER INNER JOIN (SPECIALITY " +
                "INNER JOIN (EVENT INNER JOIN (EDUCATION_FORM INNER JOIN (DISCIPLINE " +
                "INNER JOIN ACTIVITY_EMPLOYEE ON DISCIPLINE.Discipline_ID = ACTIVITY_EMPLOYEE.Discipline_ID) " +
                "ON EDUCATION_FORM.Form_ID = ACTIVITY_EMPLOYEE.EducationForm_ID) " +
                "ON EVENT.Event_ID = ACTIVITY_EMPLOYEE.Event_ID) " +
                "ON SPECIALITY.Speciality_ID = Activity_Employee.Speciality_ID) " +
                "ON WORKER.Worker_ID = ACTIVITY_EMPLOYEE.Worker_ID " +
                "WHERE (((EDUCATION_FORM.Education_Form)='Очная'));", connection);
            SqlDataAdapter da = new SqlDataAdapter();
            System.Data.DataTable DataSqlTable = new System.Data.DataTable();
            da.SelectCommand = sql;
            da.Fill(DataSqlTable);
            connection.Close();
            WorkersGridViewForm workersGridViewForm = new WorkersGridViewForm();
            workersGridViewForm.guna2DataGridView1.DataSource = DataSqlTable;
            workersGridViewForm.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                // Создаем новый лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ACTIVITY_EMPLOYEE");

                // Задаем заголовки столбцов
                worksheet.Cells[1, 1].Value = "ActEmp_ID";
                worksheet.Cells[1, 2].Value = "Discipline_ID";
                worksheet.Cells[1, 3].Value = "Worker_ID";
                worksheet.Cells[1, 4].Value = "EducationForm_ID";
                worksheet.Cells[1, 5].Value = "Speciality_ID";
                worksheet.Cells[1, 6].Value = "Description";
                worksheet.Cells[1, 7].Value = "Event_ID";

                // Получаем данные из таблицы ACTIVITY_EMPLOYEE
                string connectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True";
                string query = "SELECT * FROM ACTIVITY_EMPLOYEE";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                System.Data.DataTable table = new System.Data.DataTable();
                adapter.Fill(table);

                // Выводим данные в эксель документ
                int rowIndex = 2;
                foreach (DataRow row in table.Rows)
                {
                    worksheet.Cells[rowIndex, 1].Value = row["ActEmp_ID"];
                    worksheet.Cells[rowIndex, 2].Value = row["Discipline_ID"];
                    worksheet.Cells[rowIndex, 3].Value = row["Worker_ID"];
                    worksheet.Cells[rowIndex, 4].Value = row["EducationForm_ID"];
                    worksheet.Cells[rowIndex, 5].Value = row["Speciality_ID"];
                    worksheet.Cells[rowIndex, 6].Value = row["Description"];
                    worksheet.Cells[rowIndex, 7].Value = row["Event_ID"];
                    rowIndex++;
                }

                // Сохраняем эксель документ
                string filePath = "ACTIVITY_EMPLOYEE.xlsx";
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);

            }


        }
    }
}
