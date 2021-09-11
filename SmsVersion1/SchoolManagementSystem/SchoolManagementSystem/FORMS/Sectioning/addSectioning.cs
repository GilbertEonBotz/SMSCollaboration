using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlKata.Execution;
using EonBotzLibrary;
using MySql.Data.MySqlClient;
namespace SchoolManagementSystem
{
    public partial class addSectioning : Form
    {

        Connection connect = new Connection();
        MySqlCommand cmd;
        MySqlConnection conn;
        MySqlDataReader dr;
        string id;
        public addSectioning(string val)
        {
            InitializeComponent();
            id = val;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        studentSched sched = new studentSched();
        private void addSectioning_Load(object sender, EventArgs e)
        {

            display();
            displaySectioning();

            //var values = DBContext.GetContext().Query("schedule").Get();
            //foreach (var value in values)
            //{
            //    dgvSched.Rows.Add(value.schedID, value.subjectCode, value.subjectTitle, value.roomID, value.date, value.timeStart, value.timeEnd);
            //}
            //conn = connect.getcon();
            //conn.Open();
            //cmd = new MySqlCommand("select a.schedid,a.subjectcode,a.subjectTitle  from schedule a, Sectioning b, sectionCategory c where a.schedID = b.schedID and b.SectionCategoryID = '"+ id+ "'Group by b.sectionId", conn);
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    dgvCategories.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            //}
        }

        public void displaySectioning()
        {
            dgvCategories.Rows.Clear();

            sched.category = id;
            sched.viewSectiong();

            dgvCategories.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvCategories.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            foreach (DataRow Drow in sched.dt.Rows)
            {
                int num = dgvCategories.Rows.Add();

                dgvCategories.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                dgvCategories.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                dgvCategories.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                dgvCategories.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
                dgvCategories.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                dgvCategories.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
                dgvCategories.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
                textBox1.Text = Drow["total"].ToString();
            }
        }
        public void display()
        {


            sched.displayFilter();
            dgvSched.Rows.Clear();
            dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            foreach (DataRow Drow in sched.dtFilter.Rows)
            {
                int num = dgvSched.Rows.Add();

                dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
                dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
                dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
                dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
                dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
                dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
                dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
            }
        }


        //public void displaySectioning()
        //{
        //    var values = DBContext.GetContext().Query("sectioning").Where("SectionCategoryID", ).Get
        //}
        private void dgvSched_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //}
            //}
            //catch (Exception)
            //{

            //}


        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addSectioning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void dgvSched_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if ((string)row.Cells[1].Value == dgvSched.SelectedRows[0].Cells[1].Value.ToString())
                {
                    Validator.AlertDanger("Subject Code exist!");
                    return;
                }
            }
            //try
            //{
            //    if (dgvSched.Rows[0].Cells[0].Value.ToString() == dgvCategories.Rows[0].Cells[0].Value.ToString())
            //    {
            //        Validator.AlertDanger("Schedule already existed!");
            //    }
            //    else
            //    {
            dgvCategories.Rows.Add(dgvSched.SelectedRows[0].Cells[0].Value, dgvSched.SelectedRows[0].Cells[1].Value, dgvSched.SelectedRows[0].Cells[2].Value
                  , dgvSched.SelectedRows[0].Cells[3].Value, dgvSched.SelectedRows[0].Cells[4].Value, dgvSched.SelectedRows[0].Cells[5].Value, dgvSched.SelectedRows[0].Cells[6].Value);

            DBContext.GetContext().Query("Sectioning").Insert(new
            {
                SectionCategoryID = id,
                schedID = dgvSched.SelectedRows[0].Cells[0].Value
            });
            displaySectioning();
        }

        private void dgvCategories_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textboxWatermark1.Text))
            //{
            //    displaySectioning();
            //}
            //else if (textboxWatermark1.Text.Equals("Search"))
            //{
            //    displaySectioning();
            //}
            //else
            //{
            //    sched.textvalue = textboxWatermark1.Text;
            //    sched.displayFilter();

            //    dgvSched.Rows.Clear();
            //    dgvSched.Columns[5].DefaultCellStyle.Format = "hh:mm tt";
            //    dgvSched.Columns[6].DefaultCellStyle.Format = "hh:mm tt";
            //    foreach (DataRow Drow in sched.dtFilter.Rows)
            //    {
            //        int num = dgvSched.Rows.Add();

            //        dgvSched.Rows[num].Cells[0].Value = Drow["SchedID"].ToString();
            //        dgvSched.Rows[num].Cells[1].Value = Drow["SubjectCode"].ToString();
            //        dgvSched.Rows[num].Cells[2].Value = Drow["SubjectTitle"].ToString();
            //        dgvSched.Rows[num].Cells[3].Value = Drow["RoomName"].ToString();
            //        dgvSched.Rows[num].Cells[4].Value = Drow["Day"].ToString();
            //        dgvSched.Rows[num].Cells[5].Value = Convert.ToDateTime(Drow["Timestart"].ToString());
            //        dgvSched.Rows[num].Cells[6].Value = Convert.ToDateTime(Drow["Timeend"].ToString());
            //    }
            //}
        }
    }
}
