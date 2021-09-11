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
    public partial class AddAcademicYear : Form
    {

        AcademicYear reloadDatagrid;
        string idd;
        public AddAcademicYear(AcademicYear reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;
           
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAcademicYear_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtYear1, txtYear2 };
            ComboBox[] cmb = { cmbTerm };
            if (btnAddAcademicYear.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.isEmptyCmb(cmb) && Validator.AddConfirmation())
                {
                    try
                    {
                        DBContext.GetContext().Query("academicyear").Where("year1", txtYear1.Text).Where("year2", txtYear2.Text).Where("term", cmbTerm.Text).First();
                        Validator.AlertDanger("Academic Year exist!");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("academicyear").Update(new
                        {
                            status = "Inactive"
                        });

                        DBContext.GetContext().Query("academicyear").Insert(new
                        {
                            year1 = txtYear1.Text.Trim(),
                            year2 = txtYear2.Text.Trim(),
                            term = cmbTerm.Text.Trim(),
                            status = "Active"
                        });
                        reloadDatagrid.displayData();
                        this.Close();
                    }
                }
            }
            else if (btnAddAcademicYear.Text.Equals("Update"))
            {
                DBContext.GetContext().Query("academicyear").Where("id", idd).Update(new
                {
                    year1 = txtYear1.Text,
                    year2 = txtYear2.Text,
                    term = cmbTerm.Text
                });
                reloadDatagrid.displayData();
                this.Close();
            }
        }

        private void txtYear1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtYear2.Text = (long.Parse(txtYear1.Text) + 1).ToString();
            }
            catch (Exception)
            {
                txtYear2.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAcademicYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmissionForm_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtYear2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AddAcademicYear_Load(object sender, EventArgs e)
        {

        }
    }
}
