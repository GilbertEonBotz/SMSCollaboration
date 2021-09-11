using SchoolManagementSystem.FORMS.MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SqlKata.Execution;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;




namespace SchoolManagementSystem
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {

            InitializeComponent();
        }


        bool isShow;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
            isShow = true;
            timer.Start();
            pnlSlide2.Show();
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {

            pnlSlide2.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isShow)
            {
                if (pnlSlide2.Width >= 1200)
                    timer.Stop();
                pnlSlide2.Width += 500;
            }
            else
            {
                if (pnlSlide2.Width <= 0)
                {
                    pnlSlide2.Hide();
                    timer.Stop();
                }

                pnlSlide2.Width -= 500;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (pnlSlide2.Visible)
            {
                isShow = false;
                timer.Start();
            }
        }

        public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        //string macadd;
        //string role;
        private void btnSignin_Click(object sender, EventArgs e)
        {
           

            //kini mao ning tinuod nga source code
            try
            {
                var query = DBContext.GetContext().Query("users")
                    .Where("status", "Active")
                    .Where(new
                    {
                        username = txtUsername.Text,
                        password = txtPassword.Text,
                    }).First();

                if (query.macAddress.Equals(GetMacAddress()))
                {

                    
                    finalDashboard myfrm2 = new finalDashboard();
                    SplashScreen myfrm = new SplashScreen();
                    // 
                   
                    //myfrm2.btnAdmin.Text = query.userrole;
                    myfrm.label2.Text = query.userrole;
                    myfrm.Show();
                    this.Hide();
                }

                else
                {
                    Validator.AlertDanger("You cant login other role to another pc");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pnlSlide2_Paint(object sender, PaintEventArgs e)
        {
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //BSED.BSEDSelectionForm bs = new BSED.BSEDSelectionForm();
            ////SMSBSED.BSEDSelectionForm bs = new SMSBSED.BSEDSelectionForm();
            //bs.Show();
            //this.Hide();
            ////bs.txtUsername.Focus();


            //SMSBSEDPrototype.BSEDSelectionForm bsed = new SMSBSEDPrototype.BSEDSelectionForm();
            //bsed.Show();
            //this.Hide();
            //bsed.txtUsername.Focus();


        }
    }
}
