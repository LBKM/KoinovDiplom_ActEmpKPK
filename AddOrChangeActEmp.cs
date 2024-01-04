using KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class AddOrChangeActEmp : Form
    {
        public AddOrChangeActEmp()
        {
            InitializeComponent();
        }

        private void wORKERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wORKERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.user2DataSet);

        }

        private void AddOrChangeActEmp_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.SPECIALITY". При необходимости она может быть перемещена или удалена.
            this.sPECIALITYTableAdapter.Fill(this.user2DataSet.SPECIALITY);
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            foreach (DataRow Row_group in user2DataSet.DISCIPLINE.Rows) ComboBoxDiscipline.Items.Add(Row_group["Name"]);
            foreach (DataRow Row_WP in user2DataSet.WORKER) ComboBoxWorker.Items.Add(Row_WP["Worker_ID"]);
            foreach (DataRow Row_PM in user2DataSet.EDUCATION_FORM.Rows) ComboBoxEducationForm.Items.Add(Row_PM["Education_Form"]);
            foreach (DataRow Row_group in user2DataSet.SPECIALITY.Rows) ComboBoxSpeciality.Items.Add(Row_group["Name"]);
            foreach (DataRow Row_WP in user2DataSet.EVENT) ComboBoxEvent.Items.Add(Row_WP["Name"]);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //    var cn = new OleDbConnection();
            //    cn.ConnectionString = Properties.Settings.Default.ConnectionStringKUMO;
            //    cn.Open();
            //    var sql = new OleDbCommand("SELECT COUNT(*) FROM ACTIVITY_EMPLOYEE WHERE ActEmp_ID = '" + TextBoxActEmpID.Text + "'", cn); // текст запроса
            //    int UserExist = Convert.ToInt32(sql.ExecuteScalar());
            //    if (UserExist > 0)
            //    {

            //    }
            //        int InsertedRows = ACTIVITY_EMPLOYEETableAdapter.Insert(TextBoxActEmpID.Text, ComboBoxDiscipline.Text, TB_Name_WP.Text, DateAddPicker.Value);
            //        if (InsertedRows == 0) //ставим условие, если кол-во строк было равно нулю, значит запись не добавилась
            //        {
            //            dialog.label_Reslt.Text = "Не удалось добавить\nрабочую программу";
            //            dialog.ShowDialog();
            //        }
            //        else //если удалось, вывод сообщения
            //        {
            //            dialogSuc.label_Reslt.Text = "Рабочая программа\nуспешно добавлена";
            //            dialogSuc.ShowDialog();
            //        }
            //        this.wORK_PROGRAMTableAdapter.Fill(this.kUMO_DataSet.WORK_PROGRAM);
            //    }
            //    DialogResult = DialogResult.OK;
            //    foreach (DataRow Row_WP in kUMO_DataSet.WORK_PROGRAM) CB_WP.Items.Add(Row_WP["Index_WorkProg"]);
            //}
            //cn.Close();
        }
    }
}
