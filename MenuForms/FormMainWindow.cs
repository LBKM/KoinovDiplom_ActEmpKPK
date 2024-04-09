using KoinovDiplom_ActEmpKPK.user2DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KoinovDiplom_ActEmpKPK.MenuForms
{
    partial class FormMainWindow : Form
    {
        ListViewItem LastSelectedItem;
        DataRow CurrentRow;
        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
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
            this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACCESS_LEVEL". При необходимости она может быть перемещена или удалена.
            this.aCCESS_LEVELTableAdapter.Fill(this.user2DataSet.ACCESS_LEVEL);
            FillActEmpList();

        }

        void FillActEmpList()
        {
            MainListViewActEmp.Items.Clear();
            foreach (DataRow Row in user2DataSet.ACTIVITY_EMPLOYEE.Rows)
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
                MainListViewActEmp.Items.Add(it);
            }
            Countlabel.Text = $"{MainListViewActEmp.Items.Count} из {user2DataSet.ACTIVITY_EMPLOYEE.Rows.Count}";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddOrChangeActEmp dialog = new AddOrChangeActEmp(CurrentRow);
            dialog.AddOrChange = false;
            dialog.ShowDialog();
            if (MainListViewActEmp.SelectedItems.Count > 0 && MainListViewActEmp.SelectedItems[0].SubItems.Count > 0)
            {
                string actEmpID = MainListViewActEmp.SelectedItems[0].SubItems[0].Text;

                // Проверяем, чтобы избежать выхода за пределы массива
                if (!string.IsNullOrEmpty(actEmpID))
                {
                    DataRow[] selectedRows = user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID = '" + actEmpID + "'");

                    if (selectedRows.Length > 0)
                    {
                        DataRow currentRow = selectedRows[0];
                        //Добавление записи
                        DataRow CurrentRow = user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID = '" + MainListViewActEmp.SelectedItems[0].SubItems[0].Text + "'")[0];
                        AddOrChangeActEmp dialogп = new AddOrChangeActEmp(CurrentRow);
                        dialogп.AddOrChange = false; 
                        dialogп.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK) 
                        { FillActEmpList(); }
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            DataRow[] RowsActEmp;
            foreach (ListViewItem item in MainListViewActEmp.CheckedItems)
            {
                DialogResult reslt = MessageBox.Show("Вы действительно хотите удалить выделенные объекты? ", "Предупреждение!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (reslt == DialogResult.OK)
                {
                    RowsActEmp = user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID = '" + item.Text + "'");
                    aCTIVITY_EMPLOYEETableAdapter.Delete(Convert.ToString(RowsActEmp[0][0]), Convert.ToInt32(RowsActEmp[0][1]), Convert.ToInt32(RowsActEmp[0][2]), Convert.ToInt32(RowsActEmp[0][3]), Convert.ToInt32(RowsActEmp[0][4]), Convert.ToString(RowsActEmp[0][5]), Convert.ToInt32(RowsActEmp[0][6]));
                    LastSelectedItem.Remove();
                    MessageBox.Show("Успешное удаление!", "Процесс удаления: 100%", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.aCTIVITY_EMPLOYEETableAdapter.Fill(user2DataSet.ACTIVITY_EMPLOYEE);
        }

        private void ListViewActEmp_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LastSelectedItem = e.Item;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddOrChangeActEmp dialog = new AddOrChangeActEmp(CurrentRow);
            dialog.AddOrChange = false;
            dialog.ShowDialog();
            if (MainListViewActEmp.SelectedItems.Count > 0 && MainListViewActEmp.SelectedItems[0].SubItems.Count > 0)
            {
                string actEmpID = MainListViewActEmp.SelectedItems[0].SubItems[0].Text;

                // Проверяем, чтобы избежать выхода за пределы массива
                if (!string.IsNullOrEmpty(actEmpID))
                {
                    DataRow[] selectedRows = user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID = '" + actEmpID + "'");

                    if (selectedRows.Length > 0)
                    {
                        DataRow currentRow = selectedRows[0];
                        //Добавление записи
                        DataRow CurrentRow = user2DataSet.ACTIVITY_EMPLOYEE.Select("ActEmp_ID = '" + MainListViewActEmp.SelectedItems[0].SubItems[0].Text + "'")[0];
                        AddOrChangeActEmp dialogп = new AddOrChangeActEmp(CurrentRow);
                        dialogп.AddOrChange = false;
                        dialogп.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK)
                        { FillActEmpList(); }
                    }
                }
            }
        }
    }
}
