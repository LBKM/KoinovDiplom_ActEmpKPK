using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class OperDocxForm : Form
    {
        public OperDocxForm()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OperDocxForm_Load(object sender, EventArgs e)
        {
            //// Путь к файлу документа Word
            //string filePath = @"D:\УП04.01\Документация по УП.04.01_Койнов\2.1\ГОСТ 19.505-79 руководство оператора.docx";

            //// Пароль для файла
            //string password = "mypassword";

            //// Создать поток для чтения файла
            //using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //{
            //    // Создать поток для чтения текста
            //    using (var reader = new StreamReader(stream))
            //    {
            //        // Прочитать текст из файла
            //        string text = reader.ReadToEnd();

            //        // Загрузить текст в RichTextBox
            //        richTextBox1.Rtf = text;

            //        // Установить свойство ReadOnly в true
            //        richTextBox1.ReadOnly = true;
            //    }
            //}

            string filePath = @"D:\УП04.01\Документация по УП.04.01_Койнов\2.1\ГОСТ 19.505-79 руководство оператора.docx";

            // Создать экземпляр приложения Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();

            // Открыть документ Word в режиме только для чтения
            var doc = wordApp.Documents.Open(filePath, ReadOnly: true); 

            // Отобразить документ Word в форме приложения
            wordApp.Visible = true;

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
