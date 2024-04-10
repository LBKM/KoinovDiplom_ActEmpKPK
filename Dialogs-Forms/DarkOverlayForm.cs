using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
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
    internal class DarkOverlayForm : Form
    {
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Timer timer1;
        private System.ComponentModel.IContainer components;

        public DarkOverlayForm()
            {
            }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DarkOverlayForm));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderColor = System.Drawing.Color.DarkGreen;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 3;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(227, 376);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(136, 70);
            this.guna2Button1.TabIndex = 8;
            this.guna2Button1.Text = "ПРОВЕРИТЬ СОЕДИНЕНИЕ С БАЗОЙ ДАННЫХ";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.MintCream;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(589, 132);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 61);
            this.label1.TabIndex = 9;
            this.label1.Text = "ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ УСТАНОВЛЕНО.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.MintCream;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(0, 132);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(589, 119);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 11;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(589, 61);
            this.label2.TabIndex = 12;
            this.label2.Text = "ПОДКЛЮЧЕНИЕ К БАЗЕ ДАННЫХ НЕ УСТАНОВЛЕНО.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(589, 61);
            this.label3.TabIndex = 13;
            this.label3.Text = "ЛАЛАЛЛАЛАЛА";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // DarkOverlayForm
            // 
            this.ClientSize = new System.Drawing.Size(589, 457);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DarkOverlayForm";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

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
    }
}
