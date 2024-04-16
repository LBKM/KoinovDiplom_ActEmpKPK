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

namespace KoinovDiplom_ActEmpKPK
{
    public partial class ConnectionStringDialog : Form
    {

        string connectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True;";
        public ConnectionStringDialog()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label1.Text = connectionString;
        }

        private void ConnectionStringDialog_Load(object sender, EventArgs e)
        {
            label1.Text = connectionString;
        }
    }
}
