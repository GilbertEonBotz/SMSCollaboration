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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            var myfrm = new AddDepartment(this, idd);
            FormFade.FadeForm(this, myfrm);
        }

        public void displayData()
        {
            dgvDepartment.Rows.Clear();
            var depts = DBContext.GetContext().Query("department").Get();

            foreach (var dept in depts)
            {
                dgvDepartment.Rows.Add(dept.deptID, dept.deptName);
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {
            displayData();

        }

        private void dgvDepartment_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvDepartment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
            e.Handled = true;
        }

        string idd;
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvDepartment.Columns[e.ColumnIndex].Name;

            if (colName.Equals("edit"))
            {
                int id = Convert.ToInt32(dgvDepartment.Rows[dgvDepartment.CurrentRow.Index].Cells[0].Value);
                idd = id.ToString();
                var myfrm = new AddDepartment(this, idd);

                myfrm.txtDeptName.Text = dgvDepartment.Rows[dgvDepartment.CurrentRow.Index].Cells[1].Value.ToString();
                myfrm.btnSave.Text = "Update";
                myfrm.ShowDialog();
            }
            else if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("department").Where("deptID", dgvDepartment.SelectedRows[0].Cells[0].Value.ToString()).Delete();
                    displayData();
                }
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
                var values = DBContext.GetContext().Query("department").WhereLike("deptID", $"{textboxWatermark1.Text}")
                  .OrWhereLike("deptName", $"%{textboxWatermark1.Text}%")
                  .Get();

                dgvDepartment.Rows.Clear();
                foreach (var value in values)
                {
                    dgvDepartment.Rows.Add(value.deptID, value.deptName);
                }
            }


        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
