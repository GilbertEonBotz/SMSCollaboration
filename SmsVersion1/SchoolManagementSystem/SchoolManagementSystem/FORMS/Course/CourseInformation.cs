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
    public partial class CourseInformation : Form
    {
        public CourseInformation()
        {
            InitializeComponent();
        }
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            displayData();
            var myfrm = new AddCourse(this, idd);
            FormFade.FadeForm(this, myfrm);
        }

        private void CourseInformation_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvCourse.Rows.Clear();
            var course = DBContext.GetContext().Query("course").Get();

            foreach (var courses in course)
            {
                dgvCourse.Rows.Add(courses.courseId, $"{courses.description}({courses.abbreviation})");
            }
        }

        private void dgvCourse_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void dgvCourse_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
            e.Handled = true;
        }

        string idd;

        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCourse.Columns[e.ColumnIndex].Name;

            if (colName.Equals("edit"))
            {
                idd = dgvCourse.Rows[dgvCourse.CurrentRow.Index].Cells[0].Value.ToString();

                var value = DBContext.GetContext().Query("course")
                    .Join("department", "department.deptID", "course.deptID")
                    .Where("courseId", idd)
                    .First();

                var myfrm = new AddCourse(this, idd);

                myfrm.cmbDepartment.Text = value.deptName;
                myfrm.txtDescription.Text = value.description;
                myfrm.txtAbbreviation.Text = value.abbreviation;

                myfrm.btnSave.Text = "Update";
                myfrm.ShowDialog();
            }
            else if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("course").Where("courseId", dgvCourse.SelectedRows[0].Cells[0].Value.ToString()).Delete();
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
                var values = DBContext.GetContext().Query("course").WhereLike("courseId", $"{textboxWatermark1.Text}")
               .OrWhereLike("description", $"%{textboxWatermark1.Text}%")
               .OrWhereLike("abbreviation", $"%{textboxWatermark1.Text}%")
               .Get();

                dgvCourse.Rows.Clear();
                foreach (var value in values)
                {
                    dgvCourse.Rows.Add(value.courseId, $"{value.description}({value.abbreviation})");
                }
            }
        }
    }
}