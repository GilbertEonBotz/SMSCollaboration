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
    public partial class AcademicYear : Form
    {
        public AcademicYear()
        {
            InitializeComponent();
        }

        private void AcademicYear_Load(object sender, EventArgs e)
        {
            displayData();
        }
        public void displayData()
        {
            dgvAcademicYear.Rows.Clear();
            var values = DBContext.GetContext().Query("academicyear").Get();

            foreach (var value in values)
            {
                dgvAcademicYear.Rows.Add(value.id, $"{value.year1}-{value.year2} {value.term}", value.status);
            }

            foreach (DataGridViewRow row in dgvAcademicYear.Rows)
            {
                if (Convert.ToString(row.Cells[2].Value) == "Active")
                {
                    row.Cells[2].Style.ForeColor = Color.Blue;
                    row.Cells[2].Style.SelectionForeColor = Color.Blue;
                }
                else
                {
                    row.Cells[2].Style.ForeColor = Color.Red;
                    row.Cells[2].Style.SelectionForeColor = Color.Red;
                }
            }
        }
        
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var myfrm = new AddAcademicYear(this, idd);
            FormFade.FadeForm(this, myfrm);
        }

        private void dgvAcademicYear_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvAcademicYear.Rows[dgvAcademicYear.CurrentRow.Index].Cells[0].Value);
        }


        string idd;
        private void dgvAcademicYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAcademicYear.Columns[e.ColumnIndex].Name;

            if (colName.Equals("open"))
            {
                if (dgvAcademicYear.SelectedRows[0].Cells[2].Value.Equals("Active"))
                {
                    Validator.AlertDanger("This academic year is already activated");
                    return;
                }
                else
                {
                    if (Validator.actYear())
                    {
                        DBContext.GetContext().Query("academicyear").Update(new
                        {
                            status = "Inactive"
                        });

                        DBContext.GetContext().Query("academicyear").Where("id", dgvAcademicYear.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Active"
                        });
                        displayData();
                    }
                }
            }
            else if (colName.Equals("edit"))
            {
                idd = dgvAcademicYear.Rows[dgvAcademicYear.CurrentRow.Index].Cells[0].Value.ToString();
                var myfrm = new AddAcademicYear(this, idd);

                var values = DBContext.GetContext().Query("academicyear").Where("id", idd).Get();


                foreach (var value in values)
                {
                    myfrm.txtYear1.Text = value.year1;
                    myfrm.txtYear2.Text = value.year2;
                    myfrm.cmbTerm.Text = value.term;
                }
                myfrm.btnAddAcademicYear.Text = "Update";
                myfrm.ShowDialog();
            }
            else if (colName.Equals("delete"))
            {
                if (dgvAcademicYear.SelectedRows[0].Cells[2].Value.Equals("Active"))
                {
                    Validator.AlertDanger("Unable to delete academic year because status is active!");
                    return;
                }
                else
                {
                    if (Validator.DeleteConfirmation())
                    {
                        DBContext.GetContext().Query("academicyear").WhereLike("id", dgvAcademicYear.SelectedRows[0].Cells[0].Value.ToString()).Delete();
                        displayData();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                var values = DBContext.GetContext().Query("academicyear").WhereLike("id", $"{textboxWatermark1.Text}")
                .OrWhereLike("year1", $"%{textboxWatermark1.Text}%")
                .OrWhereLike("term", $"%{textboxWatermark1.Text}%")
                .Get();

                dgvAcademicYear.Rows.Clear();
                foreach (var value in values)
                {
                    dgvAcademicYear.Rows.Add(value.id, $"{value.year1}-{value.year2} {value.term}", value.status);
                }

                foreach (DataGridViewRow row in dgvAcademicYear.Rows)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "Activate")
                    {
                        row.Cells[2].Style.ForeColor = Color.Blue;
                        row.Cells[2].Style.SelectionForeColor = Color.Blue;
                    }
                    else
                    {
                        row.Cells[2].Style.ForeColor = Color.Red;
                        row.Cells[2].Style.SelectionForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
