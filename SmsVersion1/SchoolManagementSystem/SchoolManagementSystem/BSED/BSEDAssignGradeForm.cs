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
    public partial class BSEDAssignGradeForm : Form
    {
        public BSEDAssignGradeForm()
        {
            InitializeComponent();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BSEDAssignGradeForm_Load(object sender, EventArgs e)
        {
           
            txtFullName.Enabled = false;
            txtGradeLevel.Enabled = false;
            txtSection.Enabled = false;
            //cbSubjects.Focus();
            txt1st.MaxLength = 6;
            txt2nd.MaxLength = 6;
            txt3rd.MaxLength = 6;
            txt4th.MaxLength = 6;


        }

        private void txt1st_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >= 6))
            {
                e.Handled = true;
            }
        }

        private void txt2nd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >= 6))
            {
                e.Handled = true;
            }
        }

        private void txt3rd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >= 6))
            {
                e.Handled = true;
            }
        }

        private void txt4th_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >= 6))
            {
                e.Handled = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtSubjects_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
