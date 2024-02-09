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
    public partial class FormForClass : Form
    {
        public FormForClass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredCode = textBox1.Text;

            MethodicalCodeValidator validator = new MethodicalCodeValidator();
            if (validator.IsValidMethodicalCode(enteredCode))
            {
                MessageBox.Show("Код методической активности правильный.", "Успех");
            }
            else
            {
                MessageBox.Show("Неправильный код методической активности. Пример правильного кода: 01.24.21", "Ошибка");
            }
        }

        private void FormForClass_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);

        }
    }
}
