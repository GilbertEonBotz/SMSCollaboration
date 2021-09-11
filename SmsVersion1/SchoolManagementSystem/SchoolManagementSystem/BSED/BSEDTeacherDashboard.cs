using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.BSED
{
    public partial class BSEDTeacherDashboard : Form
    {
        public BSEDTeacherDashboard()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            BSEDStudents frm2 = new BSEDStudents();
            frm2.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            BSEDSubjects frm3 = new BSEDSubjects();
            frm3.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            BSEDAssignGrade frm4 = new BSEDAssignGrade();
            frm4.ShowDialog();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            this.Hide();
            BSEDAdminDashboard frm5 = new BSEDAdminDashboard();
            frm5.ShowDialog();
            
        }

        private void pnlShow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
