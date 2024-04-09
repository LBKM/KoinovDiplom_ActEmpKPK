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

namespace KoinovDiplom_ActEmpKPK.MenuForms
{
    public partial class FormLK : Form

    {
        private ClassUserInfo authorizedUser;

        public FormLK(ClassUserInfo authorizedUser)
        {
            
            this.authorizedUser = authorizedUser;
            InitializeComponent();
        }

        private void FormLK_Load(object sender, EventArgs e)
        {
            guna2TextBoxLoginUser.Text = authorizedUser.Login;
            guna2TextBoxPasswordUser.Text = authorizedUser.Password;
        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBox3.Checked)
            {
                guna2TextBoxPasswordUser.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBoxPasswordUser.UseSystemPasswordChar = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT Password FROM [User] WHERE Login = @Login";
            using (SqlConnection connection = new SqlConnection("Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=user2;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", authorizedUser.Login);
                string currentPassword = (string)command.ExecuteScalar();

                // Сравнить текущий пароль с введенным пользователем паролем
                if (currentPassword == TextBoxOldPassword.Text)
                {
                    // Обновить пароль в базе данных
                    query = "UPDATE [User] SET Password = @NewPassword WHERE Login = @Login";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewPassword", TextBoxNewPassword.Text);
                    command.Parameters.AddWithValue("@Login", authorizedUser.Login);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Пароль успешно обновлен.");
                }
                else
                {
                    MessageBox.Show("Неверный текущий пароль.");
                }
            }

        }
    }
}
