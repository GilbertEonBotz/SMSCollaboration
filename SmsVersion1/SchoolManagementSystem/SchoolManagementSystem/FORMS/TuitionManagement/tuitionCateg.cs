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
    public partial class tuitionCateg : Form
    {
        TuitionCategoryInfo reloadDatagrid;
        public tuitionCateg(TuitionCategoryInfo reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtCategory, txtDescription };

            if (btnSave.Text.Equals("Update"))
            {
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    DBContext.GetContext().Query("tuitioncategory").Where("tuitionCatID", lblIDD.Text).Update(new
                    {
                        category = txtCategory.Text.Trim(),
                        description = txtDescription.Text.Trim()
                    });
                    reloadDatagrid.displayData();
                    this.Close();
                }
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    DBContext.GetContext().Query("tuitioncategory").Insert(new
                    {
                        category = txtCategory.Text.Trim(),
                        description = txtDescription.Text.Trim()
                    });
                    reloadDatagrid.displayData();
                    this.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
