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
    public partial class TuitionCategoryInfo : Form
    {
        public TuitionCategoryInfo()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void TuitionCategoryInfo_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvTuition.Rows.Clear();
            var values = DBContext.GetContext().Query("tuitioncategory").Get();

            foreach (var value in values)
            {
                dgvTuition.Rows.Add(value.tuitionCatID, value.category, value.Description);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myfrm = new tuitionCateg(this);
            FormFade.FadeForm(this, myfrm);
        }

        private void dgvTuition_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var myfrm = new tuitionCateg(this);
            int id = Convert.ToInt32(dgvTuition.Rows[dgvTuition.CurrentRow.Index].Cells[0].Value);
            var value = DBContext.GetContext().Query("tuitioncategory").Where("tuitionCatID", id).First();

            myfrm.lblIDD.Text = id.ToString();
            myfrm.txtCategory.Text = value.category;
            myfrm.txtDescription.Text = value.Description;

            myfrm.btnSave.Text = "Update";
            myfrm.ShowDialog();
        }
    }
}
