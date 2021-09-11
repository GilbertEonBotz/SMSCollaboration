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
    public partial class BSEDManageTeacher : Form
    {
        public BSEDManageTeacher()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            BSEDAdminManageTeacher frm2 = new BSEDAdminManageTeacher();
            frm2.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BSEDManageTeacher_Load(object sender, EventArgs e)
        {

        }
    }
}
