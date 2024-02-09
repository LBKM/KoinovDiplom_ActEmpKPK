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
using KoinovDiplom_ActEmpKPK.Dialogs_Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public partial class AuthRegForm : Form
    {
        private Timer timer;
        private string text = string.Empty;
        public AuthRegForm()
        {
            InitializeComponent();
        }
        private Bitmap CreateImage(int width, int height)
        {
            // создание рандома 
            Random rnd = new Random();
            //Создание изображение
            Bitmap result = new Bitmap(Width, Height);
            //Вычислим позицию текста
            int iHeight = 80;
            int iWidth = 300;
            int Xpos = rnd.Next(iWidth);
            int Ypos = rnd.Next(iHeight);
            //Добавим различные цвета для вывода текста 
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };
            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);
            //Пусть фон картинки будет серым
            g.Clear(Color.White);
            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            for (int i = 0; i < 6; ++i)
                text += ALF[rnd.Next(ALF.Length)];
            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Century Gothic", 90),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));
            // немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);
            return result;
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
            string[] connectionStrings = new string[]
            {
        "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True;",
        "Server=PR59\\SQLEXPRESS;Database=user2;User Id=user2;Password=212345;"
            };

            string login = TextBoxLoginAuth.Text;
            string password = TextBoxPasswpordAuth.Text;

            bool success = false; // Флаг, указывающий на успешное подключение

            foreach (string connectionString in connectionStrings)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(*) FROM [User] WHERE Login = @Login AND Password = @Password";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = (int)command.ExecuteScalar();

                        // Если учетные данные верны
                        if (count > 0)
                        {
                            // Установить флаг успеха
                            success = true;
                            // Открыть главное меню
                            MainMenuForm dialog = new MainMenuForm();
                            this.Hide();
                            dialog.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверное имя пользователя или пароль.");
                            MessageBox.Show("Подсказка администратора: admin, adminpass");
                        }
                    }

                    // Если подключение и выполнение запроса прошло успешно, выйти из цикла
                    if (success)
                        break;
                }
                catch (Exception ex)
                {
                    // Обработка исключений при подключении к базе данных
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
            }

            // Если не удалось подключиться к ни одной базе данных
            if (!success)
            {
                MessageBox.Show("Не удалось подключиться к базе данных.");
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pictureBoxCode.Image = this.CreateImage(pictureBoxCode.Width, pictureBoxCode.Height);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text == this.text)
            {
                ButtonReg.Enabled = true;
                tabControl1.Visible = false;
                textBoxCode.Clear();
            }
            else
            {
                UnsuccessCaptcha unsuccessCaptcha = new UnsuccessCaptcha();
                unsuccessCaptcha.ShowDialog();
                pictureBoxCode.Image = this.CreateImage(pictureBoxCode.Width, pictureBoxCode.Height); textBoxCode.Clear();
            }
        }
    }
}