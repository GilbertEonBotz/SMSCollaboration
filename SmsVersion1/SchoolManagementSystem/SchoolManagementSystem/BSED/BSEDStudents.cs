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
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem.BSED
{
    public partial class BSEDStudents : Form
    {
        public BSEDStudents()
        {
            InitializeComponent();
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            BSEDAddStudent frm2 = new BSEDAddStudent();
            frm2.Show();
            frm2.txtStudentID.Focus();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BSEDStudents_Load(object sender, EventArgs e)
        {
            display();
        }

        public void display()
        {
            var values = DBContexts.GetContext().Query("studentinfo").Join("gradelevel","gradelevel.GradeLevel_ID","studentinfo.GradeLevel_ID").Get();
                

            dgvStudent.Rows.Clear();
            foreach (var value in values)
            {
                dgvStudent.Rows.Add(value.StudentID, value.FirstName, value.LastName, value.Gender,value.GradeLevel);
            }

            //Connection connect = new Connection();
            //MySqlConnection conn;
            //MySqlCommand cmd;
            //MySqlDataAdapter da = new MySqlDataAdapter();
            //DataTable dt = new DataTable();

            //try
            //{
            //    string sql = "Select StudentID,FirstName,MiddleName,LastName FROM studentinfo";

            //    conn = connect.getconn();
            //    conn.Open();
            //    cmd = new MySqlCommand(sql, conn);
            //    da.SelectCommand = cmd;
            //    da.Fill(dt);

            //    dgvStudent.DataSource = dt.DefaultView;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var relativeMousePosition = dgvStudent.PointToClient(Cursor.Position);

                contextMenuStrip1.Show(dgvStudent,relativeMousePosition);
            }
        }
    }
}
