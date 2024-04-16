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
    public partial class AllTablesForm : Form
    {
        public AllTablesForm()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aCCESS_LEVELBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aCCESS_LEVELBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.user2DataSet);

        }

        private void AllTablesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
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

        }
    }
}
