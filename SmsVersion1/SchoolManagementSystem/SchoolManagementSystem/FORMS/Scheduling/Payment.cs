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
using SchoolManagementSystem.UITools;


namespace SchoolManagementSystem.FORMS.Scheduling
{
    public partial class Payment : Form
    {
        studentPaymentDisplay disp = new studentPaymentDisplay();
        public string billingid;
        finalDashboard display;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection conn;
        Connection connect = new Connection();
       
        double amount;
        double amountprelim;
        double amountmid;
        double amountsemi = 0;
        double amountfinal = 0;
        double amountDown = 0;
        
        double number;
        double total;



        public Payment(finalDashboard display)
        {
            InitializeComponent();
            this.display = display;
        }

        public Payment()
        {
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            displayData();
            txtAmount.KeyPress += Validator.ValidateKeypressNumber;
            
        }

        public void displayData()
        {

            disp.studentID = studentid.Text;
            disp.viewPayment();

            //txt5.Text = disp.studentfullpayment;
            
            txt1.Text = Convert.ToDouble(disp.prelim).ToString("N");

            txt2.Text = Convert.ToDouble(disp.midterm).ToString("N");

            txt3.Text = Convert.ToDouble(disp.semi).ToString("N");

            txt4.Text = Convert.ToDouble(disp.final).ToString("N");

            lbltotal.Text = disp.total;


        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {


        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        public void printShow()
        {

            dgv.Rows.Clear();
            //txtTotal.Text = "";
            //txtAmount.Text = "";
            //txtchange.Text = "00.00";

            comboBox2.Text.Trim();

            disp.studentID = studentid.Text;

            disp.studentDOwn();
            dgv.Rows.Add("0", disp.studentdownpayment, disp.remarksFordown, disp.dateForDown);

            disp.billingid = billingid;
            disp.viewtransaction();
            foreach (DataRow Drow in disp.dt.Rows)
            {
                int num = dgv.Rows.Add();
                dgv.Rows[num].Cells[0].Value = Drow["paymentid"].ToString();
                dgv.Rows[num].Cells[1].Value = Drow["paymentanomount"].ToString();
                dgv.Rows[num].Cells[2].Value = Drow["paymentremarks"].ToString();
                dgv.Rows[num].Cells[3].Value = Drow["paymentdate"].ToString();

            }
        }
        ReportDataSource rsRpt = new ReportDataSource();
        ReportDataSource rsCourse = new ReportDataSource();
        ReportDataSource rsPaid = new ReportDataSource();

        public void viewOr()
        {
            try
            {
                ReceiptViewer frm = new ReceiptViewer();
                var maxOr = DBContext.GetContext().Query("payment").Where("billingID", billingid).OrderByDesc("paymentID").First();

                List<Receipt> rcpt = new List<Receipt>();
                rcpt.Clear();

                if (checkBox1.Checked)
                {
                    rcpt.Add(new Receipt
                    {
                        currentBalance = Convert.ToDouble(txtcurrentBal.Text),
                        receiveAmt = Convert.ToDouble(txtAmount.Text),
                        change = Convert.ToDouble(txtchange.Text) + Convert.ToDouble(lbldiscount.Text),
                        name = txtLastname.Text,
                        orNo = Convert.ToInt32(maxOr.orNumber),
                        remarks = txtRemarks.Text,
                        studentNo = studentid.Text
                    });

                    List<PaymentCourse> courseList = new List<PaymentCourse>();
                    courseList.Clear();
                    courseList.Add(new PaymentCourse
                    {
                        course = txtGender.Text
                    });

                    List<TotalPaid> totPaid = new List<TotalPaid>();
                    totPaid.Clear();
                    totPaid.Add(new TotalPaid
                    {
                        paid = Convert.ToDouble(lbltotal.Text)
                    });

                    rsRpt.Name = "DataSet1";
                    rsRpt.Value = rcpt;
                    rsCourse.Name = "DataSet2";
                    rsCourse.Value = courseList;
                    rsPaid.Name = "DataSet3";
                    rsPaid.Value = totPaid;

                    frm.reportViewer1.LocalReport.DataSources.Clear();
                    frm.reportViewer1.LocalReport.DataSources.Add(rsRpt);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsCourse);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsPaid);
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report4.rdlc";
                    frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    frm.reportViewer1.ZoomMode = ZoomMode.Percent;
                    frm.reportViewer1.ZoomPercent = 100;
                    FormFade.FadeForm(this, frm);
                }
                else
                {
                    rcpt.Add(new Receipt
                    {
                        currentBalance = Convert.ToDouble(txtcurrentBal.Text),
                        receiveAmt = Convert.ToDouble(txtAmount.Text),
                        change = 0.00,
                        name = txtLastname.Text,
                        orNo = Convert.ToInt32(maxOr.orNumber),
                        remarks = txtRemarks.Text,
                        studentNo = studentid.Text
                    });

                    List<PaymentCourse> courseList = new List<PaymentCourse>();
                    courseList.Clear();
                    courseList.Add(new PaymentCourse
                    {
                        course = txtGender.Text
                    });

                    List<TotalPaid> totPaid = new List<TotalPaid>();
                    totPaid.Clear();
                    totPaid.Add(new TotalPaid
                    {
                        paid = Convert.ToDouble(lbltotal.Text)
                    });

                    rsRpt.Name = "DataSet1";
                    rsRpt.Value = rcpt;
                    rsCourse.Name = "DataSet2";
                    rsCourse.Value = courseList;
                    rsPaid.Name = "DataSet3";
                    rsPaid.Value = totPaid;

                    frm.reportViewer1.LocalReport.DataSources.Clear();
                    frm.reportViewer1.LocalReport.DataSources.Add(rsRpt);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsCourse);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsPaid);
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report4.rdlc";
                    frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    frm.reportViewer1.ZoomMode = ZoomMode.Percent;
                    frm.reportViewer1.ZoomPercent = 100;
                    FormFade.FadeForm(this, frm);
                }

            }
            catch (Exception)
            {

            }
            /*try
            {
                ReceiptViewer frm = new ReceiptViewer();
                var maxOr = DBContext.GetContext().Query("payment").Where("billingID", billingid).OrderByDesc("paymentID").First();

                List<Receipt> rcpt = new List<Receipt>();
                rcpt.Clear();

                if (checkBox1.Checked)
                {
                    
                    rcpt.Add(new Receipt
                    {
                        currentBalance = Convert.ToDouble(txtcurrentBal.Text),
                        receiveAmt = Convert.ToDouble(txtAmount.Text),
                        change = Convert.ToDouble(txtchange.Text),
                        name = txtLastname.Text,
                        orNo = Convert.ToInt32(maxOr.orNumber),
                        remarks = txtRemarks.Text,
                        studentNo = studentid.Text
                    });

                    List<PaymentCourse> courseList = new List<PaymentCourse>();
                    courseList.Clear();
                    courseList.Add(new PaymentCourse
                    {
                        course = txtGender.Text
                    });

                    List<TotalPaid> totPaid = new List<TotalPaid>();
                    totPaid.Clear();
                    totPaid.Add(new TotalPaid
                    {
                        paid = Convert.ToDouble(lbltotal.Text)
                    });

                    rsRpt.Name = "DataSet1";
                    rsRpt.Value = rcpt;
                    rsCourse.Name = "DataSet2";
                    rsCourse.Value = courseList;
                    rsPaid.Name = "DataSet3";
                    rsPaid.Value = totPaid;

                    frm.reportViewer1.LocalReport.DataSources.Clear();
                    frm.reportViewer1.LocalReport.DataSources.Add(rsRpt);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsCourse);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsPaid);
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report4.rdlc";
                    frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    frm.reportViewer1.ZoomMode = ZoomMode.Percent;
                    frm.reportViewer1.ZoomPercent = 100;
                    FormFade.FadeForm(this, frm);
                }
                else
                {
                    rcpt.Add(new Receipt
                    {
                        currentBalance = Convert.ToDouble(txtcurrentBal.Text),
                        receiveAmt = Convert.ToDouble(txtAmount.Text),
                        change = 0.00,
                        name = txtLastname.Text,
                        orNo = Convert.ToInt32(maxOr.orNumber),
                        remarks = txtRemarks.Text,
                        studentNo = studentid.Text
                    });

                    List<PaymentCourse> courseList = new List<PaymentCourse>();
                    courseList.Clear();
                    courseList.Add(new PaymentCourse
                    {
                        course = txtGender.Text
                    });

                    List<TotalPaid> totPaid = new List<TotalPaid>();
                    totPaid.Clear();
                    totPaid.Add(new TotalPaid
                    {
                        paid = Convert.ToDouble(lbltotal.Text)
                    });

                    rsRpt.Name = "DataSet1";
                    rsRpt.Value = rcpt;
                    rsCourse.Name = "DataSet2";
                    rsCourse.Value = courseList;
                    rsPaid.Name = "DataSet3";
                    rsPaid.Value = totPaid;

                    frm.reportViewer1.LocalReport.DataSources.Clear();
                    frm.reportViewer1.LocalReport.DataSources.Add(rsRpt);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsCourse);
                    frm.reportViewer1.LocalReport.DataSources.Add(rsPaid);
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report4.rdlc";
                    frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    frm.reportViewer1.ZoomMode = ZoomMode.Percent;
                    frm.reportViewer1.ZoomPercent = 100;
                    FormFade.FadeForm(this, frm);
                }
                
            }
            catch (Exception)
            {

            }*/

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                insert();
                printShow();
                showw();
                viewOr();

