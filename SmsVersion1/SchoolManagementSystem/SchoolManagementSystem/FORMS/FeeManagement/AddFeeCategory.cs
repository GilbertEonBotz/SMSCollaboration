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
    public partial class AddFeeCategory : Form
    {

        FeeManagement reloadDatagrid;
        string idd;
        public AddFeeCategory(FeeManagement reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtCategory };

            if (btnAddCategory.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs))
                {
                    try
                    {
                        DBContext.GetContext().Query("categoryfee").Where("category", txtCategory.Text).First();
                        Validator.AlertDanger("Category fee existed");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("categoryfee").Insert(new
                        {
                            category = txtCategory.Text.Trim(),
                        });
                        Validator.AlertSuccess("Category Added");
                        reloadDatagrid.displayData();
                    }
                    txtCategory.Text = "";
                }
            }
            else if (btnAddCategory.Text.Equals("Update"))
            {
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    DBContext.GetContext().Query("categoryfee").Where("categoryID", idd).Update(new
                    {
                        category = txtCategory.Text.Trim(),
                    });
                    reloadDatagrid.displayData();
                    Validator.AlertSuccess("Category Updated");
                    this.Close();
                }

            }
        }

        private void AddFeeCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

