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
    public partial class addSchedule : Form
    {
        string dateequal;
        string dtpTimstart;
        string dtpTimeEnd;
        string monday;
        string tuesday;
        string wednesday;
        string thursday;
        string friday;
        string saturday;
        schedule scheds = new schedule();
        int courseIdd;
        Sched reloadDatagrid;
        public addSchedule(Sched reloadDatagrid)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void addSchedule_Load(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            TimeSpan ts = new TimeSpan(7, 00, 0);
            dt1 = dt1.Date + ts;

            DateTime dt2 = DateTime.Now;
            TimeSpan ts2 = new TimeSpan(8, 00, 0);
            dt2 = dt2.Date + ts2;

            dateTimePicker1.Value = dt1;
            dateTimePicker2.Value = dt2;


            displayCourse();
            scheds.Schedule();


            CbRoomNO.DataSource = scheds.datafillroom;

        }

        private void displayCourse()
        {
            var values = DBContext.GetContext().Query("course").Get();

            foreach (var value in values)
            {
                cmbCourse.Items.Add(value.description);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            scheds.subjcode = cbSubjCode.Text;

            scheds.Viewdescription();
            txtDescrip.Text = scheds.subjTitle;
        }

        private void txtDescrip_TextChanged(object sender, EventArgs e)
        {

        }
        private CheckBox[] checkboxcontrol;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                checkboxcontrol = new CheckBox[] { cbmon, cbtues, cbwed, cbthu, cbfri, cbsat };

                foreach (CheckBox chk in checkboxcontrol)
                {
                    if (chk.Checked)
                    {
                        dateequal += chk.Text;
                    }
                }

                dateequal = monday + tuesday + wednesday + thursday + friday + saturday;

                dtpTimstart = dateTimePicker1.Value.ToString("HH:mm");
                dtpTimeEnd = dateTimePicker2.Value.ToString("HH:mm");

                scheds.timeStart = dtpTimstart;
                scheds.timeEnd = dtpTimeEnd;
                scheds.subjcode = cbSubjCode.Text;
                scheds.subjTitle = txtDescrip.Text;
                scheds.date = dateequal;

                scheds.viewCourseID();
                scheds.Viewdescription();
                scheds.viewroomNum();
                scheds.times();

                if (dateTimePicker1.Value.TimeOfDay > dateTimePicker2.Value.TimeOfDay)
                {
                    Validator.AlertDanger("Time-start must not be advance to schedule Time-end!");
                }
                else if (string.IsNullOrEmpty(cmbCourse.Text))
                {
                    Validator.AlertDanger("Please select Course!");
                }
                else if (string.IsNullOrEmpty(cbCourseCode.Text))
                {
                    Validator.AlertDanger("Please select Course code!");
                }
                else if (string.IsNullOrEmpty(cbSubjCode.Text))
                {
                    Validator.AlertDanger("Please select Subject code!");
                }
                else if (dateTimePicker1.Value.TimeOfDay.Equals(dateTimePicker2.Value.TimeOfDay))
                {
                    Validator.AlertDanger("Time-start must not be equal to schedule Time-end!");
                }
                else if (scheds.timeEnd == dtpTimstart)
                {
                    Validator.AlertDanger("Time-start must not be equal to schedule Time-end!");
                }
                else if (scheds.timediff == null || scheds.timediff == "")
                {
                    save();
                    Validator.AlertSuccess("Schedule successfully created");
                    reloadDatagrid.displayData();
                    this.Close();
                }
                else
                {
                    Validator.AlertDanger("Schedule Conflict");
                }
            }
            catch (Exception)
            {
                Validator.AlertDanger("Please fill up the following fields");
            }

            scheds.timediff = "";

            scheds.date = "";
            scheds.timeStart = "";
            scheds.timeEnd = "";
        }

        private void save()
        {
            CbRoomNO.Text = scheds.roomdesc;
            //  scheds.date = txtDate.Text;
            scheds.date = dateequal;
            scheds.timeEnd = dtpTimeEnd;
            scheds.timeStart = dtpTimstart;
            scheds.maxStudent = txtMax.Text;
            cbSubjCode.Text = scheds.subjcode;
            scheds.course = Convert.ToString(courseIdd);
            scheds.insertSched();
        }

        private void CbRoomNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            scheds.roomdesc = CbRoomNO.Text;
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSubjCode.Text = "";
            txtDescrip.Text = "";

            var values = DBContext.GetContext().Query("subjects").Where("courseCode", cbCourseCode.Text).Get();
            cbSubjCode.Text = "";
            cbSubjCode.Items.Clear();
            foreach (var value in values)
            {
                cbSubjCode.Items.Add(value.subjectCode);


            }

            var idd = DBContext.GetContext().Query("coursecode").Where("coursecode", cbCourseCode.Text).First();
            courseIdd = idd.courseId;
        }

        private void button2_Click(object sender, EventArgs e)
        {





        }


        private void btnAddAccountant_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateequal);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dtpTimstart = dateTimePicker1.Value.ToString("H:mm:ss");
        }

        private void cbmon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmon.Checked)
            {
                monday = "1";
            }
            else
            {
                monday = "";
            }
        }

        private void cbtues_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtues.Checked)
            {
                tuesday = "2";
            }
            else
            {
                tuesday = "";
            }
        }

        private void cbwed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbwed.Checked)
            {
                wednesday = "3";
            }
            else
            {
                wednesday = "";
            }
        }

        private void cbthu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbthu.Checked)
            {
                thursday = "4";
            }
            else
            {
                thursday = "";
            }
        }

        private void cbfri_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfri.Checked)
            {
                friday = "5";
            }
            else
            {
                friday = "";
            }
        }

        private void cbsat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat.Checked)
            {
                saturday = "6";
            }
            else
            {
                saturday = "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            scheds.times();
            MessageBox.Show(scheds.timediff);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        int idd;
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCourseCode.Text = "";
            cbSubjCode.Text = "";
            txtDescrip.Text = "";
           
            var getID = DBContext.GetContext().Query("course").Where("description", cmbCourse.Text).First();

            idd = getID.courseId;

            var values = DBContext.GetContext().Query("coursecode")
                .Join("course", "course.courseId", "coursecode.courseId")
                .Where("coursecode.courseId", idd.ToString())
                .Get();
            cbCourseCode.Items.Clear();
            foreach (var value in values)
            {
                cbCourseCode.Items.Add(value.coursecode);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void addSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}