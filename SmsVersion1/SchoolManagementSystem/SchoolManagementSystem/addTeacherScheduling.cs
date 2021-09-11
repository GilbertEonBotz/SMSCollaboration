using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlKata.Execution;
using SqlKata.Compilers;
using EonBotzLibrary;
namespace SchoolManagementSystem
{
    public partial class addTeacherScheduling : Form
    {
        teacherSched teachDgv;
        schedule sched = new schedule();
        public addTeacherScheduling(teacherSched teachDg)
        {
            InitializeComponent();

            this.teachDgv = teachDg;

           
        }
        public void aa()
        {
            try
            {
                dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
                dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
                sched.viewsched();

                dgvSched.Rows.Clear();
                foreach (DataRow Drow in sched.dt.Rows)
                {
                    int num = dgvSched.Rows.Add();

                    dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                    dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                    dgvSched.Rows[num].Cells[2].Value = Drow["SubjTitle"].ToString();
                    dgvSched.Rows[num].Cells[3].Value = Drow["roomID"].ToString();
                    dgvSched.Rows[num].Cells[4].Value = Drow["date"].ToString();
                    dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["time start"].ToString());
                    dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["time end"].ToString());
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

            //var values = DBContext.GetContext().Query("schedule")
            //    .Join("rooms", "rooms.roomId", "schedule.roomID")
            //    .Get();


            //foreach (var value in values)
            //{
            //    dgvSched.Rows.Add(value.schedID, value.subjectCode, value.subjectTitle, value.description, value.date, value.timeStart, value.timeEnd);
            //}
        }
        private void addTeacherScheduling_Load(object sender, EventArgs e)
        {
            dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            aa();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvSched.Rows.Clear();
            //sched.category = comboBox1.Text;


            //dgvSched.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            //dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            //sched.display();

            //foreach (DataRow Drow in sched.dt.Rows)
            //{
            //    int num = dgvSched.Rows.Add();
            //    dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
            //    dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
            //    dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
            //    dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
            //    dgvSched.Rows[num].Cells[4].Value = Drow["Timestart"].ToString();
            //    dgvSched.Rows[num].Cells[5].Value = Drow["Timeend"].ToString();
            //    dgvSched.Rows[num].Cells[6].Value = Drow["Day"].ToString();
            //    dgvSched.Rows[num].Cells[7].Value = Drow["MaxStudent"].ToString();
            //    dgvSched.Rows[num].Cells[8].Value = Drow["Status"].ToString();
            //    dgvSched.Rows[num].Cells[9].Value = Drow["lablec"].ToString();
            //}
        }

        private void dgvSched_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //foreach (DataGridViewRow row in teachDgv.dgvStudentSched.Rows)
            //{
            //    if ((string)row.Cells[0].Value == dgvSched.SelectedRows[0].Cells[0].Value.ToString())
            //    {
            //        Validator.AlertDanger("Subject existed");
            //        return;
            //    }
            //}
            //teachDgv.dgvStudentSched.Rows.Add(dgvSched.SelectedRows[0].Cells[0].Value.ToString(), dgvSched.SelectedRows[0].Cells[1].Value.ToString(), dgvSched.SelectedRows[0].Cells[2].Value.ToString()
            //    ,dgvSched.SelectedRows[0].Cells[3].Value.ToString(), dgvSched.SelectedRows[0].Cells[4].Value.ToString(), dgvSched.SelectedRows[0].Cells[5].Value.ToString(), dgvSched.SelectedRows[0].Cells[6].Value.ToString()
            //  );
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSched_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in teachDgv.dgvStudentSched.Rows)
            {
                if ((string)row.Cells[0].Value == dgvSched.SelectedRows[0].Cells[0].Value.ToString())
                {
                    Validator.AlertDanger("Subject existed");
                    return;
                }
            }
            teachDgv.dgvStudentSched.Rows.Add(dgvSched.SelectedRows[0].Cells[0].Value.ToString(), dgvSched.SelectedRows[0].Cells[1].Value.ToString(), 
                dgvSched.SelectedRows[0].Cells[2].Value.ToString(), dgvSched.SelectedRows[0].Cells[3].Value.ToString()
                , dgvSched.SelectedRows[0].Cells[4].Value.ToString(), dgvSched.SelectedRows[0].Cells[5].FormattedValue.ToString()
                , dgvSched.SelectedRows[0].Cells[6].FormattedValue.ToString());
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addTeacherScheduling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }
}
