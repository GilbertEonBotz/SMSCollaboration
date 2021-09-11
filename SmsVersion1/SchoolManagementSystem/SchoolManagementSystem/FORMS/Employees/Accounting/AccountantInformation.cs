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
    public partial class AccountantInformation : Form
    {
        public AccountantInformation()
        {
            InitializeComponent();
        }

        private void btnAddAccountant_Click(object sender, EventArgs e)
        {
            var myform = new AddAccountant(this);
            myform.ShowDialog();
        }

        private void AccountantInformation_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvAccountant.Rows.Clear();
            var values = DBContext.GetContext().Query("accountants").Get();

            foreach (var value in values)
            {
                dgvAccountant.Rows.Add(value.accountantId, $"{value.Firstname} {value.Middlename} {value.Lastname}", value.ContactNo, value.Gender, value.Address);
            }
        }

        private void dgvAccountant_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var myfrm = new AddAccountant(this);
            int id = Convert.ToInt32(dgvAccountant.Rows[dgvAccountant.CurrentRow.Index].Cells[0].Value);
            var value = DBContext.GetContext().Query("accountants").Where("accountantId", id).First();

            myfrm.lblID.Text = id.ToString();
            myfrm.txtLastname.Text = value.Lastname;
            myfrm.txtFirstname.Text = value.Firstname;
            myfrm.txtMiddlename.Text = value.Middlename;
            myfrm.dtpDateofbirth.Text = value.Dateofbirth;
            myfrm.txtPlaceofbirth.Text = value.Placeofbirth;
            myfrm.txtContactNo.Text = Convert.ToString(value.ContactNo);
            myfrm.cmbGender.Text = value.Gender;
            myfrm.cmbMaritalStatus.Text = value.MaritalStatus;
            myfrm.txtCitizen.Text = value.Citizenship;
            myfrm.txtReligion.Text = value.Religion;
            myfrm.txtAddress.Text = value.Address;
            myfrm.btnAddAccountant.Text = "Update";
            myfrm.ShowDialog();
        }
    }
}
