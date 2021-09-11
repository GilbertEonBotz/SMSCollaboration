using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;

namespace SchoolManagementSystem
{
    public partial class Dashboard : Form
    {
        DashboardData dash = new DashboardData();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var myForm = new reports();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();

            dash.CountStudent();
            lblStudent.Text = dash.count.ToString();
            
            
            dash.CountTeacher();
            lblTeacher.Text = dash.count.ToString();

            dash.CountLibrarian();
            lblLibrarian.Text = dash.count.ToString();

            dash.CountAccountants();
            lblAccountant.Text = dash.count.ToString();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
