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
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem.BSED
{
    public partial class BSEDSelectionForm : Form
    {
        public BSEDSelectionForm()
        {
            InitializeComponent();
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
        string macadd;
        string role;
        private void btnSignin_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            

            try
            {

                string sql = "SELECT username,password,macAddress,userrole FROM users WHERE username = '" + txtUsername.Text+"' and password ='"+txtPassword.Text+"'";


                conn = connect.getconn();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        macadd = mdr[2].ToString();
                        role = mdr[3].ToString();
                    }
                }




                //     var query = DBContexts.GetContext().Query("users")
                //    .Where("status", "Active")
                //    .Where(new
                //    {
                //        username = txtUsername.Text,
                //        password = txtPassword.Text,
                //    }).First();

                //if (query.macAddress.Equals(GetMacAddress()))
                if(macadd.Equals(GetMacAddress()))
                {
                    this.Hide();
                    var myfrm = new BSEDAdminDashboard();
                    myfrm.btnAdmin.Text = role;
                    myfrm.Show();
                }

                else
                {
                    Validator.AlertDanger("You cant login other role to another pc");
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid credentials");
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignin.PerformClick();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            SelectionForm f = new SelectionForm();
            f.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
