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
using EonBotzLibrary;
using SchoolManagementSystem.UITools;

namespace SchoolManagementSystem
{
    public partial class viewTeacherSched : Form
    {
        public viewTeacherSched()
        {
            InitializeComponent();
        }

        private void viewTeacherSched_Load(object sender, EventArgs e)
        {
            displayTeachSched();
        }
        public void displayTeachSched()
        {
            var values = DBContext.GetContext().Query("teachers")
                .Join("teachersched", "teachersched.teacherId", "teachers.teacherId")
                .WhereNotNull("teachersched.schedId")
                .Get();

            foreach (var value in values)
            {
                comboBox1.Items.Add(value.teacherId);
            }
        }
        string teachID;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSched_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                viewTeacherStudent v = new viewTeacherStudent(dgvSched.SelectedRows[0].Cells[0].Value.ToString(), teachID);
                var value = DBContext.GetContext().Query("teachers").Where("teacherId", teachID).First();
                v.txtName.Text = $"{value.Firstname} {value.Lastname}";
                v.txtDepartment.Text = value.department;
                v.txtSubjName.Text = dgvSched.SelectedRows[0].Cells[2].Value.ToString();
                v.txtRoom.Text = dgvSched.SelectedRows[0].Cells[3].Value.ToString();
                v.txtSchedule.Text = $"{dgvSched.SelectedRows[0].Cells[4].Value.ToString()} {dgvSched.SelectedRows[0].Cells[5].FormattedValue} {dgvSched.SelectedRows[0].Cells[6].FormattedValue}";
                FormFade.FadeForm(this, v);
            }
            catch (Exception)
            {

            }

        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            try
            {
                dgvSched.Rows.Clear();
                teacherScheds sched = new teacherScheds();

                var values = DBContext.GetContext().Query("teachersched").Where("teacherId", comboBox1.Text).First();
                teachID = Convert.ToString(values.teacherId);
                string str = values.schedId;
                var words = str.Split(' ');

                for (int i = 0; i < words.Length - 1; i++)
                {
                    sched.subjectcode = (words[i].ToString());
                    dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
                    dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
                    sched.viewteachsubj();
                    foreach (DataRow Drow in sched.dt.Rows)
                    {
                        int num = dgvSched.Rows.Add();
                        dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                        dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                        dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                        dgvSched.Rows[num].Cells[3].Value = Drow["Room"].ToString();
                        dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                        dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["TimeStart"].ToString());
                        dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["TimeEnd"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                Validator.AlertDanger("Please add schedule");
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
