using SchoolManagementSystem.FORMS.Sectioning;
using SchoolManagementSystem.UITools;
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
    public partial class SectionCategory : Form
    {
        public SectionCategory()
        {
            InitializeComponent();
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            ////var myfrm = new addSectionCategory(this, idd);
            ////FormFade.FadeForm(this, myfrm);
        }

        public void displayData()
        {
            var values = DBContext.GetContext().Query("sectionCategory").Get();
            dgvDepartment.Rows.Clear();
            foreach (var value in values)
            {
                dgvDepartment.Rows.Add(value.SectionCategoryID, value.sectionName, value.Description);
            }
        }

        private void SectionCategory_Load(object sender, EventArgs e)
        {
            displayData();
        }

        string idd;
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string colName = dgvDepartment.Columns[e.ColumnIndex].Name;
            //idd = dgvDepartment.SelectedRows[0].Cells[0].Value.ToString();
            //if (colName.Equals("edit"))
            //{
            //    var myfrm = new addSectionCategory(this, idd);

            //    myfrm.txtStructure.Text = dgvDepartment.SelectedRows[0].Cells[1].Value.ToString();
            //    myfrm.txtDescription.Text = dgvDepartment.SelectedRows[0].Cells[2].Value.ToString();
            //    myfrm.btnAddCourse.Text = "Update";
            //    myfrm.ShowDialog();
            //}
        }
    }
}
