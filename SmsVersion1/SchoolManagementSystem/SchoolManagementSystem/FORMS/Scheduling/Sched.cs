using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SqlKata.Execution;
using SchoolManagementSystem.UITools;

namespace SchoolManagementSystem
{
    public partial class Sched : Form
    {
        schedule sched = new schedule();

        public Sched()
        {
            InitializeComponent();
        }

        private void Sched_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            try
            {
                dgvSched.Columns[7].DefaultCellStyle.Format = "hh:mm tt";
                dgvSched.Columns[8].DefaultCellStyle.Format = "hh:mm tt";
                sched.viewsched();

                dgvSched.Rows.Clear();
                foreach (DataRow Drow in sched.dt.Rows)
                {
                    int num = dgvSched.Rows.Add();

                    dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                    dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                    dgvSched.Rows[num].Cells[2].Value = Drow["SubjTitle"].ToString();
                    dgvSched.Rows[num].Cells[3].Value = Drow["roomID"].ToString();
                    dgvSched.Rows[num].Cells[4].Value = Drow["courseID"].ToString();
                    dgvSched.Rows[num].Cells[5].Value = Drow["date"].ToString();
                    dgvSched.Rows[num].Cells[6].Value = Drow["maxStudent"].ToString();
                    dgvSched.Rows[num].Cells[7].Value = Convert.ToDateTime(Drow["time start"].ToString());
                    dgvSched.Rows[num].Cells[8].Value = Convert.ToDateTime(Drow["time end"].ToString());
                    dgvSched.Rows[num].Cells[9].Value = Drow["status"].ToString();
                }

                foreach (DataGridViewRow Myrow in dgvSched.Rows)
                {            //Here 2 cell is target value and 1 cell is Volume
                    if (Convert.ToString(Myrow.Cells[6].Value) == "available")// Or your condition 
                    {
                        // Myrow.DefaultCellStyle.BackColor = Color.IndianRed;
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                    }

                    else if (Convert.ToString(Myrow.Cells[6].Value) == "full")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
            catch (Exception)
            {
                Validator.AlertDanger("Conflict on Rooms data. Please contact MSID!");
            }
        }
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            addSchedule s = new addSchedule(this);
            FormFade.FadeForm(this, s);
        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvSched.Rows[dgvSched.CurrentRow.Index].Cells[0].Value.ToString();
            string colName = dgvSched.Columns[e.ColumnIndex].Name;
            if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("schedule").Where("schedID", id).Delete();
                   
                    displayData();
                }
            }

            //if (colName.Equals("edit"))
            //{
            //    idd = dgvSched.Rows[dgvSched.CurrentRow.Index].Cells[0].Value.ToString();
            //    var myfrm = new addSchedule(this, idd);

            //    var value = DBContext.GetContext().Query("schedule").First();

            //    myfrm.label7.Text = value.
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            dgvSched.Rows.Clear();
            
            sched.textValue = textboxWatermark1.Text;
            sched.filterSched();
            dgvSched.Columns[7].DefaultCellStyle.Format = "hh:mm tt";
            dgvSched.Columns[8].DefaultCellStyle.Format = "hh:mm tt";
            foreach (DataRow Drow in sched.dtFilter.Rows)
            {
            
                int num = dgvSched.Rows.Add();

                dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                dgvSched.Rows[num].Cells[2].Value = Drow["SubjTitle"].ToString();
                dgvSched.Rows[num].Cells[3].Value = Drow["roomID"].ToString();
                dgvSched.Rows[num].Cells[4].Value = Drow["courseID"].ToString();
                dgvSched.Rows[num].Cells[5].Value = Drow["date"].ToString();
                dgvSched.Rows[num].Cells[6].Value = Drow["maxStudent"].ToString();
                dgvSched.Rows[num].Cells[7].Value = Convert.ToDateTime(Drow["time start"].ToString());
                dgvSched.Rows[num].Cells[8].Value = Convert.ToDateTime(Drow["time end"].ToString());
                dgvSched.Rows[num].Cells[9].Value = Drow["status"].ToString();
            }
           
        }

        private void textboxWatermark1_Leave(object sender, EventArgs e)
        {
            if (textboxWatermark1.Text.Equals("Search"))
            {
                displayData();
            }
            
        }
    }
}
