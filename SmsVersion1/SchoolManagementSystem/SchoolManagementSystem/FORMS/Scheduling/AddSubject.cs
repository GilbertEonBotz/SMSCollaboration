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
    public partial class AddSubject : Form
    {
        Subjects subj = new Subjects();

        Subject reloadDatagrid;
        string getId;
        int idd;

        public AddSubject(Subject reloadDatagrid, string getId)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.getId = getId;
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            string value = "";

            TextBox[] inputs = { txtSubjectCode, txtDescriptiveTitle, txtLec, txtLab, txtTotalUnits, txtLecPrice, txtLabprice };
            if (btnAddSubjects.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("subjects").Get();
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    if (string.IsNullOrEmpty(txtTotalUnits.Text) || txtTotalUnits.Text.Equals("0"))
                    {
                        Validator.AlertDanger("Total units must not be empty");
                        return;
                    }
                    else if (lblLectotal.Text.Equals("0") && lblabTotal.Text.Equals("0"))
                    {
                        Validator.AlertDanger("Please enter an amount for lecture and lab!");
                        return;
                    }
                    else if (string.IsNullOrEmpty(cmbCourse.Text))
                    {
                        Validator.AlertDanger("Please select course!");
                        return;
                    }
                    else if (string.IsNullOrEmpty(cmbCourseCode.Text))
                    {
                        Validator.AlertDanger("Please select course code!");
                        return;
                    }
                    else if (Convert.ToDouble(txtLecPrice.Text) > 0 && txtLec.Text.Equals("0"))
                    {
                        foreach (var val in values)
                        {
                            if (val.subjectId.Equals(Convert.ToInt32(getId)) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                for (int i = 0; i < lstPrereq.Items.Count; i++)
                                {
                                    if (value != "")
                                    {
                                        value += ",";
                                    }
                                    value += lstPrereq.Items[i].ToString();
                                }
                                DBContext.GetContext().Query("subjects")
                                    .Where("subjectId", getId)
                                    .Update(new
                                    {
                                        courseCode = cmbCourseCode.Text,
                                        subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                        subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                        lec = txtLec.Text.Trim(),
                                        lab = txtLab.Text.Trim(),
                                        totalUnits = txtTotalUnits.Text,
                                        prereq = value,
                                        status = "Avail",
                                        totalLecprice = "0",
                                        totalLabprice = lblabTotal.Text.Trim(),
                                        labprice = txtLabprice.Text.Trim(),
                                        lecprice = "0",
                                        totalprice = TotalPrice.Text
                                    });
                                reloadDatagrid.displayData();
                                this.Close();
                                return;
                            }
                            else if (val.subjectId != Convert.ToInt32(idd) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                Validator.AlertDanger("Subject code already existed");
                                return;
                            }
                        }
                        return;

                    }
                    else if (Convert.ToDouble(txtLabprice.Text) > 0 && txtLab.Text.Equals("0"))
                    {
                        foreach (var val in values)
                        {
                            if (val.subjectId.Equals(Convert.ToInt32(getId)) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                for (int i = 0; i < lstPrereq.Items.Count; i++)
                                {
                                    if (value != "")
                                    {
                                        value += ",";
                                    }
                                    value += lstPrereq.Items[i].ToString();
                                }
                                DBContext.GetContext().Query("subjects")
                                    .Where("subjectId", getId)
                                    .Update(new
                                    {
                                        courseCode = cmbCourseCode.Text,
                                        subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                        subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                        lec = txtLec.Text.Trim(),
                                        lab = txtLab.Text.Trim(),
                                        totalUnits = txtTotalUnits.Text,
                                        prereq = value,
                                        status = "Avail",
                                        totalLecprice = lblLectotal.Text.Trim(),
                                        totalLabprice = "0",
                                        labprice = "0",
                                        lecprice = txtLecPrice.Text.Trim(),
                                        totalprice = TotalPrice.Text
                                    });
                                reloadDatagrid.displayData();
                                this.Close();
                                return;
                            }
                            else if (val.subjectId != Convert.ToInt32(idd) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                Validator.AlertDanger("Subject code already existed");
                                return;
                            }
                        }
                    }
                    else
                    {
                        foreach (var val in values)
                        {
                            if (val.subjectId.Equals(Convert.ToInt32(getId)) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                for (int i = 0; i < lstPrereq.Items.Count; i++)
                                {
                                    if (value != "")
                                    {
                                        value += ",";
                                    }
                                    value += lstPrereq.Items[i].ToString();
                                }
                                DBContext.GetContext().Query("subjects")
                                    .Where("subjectId", getId)
                                    .Update(new
                                    {
                                        courseCode = cmbCourseCode.Text,
                                        subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                        subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                        lec = txtLec.Text.Trim(),
                                        lab = txtLab.Text.Trim(),
                                        totalUnits = txtTotalUnits.Text,
                                        prereq = value,
                                        status = "Avail",
                                        totalLecprice = lblLectotal.Text.Trim(),
                                        totalLabprice = lblabTotal.Text.Trim(),
                                        labprice = txtLabprice.Text.Trim(),
                                        lecprice = txtLecPrice.Text.Trim(),
                                        totalprice = TotalPrice.Text
                                    });
                                reloadDatagrid.displayData();
                                this.Close();
                                return;
                            }
                            else if (val.subjectId != Convert.ToInt32(idd) && val.subjectCode.Equals(txtSubjectCode.Text))
                            {
                                Validator.AlertDanger("Subject code already existed");
                                return;
                            }
                        }
                    }
                }
                for (int i = 0; i < lstPrereq.Items.Count; i++)
                {
                    if (value != "")
                    {
                        value += ",";
                    }
                    value += lstPrereq.Items[i].ToString();
                }
                DBContext.GetContext().Query("subjects")
                    .Where("subjectId", getId)
                    .Update(new
                    {
                        courseCode = cmbCourseCode.Text,
                        subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                        subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                        lec = txtLec.Text.Trim(),
                        lab = txtLab.Text.Trim(),
                        totalUnits = txtTotalUnits.Text,
                        prereq = value,
                        status = "Avail",
                        totalLecprice = lblLectotal.Text.Trim(),
                        totalLabprice = lblabTotal.Text.Trim(),
                        labprice = txtLabprice.Text.Trim(),
                        lecprice = txtLecPrice.Text.Trim(),
                        totalprice = TotalPrice.Text
                    });
                reloadDatagrid.displayData();
                this.Close();

            }
            else if (btnAddSubjects.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    if (string.IsNullOrEmpty(txtTotalUnits.Text) || txtTotalUnits.Text.Equals("0"))
                    {
                        Validator.AlertDanger("Total unit must not be empty");
                    }
                    else if (lblLectotal.Text.Equals("0") && lblabTotal.Text.Equals("0"))
                    {
                        Validator.AlertDanger("Please enter an amount for lecture and lab!");
                    }
                    else if (string.IsNullOrEmpty(cmbCourse.Text))
                    {
                        Validator.AlertDanger("Please select course!");
                    }
                    else if (string.IsNullOrEmpty(cmbCourseCode.Text))
                    {
                        Validator.AlertDanger("Please select course code!");
                    }
                    else if (Convert.ToDouble(txtLecPrice.Text) > 0 && txtLec.Text.Equals("0"))
                    {
                        try
                        {
                            DBContext.GetContext().Query("subjects").Where("subjectCode", txtSubjectCode.Text).First();
                            Validator.AlertDanger("Subject code already existed");
                        }
                        catch (Exception)
                        {
                            value = "";

                            for (int i = 0; i < lstPrereq.Items.Count; i++)
                            {
                                if (value != "")
                                {
                                    value += ",";
                                }
                                value += lstPrereq.Items[i].ToString();

                            }
                            DBContext.GetContext().Query("subjects").Insert(new
                            {
                                courseCode = cmbCourseCode.Text,
                                subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                lec = txtLec.Text.Trim(),
                                lab = txtLab.Text.Trim(),
                                totalUnits = txtTotalUnits.Text,
                                prereq = value,
                                status = "Avail",
                                totalLecprice = "0",
                                totalLabprice = lblabTotal.Text.Trim(),
                                labprice = txtLabprice.Text.Trim(),
                                lecprice = "0",
                                totalprice = TotalPrice.Text
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                        }
                    }
                    else if (Convert.ToDouble(txtLabprice.Text) > 0 && txtLab.Text.Equals("0"))
                    {
                        try
                        {
                            DBContext.GetContext().Query("subjects").Where("subjectCode", txtSubjectCode.Text).First();
                            Validator.AlertDanger("Subject code already existed");
                        }
                        catch (Exception)
                        {
                            value = "";

                            for (int i = 0; i < lstPrereq.Items.Count; i++)
                            {
                                if (value != "")
                                {
                                    value += ",";
                                }
                                value += lstPrereq.Items[i].ToString();

                            }
                            DBContext.GetContext().Query("subjects").Insert(new
                            {
                                courseCode = cmbCourseCode.Text,
                                subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                lec = txtLec.Text.Trim(),
                                lab = txtLab.Text.Trim(),
                                totalUnits = txtTotalUnits.Text,
                                prereq = value,
                                status = "Avail",
                                totalLecprice = lblLectotal.Text.Trim(),
                                totalLabprice = "0",
                                labprice = "0",
                                lecprice = txtLecPrice.Text.Trim(),
                                totalprice = TotalPrice.Text
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                        }
                    }
                    else
                    {
                        try
                        {
                            DBContext.GetContext().Query("subjects").Where("subjectCode", txtSubjectCode.Text).First();
                            Validator.AlertDanger("Subject code already existed");
                        }
                        catch (Exception)
                        {
                            value = "";

                            for (int i = 0; i < lstPrereq.Items.Count; i++)
                            {
                                if (value != "")
                                {
                                    value += ",";
                                }
                                value += lstPrereq.Items[i].ToString();

                            }
                            DBContext.GetContext().Query("subjects").Insert(new
                            {
                                courseCode = cmbCourseCode.Text,
                                subjectCode = txtSubjectCode.Text.Trim().ToUpper(),
                                subjectTitle = Validator.ToTitleCase(txtDescriptiveTitle.Text.Trim()),
                                lec = txtLec.Text.Trim(),
                                lab = txtLab.Text.Trim(),
                                totalUnits = txtTotalUnits.Text,
                                prereq = value,
                                status = "Avail",
                                totalLecprice = lblLectotal.Text.Trim(),
                                totalLabprice = lblabTotal.Text.Trim(),
                                labprice = txtLabprice.Text.Trim(),
                                lecprice = txtLecPrice.Text.Trim(),
                                totalprice = TotalPrice.Text
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLab_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLec.Text) && !string.IsNullOrEmpty(txtLab.Text))
                txtTotalUnits.Text = (Convert.ToInt32(txtLec.Text) + Convert.ToInt32(txtLab.Text)).ToString();

            if (string.IsNullOrEmpty(txtLab.Text))
            {
                txtTotalUnits.Text = txtLec.Text;
            }

            if (string.IsNullOrWhiteSpace(txtLab.Text))
            {
                lblabTotal.Text = "0";
            }

            else
            {
                if (txtLabprice.Text == "" || txtLabprice.Text == "0")
                {
                    lblabTotal.Text = "0";
                    TotalPrice.Text = lblLectotal.Text;
                }
                else
                {

                    double total;
                    double total2;
                    double num1;
                    double num2;

                    try
                    {
                        total = Convert.ToDouble(txtLabprice.Text) * Convert.ToDouble(txtLab.Text);
                        lblabTotal.Text = total.ToString();
                    }
                    catch (Exception)
                    {

                    }
                    num1 = Convert.ToDouble(lblabTotal.Text);

                    num2 = Convert.ToDouble(lblLectotal.Text);

                    total2 = num1 + num2;
                    TotalPrice.Text = total2.ToString();
                }
            }


        }

        private void txtLec_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLec.Text) && !string.IsNullOrEmpty(txtLab.Text))
                txtTotalUnits.Text = (Convert.ToInt32(txtLec.Text) + Convert.ToInt32(txtLab.Text)).ToString();
            if (string.IsNullOrEmpty(txtLec.Text))
            {
                txtTotalUnits.Text = txtLab.Text;
            }

            if (string.IsNullOrWhiteSpace(txtLec.Text))
            {
                lblLectotal.Text = "0";
            }

            else
            {
                if (txtLecPrice.Text == "" || txtLecPrice.Text == "0")
                {
                    lblLectotal.Text = "0";
                    TotalPrice.Text = lblabTotal.Text;
                }
                else
                {
                    double total;
                    double total2;
                    double num1;
                    double num2;
                    try
                    {
                        total = Convert.ToDouble(txtLecPrice.Text) * Convert.ToDouble(txtLec.Text);
                        lblLectotal.Text = total.ToString();
                    }
                    catch (Exception)
                    {
                    }
                    num1 = Convert.ToDouble(lblabTotal.Text);

                    num2 = Convert.ToDouble(lblLectotal.Text);

                    total2 = num1 + num2;
                    TotalPrice.Text = total2.ToString();
                }
            }


        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            if (cmbCourseCode.Text.Equals(""))
            {
                cmbPreReq.Items.Clear();
            }
            else
            {
                var values = DBContext.GetContext().Query("subjects")
               .Join("coursecode", "coursecode.coursecode", "subjects.courseCode")
               .Where("subjects.courseCode", cmbCourseCode.Text).Get();

                cmbPreReq.Items.Clear();
                foreach (var value in values)
                {
                    cmbPreReq.Items.Add(value.subjectCode);
                }
            }
            txtLecPrice.KeyPress += Validator.ValidateKeypressNumber;
            txtLabprice.KeyPress += Validator.ValidateKeypressNumber;
            displayCourse();
            displayUnit();
        }

        public void displayUnit()
        {
            try
            {
                var value = DBContext.GetContext().Query("unitPrice").Where("status", "Active").First();
                txtLecPrice.Text = value.amount.ToString();
                txtLabprice.Text = value.amount.ToString();
            }
            catch (Exception)
            {

            }

        }

        public void displayCourse()
        {
            var values = DBContext.GetContext().Query("course").Get();

            foreach (var value in values)
            {
                cmbCourse.Items.Add(value.description);
            }
        }
        private void txtLab_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtLec_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTotalUnits_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLecPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLec.Text))
            {

            }
            else
            {
                if (txtLecPrice.Text == "" || txtLecPrice.Text == "0")
                {
                    lblLectotal.Text = "0";
                    TotalPrice.Text = lblabTotal.Text;
                }
                else
                {

                    //double total;
                    //total = Convert.ToDouble(txtLecPrice.Text) * Convert.ToDouble(txtLec.Text);

                    //lblLectotal.Text = total.ToString();
                    double total;
                    double total2;
                    double num1;
                    double num2;
                    try
                    {
                        total = Convert.ToDouble(txtLecPrice.Text) * Convert.ToDouble(txtLec.Text);
                        lblLectotal.Text = total.ToString();
                    }
                    catch (Exception)
                    {
                    }


                    num1 = Convert.ToDouble(lblabTotal.Text);

                    num2 = Convert.ToDouble(lblLectotal.Text);

                    total2 = num1 + num2;
                    TotalPrice.Text = total2.ToString();

                }
            }
        }

        private void txtLabprice_TextChanged(object sender, EventArgs e)
        {

            if (txtLab.Text == "")
            {

            }
            else
            {

                if (txtLabprice.Text == "" || txtLabprice.Text == "0")
                {
                    lblabTotal.Text = "0";
                    TotalPrice.Text = lblLectotal.Text;
                }
                else
                {

                    double total;
                    double total2;
                    double num1;
                    double num2;

                    try
                    {
                        total = Convert.ToDouble(txtLabprice.Text) * Convert.ToDouble(txtLab.Text);
                        lblabTotal.Text = total.ToString();
                    }
                    catch (Exception)
                    {

                    }
                    num1 = Convert.ToDouble(lblabTotal.Text);

                    num2 = Convert.ToDouble(lblLectotal.Text);

                    total2 = num1 + num2;
                    TotalPrice.Text = total2.ToString();

                }
            }
        }

        private void cmbCourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            var values = DBContext.GetContext().Query("subjects")
                .Join("coursecode", "coursecode.coursecode", "subjects.courseCode")
                .Where("subjects.courseCode", cmbCourseCode.Text).Get();

            cmbPreReq.Items.Clear();
            foreach (var value in values)
            {
                cmbPreReq.Items.Add(value.subjectCode);
            }

        }
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourseCode.Text = "";
            var getID = DBContext.GetContext().Query("course").Where("description", cmbCourse.Text).First();

            idd = getID.courseId;

            var values = DBContext.GetContext().Query("coursecode")
                .Join("course", "course.courseId", "coursecode.courseId")
                .Where("coursecode.courseId", idd.ToString())
                .Get();
            cmbCourseCode.Items.Clear();
            foreach (var value in values)
            {
                cmbCourseCode.Items.Add(value.coursecode);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbPreReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrereq.Items.Contains(cmbPreReq.Text))
            {
                Validator.AlertDanger("Subject already added in the list!");
            }
            else
            {
                lstPrereq.Items.Add(cmbPreReq.SelectedItem);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lstPrereq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstPrereq.SelectedItems.Count != 0)
            {
                while (lstPrereq.SelectedIndex != -1)
                {
                    lstPrereq.Items.RemoveAt(lstPrereq.SelectedIndex);
                }
            }
        }

        private void txtLec_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLec.Text))
            {
                txtLec.Text = "0";
            }
        }

        private void txtLab_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLab.Text))
            {
                txtLab.Text = "0";
            }
        }

        private void txtLecPrice_Leave(object sender, EventArgs e)
        {

        }

        private void txtLabprice_Leave(object sender, EventArgs e)
        {

        }

        private void txtLab_Enter(object sender, EventArgs e)
        {
            txtLab.Text = "";
        }

        private void txtLecPrice_Enter(object sender, EventArgs e)
        {

        }

        private void txtLec_Enter(object sender, EventArgs e)
        {
            txtLec.Text = "";
        }

        private void txtLabprice_Enter(object sender, EventArgs e)
        {
        }

        private void AddSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }
}
