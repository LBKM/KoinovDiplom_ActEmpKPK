﻿using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class ActEmpPageViewForm : Form
    {
        int pageSize = 2, pageNumber = 0;
        public ActEmpPageViewForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ActEmpPageViewForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
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
            this.aCTIVITY_EMPLOYEETableAdapter.ActEmpFillByPageView(this.user2DataSet.ACTIVITY_EMPLOYEE, pageNumber, pageSize);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACCESS_LEVEL". При необходимости она может быть перемещена или удалена.
            this.aCCESS_LEVELTableAdapter.Fill(this.user2DataSet.ACCESS_LEVEL);
            ComboBoxEducationForm.Items.Clear();
            foreach (DataRow Row_WP in user2DataSet.EDUCATION_FORM.Rows) ComboBoxEducationForm.Items.Add(Row_WP["Education_Form"]);
            FillActEmpListPageView();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (pageNumber > 0)
            {
                pageNumber--;
                FillActEmpListPageView();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            pageNumber++;
            FillActEmpListPageView();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == null)
            {
                TextBox1.Text = "";
            }

            string strFindMDK = TextBox1.Text;
            this.aCTIVITY_EMPLOYEETableAdapter.ActEmpFillByPageView(this.user2DataSet.ACTIVITY_EMPLOYEE, pageNumber, pageSize);
            MainListViewActEmpPage.Items.Clear();
            try
            {
                foreach (DataRow Row in this.user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID LIKE '%" + strFindMDK + "*'"))
                {
                    string[] items = new string[10];
                    DataRow TempRow;
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_DISCIPLINE");
                    items[1] = TempRow[1].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_WORKER");
                    items[2] = TempRow["Name"].ToString();
                    items[3] = TempRow["Surname"].ToString();
                    items[4] = TempRow["Lastname"].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EDUCATION_FORM");
                    items[5] = TempRow["Education_Form"].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_SPECIALITY");
                    items[6] = TempRow["Name"].ToString();
                    items[7] = Row[4].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EVENT");
                    items[8] = TempRow["Name"].ToString();
                    ListViewItem it = new ListViewItem();
                    it.Text = Row["ActEmp_ID"].ToString();
                    it.SubItems.AddRange(items);
                    MainListViewActEmpPage.Items.Add(it);
                }
                label5.Text = "СТРАНИЦА: " + pageNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Введите данные для поиска", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ComboBoxEducationForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.aCTIVITY_EMPLOYEETableAdapter.ActEmpFillByPageView(this.user2DataSet.ACTIVITY_EMPLOYEE, pageNumber, pageSize);
            MainListViewActEmpPage.Items.Clear();
            foreach (DataRow Row in this.user2DataSet.ACTIVITY_EMPLOYEE.Rows)
            {
                DataRow RowFilter_WP = user2DataSet.EDUCATION_FORM.Select("Education_Form = '" + ComboBoxEducationForm.SelectedItem + "'")[0];
                if (Convert.ToString(Row["EducationForm_ID"]) == Convert.ToString(RowFilter_WP["Form_ID"]))
                {
                    string[] items = new string[10];
                    DataRow TempRow;
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_DISCIPLINE");
                    items[1] = TempRow[1].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_WORKER");
                    items[2] = TempRow["Name"].ToString();
                    items[3] = TempRow["Surname"].ToString();
                    items[4] = TempRow["Lastname"].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EDUCATION_FORM");
                    items[5] = TempRow["Education_Form"].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_SPECIALITY");
                    items[6] = TempRow["Name"].ToString();
                    items[7] = Row[4].ToString();
                    TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EVENT");
                    items[8] = TempRow["Name"].ToString();
                    ListViewItem it = new ListViewItem();
                    it.Text = Row["ActEmp_ID"].ToString();
                    it.SubItems.AddRange(items);
                    MainListViewActEmpPage.Items.Add(it);
                }
                label5.Text = "СТРАНИЦА: " + pageNumber;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ComboBoxEducationForm.Items.Clear();
            foreach (DataRow Row_WP in user2DataSet.EDUCATION_FORM.Rows) ComboBoxEducationForm.Items.Add(Row_WP["Education_Form"]);
            TextBox1.Text = "";

            MainListViewActEmpPage.Items.Clear();

            DataManager dataManager = new DataManager(user2DataSet, MainListViewActEmpPage, label5);
            dataManager.FillActEmpList();
        }

        void FillActEmpListPageView()
        {
            this.aCTIVITY_EMPLOYEETableAdapter.ActEmpFillByPageView(this.user2DataSet.ACTIVITY_EMPLOYEE, pageNumber, pageSize);
            MainListViewActEmpPage.Items.Clear();
            foreach (DataRow Row in this.user2DataSet.ACTIVITY_EMPLOYEE)
            {
                string[] items = new string[10];
                DataRow TempRow;
                TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_DISCIPLINE");
                items[1] = TempRow[1].ToString();
                TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_WORKER");
                items[2] = TempRow["Name"].ToString();
                items[3] = TempRow["Surname"].ToString();
                items[4] = TempRow["Lastname"].ToString();
                TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EDUCATION_FORM");
                items[5] = TempRow["Education_Form"].ToString();
                TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_SPECIALITY");
                items[6] = TempRow["Name"].ToString();
                items[7] = Row[4].ToString();
                TempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EVENT");
                items[8] = TempRow["Name"].ToString();
                ListViewItem it = new ListViewItem();
                it.Text = Row["ActEmp_ID"].ToString();
                it.SubItems.AddRange(items);
                MainListViewActEmpPage.Items.Add(it);
            }
            label5.Text = "СТРАНИЦА: " + pageNumber;
        }
    }
}
