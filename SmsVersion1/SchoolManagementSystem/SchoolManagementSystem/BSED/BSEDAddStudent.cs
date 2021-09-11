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
    public partial class BSEDAddStudent : Form
    {
        public BSEDAddStudent()
        {
            InitializeComponent();
        }
        public int GradeLevelid;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void BSEDAddStudent_Load(object sender, EventArgs e)
        {
            string yr = DateTime.Now.Year.ToString();
            string yr2 = (DateTime.Now.Year+1).ToString();
            //textBox18.Text = yr2;
            try
            {

                var query = DBContexts.GetContext().Query("gradelevel")
                    .Where(new { SchoolYearStart = yr, SchoolYearEnd = yr2 }).Get();

                foreach (var value in query)
                {
                    cbGradeLevel.Items.Add(value.GradeLevel);
                    
                }





            }
            catch (Exception)
            {
                MessageBox.Show("Invalid credentials");
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        //{

        //}

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void cbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            string yr = DateTime.Now.Year.ToString();
            string yr2 = (DateTime.Now.Year + 1).ToString();


            string sql = "SELECT GradeLevel_ID FROM gradelevel WHERE GradeLevel ='"+cbGradeLevel.Text+"' and SchoolYearStart ='"+yr+"'";

            conn = connect.getconn();
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                GradeLevelid = Convert.ToInt32(mdr[0].ToString());
            }
            conn.Close();
            //textBox2.Text = GradeLevelid.ToString();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPresentadd.Text != "")
            {
                if (checkBox5.Checked)
                {
                    txtHomeadd.Text = txtPresentadd.Text;
                    txtHomeadd.ReadOnly = true;
                }
                else
                {
                    txtHomeadd.Text = "";
                    txtHomeadd.ReadOnly = false;
                }
            }
            else
            {
                checkBox5.CheckState = CheckState.Unchecked;
            }
        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void txtPresentadd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPresentadd.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtPresentadd, "Address should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPresentadd, "");
            }
        }

        private void txtPresentadd_Leave(object sender, EventArgs e)
        {
            //if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            //    MessageBox.Show(txtPresentadd.Text, "Demo App - Message!");
            //}
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtLastName, "Last Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtFirstName, "First Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtMI_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMI.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtMI, "Middle Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMI, "");
            }
        }

        private void txtBirthPlace_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBirthPlace.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtBirthPlace, "Birth Place should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBirthPlace, "");
            }
        }

        private void txtReligion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReligion.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtReligion, "Religion should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtReligion, "");
            }
        }

        private void txtContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtContactNo, "Contact No should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtContactNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtEmail, "Email should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtFLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFLastName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtFLastName, "Last Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFLastName, "");
            }
        }

        private void txtFFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFFirstName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtFFirstName, "First Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFFirstName, "");
            }
        }

        private void txtFMI_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFMI.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtFMI, "Middle Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFMI, "");
            }
        }

        private void txtFOccupation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFOccupation.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtFOccupation, "Occupation should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFOccupation, "");
            }
        }

        private void txtMLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMLastName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtMLastName, "Last Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMLastName, "");
            }
        }

        private void txtMFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMFirstName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtMFirstName, "First Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMFirstName, "");
            }
        }

        private void txtMMI_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMMI.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtMMI, "Middle Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMMI, "");
            }
        }

        private void txtMOccupation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMOccupation.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtMOccupation, "Occupation should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMOccupation, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(textBox1, "This should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(textBox13, "This should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox13, "");
            }
        }

        private void txtGName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGName.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtGName, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGName, "");
            }
        }

        private void txtGAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGAddress.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtGAddress, "Address should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGAddress, "");
            }
        }

        private void txtGContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGContactNo.Text))
            {
                e.Cancel = true;
                //textBoxName.Focus();
                errorProvider1.SetError(txtGContactNo, "Contact No should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGContactNo, "");
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                if (btnAddStudent.Text.Equals("Save"))
                {

                    if (txtStudentID.Text.Equals(""))
                    {
                        string sql = "INSERT INTO `studentinfo`( `StudentID`, `FirstName`, `MiddleName`, `LastName`, `Suffix`, `Gender`, `ContactNo`, `Email`, `Birthday`, `BirthPlace`, `Religion`, `GradeLevel_ID`, `PresentAddress`, `HomeAddress`, `FatherFirstName`, `FatherMiddleName`, `FatherLastName`, `FatherOccupation`, `MotherFirstName`, `MotherMiddleName`, `MotherLastName`, `MotherOccupation`, `LastSchoolAttended`, `SchoolAddress`, `FamilyStatus`, `GuardiansName`,GuardianAddress, `GuardiansContactNo`, `ReportCard`, `GoodMoral`, `PSACert`, `Picture`, `BaptimalCert`, `DateRegistered`) VALUES" +
                        " ((SELECT max(b.StudentID) as number FROM `identification` as b),@FirstName,@MiddleName,@LastName,@Suffix,@Gender,@ContactNo,@Email,@Birthday,@BirthPlace,@Religion,@Gradelevel,@PresentAdd,@HomeAdd,@FFirstName,@FMiddleName,@FLastName,@FOccupation,@MFirstName,@MMiddleName,@MLastName,@MOccupation,@LastSchoolName,@LastSchoolAdd,@FamilyStatus,@GName,@GAddress,@GContactNo,@ReportCard,@GoodMoral,@PSA,@Picture,@Baptismal,CURRENT_DATE());" +
                        "INSERT INTO `identification`( `StudentID`) VALUES ((SELECT max(b.StudentID+1) as number FROM `identification` as b))";
                        conn = connect.getconn();
                        conn.Open();
                        using (cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@MiddleName", txtMI.Text);
                            cmd.Parameters.AddWithValue("@Suffix", cbSuffix.Text);
                            cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                            cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Birthday", dtpBirthdate.Text);
                            cmd.Parameters.AddWithValue("@BirthPlace", txtBirthPlace.Text);
                            cmd.Parameters.AddWithValue("@Religion", txtReligion.Text);
                            cmd.Parameters.AddWithValue("@GradeLevel", GradeLevelid);
                            cmd.Parameters.AddWithValue("@PresentAdd", txtPresentadd.Text);
                            cmd.Parameters.AddWithValue("@HomeAdd", txtHomeadd.Text);
                            cmd.Parameters.AddWithValue("@FFirstName", txtFFirstName.Text);
                            cmd.Parameters.AddWithValue("@FMiddleName", txtFMI.Text);
                            cmd.Parameters.AddWithValue("@FLastName", txtFLastName.Text);
                            cmd.Parameters.AddWithValue("@FOccupation", txtFOccupation.Text);
                            cmd.Parameters.AddWithValue("@MFirstName", txtMFirstName.Text);
                            cmd.Parameters.AddWithValue("@MMiddleName", txtMMI.Text);
                            cmd.Parameters.AddWithValue("@MLastName", txtMLastName.Text);
                            cmd.Parameters.AddWithValue("@MOccupation", txtMOccupation.Text);
                            cmd.Parameters.AddWithValue("@LastSchoolName", textBox1.Text);
                            cmd.Parameters.AddWithValue("@LastSchoolAdd", textBox13.Text);

                            if (rbBothParents.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbBothParents.Text);
                            }
                            else if (rbFatherOnly.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbFatherOnly.Text);
                            }
                            else if (rbMotherOnly.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbMotherOnly.Text);
                            }
                            else if (rbGrandParents.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbGrandParents.Text);
                            }
                            else if (rbGuardians.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbGuardians.Text);
                            }

                            cmd.Parameters.AddWithValue("@GName", txtGName.Text);
                            cmd.Parameters.AddWithValue("@GAddress", txtGAddress.Text);
                            cmd.Parameters.AddWithValue("@GContactNo", txtGContactNo.Text);
                            cmd.Parameters.AddWithValue("@GAdd", txtPresentadd.Text);

                            if (ckbSReportCard.Checked || ckbEJReportCard.Checked)
                            {
                                cmd.Parameters.AddWithValue("@ReportCard", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ReportCard", "No");
                            }
                            if (ckbSGoodMoral.Checked || ckbEJGoodMoral.Checked)
                            {
                                cmd.Parameters.AddWithValue("@GoodMoral", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@GoodMoral", "No");
                            }
                            if (ckbKPSA.Checked || ckbSPSA.Checked || ckbEJPSA.Checked)
                            {
                                cmd.Parameters.AddWithValue("@PSA", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@PSA", "No");
                            }
                            if (ckbKPicture.Checked || ckbSPicture.Checked || ckbEJPicture.Checked)
                            {
                                cmd.Parameters.AddWithValue("@Picture", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Picture", "No");
                            }
                            if (ckbKBaptismal.Checked)
                            {
                                cmd.Parameters.AddWithValue("@Baptismal", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Baptismal", "No");
                            }

                            cmd.ExecuteNonQuery();
                        }


                        conn.Close();
                        Validator.AddConfirmation();
                    }
                    else
                    {
                        string sql = "INSERT INTO `studentinfo`( `StudentID`, `FirstName`, `MiddleName`, `LastName`, `Suffix`, `Gender`, `ContactNo`, `Email`, `Birthday`, `BirthPlace`, `Religion`, `GradeLevel_ID`, `PresentAddress`, `HomeAddress`, `FatherFirstName`, `FatherMiddleName`, `FatherLastName`, `FatherOccupation`, `MotherFirstName`, `MotherMiddleName`, `MotherLastName`, `MotherOccupation`, `LastSchoolAttended`, `SchoolAddress`, `FamilyStatus`, `GuardiansName`,GuardianAddress, `GuardiansContactNo`, `ReportCard`, `GoodMoral`, `PSACert`, `Picture`, `BaptimalCert`, `DateRegistered`) VALUES" +
                       " (@StudentID,@FirstName,@MiddleName,@LastName,@Suffix,@Gender,@ContactNo,@Email,@Birthday,@BirthPlace,@Religion,@Gradelevel,@PresentAdd,@HomeAdd,@FFirstName,@FMiddleName,@FLastName,@FOccupation,@MFirstName,@MMiddleName,@MLastName,@MOccupation,@LastSchoolName,@LastSchoolAdd,@FamilyStatus,@GName,@GAddress,@GContactNo,@ReportCard,@GoodMoral,@PSA,@Picture,@Baptismal,CURRENT_DATE());";
                        conn = connect.getconn();
                        conn.Open();
                        using (cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@MiddleName", txtMI.Text);
                            cmd.Parameters.AddWithValue("@Suffix", cbSuffix.Text);
                            cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                            cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Birthday", dtpBirthdate.Text);
                            cmd.Parameters.AddWithValue("@BirthPlace", txtBirthPlace.Text);
                            cmd.Parameters.AddWithValue("@Religion", txtReligion.Text);
                            cmd.Parameters.AddWithValue("@GradeLevel", GradeLevelid);
                            cmd.Parameters.AddWithValue("@PresentAdd", txtPresentadd.Text);
                            cmd.Parameters.AddWithValue("@HomeAdd", txtHomeadd.Text);
                            cmd.Parameters.AddWithValue("@FFirstName", txtFFirstName.Text);
                            cmd.Parameters.AddWithValue("@FMiddleName", txtFMI.Text);
                            cmd.Parameters.AddWithValue("@FLastName", txtFLastName.Text);
                            cmd.Parameters.AddWithValue("@FOccupation", txtFOccupation.Text);
                            cmd.Parameters.AddWithValue("@MFirstName", txtMFirstName.Text);
                            cmd.Parameters.AddWithValue("@MMiddleName", txtMMI.Text);
                            cmd.Parameters.AddWithValue("@MLastName", txtMLastName.Text);
                            cmd.Parameters.AddWithValue("@MOccupation", txtMOccupation.Text);
                            cmd.Parameters.AddWithValue("@LastSchoolName", textBox1.Text);
                            cmd.Parameters.AddWithValue("@LastSchoolAdd", textBox13.Text);

                            if (rbBothParents.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbBothParents.Text);
                            }
                            else if (rbFatherOnly.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbFatherOnly.Text);
                            }
                            else if (rbMotherOnly.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbMotherOnly.Text);
                            }
                            else if (rbGrandParents.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbGrandParents.Text);
                            }
                            else if (rbGuardians.Checked)
                            {
                                cmd.Parameters.AddWithValue("@FamilyStatus", rbGuardians.Text);
                            }

                            cmd.Parameters.AddWithValue("@GName", txtGName.Text);
                            cmd.Parameters.AddWithValue("@GAddress", txtGAddress.Text);
                            cmd.Parameters.AddWithValue("@GContactNo", txtGContactNo.Text);
                            cmd.Parameters.AddWithValue("@GAdd", txtPresentadd.Text);

                            if (ckbSReportCard.Checked || ckbEJReportCard.Checked)
                            {
                                cmd.Parameters.AddWithValue("@ReportCard", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ReportCard", "No");
                            }
                            if (ckbSGoodMoral.Checked || ckbEJGoodMoral.Checked)
                            {
                                cmd.Parameters.AddWithValue("@GoodMoral", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@GoodMoral", "No");
                            }
                            if (ckbKPSA.Checked || ckbSPSA.Checked || ckbEJPSA.Checked)
                            {
                                cmd.Parameters.AddWithValue("@PSA", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@PSA", "No");
                            }
                            if (ckbKPicture.Checked || ckbSPicture.Checked || ckbEJPicture.Checked)
                            {
                                cmd.Parameters.AddWithValue("@Picture", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Picture", "No");
                            }
                            if (ckbKBaptismal.Checked)
                            {
                                cmd.Parameters.AddWithValue("@Baptismal", "Yes");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Baptismal", "No");
                            }

                            cmd.ExecuteNonQuery();
                        }


                        conn.Close();
                        Validator.AddConfirmation();
                    }









                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void ckbKPSA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbKPSA.Checked || ckbKBaptismal.Checked || ckbKPicture.Checked)
            {
                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbKBaptismal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbKPSA.Checked || ckbKBaptismal.Checked || ckbKPicture.Checked)
            {
                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbKPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbKPSA.Checked || ckbKBaptismal.Checked || ckbKPicture.Checked)
            {
                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbEJReportCard_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEJPSA.Checked || ckbEJReportCard.Checked || ckbEJGoodMoral.Checked || ckbEJPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                //ckbEJPSA.CheckState = CheckState.Unchecked;
                //ckbEJReportCard.CheckState = CheckState.Unchecked;
                //ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                //ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbEJGoodMoral_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEJPSA.Checked || ckbEJReportCard.Checked || ckbEJGoodMoral.Checked || ckbEJPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                //ckbEJPSA.CheckState = CheckState.Unchecked;
                //ckbEJReportCard.CheckState = CheckState.Unchecked;
                //ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                //ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbEJPSA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEJPSA.Checked || ckbEJReportCard.Checked || ckbEJGoodMoral.Checked || ckbEJPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                //ckbEJPSA.CheckState = CheckState.Unchecked;
                //ckbEJReportCard.CheckState = CheckState.Unchecked;
                //ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                //ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbEJPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEJPSA.Checked || ckbEJReportCard.Checked || ckbEJGoodMoral.Checked || ckbEJPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                //ckbEJPSA.CheckState = CheckState.Unchecked;
                //ckbEJReportCard.CheckState = CheckState.Unchecked;
                //ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                //ckbEJPicture.CheckState = CheckState.Unchecked;

                ckbSReportCard.CheckState = CheckState.Unchecked;
                ckbSGoodMoral.CheckState = CheckState.Unchecked;
                ckbSPSA.CheckState = CheckState.Unchecked;
                ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbSReportCard_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSReportCard.Checked || ckbSGoodMoral.Checked || ckbSPSA.Checked || ckbSPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                //ckbSReportCard.CheckState = CheckState.Unchecked;
                //ckbSGoodMoral.CheckState = CheckState.Unchecked;
                //ckbSPSA.CheckState = CheckState.Unchecked;
                //ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbSGoodMoral_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSReportCard.Checked || ckbSGoodMoral.Checked || ckbSPSA.Checked || ckbSPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                //ckbSReportCard.CheckState = CheckState.Unchecked;
                //ckbSGoodMoral.CheckState = CheckState.Unchecked;
                //ckbSPSA.CheckState = CheckState.Unchecked;
                //ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbSPSA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSReportCard.Checked || ckbSGoodMoral.Checked || ckbSPSA.Checked || ckbSPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                //ckbSReportCard.CheckState = CheckState.Unchecked;
                //ckbSGoodMoral.CheckState = CheckState.Unchecked;
                //ckbSPSA.CheckState = CheckState.Unchecked;
                //ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void ckbSPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSReportCard.Checked || ckbSGoodMoral.Checked || ckbSPSA.Checked || ckbSPicture.Checked)
            {
                ckbKPSA.CheckState = CheckState.Unchecked;
                ckbKBaptismal.CheckState = CheckState.Unchecked;
                ckbKPicture.CheckState = CheckState.Unchecked;

                ckbEJPSA.CheckState = CheckState.Unchecked;
                ckbEJReportCard.CheckState = CheckState.Unchecked;
                ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                ckbEJPicture.CheckState = CheckState.Unchecked;

                //ckbSReportCard.CheckState = CheckState.Unchecked;
                //ckbSGoodMoral.CheckState = CheckState.Unchecked;
                //ckbSPSA.CheckState = CheckState.Unchecked;
                //ckbSPicture.CheckState = CheckState.Unchecked;
            }
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            
            if (txtStudentID.Text.Equals(""))
            {

            }
            else
            {
                try
                {
                    //string sql = "SELECT * FROM `studentinfo` WHERE StudentID = " + txtStudentID.Text + " and RegisterID = (SELECT MAX(a.RegisterID) FROM studentinfo a WHERE a.StudentID = " + txtStudentID.Text + ")";
                    string sql = "SELECT studentinfo.*,gradelevel.GradeLevel FROM studentinfo join gradelevel on gradelevel.GradeLevel_ID = studentinfo.GradeLevel_ID WHERE studentinfo.StudentID = " + txtStudentID.Text + " and studentinfo.RegisterID = (SELECT MAX(a.RegisterID) FROM studentinfo a WHERE a.StudentID = " + txtStudentID.Text + ")";


                    conn = connect.getconn();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    mdr = cmd.ExecuteReader();

                    

                    if (mdr.HasRows)
                    {
                        while (mdr.Read())
                        {






                            txtLastName.Text = mdr[4].ToString();
                            txtFirstName.Text = mdr[2].ToString();
                            txtMI.Text = mdr[3].ToString();
                            cbSuffix.SelectedItem = mdr[5].ToString();
                            dtpBirthdate.Text = mdr[9].ToString();
                            txtBirthPlace.Text = mdr[10].ToString();
                            txtReligion.Text = mdr[11].ToString();
                            cbGender.SelectedItem = mdr[6].ToString();
                            txtContactNo.Text = mdr[7].ToString();
                            txtEmail.Text = mdr[8].ToString();
                            cbGradeLevel.SelectedItem = mdr[35].ToString();
                            txtPresentadd.Text = mdr[13].ToString();
                            if (mdr[13].ToString().Equals(mdr[14].ToString()))
                            {
                                checkBox5.CheckState = CheckState.Checked;
                            }
                            else
                            {
                                checkBox5.CheckState = CheckState.Unchecked;
                                txtHomeadd.Text = mdr[14].ToString();
                            }

                            txtFLastName.Text = mdr[17].ToString();
                            txtFFirstName.Text = mdr[15].ToString();
                            txtFMI.Text = mdr[16].ToString();
                            txtFOccupation.Text = mdr[18].ToString();
                            txtMLastName.Text = mdr[21].ToString();
                            txtMFirstName.Text = mdr[19].ToString();
                            txtMMI.Text = mdr[20].ToString();
                            txtMOccupation.Text = mdr[22].ToString();

                            textBox1.Text = mdr[23].ToString();
                            textBox13.Text = mdr[24].ToString();

                            if (mdr[25].ToString().Equals(rbBothParents.Text))
                            {
                                rbBothParents.Checked = true;
                            }
                            else if (mdr[25].ToString().Equals(rbFatherOnly.Text))
                            {
                                rbFatherOnly.Checked = true;
                            }
                            else if (mdr[25].ToString().Equals(rbMotherOnly.Text))
                            {
                                rbMotherOnly.Checked = true;
                            }
                            else if (mdr[25].ToString().Equals(rbGrandParents.Text))
                            {
                                rbGrandParents.Checked = true;
                            }
                            else if (mdr[25].ToString().Equals(rbGuardians.Text))
                            {
                                rbGuardians.Checked = true;
                            }

                            txtGName.Text = mdr[26].ToString();
                            txtGAddress.Text = mdr[27].ToString();
                            txtGContactNo.Text = mdr[28].ToString();

                            if(cbGradeLevel.Text == "Kinder 1" || cbGradeLevel.Text == "Kinder 2")
                            {
                                if (mdr[31].ToString()=="Yes")
                                {
                                    ckbKPSA.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbKPSA.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[33].ToString()=="Yes")
                                {
                                    ckbKBaptismal.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbKBaptismal.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[32].ToString()=="Yes")
                                {
                                    ckbKPicture.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbKPicture.CheckState = CheckState.Unchecked;
                                }
                            }
                            if (cbGradeLevel.Text == "Grade 1" || cbGradeLevel.Text == "Grade 2" || cbGradeLevel.Text == "Grade 3" || cbGradeLevel.Text == "Grade 4" || cbGradeLevel.Text == "Grade 5" || cbGradeLevel.Text == "Grade 6" || cbGradeLevel.Text == "Grade 7" || cbGradeLevel.Text == "Grade 8" || cbGradeLevel.Text == "Grade 9" || cbGradeLevel.Text == "Grade 10" )
                            {
                                if (mdr[29].ToString()=="Yes")
                                {
                                    ckbEJReportCard.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbEJReportCard.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[30].ToString()=="Yes") 
                                {
                                    ckbEJGoodMoral.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbEJGoodMoral.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[31].ToString()=="Yes")
                                {
                                    ckbEJPSA.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbEJPSA.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[32].ToString() == "Yes")
                                {
                                    ckbEJPicture.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbEJPicture.CheckState = CheckState.Unchecked;
                                }

                            }
                            if (cbGradeLevel.Text == "1st Year" || cbGradeLevel.Text == "2nd Year")
                            {
                                if (mdr[29].ToString() == "Yes")
                                {
                                    ckbSReportCard.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbSReportCard.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[30].ToString() == "Yes")
                                {
                                    ckbSGoodMoral.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbSGoodMoral.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[31].ToString() == "Yes")
                                {
                                    ckbSPSA.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbSPSA.CheckState = CheckState.Unchecked;
                                }
                                if (mdr[32].ToString() == "Yes")
                                {
                                    ckbSPicture.CheckState = CheckState.Checked;
                                }
                                else
                                {
                                    ckbSPicture.CheckState = CheckState.Unchecked;
                                }
                            }



                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                        txtStudentID.Text = "";
                    }

                    
                    conn.Close();


                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            

           
        }

        private void ckbOldStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOldStudent.Checked)
            {
                txtStudentID.Enabled = true;
                txtStudentID.Text = "";
                txtStudentID.Focus();
            }
            else
            {
                txtStudentID.Enabled = false;
                txtStudentID.Text = "";
                //txtLastName.Focus();
            }
            
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
