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
    public partial class StudentScheduling : Form
    {
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
        public StudentScheduling(finalDashboard reload)
        {
            InitializeComponent();
            this.reload = reload;
        }

        public StudentScheduling()
        {
        }

        private void StudentScheduling_Load(object sender, EventArgs e)
        {
            //panel1.Enabled = false;
            //pnlBilling.SetBounds(0, 0, 0, 0);
            displayDataCmb();
        }

        public void displayStudents()
        {
            dgvStudentSched.Columns[4].DefaultCellStyle.Format = "hh:mm tt";
            dgvStudentSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";

            var values = DBContext.GetContext().Query("student").Get();

            foreach (var value in values)
            {
                cmbStudentNo.Items.Add(value.lastname);
            }
        }

        public void displayDataCmb()
        {
            var values = DBContext.GetContext().Query("sectionCategory")
                .Join("Sectioning", "Sectioning.SectionCategoryID", "sectionCategory.SectionCategoryID")
                .GroupBy("sectionCategory.SectionCategoryID")
                .Get();

            foreach (var value in values)
            {
                cmbSubjects.Items.Add(value.sectionName);
            }
            //var values = DBContext.GetContext().Query("tuitioncategory").Join("tuition", "tuition.tuitionCatID", "tuitioncategory.tuitionCatID").GroupBy("tuitioncategory.tuitionCatID").Get();

            //foreach (var value in values)
            //{
            //    cmbSubjects.Items.Add(value.category);
            //}

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select a.studentid from student a, studentActivation b where a.studentId = b.studentid and b.status ='Activated' ", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbStudentNo.Items.Add(dr[0].ToString());
            }

            var fee = DBContext.GetContext().Query("feestructure").Join("totalfee", "totalfee.structureID", "feestructure.structureID").GroupBy("feestructure.structureID").Get();


            foreach (var value in fee)
            {
                cmbCategoryFee.Items.Add(value.structureName);
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            var myfrm = new AddStudentScheduling(this);
            FormFade.FadeForm(this, myfrm);
            cmbSubjects.Text = "";
        }

        string splitSched;

        private void btnSearchStudent_Click(object sender, EventArgs e)
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






            //0, 229



            //try
            //{
            //    if (string.IsNullOrWhiteSpace(cmbStudentNo.Text))
            //    {
            //        Validator.AlertDanger("Please enter student number");
            //    }
            //    else
            //    {
            //        var value = DBContext.GetContext().Query("student").Where("studentId", cmbStudentNo.Text).First();

            //        txtName.Text = $"{value.firstname} {value.lastname}";
            //        txtGender.Text = value.gender;
            //        txtCourse.Text = value.course;
            //        txtDateOfRegistration.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            //        panel1.Enabled = true;
            //    }
            //}

            //catch (Exception)
            //{
            //    Validator.AlertDanger("Student number doesn't exist");
            //}



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtName, txtCourse, txtGender, txtDateOfRegistration };
            Validator.ClearTextField(inputs);
            cmbTypeStudent.Text = "";
            cmbYear.Text = "";
            dgvStudentSched.Rows.Clear();
            //var values = DBContext.GetContext().Query("student").Where("studentId", comboBox1.Text).Get();

            //foreach (var value in values)
            //{
            //    txtName.Text = value.firstname();
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                aa = 0;
                amount = 0;

                var value = DBContext.GetContext().Query("sectionCategory").Where("sectionName", cmbSubjects.Text).First();
                string getid = value.SectionCategoryID.ToString();

                dgvStudentSched.Rows.Clear();

                sched.category = getid;
                //MessageBox.Show(getid);

                dgvStudentSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
                dgvStudentSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";

                sched.display();

                foreach (DataRow Drow in sched.dt.Rows)
                {
                    int num = dgvStudentSched.Rows.Add();
                    dgvStudentSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                    dgvStudentSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                    dgvStudentSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                    dgvStudentSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
                    dgvStudentSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                    dgvStudentSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
                    dgvStudentSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
                    dgvStudentSched.Rows[num].Cells[7].Value = Drow["MaxStudent"].ToString();
                    dgvStudentSched.Rows[num].Cells[8].Value = Drow["Status"].ToString();
                    dgvStudentSched.Rows[num].Cells[9].Value = Drow["lablec"].ToString();
                    aa += Convert.ToDouble(Drow["total"].ToString());
                }


            }
            catch (NullReferenceException)
            {
                Validator.AlertDanger("Please add tuition charges!");
            }


        }

        private void dgvStudentSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select studentschedID from studentSched where studentid ='" + cmbStudentNo.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    billingIDS = dr[0].ToString();

                }
                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand("SELECT downpayment FROM smsdb.studentActivation where status = 'Activated' and studentid = '" + cmbStudentNo.Text + "'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    paidDownpayment = Convert.ToDouble(dr[0]);
                }

                List<Schedulings> lst = new List<Schedulings>();
                lst.Clear();
                int stored = 0;
                string wewww = "";
                string getSchedule = "";

                for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                {
                    getSchedule = dgvStudentSched.Rows[i].Cells[0].Value.ToString();

                    conn = connect.getcon();
                    conn.Open();

                    cmd = new MySqlCommand("select Sum(b.totalUnits) from schedule a, subjects b where a.subjectCode = b.subjectCode and a.schedID = '" + getSchedule + "'", conn);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        xxxx = new string[] { Convert.ToString(dr[0]) };
                        foreach (string aa in xxxx)
                        {
                            stored += Convert.ToInt32(aa);
                        }
                    }
                }

                for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                {
                    lst.Add(new Schedulings
                    {
                        studentNo = cmbStudentNo.Text,
                        name = txtName.Text,
                        course = txtCourse.Text,
                        gender = txtGender.Text,
                        date = txtDateOfRegistration.Text,
                        schedID = dgvStudentSched.Rows[i].Cells[1].Value.ToString(),
                        subjectCode = dgvStudentSched.Rows[i].Cells[2].Value.ToString(),
                        room = dgvStudentSched.Rows[i].Cells[3].FormattedValue.ToString(),
                        mergeTime = dgvStudentSched.Rows[i].Cells[4].FormattedValue.ToString() + " " + dgvStudentSched.Rows[i].Cells[5].FormattedValue.ToString() + "-" + dgvStudentSched.Rows[i].Cells[6].FormattedValue.ToString(),
                        capacity = dgvStudentSched.Rows[i].Cells[7].Value.ToString(),
                        status = dgvStudentSched.Rows[i].Cells[8].Value.ToString(),
                        lablec = dgvStudentSched.Rows[i].Cells[9].Value.ToString(),
                        totalUnits = Convert.ToString($"{stored}.0")
                    });
                }
                if (Validator.AddConfirmation())
                {

                    for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                    {
                        wew = new string[] { dgvStudentSched.Rows[i].Cells[0].Value.ToString()
                    };
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
                        DBContext.GetContext().Query("studentSched").Where("studentID", cmbStudentNo.Text).Update(new
                        {
                            schedId = storeID,
                            section = cmbSubjects.Text

                        });
                        storeID = "";
                        Validator.AlertSuccess("Student schedule updated");
                    }

                    List<feeBillings> bills = new List<feeBillings>();
                    bills.Clear();

                    List<tuitionBilling> tuit = new List<tuitionBilling>();
                    tuit.Clear();


                    for (int i = 0; i < dgvCategories.Rows.Count; i++)
                    {
                        bills.Add(new feeBillings
                        {
                            total = Convert.ToDouble(lblTotal.Text),
                            category = dgvCategories.Rows[i].Cells[0].Value.ToString(),
                            amount = Convert.ToDouble(dgvCategories.Rows[i].Cells[1].Value.ToString()),
                        });
                    }
                    var values = DBContext.GetContext().Query("studentActivation").Where("studentID", cmbStudentNo.Text).First();

                    discount = values.discount;

                    totaldiscount = amount * discount;
                    double totaltotal = amount - totaldiscount;

                    tuit.Add(new tuitionBilling
                    {

                        tuitionTotal = Convert.ToDouble(totaltotal.ToString()),
                    });

                    string structureid = struc.structureID;
                    double total = amount + Convert.ToDouble(lblTotal.Text);

                    try
                    {
                        //DBContext.GetContext().Query("percentage").Where("status", "Deactivate").First();

                        //ledgerPercent led = new ledgerPercent();
                        //downpayment = Convert.ToDouble(led.downpayment);
                        //led.selectstudentid = cmbStudentNo.Text;
                        //led.selectSchedID();
                        //led.percent();
                        //double total2 = total - Convert.ToDouble(led.downpayment);
                        //
                        DBContext.GetContext().Query("percentage").Where("status", "Active").First();

                        var downpayments = DBContext.GetContext().Query("percentage").Where("status", "Active").First();

                        downpayment = Convert.ToDouble(downpayments.downpayment);
                        total2 = amount + Convert.ToDouble(lblTotal.Text);
                        totaldiscount = amount * discount;
                        double totalamoun = total2 - downpayment - totaldiscount;
                        //MessageBox.Show(totaldiscount.ToString());
                        //
                        List<discountedPrice> disc = new List<discountedPrice>();
                        disc.Clear();
                        disc.Add(new discountedPrice
                        {
                            discounted = totaldiscount,
                            discPercent = discount * 100,
                        });

                        led.selectstudentid = cmbStudentNo.Text;
                        led.selectSchedID();
                        led.percent();
                        total = totalamoun;
                        totalaaa = total + downpayment;
                        //

                        double extractPrelim = totalamoun * Convert.ToDouble(led.prelim);
                        double extractMidterm = totalamoun * Convert.ToDouble(led.midterm);
                        double extractSemi = totalamoun * Convert.ToDouble(led.semi);
                        double extractFinal = totalamoun * Convert.ToDouble(led.finals);

                        // KUHAON WHOLE NUMBER EACH EXAM
                        var prelim = ComputePercentage(extractPrelim, "", "", 0);
                        var midterm = ComputePercentage(extractMidterm, "", "", 0);
                        var semi = ComputePercentage(extractSemi, "", "", 0);
                        var final = ComputePercentage(extractFinal, "", "", 0);

                        // KUHAON UG I ADD TANAN DECIMAL
                        var prelimDec = ComputeDecimals(extractPrelim, "", "", 0);
                        var midtermDec = ComputeDecimals(extractMidterm, "", "", 0);
                        var semiDec = ComputeDecimals(extractSemi, "", "", 0);
                        var finalDec = ComputeDecimals(extractFinal, "", "", 0);
                        var totalDec = prelimDec + midtermDec + semiDec + finalDec;

                        //IADD ANG PRELIM RESULT UG ANG TOTAL DECIMAL
                        var amt1 = prelim + totalDec;

                        List<examDivision> exams = new List<examDivision>();
                        exams.Clear();

                        exams.Add(new examDivision
                        {
                            prelim = amt1,
                            midterm = midterm,
                            semi = semi,
                            final = final
                        });
                        ;

                        List<paymentDetails> pds = new List<paymentDetails>();
                        pds.Clear();
                        pds.Add(new paymentDetails
                        {
                            dp = Convert.ToDouble(led.downpayment),
                            ap = studentdownpayment,
                            mp = "Cash",
                            rmk = "N/A"
                        });

                        List<YearType> typeYr = new List<YearType>();
                        typeYr.Clear();

                        typeYr.Add(new YearType
                        {
                            yrLevel = cmbYear.Text,
                            studentType = cmbTypeStudent.Text
                        });

                        LocalReport localReport = new LocalReport();
                        localReport.ReportEmbeddedResource = "SchoolManagementSystem.Report2.rdlc";
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lst));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", bills));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", tuit));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", exams));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5", pds));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet6", disc));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet7", typeYr));
                        localReport.Print();

                        //MessageBox.Show(billingIDS);
                        conn = connect.getcon();
                        conn.Open();
                        cmd = new MySqlCommand("select billingID from Billing where studentSchedid ='" + billingIDS + "'", conn);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                billingids2 = dr[0].ToString();
                            }
                            DBContext.GetContext().Query("Billing").Where("billingID", billingids2).Update(new
                            {
                                studentSchedid = led.selectStudentSchedid,
                                structureid = structureid,
                                total = totalaaa,
                                prelim = amt1,
                                midterm = midterm,
                                semi = semi,
                                finals = final,
                                date = DateTime.Now,
                                academicID = academicid
                            });
                            //MessageBox.Show("success update bllling");
                            //MessageBox.Show("downpayment paid is" + paidDownpayment.ToString());
                            reload.displayStudentScheduling();
                        }
                    }
                    catch (Exception)
                    {
                        Validator.AlertDanger("Please select an exam percentage on exam percentage menu");
                    }
                }
            }

            else
            {


                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand("SELECT id FROM smsdb.academicyear where status = 'Deactivate'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    academicid = dr[0].ToString();
                }

                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand("SELECT downpayment FROM smsdb.studentActivation where status = 'Activated' and studentid = '" + cmbStudentNo.Text + "'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    paidDownpayment = Convert.ToDouble(dr[0]);
                }


                List<Schedulings> lst = new List<Schedulings>();
                lst.Clear();
                int stored = 0;
                string wewww = "";
                string getSchedule = "";

                for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                {
                    getSchedule = dgvStudentSched.Rows[i].Cells[0].Value.ToString();


                    conn = connect.getcon();
                    conn.Open();



                    cmd = new MySqlCommand("select Sum(b.totalUnits) from schedule a, subjects b where a.subjectCode = b.subjectCode and a.schedID = '" + getSchedule + "'", conn);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        xxxx = new string[] { Convert.ToString(dr[0]) };
                        foreach (string aa in xxxx)
                        {
                            stored += Convert.ToInt32(aa);
                        }
                    }
                }

                for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                {
                    lst.Add(new Schedulings
                    {
                        studentNo = cmbStudentNo.Text,
                        name = txtName.Text,
                        course = txtCourse.Text,
                        gender = txtGender.Text,
                        date = txtDateOfRegistration.Text,
                        schedID = dgvStudentSched.Rows[i].Cells[1].Value.ToString(),
                        subjectCode = dgvStudentSched.Rows[i].Cells[2].Value.ToString(),
                        room = dgvStudentSched.Rows[i].Cells[3].FormattedValue.ToString(),
                        mergeTime = dgvStudentSched.Rows[i].Cells[4].FormattedValue.ToString() + " " + dgvStudentSched.Rows[i].Cells[5].FormattedValue.ToString() + "-" + dgvStudentSched.Rows[i].Cells[6].FormattedValue.ToString(),
                        capacity = dgvStudentSched.Rows[i].Cells[7].Value.ToString(),
                        status = dgvStudentSched.Rows[i].Cells[8].Value.ToString(),
                        lablec = dgvStudentSched.Rows[i].Cells[9].Value.ToString(),
                        totalUnits = Convert.ToString($"{stored}.0")
                    });
                }

                if (Validator.AddConfirmation())
                {
                    try
                    {
                        DBContext.GetContext().Query("studentSched").Where("studentID", cmbStudentNo.Text).First();
                        Validator.AlertDanger("Student is already enrolled in this semester");
                    }
                    catch (Exception)
                    {


                        for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
                        {
                            wew = new string[] { dgvStudentSched.Rows[i].Cells[0].Value.ToString()
                    };
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
                            if (string.IsNullOrEmpty(cmbSubjects.Text))
                            {
                                DBContext.GetContext().Query("studentSched").Insert(new
                                {
                                    studentID = cmbStudentNo.Text,
                                    schedId = storeID,
                                    academicID = academicid,
                                    section = "irreg" + " " + cmbYear.Text
                                });
                                storeID = "";
                            }
                            else
                            {
                                DBContext.GetContext().Query("studentSched").Insert(new
                                {
                                    studentID = cmbStudentNo.Text,
                                    schedId = storeID,
                                    academicID = academicid,
                                    section = cmbSubjects.Text
                                });
                                storeID = "";
                            }
                            Validator.AlertSuccess("Student Enrolled");
                        }

                        List<feeBillings> bills = new List<feeBillings>();
                        bills.Clear();

                        List<tuitionBilling> tuit = new List<tuitionBilling>();
                        tuit.Clear();


                        for (int i = 0; i < dgvCategories.Rows.Count; i++)
                        {
                            bills.Add(new feeBillings
                            {
                                total = Convert.ToDouble(lblTotal.Text),
                                category = dgvCategories.Rows[i].Cells[0].Value.ToString(),
                                amount = Convert.ToDouble(dgvCategories.Rows[i].Cells[1].Value.ToString()),
                            });
                        }

                        var values = DBContext.GetContext().Query("studentActivation").Where("studentID", cmbStudentNo.Text).First();

                        discount = values.discount;

                        totaldiscount = amount * discount;
                        double totaltotal = amount - totaldiscount;

                        tuit.Add(new tuitionBilling
                        {

                            tuitionTotal = Convert.ToDouble(totaltotal.ToString()),
                        });

                        string structureid = struc.structureID;
                        double total = amount + Convert.ToDouble(lblTotal.Text);


                        //DBContext.GetContext().Query("percentage").Where("status", "Deactivate").First();

                        //ledgerPercent led = new ledgerPercent();
                        //downpayment = Convert.ToDouble(led.downpayment);
                        //led.selectstudentid = cmbStudentNo.Text;
                        //led.selectSchedID();
                        //led.percent();
                        //double total2 = total - Convert.ToDouble(led.downpayment);


                        //
                        DBContext.GetContext().Query("percentage").Where("status", "Active").First();

                        var downpayments = DBContext.GetContext().Query("percentage").Where("status", "Active").First();


                        downpayment = Convert.ToDouble(downpayments.downpayment);
                        total2 = amount + Convert.ToDouble(lblTotal.Text);
                        totaldiscount = amount * discount;
                        double totalamoun = total2 - downpayment - totaldiscount;
                        //MessageBox.Show(totaldiscount.ToString());

                        List<discountedPrice> disc = new List<discountedPrice>();
                        disc.Clear();
                        disc.Add(new discountedPrice
                        {
                            discounted = totaldiscount,
                            discPercent = discount * 100,
                        });




                        led.selectstudentid = cmbStudentNo.Text;
                        led.selectSchedID();
                        led.percent();
                        total = totalamoun;
                        //
                        totalaaa = total + downpayment;

                        double extractPrelim = totalamoun * Convert.ToDouble(led.prelim);
                        double extractMidterm = totalamoun * Convert.ToDouble(led.midterm);
                        double extractSemi = totalamoun * Convert.ToDouble(led.semi);
                        double extractFinal = totalamoun * Convert.ToDouble(led.finals);

                        // KUHAON WHOLE NUMBER EACH EXAM
                        var prelim = ComputePercentage(extractPrelim, "", "", 0);
                        var midterm = ComputePercentage(extractMidterm, "", "", 0);
                        var semi = ComputePercentage(extractSemi, "", "", 0);
                        var final = ComputePercentage(extractFinal, "", "", 0);

                        // KUHAON UG I ADD TANAN DECIMAL
                        var prelimDec = ComputeDecimals(extractPrelim, "", "", 0);
                        var midtermDec = ComputeDecimals(extractMidterm, "", "", 0);
                        var semiDec = ComputeDecimals(extractSemi, "", "", 0);
                        var finalDec = ComputeDecimals(extractFinal, "", "", 0);
                        var totalDec = prelimDec + midtermDec + semiDec + finalDec;

                        //IADD ANG PRELIM RESULT UG ANG TOTAL DECIMAL
                        var amt1 = prelim + totalDec;

                        List<examDivision> exams = new List<examDivision>();
                        exams.Clear();

                        exams.Add(new examDivision
                        {
                            prelim = amt1,
                            midterm = midterm,
                            semi = semi,
                            final = final
                        });

                        List<paymentDetails> pds = new List<paymentDetails>();
                        pds.Clear();
                        pds.Add(new paymentDetails
                        {
                            dp = Convert.ToDouble(led.downpayment),
                            ap = studentdownpayment,
                            mp = "Cash",
                            rmk = "N/A"
                        });

                        List<YearType> typeYr = new List<YearType>();
                        typeYr.Clear();

                        typeYr.Add(new YearType
                        {
                            yrLevel = cmbYear.Text,
                            studentType = cmbTypeStudent.Text
                        });

                        LocalReport localReport = new LocalReport();
                        localReport.ReportEmbeddedResource = "SchoolManagementSystem.Report2.rdlc";
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lst));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", bills));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", tuit));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", exams));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5", pds));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet6", disc));
                        localReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet7", typeYr));
                        localReport.Print();

                        DBContext.GetContext().Query("Billing").Insert(new
                        {
                            studentSchedid = led.selectStudentSchedid,
                            structureid = structureid,
                            total = totalaaa,
                            prelim = amt1,
                            midterm = midterm,
                            semi = semi,
                            finals = final,
                            date = DateTime.Now,
                            academicID = academicid
                        });
                        //MessageBox.Show("success bllling");
                        //MessageBox.Show("downpayment paid is" + paidDownpayment.ToString());
                        reload.displayStudentScheduling();

                    }
                }
            }
        }
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

        private void cmbCategoryFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCategories.Rows.Clear();

            var value = DBContext.GetContext().Query("feestructure").Where("structureName", cmbCategoryFee.Text).First();

            string feeId = value.structureID.ToString();

            struc.structureID = feeId;
            struc.dt.Clear();


            struc.viewfees();

            foreach (DataRow Drow in struc.dt.Rows)
            {
                int num = dgvCategories.Rows.Add();

                dgvCategories.Rows[num].Cells[0].Value = Drow["category"].ToString();
                dgvCategories.Rows[num].Cells[1].Value = Drow["amount"].ToString();
            }

            lblTotal.Text = struc.total;
        }
        int[] arrayContainer;
        string[] subjectCodeArray;
        private void btnEnroll_Click(object sender, EventArgs e)
        {

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select b.downpayment from student a, studentActivation b where b.studentId = '" + cmbStudentNo.Text + "' and b.status ='Activated' ", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                studentdownpayment = Convert.ToDouble(dr[0]);
            }

            amount = 0;
            pnlBilling.SetBounds(180, 50, 795, 462);
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


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlBilling.SetBounds(0, 0, 0, 0);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            StudentSchedulesReportViewer frm = new StudentSchedulesReportViewer();

            List<Schedulings> lst = new List<Schedulings>();
            lst.Clear();

            int stored = 0;
            string wewww = "";
            string getSchedule = "";

            for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
            {
                getSchedule = dgvStudentSched.Rows[i].Cells[0].Value.ToString();

                conn = connect.getcon();
                conn.Open();

                cmd = new MySqlCommand("select Sum(b.totalUnits) from schedule a, subjects b where a.subjectCode = b.subjectCode and a.schedID = '" + getSchedule + "'", conn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    xxxx = new string[] { Convert.ToString(dr[0]) };
                    foreach (string aa in xxxx)
                    {
                        stored += Convert.ToInt32(aa);
                    }
                }
            }

            for (int i = 0; i < dgvStudentSched.Rows.Count; i++)
            {
                lst.Add(new Schedulings
                {
                    studentNo = cmbStudentNo.Text,
                    name = txtName.Text,
                    course = txtCourse.Text,
                    gender = txtGender.Text,
                    date = txtDateOfRegistration.Text,
                    schedID = dgvStudentSched.Rows[i].Cells[1].Value.ToString(),
                    subjectCode = dgvStudentSched.Rows[i].Cells[2].Value.ToString(),
                    room = dgvStudentSched.Rows[i].Cells[3].FormattedValue.ToString(),
                    mergeTime = dgvStudentSched.Rows[i].Cells[4].FormattedValue.ToString() + " " + dgvStudentSched.Rows[i].Cells[5].FormattedValue.ToString() + "-" + dgvStudentSched.Rows[i].Cells[6].FormattedValue.ToString(),
                    capacity = dgvStudentSched.Rows[i].Cells[7].Value.ToString(),
                    status = dgvStudentSched.Rows[i].Cells[8].Value.ToString(),
                    lablec = dgvStudentSched.Rows[i].Cells[9].Value.ToString(),
                    totalUnits = Convert.ToString($"{stored}.0")
                });
            }

            List<feeBillings> bills = new List<feeBillings>();
            bills.Clear();

            List<tuitionBilling> tuit = new List<tuitionBilling>();

            for (int i = 0; i < dgvCategories.Rows.Count; i++)
            {
                bills.Add(new feeBillings
                {
                    total = Convert.ToDouble(lblTotal.Text),
                    category = dgvCategories.Rows[i].Cells[0].Value.ToString(),
                    amount = Convert.ToDouble(dgvCategories.Rows[i].Cells[1].Value.ToString()),

                });
            }
            var values = DBContext.GetContext().Query("studentActivation").Where("studentID", cmbStudentNo.Text).First();

            discount = values.discount;

            totaldiscount = amount * discount;
            double totaltotal = amount - totaldiscount;
            tuit.Add(new tuitionBilling
            {

                tuitionTotal = Convert.ToDouble(totaltotal.ToString()),
            });

            double total = amount + Convert.ToDouble(lblTotal.Text);

            DBContext.GetContext().Query("percentage").Where("status", "Active").First();

            var downpayments = DBContext.GetContext().Query("percentage").Where("status", "Active").First();

            downpayment = Convert.ToDouble(downpayments.downpayment);
            total2 = amount + Convert.ToDouble(lblTotal.Text);
            totaldiscount = amount * discount;
            double totalamoun = total2 - downpayment - totaldiscount;

            //MessageBox.Show(totaldiscount.ToString());
            //MessageBox.Show(discount.ToString());

            List<discountedPrice> disc = new List<discountedPrice>();
            disc.Clear();
            disc.Add(new discountedPrice
            {
                discounted = totaldiscount,
                discPercent = discount * 100,
            });

            led.selectstudentid = cmbStudentNo.Text;
            led.selectSchedID();
            led.percent();
            total = totalamoun;
            totalaaa = total + downpayment;
            double extractPrelim = total * Convert.ToDouble(led.prelim);
            double extractMidterm = total * Convert.ToDouble(led.midterm);
            double extractSemi = total * Convert.ToDouble(led.semi);
            double extractFinal = total * Convert.ToDouble(led.finals);

            // KUHAON WHOLE NUMBER EACH EXAM
            prelim = ComputePercentage(extractPrelim, "", "", 0);
            midterm = ComputePercentage(extractMidterm, "", "", 0);
            semi = ComputePercentage(extractSemi, "", "", 0);
            final = ComputePercentage(extractFinal, "", "", 0);


            //KUHAON UG I ADD TANAN DECIMAL
            var prelimDec = ComputeDecimals(extractPrelim, "", "", 0);
            var midtermDec = ComputeDecimals(extractMidterm, "", "", 0);
            var semiDec = ComputeDecimals(extractSemi, "", "", 0);
            var finalDec = ComputeDecimals(extractFinal, "", "", 0);
            var totalDec = prelimDec + midtermDec + semiDec + finalDec;

            //IADD ANG PRELIM RESULT UG ANG TOTAL DECIMAL
            var amt1 = prelim + totalDec;



            List<examDivision> exams = new List<examDivision>();
            exams.Clear();

            exams.Add(new examDivision
            {
                prelim = amt1,
                midterm = midterm,
                semi = semi,
                final = final
            });

            List<paymentDetails> pds = new List<paymentDetails>();
            pds.Clear();

            pds.Add(new paymentDetails
            {
                dp = Convert.ToDouble(led.downpayment),
                ap = studentdownpayment,
                mp = "Cash",
                rmk = "N/A"
            });

            List<YearType> typeYr = new List<YearType>();
            typeYr.Clear();

            typeYr.Add(new YearType
            {
                yrLevel = cmbYear.Text,
                studentType = cmbTypeStudent.Text
            });


            rs.Name = "DataSet1";
            rs.Value = lst;
            rsBill.Name = "DataSet2";
            rsBill.Value = bills;
            rsTuition.Name = "DataSet3";
            rsTuition.Value = tuit;
            rsExams.Name = "DataSet4";
            rsExams.Value = exams;
            rsPayment.Name = "DataSet5";
            rsPayment.Value = pds;
            rsDiscount.Name = "DataSet6";
            rsDiscount.Value = disc;
            rsYrType.Name = "DataSet7";
            rsYrType.Value = typeYr;

            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(rs);
            frm.reportViewer1.LocalReport.DataSources.Add(rsBill);
            frm.reportViewer1.LocalReport.DataSources.Add(rsTuition);
            frm.reportViewer1.LocalReport.DataSources.Add(rsExams);
            frm.reportViewer1.LocalReport.DataSources.Add(rsPayment);
            frm.reportViewer1.LocalReport.DataSources.Add(rsDiscount);
            frm.reportViewer1.LocalReport.DataSources.Add(rsYrType);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report2.rdlc";
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.Percent;
            frm.reportViewer1.ZoomPercent = 100;
            FormFade.FadeForm(this, frm);



        }

        public string[] waw;

        public void DisplayStringUnits(string value)
        {
            var regex = new System.Text.RegularExpressions.Regex($@"(?<=[\\/])[0-9]+");
            string units = "";

            if (regex.IsMatch(value))
            {
                string result = regex.Match(value).Value;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i].Equals('/'))
                    {
                        units += value[i - 1];
                    }
                }
                var fResult = $"{units}.{result}";

                MessageBox.Show(fResult);
            }
        }

        private void dgvStudentSched_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvStudentSched.Rows.Count != 0)
            {
                btnEnroll.Enabled = true;
            }
        }

        private void dgvStudentSched_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Validator.RemoveSubject())
            {
                foreach (DataGridViewRow item in this.dgvStudentSched.SelectedRows)
                {
                    dgvStudentSched.Rows.RemoveAt(item.Index);
                }
            }

        }

        private void dgvStudentSched_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvStudentSched.Rows.Count == 0)
            {
                btnEnroll.Enabled = false;
            }
        }

        private void dgvCategories_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvStudentSched.Rows.Count != 0)
            {
                btnPrint.Enabled = true;
                btnPreview.Enabled = true;
            }
        }

        private void cmbStudentNo_TextChanged(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtName, txtCourse, txtGender };
            Validator.ClearTextField(inputs);
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void pnlBilling_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }



    public class Schedulings
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
        public string totalUnits { get; set; }
    }

    public class feeBillings
    {
        public string category { get; set; }
        public double amount { get; set; }
        public double total { get; set; }
    }

    public class tuitionBilling
    {
        public double tuitionTotal { get; set; }
    }
    public class examDivision
    {
        public double prelim { get; set; }
        public double midterm { get; set; }
        public double semi { get; set; }
        public double final { get; set; }
    }

    public class paymentDetails
    {
        public double dp { get; set; }
        public double ap { get; set; }
        public string mp { get; set; }
        public string rmk { get; set; }
    }
    public class discountedPrice
    {
        public double discounted { get; set; }
        public double discPercent { get; set; }
    }

    public class YearType
    {
        public string yrLevel { get; set; }
        public string studentType { get; set; }
    }
}
