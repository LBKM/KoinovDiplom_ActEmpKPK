using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class DatabaseConnectionCheckForm : Form
    {
        public DatabaseConnectionCheckForm()
        {
            InitializeComponent();
        }

        private void DatabaseConnectionCheckForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
                // Установить таймаут подключения (в секундах)
                int timeout = 5;

                try
                {
                    // Открыть подключение к базе данных
                    using (SqlConnection connection = new SqlConnection("Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True;"))
                    {
                        connection.Open();

                        // Проверить состояние подключения
                        if (connection.State == ConnectionState.Open)
                        {
                            // Измерить время отклика
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            var command = new SqlCommand("SELECT 1", connection);
                            command.ExecuteScalar();
                            stopwatch.Stop();
                            long responseTime = stopwatch.ElapsedMilliseconds;
                            guna2PictureBox1.Visible = true;
                            // Вывести результат
                            label1.Visible = true;
                            label3.Visible = true;
                            label3.Text = $"Время отклика: {responseTime} мс.";
                        }
                        else
                        {
                            label2.Visible = true;
                            guna2PictureBox2.Visible = true;
                            // Вывести сообщение об ошибке
                            MessageBox.Show($"Подключение к базе данных не установлено.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Вывести сообщение об ошибке
                    MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