                txtAmount.Text = "";
                txtRemarks.Text = "";
                txtTotal.Text = "0.00";

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "0")
                    {
                        foreach (var cell in row.Cells)
                        {
                            DataGridViewLinkCell linkCell = cell as DataGridViewLinkCell;

                            if (linkCell != null)
                            {
                                linkCell.UseColumnTextForLinkValue = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please fill up the field","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        public void insert()
        {
            disp.billingid = billingid;
            disp.studentID = studentid.Text;
            disp.viewPayment();
            disp.studentDOwn();

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select sum(a.amount), (select b.total from Billing b where b.billingid = '"+billingid+ "') from payment a join Billing b on b.billingID=a.billingID where a.status ='paid' and a.billingID ='" + billingid + "'", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //number = Convert.ToDouble(dr[0]) + Convert.ToDouble(disp.studentdownpayment) + Convert.ToDouble(txtAmount.Text);
                number = Convert.ToDouble(dr[0].ToString() + 0) + Convert.ToDouble(disp.studentdownpayment) + Convert.ToDouble(txtAmount.Text);
                //lbldiscount.Text = number.ToString();
                
                if (number > Convert.ToDouble(dr[1].ToString()))
                {
                    total = Convert.ToDouble(disp.total) - Convert.ToDouble(dr[0].ToString() + 0) - Convert.ToDouble(disp.studentdownpayment);

                    
                    if (comboBox2.Text == "FULLPAYMENT")
                    {
                        double discnt = Convert.ToDouble(txtcurrentBal.Text) * 0.05;
                        disp.amount = (Convert.ToDouble(txtTotal.Text)-discnt).ToString();
                        disp.remarks = txtRemarks.Text;
                        disp.status = "paid";
                        disp.paymentMethod = cmbpaymentMethod.Text;
                        disp.insertpayment();
                        comboBox2.Enabled = true;

                       
                        disp.amount = lbldiscount.Text;
                        disp.remarks = "5% Discount";
                        disp.status = "paid";
                        disp.paymentMethod = "Discount";
                        disp.insertpayment();
                    }
                    else
                    {
                        disp.amount = total.ToString();
                        disp.remarks = txtRemarks.Text;
                        disp.status = "paid";
                        disp.paymentMethod = cmbpaymentMethod.Text;
                        disp.insertpayment();
                        comboBox2.Enabled = true;
                    }
                    //else if (comboBox2.Text == "MIDTERM")
                    //{
                    //    disp.amount = total.ToString();
                    //    disp.remarks = txtRemarks.Text;
                    //    disp.status = "paid";
                    //    disp.paymentMethod = cmbpaymentMethod.Text;
                    //    disp.insertpayment();
                    //    comboBox2.Enabled = true;
                    //}
                    //else if (comboBox2.Text == "SEMI-FINAL")
                    //{
                    //    disp.amount = total.ToString();
                    //    disp.remarks = txtRemarks.Text;
                    //    disp.status = "paid";
                    //    disp.paymentMethod = cmbpaymentMethod.Text;
                    //    disp.insertpayment();
                    //    comboBox2.Enabled = true;
                    //}
                    //else if (comboBox2.Text == "FINAL")
                    //{
                    //    disp.amount = total.ToString();
                    //    disp.remarks = txtRemarks.Text;
                    //    disp.status = "paid";
                    //    disp.paymentMethod = cmbpaymentMethod.Text;
                    //    disp.insertpayment();
                    //    comboBox2.Enabled = true;
                    //}
                }
                else if (checkBox1.Checked)
                {
                    if (checkBox1.Checked && txtchange.Text == "00.00")
                    {
                        disp.amount =  Convert.ToDouble(txtAmount.Text).ToString();
                        disp.remarks = txtRemarks.Text;
                        disp.status = "paid";
                        disp.paymentMethod = cmbpaymentMethod.Text;
                        disp.insertpayment();
                    }
                    else
                    {
                        if (txtchange.Text == "00.00")
                        {
                            disp.amount = txtAmount.Text.ToString();
                            disp.remarks = txtRemarks.Text;
                            disp.status = "paid";
                            disp.paymentMethod = cmbpaymentMethod.Text;
                            disp.insertpayment();
                        }
                        else
                        {
                            disp.amount = txtTotal.Text.ToString();
                            disp.remarks = txtRemarks.Text;
                            disp.status = "paid";
                            disp.paymentMethod = cmbpaymentMethod.Text;
                            disp.insertpayment();
                        }
                    }
                }
                else
                {
                    if (comboBox2.Text == "FINAL" && Convert.ToDouble(txtAmount.Text) > Convert.ToDouble(txtTotal.Text))
                    {
                        disp.billingid = billingid;
                        disp.amount = txtTotal.Text;
                        disp.remarks = txtRemarks.Text;
                        disp.status = "paid";
                        disp.paymentMethod = cmbpaymentMethod.Text;
                        disp.insertpayment();
                        comboBox2.SelectedIndex = 1;
                        comboBox2.Enabled = true;
                    }
                    else
                    {
                        disp.billingid = billingid;
                        disp.amount = txtAmount.Text;
                        disp.remarks = txtRemarks.Text;
                        disp.status = "paid";
                        disp.paymentMethod = cmbpaymentMethod.Text;
                        comboBox2.SelectedItem = 1;
                        disp.insertpayment();
                    }
                }
            }
            conn.Close();
            dr.Close();
            
        }


        public void showw()
        {

           ledgerPercent led = new ledgerPercent();
            led.percent();
            disp.viewPayment();
            disp.viewPaymentDetailed();
            disp.studentDOwn();


            double finalss = Convert.ToDouble(disp.totalpaid) + 0;
            double current = Convert.ToDouble(textBox15.Text) - Convert.ToDouble(disp.totalpaid);
            //textBox15.Text = (Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt4.Text)).ToString();
            lbltotal.Text = disp.totalpaid.ToString("N");
            txtcurrentBal.Text = current.ToString("N");
            try
            {

                
                if (Convert.ToDouble(led.downpayment) <= finalss)
                {
                    amount = finalss - Convert.ToDouble(led.downpayment);

                    comboBox2.Items.Remove("DOWNPAYMENT");

                    if (Convert.ToDouble(txt1.Text) <= amount)
                    {
                        amount = amount - Convert.ToDouble(txt1.Text);
                        comboBox2.Items.Remove("PRELIM");
                        if (Convert.ToDouble(txt2.Text) <= amount)
                        {
                            amount = amount - Convert.ToDouble(txt2.Text);
                            comboBox2.Items.Remove("MIDTERM");
                            if (Convert.ToDouble(txt3.Text) <= amount)
                            {
                                amount = amount - Convert.ToDouble(txt3.Text);

                                comboBox2.Items.Remove("SEMI-FINAL");
                                if (Convert.ToDouble(txt4.Text) <= amount)
                                {
                                    amount = amount - Convert.ToDouble(txt4.Text);
                                    //lblfullpayment.Text = led.fullpayment.ToString();
                                    lbldownpayment.Text = led.downpayment.ToString();
                                    lblpre.Text = txt1.Text;
                                    lblmid.Text = txt2.Text;
                                    lblsemi.Text = txt3.Text;
                                    lblfin.Text = txt4.Text;
                                    comboBox2.Items.Remove("FINAL");

                                }
                                else
                                {
                                   // lblfullpayment.Text = led.fullpayment.ToString();
                                    lbldownpayment.Text = led.downpayment.ToString();
                                    lblpre.Text = txt1.Text;
                                    lblmid.Text = txt2.Text;
                                    lblsemi.Text = txt3.Text;
                                    lblfin.Text = amount.ToString("N");
                                }
                            }
                            else
                            {
                                //lblfullpayment.Text = led.fullpayment.ToString();
                                lbldownpayment.Text = led.downpayment.ToString();
                                lblpre.Text = txt1.Text;
                                lblmid.Text = txt2.Text;
                                lblsemi.Text = amount.ToString("N");
                            }
                        }
                        else
                        {
                            ///lblfullpayment.Text = led.fullpayment.ToString();
                            lbldownpayment.Text = led.downpayment.ToString();
                            lblpre.Text = txt1.Text;
                            lblmid.Text = amount.ToString("N");
                        }
                    }
                    else
                    {
                       // lblfullpayment.Text = led.fullpayment.ToString();
                        lbldownpayment.Text = led.downpayment.ToString();
                        lblpre.Text = amount.ToString("N");
                    }
                }
                else
                {
                    //lblfullpayment.Text = led.fullpayment.ToString();
                    lbldownpayment.Text = finalss.ToString("N");
                    
                }
            }
            catch (Exception)
            {

                txtcurrentBal.Text = disp.total;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    txtchange.Text = "00.00";
                }

                else if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(txtTotal.Text))
                {
                    txtchange.Text = "00.00";
                }
                else
                {
                    //if (Convert.ToDouble(txtAmount.Text) > Convert.ToDouble(lblpaymentfor.Text))
                    //{
                    //    txtAmount.Text = lblpaymentfor.Text;
                    //}    
                    double change = Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtTotal.Text);
                    txtchange.Text = change.ToString("N");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "FULLPAYMENT")  
            {
                if (Convert.ToDouble(txt0.Text) + Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt4.Text) > (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text) + Convert.ToDouble(lbldownpayment.Text) + Convert.ToDouble(lblfin.Text)))
                {
                    
                    double ful = (Convert.ToDouble(txt0.Text) + Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt4.Text)) - (Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text) + Convert.ToDouble(lblfin.Text)));

                    double dtemp = Convert.ToDouble(txtcurrentBal.Text) * 0.05;
                    double ntemp = ful - dtemp;
                    lbldiscount.Text = dtemp.ToString();
                   // textBox15.Text = ntemp.ToString();
                   // txtTotal.Text = ntemp.ToString();
                    txtTotal.Text = ful.ToString();
                    txtRemarks.Text = "";
                }
                else
                {
                    txtTotal.Text = "0";
                }

                txtRemarks.Text = "Fullpayment";

                
            }
            else if (comboBox2.Text == "DOWNPAYMENT")
            {
                if (Convert.ToDouble(txt0.Text) > Convert.ToDouble(lbldownpayment.Text))
                {
                    amountDown = Convert.ToDouble(txt0.Text) - Convert.ToDouble(lbldownpayment.Text);
                    txtTotal.Text = amountDown.ToString("N");
                    txtRemarks.Text = "";
                }
                else
                {
                    txtTotal.Text = 0.ToString();
                }
            }
            else if (comboBox2.Text == "PRELIM")
            {
                if (Convert.ToDouble(txt0.Text) + Convert.ToDouble(txt1.Text) > Convert.ToDouble(lbldownpayment.Text) + Convert.ToDouble(lblpre.Text))
                {
                    amountprelim = (Convert.ToDouble(txt1.Text) + (Convert.ToDouble(txt0.Text)) - (Convert.ToDouble(lbldownpayment.Text) + Convert.ToDouble(lblpre.Text)));
                    txtTotal.Text = amountprelim.ToString("N");
                    txtRemarks.Text = "";

                }
                else
                {
                    txtTotal.Text = 0.ToString();
                }
            }
            else if (comboBox2.Text == "MIDTERM")
            {
                if (Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt0.Text) > Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text)))
                {
                    //amountmid = amount -Convert.ToDouble(lblmid.Text);
                    //amount = amountmid;
                    amountmid = (Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + (Convert.ToDouble(txt0.Text)) - (Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text))));

                    txtTotal.Text = amountmid.ToString("N");
                    txtRemarks.Text = "";
                }
                else
                {
                    txtTotal.Text = "0";
                }

            }

            else if (comboBox2.Text == "SEMI-FINAL")
            {
                if (Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt0.Text) > Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text)))
                {
                    //amountmid = amount -Convert.ToDouble(lblmid.Text);

                    //amount = amountmid;
                    amountsemi = (Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + (Convert.ToDouble(txt0.Text)) - (Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text))));


                    txtTotal.Text = amountsemi.ToString("N");
                    txtRemarks.Text = "";

                }
                else
                {
                    txtTotal.Text = "0";
                }

            }
            else if (comboBox2.Text == "FINAL")
            {
                if (Convert.ToDouble(txt0.Text) + Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt4.Text) > (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text) + Convert.ToDouble(lbldownpayment.Text) + Convert.ToDouble(lblfin.Text)))
                {


                    amountfinal = (Convert.ToDouble(txt0.Text) + Convert.ToDouble(txt1.Text) + Convert.ToDouble(txt2.Text) + Convert.ToDouble(txt3.Text) + Convert.ToDouble(txt4.Text)) - (Convert.ToDouble(lbldownpayment.Text) + (Convert.ToDouble(lblpre.Text) + Convert.ToDouble(lblmid.Text) + Convert.ToDouble(lblsemi.Text) + Convert.ToDouble(lblfin.Text)));


                    txtTotal.Text = amountfinal.ToString("N");
                    txtRemarks.Text = "";
                }
                else
                {
                    txtTotal.Text = "0";
                }

            }






        }

        private void txtAmount_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
        }
        public string temp = null;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
                //if (checkBox1.Checked)
                //{
                //    temp = txtcurrentBal.Text;
                //    txtcurrentBal.Text = "0.00";
                //    double n = -1 * Convert.ToDouble(temp);

                //    txtchange.Text = n.ToString();
                //}
                //else
                //{
                //    txtcurrentBal.Text = temp;
                //    txtchange.Text = "";
                //}

            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("update payment set status ='void' where paymentid = '" + dgv.SelectedRows[0].Cells[0].Value + "'", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Void");
            lbldownpayment.Text = "";
            lblpre.Text = "0.00";
            lblsemi.Text = "0.00";
            lblfin.Text = "0.00";
            lblmid.Text = "0.00";
            comboBox2.Items.Add("FULLPAYMENT");
            comboBox2.Items.Add("DOWNPAYMENT");
            comboBox2.Items.Add("PRELIM");
            comboBox2.Items.Add("MIDTERM");
            comboBox2.Items.Add("SEMI-FINAL");
            comboBox2.Items.Add("FINAL");
            printShow();
            showw();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //insert();

            //printShow();
            //showw();

        }

        private void cmbpaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {


        }

        private void Payment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button1.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {

                if (row.Cells[0].Value.ToString() == "0")
                {
                    foreach (var cell in row.Cells)
                    {
                        DataGridViewLinkCell linkCell = cell as DataGridViewLinkCell;

                        if (linkCell != null)
                        {
                            linkCell.UseColumnTextForLinkValue = false;
                        }
                    }
                }
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtchange_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (colName.Equals("action"))
            {
                var myfrm = new voidNotification(this);
                myfrm.ShowDialog();
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txt5discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click_1(object sender, EventArgs e)
        {

        }

        private void lbldownpayment_Click(object sender, EventArgs e)
        {

        }

        private void txt0_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lbldownpayment_TextChanged(object sender, EventArgs e)
        {
            
        }

        double totalaaa;
        double totaldiscount;
        double discount;
        string billingIDS = "";
        string billingids2 = "";
        string academicid;

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


        StudentTuition stud = new StudentTuition();
        Double amnt;

        ReportDataSource rs = new ReportDataSource();
        ReportDataSource rsBill = new ReportDataSource();
        ReportDataSource rsTuition = new ReportDataSource();
        ReportDataSource rsExams = new ReportDataSource();
        ReportDataSource rsPayment = new ReportDataSource();
        ReportDataSource rsDiscount = new ReportDataSource();
        ReportDataSource rsYrType = new ReportDataSource();


        


        private void BSOA_Click(object sender, EventArgs e)
        {
            SOA soa = new SOA();
            soa.cmbStudentNo.Text = studentid.Text;
            soa.BI.Text = billingid;
            soa.Show();

           /*conn.Open();
            string sql = "SELECT categoryfee.category,totalfee.total FROM `totalfee` join feestructure on feestructure.structureID = totalfee.structureID join categoryfee ON categoryfee.categoryID = totalfee.categoryID WHERE totalfee.structureID = (SELECT structureID FROM `Billing` WHERE  billingID = "+billingid+")";
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;*/

           // StatementOfAccount soa = new StatementOfAccount();


           /* List<Schedulings> lst = new List<Schedulings>();
            lst.Clear();
            lst.Add(new Schedulings
            {
                studentNo = studentid.Text,
                name = txtLastname.Text,
                course = txtCourse.Text,
                gender = txtGender.Text,
                date = "",
                schedID = "",
                subjectCode = "",
                room = "",
                mergeTime = "",
                capacity = "",
                status = "",
                lablec = "",
                totalUnits = ""
            });

            /* List<feeBillings> bills = new List<feeBillings>();
             bills.Clear();



             List<discountedPrice> disc = new List<discountedPrice>();

             List<tuitionBilling> tuit = new List<tuitionBilling>();

             List<examDivision> exams = new List<examDivision>();
             exams.Clear();

             List<paymentDetails> pds = new List<paymentDetails>();
             pds.Clear();*/
           /* List<YearType> typeYr = new List<YearType>();
            typeYr.Clear();
            typeYr.Add(new YearType
            {
                // yrLevel = cmbYear.Text,
                //studentType = cmbTypeStudent.Text
            });





            /* rsBill.Name = "DataSet2";
             rsBill.Value = bills;
             rsTuition.Name = "DataSet3";
             rsTuition.Value = tuit;
             rsExams.Name = "DataSet4";
             rsExams.Value = exams;
             rsPayment.Name = "DataSet5";
             rsPayment.Value = pds;
             rsDiscount.Name = "DataSet6";
             rsDiscount.Value = disc;*/
           /* rs.Name = "DataSet1";
            rs.Value = lst;
            rsYrType.Name = "DataSet7";
            rsYrType.Value = typeYr;

            /* soa.reportViewer1.LocalReport.DataSources.Clear();
             soa.reportViewer1.LocalReport.DataSources.Add(rsRpt);
             soa.reportViewer1.LocalReport.DataSources.Add(rsCourse);
             soa.reportViewer1.LocalReport.DataSources.Add(rsPaid);*/
           /* soa.reportViewer1.LocalReport.DataSources.Add(rs);
            soa.reportViewer1.LocalReport.DataSources.Add(rsYrType);
            soa.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report5.rdlc";
            soa.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            soa.reportViewer1.ZoomMode = ZoomMode.Percent;
            soa.reportViewer1.ZoomPercent = 100;
            soa.Show();*/

            /*
            StatementOfAccount frm = new StatementOfAccount();
            StudentScheduling ss = new StudentScheduling();
            

           
            

            int stored = 0;
            string wewww = "";
            string getSchedule = "";

            

            List<feeBillings> bills = new List<feeBillings>();
            bills.Clear();

            List<tuitionBilling> tuit = new List<tuitionBilling>();

            for (int i = 0; i < ss.dgvCategories.Rows.Count; i++)
            {
                bills.Add(new feeBillings
                {
                    total = Convert.ToDouble(ss.lblTotal.Text),
                    category = ss.dgvCategories.Rows[i].Cells[0].Value.ToString(),
                    amount = Convert.ToDouble(ss.dgvCategories.Rows[i].Cells[1].Value.ToString()),

                });
            }
            var values = DBContext.GetContext().Query("studentActivation").Where("studentID", studentid.Text).First();

            discount = values.discount;

            totaldiscount = amnt * discount;
            double totaltotal = amnt - totaldiscount;
            tuit.Add(new tuitionBilling
            {

                tuitionTotal = Convert.ToDouble(totaltotal.ToString()),
            });

            double total = amount + Convert.ToDouble(ss.lblTotal.Text);

            DBContext.GetContext().Query("percentage").Where("status", "Active").First();

            var downpayments = DBContext.GetContext().Query("percentage").Where("status", "Active").First();

            downpayment = Convert.ToDouble(downpayments.downpayment);
            total2 = amount + Convert.ToDouble(ss.lblTotal.Text);
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

            led.selectstudentid = studentid.Text;
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
               // yrLevel = cmbYear.Text,
                //studentType = cmbTypeStudent.Text
            });

            
            /*rs.Name = "DataSet1";
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
            //frm.reportViewer1.LocalReport.DataSources.Add(rs);
            //frm.reportViewer1.LocalReport.DataSources.Add(rsBill);
            //frm.reportViewer1.LocalReport.DataSources.Add(rsTuition);
           // frm.reportViewer1.LocalReport.DataSources.Add(rsExams);
            //frm.reportViewer1.LocalReport.DataSources.Add(rsPayment);
           // frm.reportViewer1.LocalReport.DataSources.Add(rsDiscount);
            frm.reportViewer1.LocalReport.DataSources.Add(rsYrType);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report5.rdlc";
            frm.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.reportViewer1.ZoomMode = ZoomMode.Percent;
            frm.reportViewer1.ZoomPercent = 100;
            frm.Show();*/


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

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }
    }


    public class Receipt
    {
        public string studentNo { get; set; }
        public string name { get; set; }
        public int orNo { get; set; }
        public string date { get; set; }
        public double currentBalance { get; set; }
        public string remarks { get; set; }
        public string paymentMode { get; set; }
        public double change { get; set; }
        public double receiveAmt { get; set; }
    }

    public class PaymentCourse
    {
        public string course { get; set; }

    }

    public class TotalPaid
    {
        public double paid { get; set; }
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
