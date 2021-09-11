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
    public partial class BSEDStudentPayment : Form
    {
        public BSEDStudentPayment()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddStudentPayment frm2 = new AddStudentPayment();
            frm2.ShowDialog();
        }
    }
}
