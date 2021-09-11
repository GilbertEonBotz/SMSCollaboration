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

namespace SchoolManagementSystem
{
    public partial class addCourseCode : Form
    {

        string idd;
        CourseCode reloadDatagrid;
        public addCourseCode(CourseCode reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
        }

        int selCourseID;
        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtCourseCode };
            ComboBox[] cmb = { cmbDepartment };

            if (btnSave.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("coursecode").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {

                        if (value.coursecodeId.Equals(Convert.ToInt32(idd)) && value.coursecode.Equals(txtCourseCode.Text))
                        {
                            DBContext.GetContext().Query("coursecode").Where("coursecodeId", idd).Update(new
                            {
                                courseId = selCourseID,
                                coursecode = txtCourseCode.Text.Trim().ToUpper(),
                                remarks = txtRemarks.Text.Trim(),
                                status = "enable"
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                            return;
                        }
                        else if (value.coursecodeId != Convert.ToInt32(idd) && value.coursecode.Equals(txtCourseCode.Text))
                        {
                            Validator.AlertDanger("Course code already existed");
                            return;
                        }
                    }
                }
                DBContext.GetContext().Query("coursecode").Where("coursecodeId", idd).Update(new
                {
                    courseId = selCourseID,
                    coursecode = txtCourseCode.Text.Trim().ToUpper(),
                    remarks = txtRemarks.Text.Trim(),
                    status = "enable"
                });
                reloadDatagrid.displayData();
                this.Close();
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmptyCmb(cmb))
                {
                    try
                    {
                        DBContext.GetContext().Query("coursecode").Where("coursecode", txtCourseCode.Text).First();
                        Validator.AlertDanger("Course code already existed!");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("coursecode").Insert(new
                        {
                            courseId = selCourseID,
                            coursecode = txtCourseCode.Text.Trim().ToUpper(),
                            remarks = txtRemarks.Text.Trim(),
                            status = "enable"
                        });
                        Validator.AlertSuccess("Course code inserted");
                        reloadDatagrid.displayData();
                        this.Close();
                    }
                }
            }
        }

        private void addCourseCode_Load(object sender, EventArgs e)
        {
            displayData();
            try
            {
                var value = DBContext.GetContext().Query("course").Where("description", cmbDepartment.Text).First();
                selCourseID = value.courseId;
            }
            catch (Exception)
            {
                selCourseID = 0;
            }
        }

        public void displayData()
        {
            var values = DBContext.GetContext().Query("course").Get();

            foreach (var value in values)
            {
                cmbDepartment.Items.Add(value.description);
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = DBContext.GetContext().Query("course").Where("description", cmbDepartment.Text).First();
            selCourseID = value.courseId;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCourseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
