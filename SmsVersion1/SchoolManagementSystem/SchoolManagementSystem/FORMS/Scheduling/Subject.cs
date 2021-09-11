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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void btnAddSybject_Click(object sender, EventArgs e)
        {
            displayData();
            var myfrm = new AddSubject(this, getId);
            FormFade.FadeForm(this, myfrm);
        }

        private void dgvSubjects_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Subject_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvSubjects.Rows.Clear();
            var values = DBContext.GetContext().Query("subjects").Get();

            foreach (var value in values)
            {
                dgvSubjects.Rows.Add(value.subjectId, value.subjectCode, value.subjectTitle, value.lec, value.lab, value.totalUnits, value.prereq);
            }
        }

        string getId;
        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSubjects.Columns[e.ColumnIndex].Name;
            if (colName.Equals("edit"))
            {
                getId = dgvSubjects.Rows[dgvSubjects.CurrentRow.Index].Cells[0].Value.ToString();
                var myfrm = new AddSubject(this, getId);

                var value = DBContext.GetContext().Query("subjects")
                    .Join("coursecode", "coursecode.coursecode", "subjects.courseCode")
                    .Join("course", "course.courseId", "coursecode.courseId")
                    .Where("subjectId", getId).First();

                myfrm.cmbCourse.Text = value.description;
                myfrm.cmbCourseCode.Text = value.courseCode;
                myfrm.txtSubjectCode.Text = value.subjectCode;
                myfrm.txtDescriptiveTitle.Text = value.subjectTitle;
                myfrm.txtLec.Text = Convert.ToString(value.lec);
                myfrm.txtLecPrice.Text = Convert.ToString(value.lecPrice);
                myfrm.txtLab.Text = Convert.ToString(value.lab);
                myfrm.txtLabprice.Text = Convert.ToString(value.labPrice);
                myfrm.txtTotalUnits.Text = Convert.ToString(value.totalUnits);

                if (value.prereq == "")
                {
                    myfrm.lstPrereq.Items.Clear();
                    myfrm.btnAddSubjects.Text = "Update";
                    myfrm.ShowDialog();
                }
                else
                {
                    var word = value.prereq.Split(',');

                    foreach (var splitWord in word)
                    {
                        myfrm.lstPrereq.Items.Add(splitWord);
                    }
                    myfrm.btnAddSubjects.Text = "Update";
                    myfrm.ShowDialog();
                }
                
            }
            if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("subjects").Where("subjectId", dgvSubjects.SelectedRows[0].Cells[0].Value).Delete();
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
                dgvSubjects.Rows.Clear();
                var values = DBContext.GetContext().Query("subjects").WhereLike("subjectId", $"{textboxWatermark1.Text}")
                  .OrWhereLike("subjectCode", $"%{textboxWatermark1.Text}%")
                  .OrWhereLike("subjectTitle", $"%{textboxWatermark1.Text}%")
                  .Get();

                foreach (var value in values)
                {
                    dgvSubjects.Rows.Add(value.subjectId, value.subjectCode, value.subjectTitle, value.lec, value.lab, value.totalUnits, value.prereq);
                }
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
