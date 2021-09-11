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
    public partial class AddAccountant : Form
    {
        AccountantInformation reloadDatagrid;
        public AddAccountant(AccountantInformation reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(800, 250);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAccountant_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtLastname, txtFirstname, txtMiddlename, txtPlaceofbirth, txtContactNo, txtCitizen, txtReligion, txtAddress };
            if (btnAddAccountant.Text.Equals("Update"))
            {
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation()  && Validator.ValidateDate(dtpDateofbirth))
                {
                    DBContext.GetContext().Query("accountants").Where("accountantId", lblID.Text).Update(new
                    {
                        Lastname = txtLastname.Text,
                        Firstname = txtFirstname.Text,
                        Middlename = txtMiddlename.Text,
                        Dateofbirth = dtpDateofbirth.Value.ToString("MM/dd/yyyy"),
                        Placeofbirth = txtPlaceofbirth.Text,
                        ContactNo = txtContactNo.Text,
                        Gender = cmbGender.Text,
                        MaritalStatus = cmbMaritalStatus.Text,
                        Citizenship = txtCitizen.Text,
                        Religion = txtReligion.Text,
                        Address = txtAddress.Text,
                    });
                    reloadDatagrid.displayData();
                    this.Close();
                }
            }
            else if (btnAddAccountant.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation()  && Validator.ValidateDate(dtpDateofbirth))
                {
                    DBContext.GetContext().Query("accountants").Insert(new
                    {
                        Lastname = txtLastname.Text,
                        Firstname = txtFirstname.Text,
                        Middlename = txtMiddlename.Text,
                        Dateofbirth = dtpDateofbirth.Value.ToString("MM/dd/yyyy"),
                        Placeofbirth = txtPlaceofbirth.Text,
                        ContactNo = txtContactNo.Text,
                        Gender = cmbGender.Text,
                        MaritalStatus = cmbMaritalStatus.Text,
                        Citizenship = txtCitizen.Text,
                        Religion = txtReligion.Text,
                        Address = txtAddress.Text,

                    });
                    reloadDatagrid.displayData();
                    this.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDateofbirth_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
