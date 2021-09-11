using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlKata.Execution;
using EonBotzLibrary;
namespace SchoolManagementSystem.FORMS
{
    public partial class studentActivation : Form
    {
        public string studentid;

        double discount;
        StudentActivation reloadDatagrid;
        public studentActivation(StudentActivation reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
        }

        private void studentActivation_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAcademicYear_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.Equals("Fullpayment"))
            {
                DBContext.GetContext().Query("studentActivation").Insert(new
                {

                    studentID = studentid,
                    fullpayment = textBox1.Text,
                    downpayment = "0.00",
                    note = comboBox2.Text,
                    paymentMethod = comboBox1.Text,
                    status = "Activated",
                    discount = discount,
                    date = DateTime.Now,
                    discountDescription = comboBox3.Text
                });
                Validator.AlertSuccess("Student activated");
                reloadDatagrid.displayData();
                this.Close();
            }
            else
            {
                DBContext.GetContext().Query("studentActivation").Insert(new
                {

                    studentID = studentid,
                    downpayment = textBox1.Text,
                    fullpayment = "0.00",
                    note = comboBox2.Text,
                    paymentMethod = comboBox1.Text,
                    status = "Activated",
                    discount = discount,
                    date = DateTime.Now,
                    discountDescription = comboBox3.Text
                });
                Validator.AlertSuccess("Student activated");
                reloadDatagrid.displayData();
                this.Close();
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Blood Related")
            {
                discount = 0.20;
                label8.Text = "20%";
            }
            else if (comboBox3.Text == "Loyalty")
            {
                discount = 0.100;
                label8.Text = "100%";
            }
            else if (comboBox3.Text == "Employee")
            {
                discount = 0.20;
                label8.Text = "20%";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
