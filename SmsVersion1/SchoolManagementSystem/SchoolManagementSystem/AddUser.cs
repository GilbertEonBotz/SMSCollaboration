using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SqlKata.Execution;

namespace SchoolManagementSystem
{
    public partial class AddUser : Form
    {
        Users reloadDatagrid;
        string idd;
        public AddUser(Users reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ComboBox[] selCmb = { cmbRole };
            TextBox[] inputs = { txtName, txtUsername, txtPassword, txtConfirmPassword, txtMacAddress };


            if (btnSave.Text.Equals("Update"))
            {
                if (Validator.isEmptyCmb(selCmb) && Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                    {
                        Validator.AlertDanger("Confirm password doesn't match");
                    }
                    else
                    {
                        DBContext.GetContext().Query("users").Where("id", idd).Update(new
                        {
                            name = txtName.Text.Trim(),
                            username = txtUsername.Text.Trim(),
                            password = txtPassword.Text.Trim(),
                            macAddress = txtMacAddress.Text.Trim()
                        });
                        reloadDatagrid.displayData();
                        this.Close();
                    }
                   
                }
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmptyCmb(selCmb) && Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                    {
                        Validator.AlertDanger("Confirm password doesn't match");
                    }
                    else
                    {
                        DBContext.GetContext().Query("users").Insert(new
                        {
                            name = txtName.Text.Trim(),
                            username = txtUsername.Text.Trim(),
                            password = txtPassword.Text.Trim(),
                            userrole = cmbRole.Text,
                            macAddress = txtMacAddress.Text.Trim()
                        });
                        reloadDatagrid.displayData();
                        this.Close();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            displayRole();
        }

        private void displayRole()
        {
            
        }

        private void cmbRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AddUser_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void AddUser_KeyDown(object sender, KeyEventArgs e)
        {
          if(e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
