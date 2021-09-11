using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using SchoolManagementSystem.FORMS.Scheduling;

namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {

        private IconButton currentBtn;
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            pnlStudentMenu.Visible = false;
            pnlAcademicMenu.Visible = false;
            pnlFeeMenu.Visible = false;
            pnlDept.Visible = false;
            pnlTuitionMenu.Visible = false;
            pnlSchedules.Visible = false;
            pnlEmployees.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //Side panel colored buttons
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
        }

        private void ActivateButton1(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton1();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.ForeColor = Color.White;
                currentBtn.BackColor = Color.FromArgb(25, 34, 49);
                currentBtn.IconColor = Color.FromArgb(235, 89, 110);
            }
        }

        private void DisableButton1()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(25, 34, 49);
                currentBtn.ForeColor = Color.Gray;
                currentBtn.IconColor = Color.White;
            }
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(45, 50, 61);
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.FromArgb(235, 89, 110);
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(25, 34, 49);
                currentBtn.ForeColor = Color.Gray;
                currentBtn.IconColor = Color.White;
            }
        }

        private void displayDashboard()
        {
            var myForm = new Dashboard();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
        private void displayAcademicYear()
        {
            //    var myForm = new AcademicYear();
            //    pnlShow.Controls.Clear();
            //    myForm.TopLevel = false;
            //    myForm.AutoScroll = false;
            //    pnlShow.Controls.Add(myForm);
            //    myForm.Show();
        }

        private void displayStudent()
        {
            var myForm = new StudentInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayTeachers()
        {
            var myForm = new TeacherInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayLibrarians()
        {
            var myForm = new LibrarianInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayAccountants()
        {
            var myForm = new AccountantInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayRooms()
        {
            var myForm = new room();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayCourse()
        {
            var myForm = new CourseInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displaySubjects()
        {
            var myForm = new Subject();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
        public void displayScheduling()
        {
            var myForm = new Sched();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayFeeManagement()
        {
            var myForm = new FeeManagement();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayFeeStructure()
        {
            var myForm = new FeeStructure();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
        private void displayDepartment()
        {
            var myForm = new Department();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayTuitionCategory()
        {
            var myForm = new TuitionCategoryInfo();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayTuitionStructure()
        {
            var myForm = new tuition();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        public void displayStudentScheduling()
        {
            //var myForm = new StudentScheduling(this);
            //pnlShow.Controls.Clear();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //pnlShow.Controls.Add(myForm);
            //myForm.Show();
        }

        private void displayUser()
        {
            var myForm = new Users();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void displayUserRole()
        {
            var myForm = new UserRole();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            displayDashboard();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            displayDashboard();
        }

        private void btnManageSession_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            displayAcademicYear();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlStudentMenu);
        }

        private void btnAdmitStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayStudent();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayTeachers();
        }

        private void btnLibrarians_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayLibrarians();
        }

        private void btnAccountants_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayAccountants();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            displayRooms();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color1);
            displayCourse();
        }



        private void btnScheduling_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayScheduling();
        }

        private void btnFeesManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displaySubjects();
        }

        private void btnFeeCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayFeeManagement();

        }

        private void btnFeeStructure_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayFeeStructure();
        }



        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayCourse();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayDepartment();
        }

        private void btnTuitionCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayTuitionCategory();
        }

        private void btnTuitionStructure_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayTuitionStructure();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBulkStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnStudentSched_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayStudentScheduling();
        }

        private void btnMngEmployees_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlEmployees);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlDept);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlAcademicMenu);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlSchedules);
        }

        private void btnScheduling_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayScheduling();
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlTuitionMenu);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {

            ActivateButton(sender, RGBColors.color1);
            showSubMenu(pnlFeeMenu);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayUser();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            displayUserRole();
        }

        private void btnSmsSetiing_Click(object sender, EventArgs e)
        {
            //var myForm = new teacherSched(null,this);
            //pnlShow.Controls.Clear();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //pnlShow.Controls.Add(myForm);
            //myForm.Show();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            //var myForm = new teacherSched(this);
            //pnlShow.Controls.Clear();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //pnlShow.Controls.Add(myForm);
            //myForm.Show();
        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            var myForm = new viewTeacherSched();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            //var myForm = new StudentPaymentShow(this);
            //pnlShow.Controls.Clear();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = false;
            //pnlShow.Controls.Add(myForm);
            //myForm.Show();
        }

        private void btnExamPercent_Click(object sender, EventArgs e)
        {
            var myForm = new ExamPercentage();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            var myForm = new CourseCode();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
