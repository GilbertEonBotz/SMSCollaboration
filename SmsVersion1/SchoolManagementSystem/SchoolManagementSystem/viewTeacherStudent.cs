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
using Microsoft.Reporting.WinForms;
using SqlKata.Execution;
namespace SchoolManagementSystem
{
    public partial class viewTeacherStudent : Form
    {

        string value2;
        teacherScheds teach = new teacherScheds();
        public viewTeacherStudent(string val, string val2)
        {
            InitializeComponent();
            label1.Text = val;
            value2 = val2;
            

        }

        private void viewTeacherStudent_Load(object sender, EventArgs e)
        {
            teach.teacherID = value2;
            teach.getSchedID = label1.Text ;
            teach.viewstudent();

            foreach (DataRow Drow in teach.dt.Rows)
            {
                int num = dgvSched.Rows.Add();

                dgvSched.Rows[num].Cells[0].Value = Drow["ID"].ToString();
                dgvSched.Rows[num].Cells[1].Value = Drow["Name"].ToString();
                dgvSched.Rows[num].Cells[2].Value = Drow["Course"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ReportDataSource rsStud = new ReportDataSource();
        ReportDataSource rsDept = new ReportDataSource();
        private void btnPrint_Click(object sender, EventArgs e)
        {

            var frm = new TeacherSchedReportViewer();

            List<StudentDetails> lst = new List<StudentDetails>();
            lst.Clear();

            for (int i=0; i <dgvSched.Rows.Count; i++)
            {
                lst.Add(new StudentDetails
                {
                    teachName = txtName.Text,
                    subjName = txtSubjName.Text,
                    room = txtRoom.Text,
                    schedule = txtSchedule.Text,
                    studName = dgvSched.Rows[i].Cells[1].Value.ToString(),
                    studCourse = dgvSched.Rows[i].Cells[2].Value.ToString()
                });
            }


            List<department> dept = new List<department>();
            dept.Clear();
            dept.Add(new department
            {
               deptName = txtDepartment.Text
            });

            rsStud.Name = "DataSet1";
            rsStud.Value = lst;
            rsDept.Name = "DataSet2";
            rsDept.Value = dept;
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rsStud);
            frm.reportViewer1.LocalReport.DataSources.Add(rsDept);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report3.rdlc";
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.Percent;
            frm.reportViewer1.ZoomPercent = 100;
            frm.ShowDialog();
        }

        private void viewTeacherStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }

    public class StudentDetails
    {
        public string teachName { get; set; }
        public string subjName { get; set; }
        public string room { get; set; }
        public string schedule { get; set; }
        public string studName { get; set; }
        public string studCourse { get; set; }
    }

    public class department
    {
        public string deptName { get; set; }
    }
}
