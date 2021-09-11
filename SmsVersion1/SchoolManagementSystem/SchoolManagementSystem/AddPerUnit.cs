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
    public partial class AddPerUnit : Form
    {
        AddUnitPrice reloadDatagrid;
        public AddPerUnit(AddUnitPrice reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAcademicYear_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtName };

            if (Validator.isEmpty(inputs))
            {
                DBContext.GetContext().Query("unitPrice").Update(new { 
                    status = "Inactive"
                });

                DBContext.GetContext().Query("unitPrice").Insert(new { 
                    amount = txtName.Text.Trim(),
                    status = "Active"
                });
                Validator.AlertSuccess("Price per unit successfully added");
                reloadDatagrid.displayData();
                this.Close();
            }

        }

        private void AddPerUnit_Load(object sender, EventArgs e)
        {
            txtName.KeyPress += Validator.ValidateKeypressNumber;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
