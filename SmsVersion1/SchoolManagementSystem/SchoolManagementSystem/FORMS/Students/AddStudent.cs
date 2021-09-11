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
    public partial class AddStudent : Form
    {

        StudentInformation reloadDatagrid; // reload datagrid 
        public AddStudent(StudentInformation reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {

            TextBox[] inputs = { txtLastname, txtFirstname, txtMiddlename,  txtPlaceofbirth, txtReligion,
            txtCitizen, txtContactNo, txtAddress, txtHomeAddress, txtFatherLname, txtFatherFname,
            txtFatherMname, txtFatherOccupation, txtMotherLname, txtMotherFname, txtMotherMname, txtMotherOccupation,
            txtSchooLast};


            var birth = (chkPsa.Checked) ? 1 : 0;
            var card = (chkReportCard.Checked) ? 1 : 0;
            var honorable = (chkHonorable.Checked) ? 1 : 0;




            if (btnAddStudent.Text.Equals("Update"))
            {
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    

                    DBContext.GetContext().Query("student").Where("studentId", lblID.Text).Update(new
                    {
                        lastname = txtLastname.Text.Trim(),
                        firstname = txtFirstname.Text.Trim(),
                        middlename = txtMiddlename.Text.Trim(),
                        suffix = cmbSuffix.Text,
                        dateofbirth = dtpDateofbirth.Value.ToString("MM/dd/yyyy"),
                        placeofbirth = txtPlaceofbirth.Text.Trim(),
                        religion = txtReligion.Text.Trim(),
                        gender = cmbGender.Text,
                        maritalstatus = cmbMaritalStatus.Text,
                        citizenship = txtCitizen.Text.Trim(),
                        contactno = txtContactNo.Text,
                        //emailAddress = txtEmailAddress.Text.Trim(),
                        course = cmbCourse.Text,
                        presentAddress = txtAddress.Text.Trim(),
                        homeAddress = txtHomeAddress.Text.Trim(),
                        fatherLastname = txtFatherLname.Text.Trim(),
                        fatherFirstname = txtFatherFname.Text.Trim(),
                        fatherMiddlename = txtFatherMname.Text.Trim(),
                        fatherOccupation = txtFatherOccupation.Text.Trim(),
                        motherLastname = txtMotherLname.Text.Trim(),
                        motherFirstname = txtMotherFname.Text.Trim(),
                        motherMiddlename = txtMotherMname.Text.Trim(),
                        motherOccupation = txtMotherOccupation.Text.Trim(),
                        schoolLastAttended = txtSchooLast.Text.Trim(),
                        dateLastAttended = dtpLast.Value.ToString("MM/dd/yyyy"),
                        psa = birth,
                        reportCard = card,
                        honorableDismissal = honorable,
                        //lastname = txtLastname.Text.Trim(),
                        //firstname = txtFirstname.Text.Trim(),
                        //middlename = txtMiddlename.Text.Trim(),
                        //suffix = cmbSuffix.Text,
                        //dateofbirth = dtpDateofbirth.Value.ToString("MM/dd/yyyy"),
                        //placeofbirth = txtPlaceofbirth.Text.Trim(),
                        //religion = txtReligion.Text.Trim(),
                        //gender = cmbGender.Text,
                        //maritalstatus = cmbMaritalStatus.Text,
                        //citizenship = txtCitizen.Text.Trim(),
                        //contactno = txtContactNo.Text,
                        //emailAddress = txtEmailAddress.Text.Trim(),
                        //course = cmbCourse.Text,
                        //presentAddress = txtAddress.Text.Trim(),
                        //homeAddress = txtHomeAddress.Text.Trim(),
                        //fatherLastname = txtFatherLname.Text.Trim(),
                        //fatherFirstname = txtFatherFname.Text.Trim(),
                        //fatherMiddlename = txtFatherMname.Text.Trim(),
                        //fatherOccupation = txtFatherOccupation.Text.Trim(),
                        //motherLastname = txtMotherLname.Text.Trim(),
                        //motherFirstname = txtMotherFname.Text.Trim(),
                        //motherMiddlename = txtMotherMname.Text.Trim(),
                        //motherOccupation = txtMotherOccupation.Text.Trim(),
                        //schoolLastAttended = txtSchooLast.Text.Trim(),
                        //dateLastAttended = dtpLast.Value.ToString("MM/dd/yyyy"),
                        //psa = birth,
                        //reportCard = card,
                        //honorableDismissal = honorable,
                    });
                    reloadDatagrid.displayData();
                    this.Close();
                }
            }
            else if (btnAddStudent.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation() && Validator.ValidateDate(dtpDateofbirth))
                {
                    try
                    {
                        try
                        {
                            DBContext.GetContext().Query("student").Where("lastname", txtLastname.Text).Where("firstname", txtFirstname.Text).Where("middlename", txtMiddlename.Text).First();
                            Validator.AlertDanger("Student already existed");
                        }
                        catch (Exception)
                        {
                            
                            DBContext.GetContext().Query("student").Insert(new
                            {
                                lastname = txtLastname.Text.Trim(),
                                firstname = txtFirstname.Text.Trim(),
                                middlename = txtMiddlename.Text.Trim(),
                                suffix = cmbSuffix.Text,
                                dateofbirth = dtpDateofbirth.Value.ToString("MM/dd/yyyy"),
                                placeofbirth = txtPlaceofbirth.Text.Trim(),
                                religion = txtReligion.Text.Trim(),
                                gender = cmbGender.Text,
                                maritalstatus = cmbMaritalStatus.Text,
                                citizenship = txtCitizen.Text.Trim(),
                                contactno = txtContactNo.Text,
                               // emailAddress = txtEmailAddress.Text.Trim(),
                                course = cmbCourse.Text,
                                presentAddress = txtAddress.Text.Trim(),
                                homeAddress = txtHomeAddress.Text.Trim(),
                                fatherLastname = txtFatherLname.Text.Trim(),
                                fatherFirstname = txtFatherFname.Text.Trim(),
                                fatherMiddlename = txtFatherMname.Text.Trim(),
                                fatherOccupation = txtFatherOccupation.Text.Trim(),
                                motherLastname = txtMotherLname.Text.Trim(),
                                motherFirstname = txtMotherFname.Text.Trim(),
                                motherMiddlename = txtMotherMname.Text.Trim(),
                                motherOccupation = txtMotherOccupation.Text.Trim(),
                                schoolLastAttended = txtSchooLast.Text.Trim(),
                                dateLastAttended = dtpLast.Value.ToString("MM/dd/yyyy"),
                                psa = birth,
                                reportCard = card,
                                honorableDismissal = honorable,

                            });
                            Validator.AlertSuccess("Student Added");
                            reloadDatagrid.displayData();
                            this.Close();
                        }

                    }
                    catch (Exception)
                    {
                        Validator.AlertDanger("The course field is empty. Please select or add course!");
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            displayCourse();
            txtLastname.Focus();
        }

        private void displayCourse()
        {
            var values = DBContext.GetContext().Query("course").Get();

            foreach (var value in values)
            {
                cmbCourse.Items.Add(value.abbreviation);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var result = (checkBox1.Checked) ? txtHomeAddress.Text = txtAddress.Text : txtHomeAddress.Text = "";
        }

        private void dtpDateofbirth_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }
}
