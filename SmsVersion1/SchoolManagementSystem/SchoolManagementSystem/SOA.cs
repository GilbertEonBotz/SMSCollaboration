using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SqlKata.Execution;
using Microsoft.Reporting.WinForms;
using System.Linq;
using MySql.Data.MySqlClient;
using SchoolManagementSystem.UITools;

namespace SchoolManagementSystem
{
    public partial class SOA : Form
    {
        public SOA()
        {
            InitializeComponent();
        }

        string xxxxx;
        double totalaaa;
        double totaldiscount;
        double discount;
        string billingIDS = "";
        string billingids2 = "";
        string academicid;
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader dr;
        MySqlCommand cmd;
        double total2;
        double downpayment;
        double paidDownpayment;
        double aa;
        double studentdownpayment;
        string storeID;
        double prelim;
        double final;
        double semi;
        int trapmaxStud;
        double midterm;
        studentSched sched = new studentSched();
        feeStruc struc = new feeStruc();
        ledgerPercent led = new ledgerPercent();
        finalDashboard reload;

        string splitSched;

        public string[] wew;
        public string[] xxxx;
        StudentTuition stud = new StudentTuition();
        Double amount;

        ReportDataSource rs = new ReportDataSource();
        ReportDataSource rsBill = new ReportDataSource();
        ReportDataSource rsTuition = new ReportDataSource();
        ReportDataSource rsExams = new ReportDataSource();
        ReportDataSource rsPayment = new ReportDataSource();
        ReportDataSource rsDiscount = new ReportDataSource();
        ReportDataSource rsYrType = new ReportDataSource();




       

        

        


        public static double ComputePercentage(double _tuition, string bDecimal, string calFraction, double wholeNum)
        {
            string result = Convert.ToString(_tuition);

            var regex = new System.Text.RegularExpressions.Regex("(?<=[\\.])[0-9]+");
            if (regex.IsMatch(result))
            {
                string decimalPlaces = regex.Match(result).Value;

                if (Convert.ToInt64(decimalPlaces) > 0)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == '.')
                        {
                            bDecimal += result[i - 1];
                        }

                    }
                    calFraction = $"{bDecimal}.{decimalPlaces}";
                }
                else
                {
                }
            }
            else
            {
                calFraction = "0";
            }

            //return Convert.ToDouble(calFraction);
            return wholeNum = Convert.ToDouble(result) - Convert.ToDouble(calFraction);
        }
        public static double ComputeDecimals(double _tuition, string bDecimal, string calFraction, double wholeNum)
        {
            string result = Convert.ToString(_tuition);

            var regex = new System.Text.RegularExpressions.Regex("(?<=[\\.])[0-9]+");
            if (regex.IsMatch(result))
            {
                string decimalPlaces = regex.Match(result).Value;

                if (Convert.ToInt64(decimalPlaces) > 0)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == '.')
                        {
                            bDecimal += result[i - 1];
                        }
                    }
                    calFraction = $"{bDecimal}.{decimalPlaces}";
                }
                else
                {
                }
            }
            else
            {
                calFraction = "0";
            }
            return Convert.ToDouble(calFraction);
        }




        private void btnEnroll_Click(object sender, EventArgs e)
        {

        }

        private void SOA_Load(object sender, EventArgs e)
        {
            

            

            
            
            dgvStudentSched.Rows.Clear();

            dgvStudentSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvStudentSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select studentID from studentSched where studentID = '" + cmbStudentNo.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                var value = DBContext.GetContext().Query("studentSched").Where("studentID", cmbStudentNo.Text).First();

                splitSched = value.schedId;
                var words = splitSched.Split(' ');

                for (int i = 0; i < words.Length - 1; i++)
                {
                    string indSubj = words[i];
                    sched.getSchedID = indSubj;
                    sched.studentID = cmbStudentNo.Text;
                    sched.viewSchedStudent();

                    foreach (DataRow drow in sched.dtStudentSched.Rows)
                    {
                        int num = dgvStudentSched.Rows.Add();

                        dgvStudentSched.Rows[num].Cells[0].Value = drow["SchedID"].ToString();
                        dgvStudentSched.Rows[num].Cells[1].Value = drow["SubjectCode"].ToString();
                        dgvStudentSched.Rows[num].Cells[2].Value = drow["SubjectTitle"].ToString();
                        dgvStudentSched.Rows[num].Cells[3].Value = drow["RoomName"].ToString();
                        dgvStudentSched.Rows[num].Cells[4].Value = drow["Day"].ToString();
                        dgvStudentSched.Rows[num].Cells[5].Value = Convert.ToDateTime(drow["Timestart"].ToString());
                        dgvStudentSched.Rows[num].Cells[6].Value = Convert.ToDateTime(drow["Timeend"].ToString());
                        dgvStudentSched.Rows[num].Cells[7].Value = drow["MaxStudent"].ToString();
                        dgvStudentSched.Rows[num].Cells[8].Value = drow["Status"].ToString();
                        dgvStudentSched.Rows[num].Cells[9].Value = drow["lablec"].ToString();
                        txtName.Text = drow["Name"].ToString();
                        txtGender.Text = drow["Gender"].ToString();
                        txtCourse.Text = drow["Course"].ToString();
                        txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                        cmbYear.Text = "1";
                        cmbTypeStudent.Text = "New";
                    }
                }
            }
            else
            {
                var values = DBContext.GetContext().Query("student").Where("studentId", cmbStudentNo.Text).Get();

                foreach (var value in values)
                {
                    txtName.Text = $"{value.firstname} {value.lastname}";
                    txtGender.Text = value.gender;
                    txtCourse.Text = value.course;
                    txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                    cmbYear.Text = "1";
                    cmbTypeStudent.Text = "New";
                }
            

            }
            conn.Close();

            conn.Open();
            cmd = new MySqlCommand("select b.downpayment from student a, studentActivation b where b.studentId = '" + cmbStudentNo.Text + "' and b.status ='Activated' ", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                studentdownpayment = Convert.ToDouble(dr[0]);
            }

            amount = 0;
            
            for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
            {
                wew = new string[] { dgvStudentSched.Rows[i].Cells[0].Value.ToString() };

                foreach (string aa in wew)
                {
                    storeID += (" " + aa);
                }
            }
            if (storeID == " ")
            {
            }
            else
            {
                string str = storeID;
                var words = str.Split(' ');

                for (int i = 1; i < words.Length; i++)
                {
                    string individualSubj = words[i];
                    stud.indsub = individualSubj;

                    stud.viewSubj();

                    foreach (DataRow Drow in stud.dt.Rows)
                    {
                        amount += Convert.ToDouble(Drow["Amount"].ToString());

                    }

                }
                storeID = "";
            }
            conn.Close();

            

            string sql;
            conn.Open();

            cmd = new MySqlCommand("SELECT categoryfee.category, totalfee.total FROM `totalfee` join feestructure on feestructure.structureID = totalfee.structureID join categoryfee ON categoryfee.categoryID = totalfee.categoryID WHERE totalfee.structureID = (SELECT structureID FROM `Billing` where billingID = " + BI+")", conn);
            dr = cmd.ExecuteReader();






        }

         

        private void cmbStudentNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}

