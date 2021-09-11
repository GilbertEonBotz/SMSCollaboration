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
namespace SchoolManagementSystem
{
    public partial class PracticeForm : Form
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader dr;
        MySqlCommand cmd;
        string aa;
        int bb;
        public PracticeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PracticeForm_Load(object sender, EventArgs e)
        {
            //conn = connect.getcon();
            //conn.Open();

            //cmd = new MySqlCommand("select b.schedID, b.subjectCode,b.maxStudent, count(a.schedId) from studentSched a, schedule b where a.schedID regexp b.schedid group by b.schedid", conn);
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    aa = dr[2].ToString();


            //    conn = connect.getcon();
            //    conn.Open();

            //    cmd = new MySqlCommand("select subjectcode from schedule where schedid = '" + dr[0].ToString() + "'", conn);
            //    dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        MessageBox.Show(dr[0].ToString());
            //    }

            //}


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //double total = 0;

            //total = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text);

            //label1.Text = total.ToString("N2");
        }
    }
}
