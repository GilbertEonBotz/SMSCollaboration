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
    public partial class AddDepartment : Form
    {
        Department reloadDatagrid;
        string idd;
        public AddDepartment(Department reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtDeptName };

            if (btnSave.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("department").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {

                        if (value.deptID.Equals(Convert.ToInt32(idd)) && value.deptName.Equals(txtDeptName.Text))
                        {
                            DBContext.GetContext().Query("department").Where("deptID", idd).Update(new
                            {
                                deptName = Validator.ToTitleCase(txtDeptName.Text.Trim())
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                            return;
                        }
                        else if (value.deptID != Convert.ToInt32(idd) && value.deptName.Equals(Validator.ToTitleCase(txtDeptName.Text)))
                        {
                            Validator.AlertDanger("Department name already existed");
                            return;
                        }
                    }
                }

                DBContext.GetContext().Query("department").Where("deptID", idd).Update(new
                {
                    deptName = Validator.ToTitleCase(txtDeptName.Text.Trim())
                });
                reloadDatagrid.displayData();
                this.Close();
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs))
                {
                    try
                    {
                        DBContext.GetContext().Query("department").Where("deptName", txtDeptName.Text).First();
                        Validator.AlertDanger("Department name already existed");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("department").Insert(new
                        {
                            deptName = Validator.ToTitleCase(txtDeptName.Text.Trim())
                        });
                        Validator.AlertSuccess("New Department added");
                        txtDeptName.Text = "";
                        reloadDatagrid.displayData();

                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDeptName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
