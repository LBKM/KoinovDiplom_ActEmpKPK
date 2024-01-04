using KoinovDiplom_ActEmpKPK.MenuForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class FormReportsNCharts : Form
    {
        public FormReportsNCharts()
        {
            InitializeComponent();
        }
        private Form acriveForm = null;
        private void openForm(Form childForm)
        {
            if (acriveForm != null)
                acriveForm.Close();
            acriveForm = childForm;
            childForm.TopLevel = false; childForm.FormBorderStyle = FormBorderStyle.None; childForm.Dock = DockStyle.Fill;
            Panel1.Controls.Add(childForm);
            Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void FormReportsNCharts_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openForm(new FormChartsView());
        }
    }
}
