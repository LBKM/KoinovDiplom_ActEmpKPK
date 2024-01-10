using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;
using static KoinovDiplom_ActEmpKPK.DarkOverlayForm;
using Guna.UI2.WinForms;
using KoinovDiplom_ActEmpKPK.MenuForms;

namespace KoinovDiplom_ActEmpKPK
{
    partial class MainMenuForm : Form
    {
        ListViewItem LastSelectedItem;                           
        DataRow CurrentRow;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
        //активная кнопка
        private Color activebackgroundcolor = Color.FromArgb(75, 0, 130);
        private Color activeforegroundcolor = Color.FromArgb(230, 230, 250);

        //неактивная кнопка
        private Color defaultbackgroundcolor = Color.FromArgb(75, 0, 130);
        private Color defaultforegroundcolor = Color.FromArgb(159, 159, 173);

        private Form acriveForm = null;
        private void openForm(Form childForm)
        {
            if (acriveForm != null)
                acriveForm.Close();
            acriveForm = childForm;
            childForm.TopLevel = false; childForm.FormBorderStyle = FormBorderStyle.None; childForm.Dock = DockStyle.Fill;
            GradientPanel1.Controls.Add(childForm);
            GradientPanel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void SetButtonColors(IconButton button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.IconColor = foreColor;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            //для перетаскивания формы
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.WORKER". При необходимости она может быть перемещена или удалена.
            this.wORKERTableAdapter.Fill(this.user2DataSet.WORKER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.USER". При необходимости она может быть перемещена или удалена.
            this.uSERTableAdapter.Fill(this.user2DataSet.USER);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.SPECIALITY". При необходимости она может быть перемещена или удалена.
            this.sPECIALITYTableAdapter.Fill(this.user2DataSet.SPECIALITY);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.POST". При необходимости она может быть перемещена или удалена.
            this.pOSTTableAdapter.Fill(this.user2DataSet.POST);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT_MATERIALS". При необходимости она может быть перемещена или удалена.
            this.eVENT_MATERIALSTableAdapter.Fill(this.user2DataSet.EVENT_MATERIALS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EVENT". При необходимости она может быть перемещена или удалена.
            this.eVENTTableAdapter.Fill(this.user2DataSet.EVENT);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.EDUCATION_FORM". При необходимости она может быть перемещена или удалена.
            this.eDUCATION_FORMTableAdapter.Fill(this.user2DataSet.EDUCATION_FORM);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.DISCIPLINE". При необходимости она может быть перемещена или удалена.
            this.dISCIPLINETableAdapter.Fill(this.user2DataSet.DISCIPLINE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACTIVITY_EMPLOYEE". При необходимости она может быть перемещена или удалена.
            this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "user2DataSet.ACCESS_LEVEL". При необходимости она может быть перемещена или удалена.
            this.aCCESS_LEVELTableAdapter.Fill(this.user2DataSet.ACCESS_LEVEL);

            PanelLeft2.Visible = false;
            PanelLeft3.Visible = false;
            PanelLeft4.Visible = false;
            PanelLeft1.Visible = true;
            SetButtonColors(iconButton4, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton2, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton3, defaultbackgroundcolor, defaultforegroundcolor);

        }
        

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddOrChangeActEmp addOrChangeActEmp = new AddOrChangeActEmp(CurrentRow);
            addOrChangeActEmp.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormChartsView formChartsView = new FormChartsView();
            formChartsView.ShowDialog();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            using (DarkOverlayForm darkOverlayForm = new DarkOverlayForm())
            {
                darkOverlayForm.Show(); // Отображаем форму-затемнение

                FormAboutProgram dialog1 = new FormAboutProgram();
                dialog1.ShowDialog();

                darkOverlayForm.Close(); // Закрываем форму-затемнение после закрытия дочерней формы
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activebackgroundcolor, activeforegroundcolor);
            //Включаем левую подсветку
            PanelLeft2.Visible = true;
            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton1, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton3, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton4, defaultbackgroundcolor, defaultforegroundcolor);
            //сбрасываем левую подсветку у других кнопок leftPanel2.Visible = false;
            PanelLeft1.Visible = false;
            PanelLeft3.Visible = false;
            PanelLeft4.Visible = false;

            openForm(new FormFilter());
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activebackgroundcolor, activeforegroundcolor);

            PanelLeft1.Visible = true;
            SetButtonColors(iconButton4, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton2, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton3, defaultbackgroundcolor, defaultforegroundcolor);

            PanelLeft2.Visible = false;
            PanelLeft3.Visible = false;
            PanelLeft4.Visible = false;

            openForm(new FormMainWindow());
        }


        private void iconButton3_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activebackgroundcolor, activeforegroundcolor);
            //Включаем левую подсветку
            PanelLeft3.Visible = true;
            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton1, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton2, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton4, defaultbackgroundcolor, defaultforegroundcolor);
            //сбрасываем левую подсветку у других кнопок leftPanel2.Visible = false;
            PanelLeft1.Visible = false;
            PanelLeft2.Visible = false;
            PanelLeft4.Visible = false;

            openForm(new FormReportsNCharts());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activebackgroundcolor, activeforegroundcolor);
            //Включаем левую подсветку
            PanelLeft4.Visible = true;
            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton1, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton3, defaultbackgroundcolor, defaultforegroundcolor);
            SetButtonColors(iconButton2, defaultbackgroundcolor, defaultforegroundcolor);
            //сбрасываем левую подсветку у других кнопок leftPanel2.Visible = false;
            PanelLeft1.Visible = false;
            PanelLeft3.Visible = false;
            PanelLeft2.Visible = false;

            openForm(new SettingsForm());

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            this.WindowState = FormWindowState.Maximized;
        }

        private void guna2Panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position; 
            dragFormPoint = this.Location;
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormChartsView formChartsView = new FormChartsView();
            formChartsView.Show();
        }
    }
}
