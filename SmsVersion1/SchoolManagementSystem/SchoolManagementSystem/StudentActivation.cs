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
using SchoolManagementSystem.FORMS;
using SqlKata.Execution;

namespace SchoolManagementSystem
{
    public partial class StudentActivation : Form
    {
        public StudentActivation()
        {
            InitializeComponent();
        }

        private void StudentActivation_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            //select a.studentid,b.status from  student a left join studentActivation b on a.studentid = b.studentid

            var values = DBContext.GetContext().Query("student")
                .LeftJoin("studentActivation", "student.studentId", "studentActivation.studentID")
                .Get();

            dgvStudents.Rows.Clear();
            foreach (var value in values)
            {
                dgvStudents.Rows.Add(value.studentId, $"{value.firstname} {value.lastname}", value.gender, value.course, value.status);
            }

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (string.IsNullOrEmpty(Convert.ToString(row.Cells[4].Value)))
                {
                    row.Cells[4].Value = "Not verified";
                }
            }

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStudents.Columns[e.ColumnIndex].Name;


            if (colName.Equals("activate"))
            {
                if (dgvStudents.SelectedRows[0].Cells[4].Value.Equals("Activated"))
                {
                    Validator.AlertDanger("This student is already activated!");
                    return;
                }
                else
                {
                    var myfrm = new studentActivation(this);
                    myfrm.txtName.Text = dgvStudents.SelectedRows[0].Cells[1].Value.ToString();
                    myfrm.txtStatus.Text = dgvStudents.SelectedRows[0].Cells[4].Value.ToString();

                    myfrm.studentid = dgvStudents.SelectedRows[0].Cells[0].Value.ToString();
                    myfrm.ShowDialog();
                }


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                displayData();
            }
            else if (txtSearch.Text.Equals("Search"))
            {
                displayData();
            }
            else
            {
                var values = DBContext.GetContext().Query("student")
                .LeftJoin("studentActivation", "studentActivation.studentID", "student.studentId").WhereLike("student.studentId", $"{txtSearch.Text}").OrWhereLike("student.lastname", $"%{txtSearch.Text}%").OrWhereLike("student.firstname", $"%{txtSearch.Text}%").OrWhereLike("student.course", $"%{txtSearch.Text}%").Get();

                dgvStudents.Rows.Clear();
                foreach (var value in values)
                {
                    dgvStudents.Rows.Add(value.studentId, $"{value.firstname} {value.lastname}", value.gender, value.course, value.status);
                }

                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(row.Cells[4].Value)))
                    {
                        row.Cells[4].Value = "Not verified";
                    }
                }
            }
        }
    }
}
