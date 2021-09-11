using SchoolManagementSystem.FORMS.Sectioning;
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

namespace SchoolManagementSystem
{
    public partial class finalDashboard : Form
    {
        public finalDashboard()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            pnlUser.Visible = false;
            pnlLoads.Visible = false;
            pnlEnrollment.Visible = false;
            pnlStudentRecords.Visible = false;
            pnlEmployees.Visible = false;
            pnlFeesMngmnt.Visible = false;
            pnlAcademic.Visible = false;
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


        private void btnEmployees_Click(object sender, EventArgs e)
        {
        }

        public void displayStudentScheduling()
        {
            var myForm = new StudentScheduling(this);
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
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

        private void finalDashboard_Load(object sender, EventArgs e)
        {

            Button[] allBtn = { btnManageUser, btnAcademicMngmt,btnStudentRecords,btnEnrollment, btnTeacherLoads, btnDepartment, btnTerm, btnCourse, btnCourseCode};
            Button[] registrarButton = { btnEmployees, btnManageUser, btnFeesManagement, btnPayment, iconButton1 };
            if (btnAdmin.Text.Equals("Cashier"))
            {
                Validator.hideButton(allBtn);
                pnlEmployees.SetBounds( 200, 200, 200, 110);

            }
            else if (btnAdmin.Text.Equals("Registrar"))
            {
                Validator.hideButton(registrarButton);

            }
            else
            {

            }
            displayDashboard();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            var myform = new SelectionForm();
            this.Hide();
            myform.ShowDialog();

        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlUser);
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            displayDashboard();
        }

        private void btnEmployees_Click_1(object sender, EventArgs e)
        {
            showSubMenu(pnlEmployees);
        }

        private void btnSchoolSettings_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnAcademicMngmt_Click_1(object sender, EventArgs e)
        {
            showSubMenu(pnlAcademic);
        }

        private void btnFeesManagement_Click_1(object sender, EventArgs e)
        {
            showSubMenu(pnlFeesMngmnt);
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlEnrollment);
        }

        private void btnStudentRecords_Click_1(object sender, EventArgs e)
        {
            showSubMenu(pnlStudentRecords);
        }

        private void btnTeacherLoads_Click_1(object sender, EventArgs e)
        {
            showSubMenu(pnlLoads);
        }

        private void btnPayment_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            var myForm = new StudentActivation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnManageRole_Click(object sender, EventArgs e)
        {
            var myForm = new UserRole();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            
            var myForm = new Users();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            var myForm = new viewTeacherSched();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnAccountant_Click(object sender, EventArgs e)
        {
            var myForm = new AccountantInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            var myForm = new LibrarianInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnTerm_Click(object sender, EventArgs e)
        {
            var myForm = new Department();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            var myForm = new AcademicYear();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();


            
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            var myForm = new CourseInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnCourseCode_Click(object sender, EventArgs e)
        {
            var myForm = new room();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnClassrooms_Click(object sender, EventArgs e)
        {
            var myForm = new Sectioning();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnExamPercentage_Click(object sender, EventArgs e)
        {
            var myForm = new ExamPercentage();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {

            var myForm = new CourseCode();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
            
        }

        private void btnSectionCategory_Click(object sender, EventArgs e)
        {
            var myForm = new Sched();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();

            
        }

        private void btnSectioning_Click(object sender, EventArgs e)
        {
            var myForm = new SectionCategory();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();

           
        }

        private void btnFeeCategory_Click(object sender, EventArgs e)
        {
            var myForm = new FeeManagement();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnFeeStructure_Click(object sender, EventArgs e)
        {
            var myForm = new FeeStructure();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnTuitionCategory_Click(object sender, EventArgs e)
        {
            var myForm = new TuitionCategoryInfo();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnTuitionStructure_Click(object sender, EventArgs e)
        {
            var myForm = new tuition();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnAdmitStudent_Click(object sender, EventArgs e)
        {
            var myForm = new StudentInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnStudentsSchedule_Click(object sender, EventArgs e)
        {
            displayStudentScheduling();
        }

        private void btnSubjectLoads_Click(object sender, EventArgs e)
        {


            var myForm = new TeacherInformation();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
           
        }

        public void displayTeacherSchedule()
        {
            var myForm = new teacherSched(this);
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }
        private void btnHandleStudents_Click(object sender, EventArgs e)
        {
            displayTeacherSchedule();
        }

        private void btnClassSchedule_Click(object sender, EventArgs e)
        {

            var myForm = new Subject();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            var myForm = new StudentPaymentShow(this);
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var myForm = new AddUnitPrice();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnOrNumber_Click(object sender, EventArgs e)
        {
            var myForm = new OrNumberMaintenance();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnStudentsSchedule_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEnrollment_Click_1(object sender, EventArgs e)
        {

        }
    }
}
