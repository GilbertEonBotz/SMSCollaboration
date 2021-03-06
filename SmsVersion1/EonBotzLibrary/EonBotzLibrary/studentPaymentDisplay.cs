using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using SqlKata.Execution;

namespace EonBotzLibrary
{


    public class studentPaymentDisplay
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;
        public DataTable dt = new DataTable();
        public string paymentid { set; get; }
        public string studentID { set; get; }
        public string prelim { set; get; }

        public string midterm { set; get; }
        public string currentbalance { set; get; }
        public string semi { set; get; }
        public string final { set; get; }
        public string total { set; get; }
        public string billingid { set; get; }
        public string amount { set; get; }
        public string remarks { set; get; }
        public string paymentMethod { set; get; }
        public string status { set; get; }
        public double totalpaid { set; get; }
        public string studentdownpayment { set; get; }
        public string studentfullpayment { set; get; }
        public string dateForDown { set; get; }
        public string remarksFordown { set; get; }
        public string dateForFull { set; get; }
        public string remarksForfull { set; get; }
        public int orNumber { set; get; }

        public void display()
        {
            //display
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select c.studentid,c.firstname,c.lastname,b.total, c.course, c.gender, c.presentAddress from  Billing b , studentSched a,student c where b.studentSchedID = a.studentSchedID and c.studentid = a.studentid", conn))
            {
                mdr = cmd.ExecuteReader();
                dt.Columns.Clear();

                dt.Columns.Add("StudentID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Total");
                dt.Columns.Add("Course");
                dt.Columns.Add("Gender");
                dt.Columns.Add("PresentAddress");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), $"{mdr[1].ToString()} {mdr[2].ToString()}", mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString(), mdr[6].ToString());
                }
                conn.Close();
                conn.Dispose();
            }
        }

        public void viewPayment()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("select a.prelim,midterm,semi,finals,total,billingid from Billing a,studentSched b,student c where  a.studentSchedid = b.studentSchedID and b.studentid = c.studentid and c.studentid ='" + studentID + "'", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    prelim = mdr[0].ToString();
                    midterm = mdr[1].ToString();
                    semi = mdr[2].ToString();
                    final = mdr[3].ToString();
                    total = mdr[4].ToString();
                    billingid = mdr[5].ToString();
                }
            }
            conn.Close();
            conn.Dispose();

        }

        public void studentDOwn()
        {

            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select downpayment,note,date from studentActivation where studentid  = '" + studentID + "'", conn);
            mdr = cmd.ExecuteReader();


            dt.Columns.Clear();
            dt.Columns.Add("studentdown");
            dt.Columns.Add("fordown");

            while (mdr.Read())
            {

                studentdownpayment = mdr[0].ToString();
                remarksFordown = mdr[1].ToString();
                dateForDown = mdr[2].ToString();


            }
            conn.Close();
            conn.Dispose();
        }

        public void studentFull()
        {

            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select fullpayment,note,date from studentActivation where studentid  = '" + studentID + "'", conn);
            mdr = cmd.ExecuteReader();


            dt.Columns.Clear();
            dt.Columns.Add("studentfull");
            dt.Columns.Add("forfull");

            while (mdr.Read())
            {

                studentfullpayment = mdr[0].ToString();
                remarksForfull = mdr[1].ToString();
                dateForFull = mdr[2].ToString();


            }
            conn.Close();
            conn.Dispose();
        }
        public void insertpayment()
        {
            try
            {
                var endNum = DBContext.GetContext().Query("ornumber").Where("status", "Active").First();

                DBContext.GetContext().Query("ornumber")
                                 .Join("payment", "payment.orNumber", "ornumber.startNum")
                                 .Where("ornumber.status", "Active")
                                 .First();

                var maxOr = DBContext.GetContext().Query("payment").OrderByDesc("paymentID").First();

                if (maxOr.orNumber == endNum.endNum)
                {
                    Validator.AlertDanger("OR Number exceed");
                }
                else
                {
                    //DBContext.GetContext().Query("payment").Insert(new
                    //{
                    //    orNumber = maxOr.orNumber + 1,
                        
                    //});
                    conn = connect.getcon();
                    conn.Open();
                    int number = maxOr.orNumber + 1;
                    dt.Clear();
                    cmd = new MySqlCommand("insert into payment(billingid,amount,remarks,paymentmethod,date,time,status, orNumber) values ('" + billingid + "','" + amount + "','" + remarks + "','" + paymentMethod + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + status + "','" + number + "')", conn);
                    cmd.ExecuteNonQuery();
                    Validator.AlertSuccess("Payment");
                    conn.Close();
                    conn.Dispose();

                }
            }
            catch (Exception)
            {
                var value = DBContext.GetContext().Query("ornumber").Where("status", "Active").First();
                conn = connect.getcon();
                conn.Open();

                dt.Clear();
                cmd = new MySqlCommand("insert into payment(billingid,amount,remarks,paymentmethod,date,time,status, orNumber) values ('" + billingid + "','" + amount + "','" + remarks + "','" + paymentMethod + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','" + status + "','" + value.startNum + "')", conn);
                cmd.ExecuteNonQuery();
                Validator.AlertSuccess("Payment");
                conn.Close();
                conn.Dispose();
            }
        }

        public void viewtransaction()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select b.paymentid, b.amount,b.remarks,b.date  from Billing a, payment b where a.billingid = b.billingid and b.status ='paid' and a.billingid ='" + billingid + "'", conn);
            mdr = cmd.ExecuteReader();

            dt.Columns.Clear();

            dt.Columns.Clear();
            dt.Columns.Add("paymentid");
            dt.Columns.Add("paymentanomount");
            dt.Columns.Add("paymentremarks");
            dt.Columns.Add("paymentdate");

            while (mdr.Read())
            {

                dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString());
            }
            conn.Close();
            conn.Dispose();
        }
        public void viewPaymentDetailed()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select a.downpayment,sum(d.amount)+a.downpayment  from studentActivation a  left join studentSched b on a.studentid ='" + studentID + "' left join Billing c on b.studentSchedid = c.studentSchedid and a.studentID = b.studentID and billingID ='" + billingid + "' left join payment d on d.billingID = c.billingID and d.status ='paid'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                try
                {
                    totalpaid = Convert.ToDouble(mdr[1].ToString());
                }
                catch (Exception) { totalpaid = Convert.ToDouble(mdr[0].ToString()); }

            }
            conn.Close();
            conn.Dispose();

                
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select  a.total  -sum(b.amount)-c.downpayment  from Billing a, payment b,studentActivation c,studentSched d where a.billingid = b.billingid and b.status ='paid' and a.billingid ='" + billingid + "' and d.studentSchedid= a.studentSchedid and d.studentID = c.studentID", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                currentbalance = mdr[0].ToString();
            }
            conn.Close();
            conn.Dispose();
        }
    }
}