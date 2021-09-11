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
namespace SchoolManagementSystem.FORMS.Sectioning
{
    public partial class addSectionCategory : Form
    {

        Sectioning reload;
        string idd;
        public addSectionCategory(Sectioning reload, string idd)
        {
            InitializeComponent();
            this.reload = reload;
            this.idd = idd;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtStructure };

            if (btnAddCourse.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("sectionCategory").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {
                        if (value.SectionCategoryID.Equals(Convert.ToInt32(idd)) && value.sectionName.Equals(txtStructure.Text))
                        {
                            DBContext.GetContext().Query("sectionCategory").Where("SectionCategoryID", idd).Update(new
                            {
                                sectionName = Validator.ToTitleCase(txtStructure.Text.Trim()),
                                Description = txtDescription.Text.Trim()
                            });
                            reload.displayData();
                            this.Close();
                            return;
                        }
                        else if (value.SectionCategoryID != Convert.ToInt32(idd) && value.sectionName.Equals(Validator.ToTitleCase(txtStructure.Text)))
                        {
                            Validator.AlertDanger("Section name already existed");
                            return;
                        }
                    }
                }

                DBContext.GetContext().Query("sectionCategory").Where("SectionCategoryID", idd).Update(new
                {
                    sectionName = Validator.ToTitleCase(txtStructure.Text.Trim()),
                    Description = txtDescription.Text.Trim()
                });
                reload.displayData();
                this.Close();
            }
            else if (btnAddCourse.Text.Equals("Save"))
            {
                try
                {
                    DBContext.GetContext().Query("sectionCategory").Where("sectionName", txtStructure.Text).First();
                    Validator.AlertDanger("Section name already existed");
                }
                catch (Exception)
                {
                    if (Validator.isEmpty(inputs))
                    {
                        DBContext.GetContext().Query("sectionCategory").Insert(new
                        {
                            sectionName = Validator.ToTitleCase(txtStructure.Text),
                            Description = txtDescription.Text
                        });
                        Validator.AlertSuccess("Section name added");
                        reload.displayData();
                        this.Close();
                    }
                    
                   
                }
            }
        }

        private void addSectionCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }
    }
}
