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
    public partial class BSEDSubjects : Form
    {
        public BSEDSubjects()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
             AddSubject frm4 = new AddSubject();
             frm4.ShowDialog();
        }
    }
}
