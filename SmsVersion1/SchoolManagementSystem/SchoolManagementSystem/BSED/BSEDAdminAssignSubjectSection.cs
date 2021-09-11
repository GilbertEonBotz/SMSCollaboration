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
    public partial class BSEDAdminAssignSubjectSection : Form
    {
        public BSEDAdminAssignSubjectSection()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            BSEDAddSectioning frm2 = new BSEDAddSectioning();
            frm2.ShowDialog();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSectioning frm2 = new AddSectioning();
            frm2.ShowDialog();
        }
    }
}
