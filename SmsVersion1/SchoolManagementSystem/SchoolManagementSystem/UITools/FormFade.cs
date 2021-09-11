using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.UITools
{
    public static class FormFade
    {
        public static void FadeForm(Form value, Form value2)
        {
            Form bgFade = new Form();

            bgFade.StartPosition = FormStartPosition.Manual;
            bgFade.FormBorderStyle = FormBorderStyle.None;
            bgFade.Opacity = .50d;
            bgFade.BackColor = Color.Black;
            bgFade.WindowState = FormWindowState.Maximized;
            bgFade.Location = value.Location;
            bgFade.ShowInTaskbar = false;
            bgFade.Show();

            value2.Owner = bgFade;
            value2.ShowDialog();

            bgFade.Dispose();

        }
    }
}
