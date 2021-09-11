using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SchoolManagementSystem.UITools;

namespace SchoolManagementSystem
{
    public partial class tuition : Form
    {
        tuitionfee tuit = new tuitionfee();
        public tuition()
        {


            InitializeComponent();
        }

        private void tuition_Load(object sender, EventArgs e)
        {
            displaydata();
        }
        public void displaydata()
        {
            tuit.view();
            dgvTuition.Rows.Clear();
            foreach (DataRow Drow in tuit.dt.Rows)
            {
                int num = dgvTuition.Rows.Add();

                dgvTuition.Rows[num].Cells[0].Value = Drow["ID"].ToString();
                dgvTuition.Rows[num].Cells[1].Value = Drow["Category"].ToString();
                dgvTuition.Rows[num].Cells[2].Value = Drow["Count"].ToString();
                dgvTuition.Rows[num].Cells[3].Value = Drow["lec price"].ToString();
                dgvTuition.Rows[num].Cells[4].Value = Drow["lab price"].ToString();
                dgvTuition.Rows[num].Cells[5].Value = Drow["total units"].ToString();
                dgvTuition.Rows[num].Cells[6].Value = Drow["total price"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //tuitionStructure tui = new tuitionStructure();
            //tui.ShowDialog();
        }

        private void dgvTuition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            viewTuitionStruc tui = new viewTuitionStruc(dgvTuition.SelectedRows[0].Cells[0].Value.ToString(), this);
            tui.struckname.Text = dgvTuition.SelectedRows[0].Cells[1].Value.ToString();
            FormFade.FadeForm(this, tui);
        }
    }
}
