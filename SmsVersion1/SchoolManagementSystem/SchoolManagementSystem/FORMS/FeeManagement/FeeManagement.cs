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
    public partial class FeeManagement : Form
    {
        public FeeManagement()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            var myfrm = new AddFeeCategory(this, idd);
            FormFade.FadeForm(this, myfrm);
        }

        private void FeeManagement_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {


            dgvCategories.Rows.Clear();
            var values = DBContext.GetContext().Query("categoryfee").Get();

            foreach (var value in values)
            {
                dgvCategories.Rows.Add(value.categoryID, value.category);
            }

        }

        private void dgvCategories_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string idd;
        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idd = dgvCategories.SelectedRows[0].Cells[0].Value.ToString();
            string colName = dgvCategories.Columns[e.ColumnIndex].Name;

            if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("categoryfee").Where("categoryID", dgvCategories.SelectedRows[0].Cells[0].Value).Delete();
                    DBContext.GetContext().Query("totalfee").Where("categoryID", dgvCategories.SelectedRows[0].Cells[0].Value).Delete();
                    displayData();
                }
            }
            else if (colName.Equals("edit"))
            {
                AddFeeCategory add = new AddFeeCategory(this, idd);
                add.txtCategory.Text = dgvCategories.SelectedRows[0].Cells[1].Value.ToString();
                add.btnAddCategory.Text = "Update";
                FormFade.FadeForm(this, add);
            }
        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxWatermark1.Text))
            {
                displayData();
            }
            else if (textboxWatermark1.Text.Equals("Search"))
            {
                displayData();
            }
            else
            {
                var values = DBContext.GetContext().Query("categoryfee").WhereLike("categoryID", $"{textboxWatermark1.Text}")
                .OrWhereLike("category", $"%{textboxWatermark1.Text}%")
                .Get();

                dgvCategories.Rows.Clear();
                foreach (var value in values)
                {
                    dgvCategories.Rows.Add(value.categoryID, value.category);
                }
            }
        }
    }
}
