using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EonBotzLibrary;
using SchoolManagementSystem.UITools;
using SqlKata.Execution;
namespace SchoolManagementSystem
{
    public partial class teacherSched : Form
    {
        string num1 = "";
        string storeID;
        string units;

        finalDashboard reloadData;
        public teacherSched(finalDashboard reloadData)
        {

            InitializeComponent();
            this.reloadData = reloadData;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addTeacherScheduling add = new addTeacherScheduling(this);
            FormFade.FadeForm(this, add);
        }

        private void teacherSched_Load(object sender, EventArgs e)
        {
            var values = DBContext.GetContext().Query("teachers").Get();

            foreach (var value in values)
            {
                cmbTeacher.Items.Add(value.teacherId);
            }
        }
        public string[] wew;
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }


        string upSched;
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
            {
                wew = new string[] { dgvStudentSched.Rows[i].Cells[0].Value.ToString() };

                foreach (string aa in wew)
                {
                    storeID += (aa + " ");
                }
            }
            if (storeID == "")
            {

            }
            else
            {
                try
                {
                    var value = DBContext.GetContext().Query("teachersched").Where("teacherId", cmbTeacher.Text).First();
                    upSched = value.schedId.ToString();

                    DBContext.GetContext().Query("teachersched").Where("teacherId", cmbTeacher.Text).Update(new
                    {
                        schedId = storeID
                    });
                    storeID = "";
                    Validator.AlertSuccess("Teacher Schedule updated");
                    reloadData.displayTeacherSchedule();
                }
                catch (Exception)
                {
                    DBContext.GetContext().Query("teachersched").Insert(new
                    {
                        teacherid = cmbTeacher.Text,
                        schedid = storeID
                    });
                    Validator.AlertSuccess("Teacher schedule added");
                    reloadData.displayTeacherSchedule();
                    storeID = "";
                }
            }
        }

        string splitSched;

        teacherScheds teach = new teacherScheds();
        private void btnSearch_Click(object sender, EventArgs e)
        {

            dgvStudentSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvStudentSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            try
            {
                var value = DBContext.GetContext().Query("teachersched").Where("teacherId", cmbTeacher.Text).First();
                
                splitSched = value.schedId;
                var words = splitSched.Split(' ');

                dgvStudentSched.Rows.Clear();
                for (int i = 0; i < words.Length - 1; i++)
                {
                    string indSubj = words[i];
                    teach.getSchedID = indSubj;
                    teach.teacherID = cmbTeacher.Text;
                    teach.viewSchedTeach();

                    foreach (DataRow drow in teach.dt.Rows)
                    {
                        int num = dgvStudentSched.Rows.Add();

                        dgvStudentSched.Rows[num].Cells[0].Value = drow["schedID"].ToString();
                        dgvStudentSched.Rows[num].Cells[1].Value = drow["subjCode"].ToString();
                        dgvStudentSched.Rows[num].Cells[2].Value = drow["subjTitle"].ToString();
                        dgvStudentSched.Rows[num].Cells[3].Value = drow["roomName"].ToString();
                        dgvStudentSched.Rows[num].Cells[4].Value = drow["day"].ToString();
                        dgvStudentSched.Rows[num].Cells[5].Value = Convert.ToDateTime(drow["timestart"].ToString());
                        dgvStudentSched.Rows[num].Cells[6].Value = Convert.ToDateTime(drow["timeend"].ToString());
                        txtName.Text = drow["fName"].ToString();
                        txtGender.Text = drow["gender"].ToString();
                        txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                        txtDepartment.Text = drow["department"].ToString();
                        
                    }
                }
            }
            catch (Exception)
            {
                var values = DBContext.GetContext().Query("teachers").Where("teacherId", cmbTeacher.Text).Get();

                foreach (var value in values)
                {
                    txtName.Text = $"{value.Firstname} {value.Lastname}";
                    txtGender.Text = value.Gender;
                    txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    txtDepartment.Text = value.department;
                   
                }
            }
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStudentSched.Rows.Clear();
            TextBox[] inputs = { txtName, txtDepartment };

            Validator.ClearTextField(inputs);
        }

        private void cmbTeacher_TextChanged(object sender, EventArgs e)
        {
            dgvStudentSched.Rows.Clear();
            TextBox[] inputs = { txtName, txtDepartment };

            Validator.ClearTextField(inputs);

        }

        private void dgvStudentSched_RowDefaultCellStyleChanged(object sender, DataGridViewRowEventArgs e)
        {


        }

        private void dgvStudentSched_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvStudentSched.Rows.Count > 0)
                btnPrint.Enabled = true;
        }

        private void dgvStudentSched_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvStudentSched.Rows.Count <= 0)
                btnPrint.Enabled = false;

        }

        private void dgvStudentSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudentSched_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Validator.RemoveSubject()) 
            {
                foreach (DataGridViewRow item in this.dgvStudentSched.SelectedRows)
                {
                    dgvStudentSched.Rows.RemoveAt(item.Index);
                }
            }
            
        }
    }
}
