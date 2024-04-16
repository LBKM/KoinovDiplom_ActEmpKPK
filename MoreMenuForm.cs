using KoinovDiplom_ActEmpKPK.QueryForms;
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
            DataTable DataSqlTable = new DataTable();
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
            DataTable DataSqlTable = new DataTable();
            da.SelectCommand = sql;
            da.Fill(DataSqlTable);
            connection.Close();
            WorkersGridViewForm workersGridViewForm = new WorkersGridViewForm();
            workersGridViewForm.guna2DataGridView1.DataSource = DataSqlTable;
            workersGridViewForm.ShowDialog();
        }
    }
}
