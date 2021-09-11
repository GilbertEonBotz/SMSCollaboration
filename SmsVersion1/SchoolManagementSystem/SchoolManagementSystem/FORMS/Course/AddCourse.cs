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
    public partial class AddCourse : Form
    {
        CourseInformation reloadDatagrid;
        string idd;
        public AddCourse(CourseInformation reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
        }


        private void displayDepartments()
        {
            var values = DBContext.GetContext().Query("department").Get();

            foreach (var value in values)
            {
                cmbDepartment.Items.Add(value.deptName);
            }
        }
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtDescription, txtAbbreviation };
            ComboBox[] cmb = { cmbDepartment };

            if (btnSave.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("course").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {
                        if (value.courseId.Equals(Convert.ToInt32(idd)) && value.abbreviation.Equals(txtAbbreviation.Text) && value.description.Equals(txtAbbreviation.Text))
                        {
                            var getId = DBContext.GetContext().Query("department").Where("deptName", cmbDepartment.Text.ToUpper()).First();
                            DBContext.GetContext().Query("course").Where("courseId", idd).Update(new
                            {
                                description = Validator.ToTitleCase(txtDescription.Text.Trim()),
                                abbreviation = txtAbbreviation.Text.Trim().ToUpper(),
                                deptID = getId.deptID,
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                        }
                        else if (value.courseId != Convert.ToInt32(idd) && value.abbreviation.Equals(txtAbbreviation.Text.ToUpper()))
                        {
                            Validator.AlertDanger("Abbreviation name already existed");
                            return;
                        }
                        else if (value.courseId != Convert.ToInt32(idd) && value.description.Equals(Validator.ToTitleCase(txtDescription.Text)))
                        {
                            Validator.AlertDanger("Description name already existed");
                            return;
                        }
                    }
                }
                var getsId = DBContext.GetContext().Query("department").Where("deptName", cmbDepartment.Text.ToUpper()).First();
                DBContext.GetContext().Query("course").Where("courseId", idd).Update(new
                {
                    description = Validator.ToTitleCase(txtDescription.Text.Trim()),
                    abbreviation = txtAbbreviation.Text.Trim().ToUpper(),
                    deptID = getsId.deptID,

                });
                reloadDatagrid.displayData();
                this.Close();
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmptyCmb(cmb) && Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {

                    try
                    {
                        DBContext.GetContext().Query("course").Where("description", txtDescription.Text).OrWhere("abbreviation", txtAbbreviation.Text).First();
                        Validator.AlertDanger("Please select unique description or abbreviation");
                    }
                    catch (Exception)
                    {
                        var value = DBContext.GetContext().Query("department").Where("deptName", cmbDepartment.Text).First();

                      
                        
                            DBContext.GetContext().Query("course").Insert(new
                            {
                                description = Validator.ToTitleCase(txtDescription.Text.Trim()),
                                abbreviation = txtAbbreviation.Text.Trim().ToUpper(),
                                deptID = value.deptID,
                                status = "enable"
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

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            displayDepartments();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddCourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
