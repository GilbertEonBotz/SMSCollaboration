using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.BSED
{
    public partial class BSEDAdminDashboard : Form
    {
        public BSEDAdminDashboard()
        {
            InitializeComponent();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlShow.Controls.Add(childForm);
            pnlShow.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            openChildForm(new BSEDAssignGrade());
          //  BSEDAssignGrade frm4 = new BSEDAssignGrade();
           // frm4.ShowDialog();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDManageTeacher());

            //fOther.Show();

            //   BSEDManageTeacher frm2 = new BSEDManageTeacher();
            //  frm2.ShowDialog();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            if (btnAdmin.Text == "Teacher")
            {
                btnAssignGradeStudent.Visible = true;



            }
            else
            {
                btnAssignTeacher.Visible = false;
                btnManageSection.Visible = false;
                //  openChildForm(new BSEDAdminTeacher());
                //BSEDAdminTeacher frm4 = new BSEDAdminTeacher();
                //frm4.ShowDialog();

                btnManageSchool.Visible = false;
                btnManageUsers.Visible = false;
                btnAcademicYear.Visible = false;
                

                btnAssignGradeStudent.Visible = true;
                btnAssignSubjectSection.Visible = true;
                btnManageTeacher.Visible = true;

                btnFeeManagement.Visible = false;
                btnPayment.Visible = false;
                btnStudentFee.Visible = false;

            }
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            BSEDSelectionForm f = new BSEDSelectionForm();
            f.Show();
            this.Hide();
            f.txtUsername.Focus();
           
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;


            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

            openChildForm(new BSEDStudents());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDSubjects());
            btnAssignTeacher.Visible = false;
            btnManageSection.Visible = false;


            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;
            //btnRoles.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDGradeLevel());
            btnAssignTeacher.Visible = false;
            btnManageSection.Visible = false;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;
            //btnRoles.Visible = false;


            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            AddSections frm4 = new AddSections();
            frm4.ShowDialog();

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            BSEDAdminAssignTeacher frm = new BSEDAdminAssignTeacher();
            frm.ShowDialog();
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDManageUser());
            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;


            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

            
        }

        private void pnlBanner_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlShow.Controls.Clear();
           // pnlShow.BringToFront();

            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;
            //btnRoles.Visible = false;


            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void pnlShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlStretchs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton22_Click(object sender, EventArgs e)
        {

        }

        private void iconButton21_Click(object sender, EventArgs e)
        {

        }

        private void iconButton20_Click(object sender, EventArgs e)
        {
            //Academic Year

            openChildForm(new BSEDAcademicYear());
            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;


            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;
           
        }

        private void iconButton19_Click(object sender, EventArgs e)
        {

        }

        private void iconButton17_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDManageSchool());
            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;


            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

          
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            btnManageSchool.Visible = true;
            btnManageUsers.Visible = true;
            btnAcademicYear.Visible = true;
           // btnRoles.Visible = true;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

            btnAssignTeacher.Visible = false;
            btnManageSection.Visible = false;

            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {

        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDPayment());
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDStudentPayment());
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDFeeManagement());
            // openChildForm(new BSEDFeeManagement());
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            btnAssignTeacher.Visible = false;
            btnManageSection.Visible = false;


            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;
            //btnRoles.Visible = false;


            btnFeeManagement.Visible = true;
            btnPayment.Visible = true;
            btnStudentFee.Visible = true;
           // openChildForm(new BSEDFeeManagement());
        }

        private void btnSections_Click(object sender, EventArgs e)
        {

            btnAssignTeacher.Visible = true;
            btnManageSection.Visible = true;

            btnManageSchool.Visible = false;
            btnManageUsers.Visible = false;
            btnAcademicYear.Visible = false;
           // btnRoles.Visible = false;


            btnAssignGradeStudent.Visible = false;
            btnAssignSubjectSection.Visible = false;
            btnManageTeacher.Visible = false;

            btnFeeManagement.Visible = false;
            btnPayment.Visible = false;
            btnStudentFee.Visible = false;

            openChildForm(new BSEDManageSections());

        }

        private void btnAssignSubjectSection_Click(object sender, EventArgs e)
        {
            openChildForm(new BSEDAdminAssignSubjectSection());
        }

        private void BSEDAdminDashboard_Load(object sender, EventArgs e)
        {
            if (btnAdmin.Text == "Registrar")
            {
                btnTeacher.Visible = true;
                btnStudent.Visible = true;
                btnSubject.Visible = true;
                btnGradeLevel.Visible = true;
                btnSections.Visible = true;
                btnReport.Visible = true;

                btnBilling.Visible = false;
                btnSettings.Visible = false;
            }
            else if (btnAdmin.Text == "Cashier")
            {
                btnTeacher.Visible = false;
                btnStudent.Visible = false;
                btnSubject.Visible = false;
                btnGradeLevel.Visible = false;
                btnSections.Visible = false;
                btnReport.Visible = false;
                btnSettings.Visible = false;

                btnBilling.Visible = true;
            }
            else if (btnAdmin.Text == "Teacher")
            {
                btnTeacher.Visible = true;


                btnStudent.Visible = false;
                btnSubject.Visible = false;
                btnGradeLevel.Visible = false;
                btnSections.Visible = false;
                btnReport.Visible = false;
                btnBilling.Visible = false;
                btnSettings.Visible = false;
            }
        }
    }

    
        
     
}

