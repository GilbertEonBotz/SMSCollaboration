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
    public partial class LibrarianInformation : Form
    {
        public LibrarianInformation()
        {
            InitializeComponent();
        }

        private void btnAddLibrarian_Click(object sender, EventArgs e)
        {
            var myform = new AddLibrarian(this);
            FormFade.FadeForm(this, myform);
        }

        private void LibrarianInformation_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvLibrarians.Rows.Clear();
            var values = DBContext.GetContext().Query("librarians").Get();

            foreach (var value in values)
            {
                dgvLibrarians.Rows.Add(value.librarianId, $"{value.Firstname} {value.Middlename} {value.Lastname}", value.ContactNo, value.Gender, value.Address);
            }
        }

        private void dgvLibrarians_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var myfrm = new AddLibrarian(this);
            int id = Convert.ToInt32(dgvLibrarians.Rows[dgvLibrarians.CurrentRow.Index].Cells[0].Value);
            var value = DBContext.GetContext().Query("librarians").Where("librarianId", id).First();

            myfrm.lblID.Text = id.ToString();
            myfrm.txtLastname.Text = value.Lastname;
            myfrm.txtFirstname.Text = value.Firstname;
            myfrm.txtMiddlename.Text = value.Middlename;
            myfrm.dtpDateofbirth.Text = value.DateofBirth;
            myfrm.txtPlaceofbirth.Text = value.PlaceofBirth;
            myfrm.txtContactNo.Text = Convert.ToString(value.ContactNo);
            myfrm.cmbGender.Text = value.Gender;
            myfrm.cmbMaritalStatus.Text = value.MaritalStatus;
            myfrm.txtCitizen.Text = value.Citizenship;
            myfrm.txtReligion.Text = value.Religion;
            myfrm.txtAddress.Text = value.Address;
            myfrm.btnAddLibrarian.Text = "Update";

            myfrm.ShowDialog();
        }
    }
}
