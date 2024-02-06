using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    internal class DarkOverlayForm : Form
    {
        public DarkOverlayForm()
            {
                // Настройки формы-затемнения
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = Color.Black;
                this.Opacity = 0.5; // Пример: установите значение прозрачности
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
            }
        }
}
