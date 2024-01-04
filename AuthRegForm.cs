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
using Guna.UI2.WinForms;


namespace KoinovDiplom_ActEmpKPK
{
    public partial class AuthRegForm : Form
    {
        private Timer timer;
        public AuthRegForm()
        {
            InitializeComponent();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            helpLabel.Visible = true;
            timer.Stop();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonAuth_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True;";
            string login = TextBoxLoginAuth.Text;
            string password = TextBoxPasswpordAuth.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE Login = @Login AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();
                {
                    //checkBox1.Checked = false;
                    if (count > 0)
                    {
                        //MessageBox.Show("ЧОООООООООООООО это вернае имя пользователя или пароль.");
                        MainMenuForm dialog = new MainMenuForm();
                        MessageDialog dialog1 = new MessageDialog();
                        dialog1.ShowDialog();
                        this.Hide(); // Скрыть текущую форму
                        dialog.ShowDialog();
                        this.Close(); // Закрыть текущую форму, когда новая форма закрыта
                    }
                    else
                    {
                        // Неверные учетные данные.
                        UnsuccesDialogcs dialog1 = new UnsuccesDialogcs();
                        dialog1.ShowDialog();
                        MessageBox.Show("Неверное имя пользователя или пароль.");
                        MessageBox.Show("подсказка админа: admin, adminpass");
                    }
                }
            }
        }

        private void CheckBoxKeyGen_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxKeyGen.Checked)
            {
                string generatedPassword = GeneratePassword();
                TextBoxRegPassword.Text = generatedPassword;
            }
        }
        private string GeneratePassword()
        {
            // Создание экземпляра Random для генерации случайных чисел
            Random random = new Random();

            // Допустимые символы для пароля (заглавные буквы, строчные буквы и цифры)
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // Длина пароля (от 8 до 15 символов)
            int passwordLength = random.Next(8, 16);

            // Генерация пароля
            char[] password = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = allowedChars[random.Next(allowedChars.Length)];
            }

            // Преобразование символов пароля в строку
            return new string(password);
        }

        private void CheckBoxChowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxChowPass.Checked)
            {
                TextBoxRegPassword.UseSystemPasswordChar = false;
                TextBoxRegConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TextBoxRegPassword.UseSystemPasswordChar = true;
                TextBoxRegConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox3.Checked)
            {
                TextBoxPasswpordAuth.UseSystemPasswordChar = false;
            }
            else
            {
                TextBoxPasswpordAuth.UseSystemPasswordChar = true;
            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            FormAboutProgram dialog1 = new FormAboutProgram();
            dialog1.ShowDialog();
        }
        private async void ShowHelpLabelAsync()
        {
            // Отображение Label
            helpLabel.Visible = true;

            // Ожидание 3 секунд
            await Task.Delay(3000);

            // Скрытие Label после ожидания
            helpLabel.Visible = false;
        }

        private void AuthRegForm_Load(object sender, EventArgs e)
        {
            // Инициализация компонентов и добавление Label на вашу форму
            helpLabel.Text = "справка о приложении ->";
            helpLabel.AutoSize = true;
            helpLabel.Visible = false;
            this.Controls.Add(helpLabel);

            // Запуск асинхронного метода
            ShowHelpLabelAsync();
        }

        private void ButtonVerification_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Enabled = true;
        }
    }
}