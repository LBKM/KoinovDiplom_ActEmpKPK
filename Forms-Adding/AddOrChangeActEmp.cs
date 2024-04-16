using Guna.UI2.WinForms;
using KoinovDiplom_ActEmpKPK.MenuForms;
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
        DataRow newRow;
        public bool AddOrChange; 
        public string imagePath, MainImagePath;

        public Guna2TextBox TextBoxActEmpIDGet { get { return TextBoxActEmpID; } }
        public Guna2ComboBox ComboBoxDisciplineGet { get { return ComboBoxDiscipline; } }
        public Guna2ComboBox ComboBoxWorkerGet { get { return ComboBoxWorker; } }
        public Guna2ComboBox ComboBoxEducationFormGet { get { return ComboBoxEducationForm; } }
        public Guna2ComboBox ComboBoxSpecialityGet { get { return ComboBoxSpeciality; } }
        public Guna2ComboBox ComboBoxEventGet { get { return ComboBoxEvent; } }
        public Guna2TextBox TextBoxNameAetEmpGet { get { return TextBoxNameAetEmp; } }
        public Guna2DateTimePicker EventDateTimePickerGet { get { return EventDateTimePicker; } }

        public AddOrChangeActEmp(DataRow OldRow)
        {
            InitializeComponent();
            newRow = OldRow;
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
            DataRow[] Rows;

            DataRow[] RowsDiscipline;
            string Discipline;
            RowsDiscipline  = this.user2DataSet.DISCIPLINE.Select("Name = '" + ComboBoxDiscipline.Text + "'");
            if (RowsDiscipline.Length == 0)
            {
                this.dISCIPLINETableAdapter.Insert(ComboBoxDiscipline.Text);
                this.dISCIPLINETableAdapter.Fill(this.user2DataSet.DISCIPLINE);
                RowsDiscipline = this.user2DataSet.DISCIPLINE.Select("Name = '" + ComboBoxDiscipline.Text + "'");
                Discipline = Convert.ToString(RowsDiscipline[0]["Discipline_ID"]);
            }
            else
            {
                Discipline = Convert.ToString(RowsDiscipline[0]["Discipline_ID"]);
            }

            DataRow[] RowsWorker;
            string Worker;
            RowsWorker = this.user2DataSet.WORKER.Select("Worker_ID = '" + ComboBoxWorker.Text + "'");
            
                Worker = Convert.ToString(RowsWorker[0]["Worker_ID"]);


            DataRow[] RowsEducationForm;
            string EducationForm;
            RowsEducationForm = this.user2DataSet.EDUCATION_FORM.Select("Education_Form = '" + ComboBoxEducationForm.Text + "'");
            if (RowsEducationForm.Length == 0)
            {
                this.eDUCATION_FORMTableAdapter.Insert(ComboBoxEducationForm.Text);
                this.eDUCATION_FORMTableAdapter.Fill(this.user2DataSet.EDUCATION_FORM);
                RowsEducationForm = this.user2DataSet.EDUCATION_FORM.Select("Education_Form = '" + ComboBoxEducationForm.Text + "'");
                EducationForm = Convert.ToString(RowsEducationForm[0]["Form_ID"]);
            }
            else
            {
                EducationForm = Convert.ToString(RowsEducationForm[0]["Form_ID"]);
            }

            DataRow[] RowsSpeciality;
            string Speciality;
            RowsSpeciality = this.user2DataSet.SPECIALITY.Select("Name = '" + ComboBoxSpeciality.Text + "'");
            if (RowsSpeciality.Length == 0)
            {
                this.sPECIALITYTableAdapter.Insert(ComboBoxSpeciality.Text);
                this.sPECIALITYTableAdapter.Fill(this.user2DataSet.SPECIALITY);
                RowsSpeciality = this.user2DataSet.SPECIALITY.Select("Name = '" + ComboBoxSpeciality.Text + "'");
                Speciality = Convert.ToString(RowsSpeciality[0]["Speciality_ID"]);
            }
            else
            {
                Speciality = Convert.ToString(RowsSpeciality[0]["Speciality_ID"]);
            }

            DataRow[] RowsEvent;
            string Event;
            RowsEvent = this.user2DataSet.EVENT.Select("Name = '" + ComboBoxEvent.Text + "'");
            if (RowsEvent.Length == 0)
            {
                this.eVENTTableAdapter.Insert(ComboBoxEvent.Text, EventDateTimePicker.Value);
                this.eVENTTableAdapter.Fill(this.user2DataSet.EVENT);
                RowsEvent = this.user2DataSet.EVENT.Select("Name = '" + ComboBoxEvent.Text + "'");
                Event = Convert.ToString(RowsEvent[0]["Event_ID"]);
            }
            else
            {
                Event = Convert.ToString(RowsEvent[0]["Event_ID"]);
            }

            int InsertedRows = aCTIVITY_EMPLOYEETableAdapter.Insert( //Добавление данных в БД через поля приложения:
                TextBoxActEmpID.Text, 
                Convert.ToInt32(Discipline), 
                Convert.ToInt32(Worker), 
                Convert.ToInt32(EducationForm), 
                Convert.ToInt32(Speciality), 
                TextBoxNameAetEmp.Text, 
                Convert.ToInt32(Event));

            try
            {
                if (InsertedRows > 0) 
                MessageBox.Show("Успешное добавление!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (InsertedRows == 0)
                    // Если произошла ошибка, отобразите сообщение об ошибке
                    MessageBox.Show("Не удалось добавить рабочую программу. Причина: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
