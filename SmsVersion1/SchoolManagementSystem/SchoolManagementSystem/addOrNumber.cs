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
    public partial class addOrNumber : Form
    {
        OrNumberMaintenance reloadDatagrid;
        public addOrNumber(OrNumberMaintenance reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
        }

        private void btnAddAcademicYear_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtFirstNum, txtEndNum };
            if (Validator.isEmpty(inputs))
            {
                if (Convert.ToInt32(txtFirstNum.Text) > Convert.ToInt32(txtEndNum.Text))
                {
                    Validator.AlertDanger("Start Number must not be greater than End Number!");
                }
                else
                {
                    DBContext.GetContext().Query("ornumber").Update(new
                    {
                        status = "Inactive"
                    });

                    DBContext.GetContext().Query("ornumber").Insert(new {
                        startNum = txtFirstNum.Text,
                        endNum = txtEndNum.Text,
                        status = "Active"
                    });
                    reloadDatagrid.displayData();
                    Validator.AlertSuccess("OR Number added");
                    this.Close();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEndNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
