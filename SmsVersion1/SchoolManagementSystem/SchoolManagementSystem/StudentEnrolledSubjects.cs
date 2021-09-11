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
using SqlKata.Execution;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
namespace SchoolManagementSystem
{
    public partial class StudentEnrolledSubjects : Form
    {

        Connection connect = new Connection();
        MySqlCommand cmd;
        MySqlConnection conn;
        MySqlDataReader dr;
        public StudentEnrolledSubjects()
        {
            InitializeComponent();
        }
        string allScheds;

        private void StudentEnrolledSubjects_Load(object sender, EventArgs e)
        {

        }
        ReportDataSource test = new ReportDataSource();
        private void button1_Click(object sender, EventArgs e)
        {
           


        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var getSched = DBContext.GetContext().Query("studentSched").Where("studentID", textboxWatermark1.Text).First();
                double[] catID = { };

                int strucID = 0;
                int getCategoryID = 0;
                string str = getSched.schedId;
                var words = str.Split(' ');


                dgvStudentSched.Rows.Clear();
                for (int i = 0; i < words.Length; i++)
                {
                    allScheds = words[i];

                    var values = DBContext.GetContext().Query("studentSched")
                      .CrossJoin("schedule")
                      .Join("Billing", "Billing.studentSchedid", "studentSched.studentSchedID")
                      .Join("student", "student.studentId", "studentSched.studentID")
                      .Join("subjects", "subjects.subjectCode", "schedule.subjectCode")
                      .LeftJoin("rooms", "rooms.roomId", "schedule.roomID")
                      .Where("schedule.schedID", allScheds)
                      .GroupBy("schedule.schedID").Get();

                    foreach (var value in values)
                    {
                        strucID = value.structureID;
                        string foo = value.date, bar = string.Empty;

                        foreach (char c in foo)
                        {
                            if (c == '1')
                            {
                                bar += "M";
                            }
                            else if (c == '2')
                            {
                                bar += "T";
                            }
                            else if (c == '3')
                            {
                                bar += "W";
                            }
                            else if (c == '4')
                            {
                                bar += "Th";
                            }
                            else if (c == '5')
                            {
                                bar += "F";
                            }
                            else if (c == '6')
                            {
                                bar += "S";
                            }
                        }
                        var aa = DBContext.GetContext().Query("feestructure").Where("structureID", strucID).First();

                        dgvStudentSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
                        dgvStudentSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

                        txtName.Text = $"{value.firstname} {value.lastname}";
                        txtGender.Text = value.gender;
                        txtCourse.Text = value.course;
                        txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                        dgvStudentSched.Rows.Add(allScheds, value.subjectCode, value.subjectTitle, bar, value.name, Convert.ToDateTime(value.timeStart.ToString()), Convert.ToDateTime(value.timeEnd.ToString()), $"{value.lec}/{value.lab}");

                    }
                }
                

                var tblTotalfee = DBContext.GetContext().Query("totalfee").Where("structureID", strucID).WhereNotNull("total").WhereNotNull("categoryID").Get();

                foreach (var tblFees in tblTotalfee)
                {
                    getCategoryID = tblFees.categoryID;
                    var assCategoryID = DBContext.GetContext().Query("categoryfee").Where("categoryID", getCategoryID).Get();

                    foreach (var getIds in assCategoryID)
                    {

                    }
                }



            }
            catch (Exception)
            {
                Validator.AlertDanger("Student number doesn't exist!");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            List<EnrolledSubjects> erTest = new List<EnrolledSubjects>();
            erTest.Clear();

            for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                erTest.Add(new EnrolledSubjects
                {
                    name = txtName.Text,
                    course = txtCourse.Text,
                    gender = txtGender.Text,
                    date = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    schedID = dgvStudentSched.Rows[i].Cells[1].Value.ToString(),
                    subjectCode = dgvStudentSched.Rows[i].Cells[2].Value.ToString(),
                    mergeTime = dgvStudentSched.Rows[i].Cells[3].FormattedValue.ToString() + " " + dgvStudentSched.Rows[i].Cells[5].FormattedValue.ToString() + "-" + dgvStudentSched.Rows[i].Cells[6].FormattedValue.ToString(),
                    room = dgvStudentSched.Rows[i].Cells[4].FormattedValue.ToString(),
                    lablec = dgvStudentSched.Rows[i].Cells[7].FormattedValue.ToString(),
                });


            test.Name = "DataSet1";
            test.Value = erTest;

            var frm = new StudentEnrolledViewer();
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(test);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report1.rdlc";
            frm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class EnrolledSubjects
    {
        public string studentNo { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string gender { get; set; }
        public string date { get; set; }
        public string schedID { get; set; }
        public string mergeTime { get; set; }
        public string subjectCode { get; set; }
        public string room { get; set; }
        public string capacity { get; set; }
        public string status { get; set; }
        public string lablec { get; set; }
        public string category { get; set; }
        public string amount { get; set; }
        public string totalUnitss { get; set; }

    }

}
