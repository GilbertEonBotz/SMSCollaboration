using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SchoolManagementSystem.UITools;
using SqlKata.Execution;

namespace SchoolManagementSystem
{
    public partial class TeacherInformation : Form
    {
        public TeacherInformation()
        {
            InitializeComponent();
        }

        private void TeacherInformation_Load(object sender, EventArgs e)
        {
            displayData();

        }

        public void displayData()
        {
            dgvTeachers.Rows.Clear();
            var values = DBContext.GetContext().Query("teachers").Get();

            foreach (var value in values)
            {
                dgvTeachers.Rows.Add(value.teacherId, $"{value.Firstname} {value.Middlename} {value.Lastname}", value.ContactNo, value.Gender, value.Address);
            }
        }
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            displayData();

            var myfrm = new AddTeacher(this);
            FormFade.FadeForm(this, myfrm);
        }

        private void dgvTeachers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dgvTeachers_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var myfrm = new AddTeacher(this);
            int id = Convert.ToInt32(dgvTeachers.Rows[dgvTeachers.CurrentRow.Index].Cells[0].Value);
            var value = DBContext.GetContext().Query("teachers").Where("teacherId", id).First();

            myfrm.lblID.Text = id.ToString();
            myfrm.txtLastname.Text = value.Lastname;
            myfrm.txtFirstname.Text = value.Firstname;
            myfrm.txtMiddlename.Text = value.Middlename;
            myfrm.dtpDateofbirth.Text = value.DateOfBirth;
            myfrm.txtPlaceofbirth.Text = value.PlaceOfBirth;
            myfrm.txtContactNo.Text = Convert.ToString(value.ContactNo);
            myfrm.cmbGender.Text = value.Gender;
            myfrm.cmbMaritalStatus.Text = value.MaritalStatus;
            myfrm.txtCitizen.Text = value.Citizenship;
            myfrm.txtReligion.Text = value.Religion;
            myfrm.txtAddress.Text = value.Address;
            myfrm.btnAddTeachers.Text = "Update";
            myfrm.cmbDepartment.Text = value.department;

            myfrm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            var values = DBContext.GetContext().Query("teachers").WhereLike("teacherId", $"{textboxWatermark1.Text}")
             .OrWhereLike("Firstname", $"%{textboxWatermark1.Text}%")
             .OrWhereLike("Lastname", $"%{textboxWatermark1.Text}%")
             .Get();

            dgvTeachers.Rows.Clear();
            foreach (var value in values)
            {
                dgvTeachers.Rows.Add(value.teacherId, $"{value.Firstname} {value.Middlename} {value.Lastname}", value.ContactNo, value.Gender, value.Address);
            }
        }
    }
}
