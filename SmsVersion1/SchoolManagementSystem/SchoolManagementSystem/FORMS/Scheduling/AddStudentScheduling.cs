using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SqlKata.Execution;

namespace SchoolManagementSystem
{


    public partial class AddStudentScheduling : Form
    {
        string teachid;
        studentSched sched = new studentSched();
        StudentScheduling addDatagrid;

        public AddStudentScheduling(StudentScheduling addDatagrid)
        {
            InitializeComponent();
            this.addDatagrid = addDatagrid;
        }

        private void AddStudentScheduling_Load(object sender, EventArgs e)
        {
            displayDataCmb();
        }

        public void displayDataCmb()
        {
            dgvSched.Rows.Clear();

            dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

            sched.displayFilter();

            foreach (DataRow Drow in sched.dtFilter.Rows)
            {
                int num = dgvSched.Rows.Add();
                dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
                dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
                dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
                dgvSched.Rows[num].Cells[7].Value = Drow["MaxStudent"].ToString();
                dgvSched.Rows[num].Cells[8].Value = Drow["Status"].ToString();
                dgvSched.Rows[num].Cells[9].Value = Drow["lablec"].ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSched_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvSched_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in addDatagrid.dgvStudentSched.Rows)
            {
                if ((string)row.Cells[1].Value == dgvSched.SelectedRows[0].Cells[1].Value.ToString())
                {
                    Validator.AlertDanger("Unable to add same subject code!");
                    return;
                }
            }
            addDatagrid.dgvStudentSched.Rows.Add(dgvSched.SelectedRows[0].Cells[0].Value.ToString(), dgvSched.SelectedRows[0].Cells[1].Value.ToString(),
            dgvSched.SelectedRows[0].Cells[2].Value.ToString(), dgvSched.SelectedRows[0].Cells[3].Value.ToString(), dgvSched.SelectedRows[0].Cells[4].Value,
            dgvSched.SelectedRows[0].Cells[5].FormattedValue.ToString(), dgvSched.SelectedRows[0].Cells[6].FormattedValue.ToString(), dgvSched.SelectedRows[0].Cells[7].Value.ToString()
            , dgvSched.SelectedRows[0].Cells[8].Value.ToString(), dgvSched.SelectedRows[0].Cells[9].Value.ToString());
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddStudentScheduling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dgvSched.Rows.Clear();

            //dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            //dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

            //sched.textvalue = txtSearch.Text;
            //sched.displayFilter();

            //foreach (DataRow Drow in sched.dtFilter.Rows)
            //{
            //    int num = dgvSched.Rows.Add();
            //    dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
            //    dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
            //    dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
            //    dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
            //    dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
            //    dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
            //    dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
            //    dgvSched.Rows[num].Cells[7].Value = Drow["MaxStudent"].ToString();
            //    dgvSched.Rows[num].Cells[8].Value = Drow["Status"].ToString();
            //    dgvSched.Rows[num].Cells[9].Value = Drow["lablec"].ToString();
            //}
        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            dgvSched.Rows.Clear();

            dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

            sched.textvalue = txtSearch.Text;
            sched.displayFilter();

            foreach (DataRow Drow in sched.dtFilter.Rows)
            {
                int num = dgvSched.Rows.Add();
                dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
                dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
                dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
                dgvSched.Rows[num].Cells[7].Value = Drow["MaxStudent"].ToString();
                dgvSched.Rows[num].Cells[8].Value = Drow["Status"].ToString();
                dgvSched.Rows[num].Cells[9].Value = Drow["lablec"].ToString();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}

