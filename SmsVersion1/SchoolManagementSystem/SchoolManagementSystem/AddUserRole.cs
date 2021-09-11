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
    public partial class AddUserRole : Form
    {
        UserRole reloadDatagrid;
        string idd;
        public AddUserRole(UserRole reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtRole };

            if (btnSave.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("role").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {
                        if (value.roleId.Equals(Convert.ToInt32(idd)) && value.roletype.Equals(txtRole.Text))
                        {
                            DBContext.GetContext().Query("role").Where("roleId", idd).Update(new
                            {
                                roletype = Validator.ToTitleCase(txtRole.Text.Trim())
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                            return;
                        }
                        else if (value.roleId != Convert.ToInt32(idd) && value.roletype.Equals(Validator.ToTitleCase(txtRole.Text)))
                        {
                            Validator.AlertDanger("Role name already existed");
                            return;
                        }
                    }
                }

                DBContext.GetContext().Query("role").Where("roleId", idd).Update(new
                {
                    roletype = Validator.ToTitleCase(txtRole.Text.Trim())
                });
                reloadDatagrid.displayData();
                this.Close();
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    try
                    {
                        DBContext.GetContext().Query("role").Where("roletype", txtRole.Text).Where("status", "activate").First();
                        Validator.AlertDanger("Role type exist");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("role").Insert(new
                        {
                            roletype = Validator.ToTitleCase(txtRole.Text.Trim()),
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

        private void AddUserRole_Load(object sender, EventArgs e)
        {
          
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
