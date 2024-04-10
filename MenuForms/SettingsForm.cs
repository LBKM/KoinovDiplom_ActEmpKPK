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
    }
}
