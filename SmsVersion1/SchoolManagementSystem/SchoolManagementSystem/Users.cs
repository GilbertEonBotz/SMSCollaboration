using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SchoolManagementSystem.UITools;
using SqlKata.Execution;

namespace SchoolManagementSystem
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            var myfrm = new AddUser(this, idd);
            FormFade.FadeForm(this, myfrm);
        }
        private void Users_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            displayData();
        }
        public void displayData()
        {
            var values = DBContext.GetContext().Query("users").Get();

            dgvUsers.Rows.Clear();
            foreach (var value in values)
            {

                dgvUsers.Rows.Add(value.id, value.name, value.userrole, value.status);
            }
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (Convert.ToString(row.Cells[3].Value) == "Active")
                {
                    row.Cells[3].Style.ForeColor = Color.Blue;
                    row.Cells[3].Style.SelectionForeColor = Color.Blue;
                }
                else
                {
                    row.Cells[3].Style.ForeColor = Color.Red;
                    row.Cells[3].Style.SelectionForeColor = Color.Red;
                }
            }
        }
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUsers.Columns[e.ColumnIndex].Name;

            if (colName.Equals("activate"))
            {
                if (dgvUsers.SelectedRows[0].Cells[3].Value.Equals("Active"))
                {
                    Validator.AlertDanger("This user is already activated");
                    return;
                }
                else
                {
                    if (Validator.actYear())
                    {
                        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Active"
                        });
                        displayData();
                    }
                }
                //if (dgvUsers.SelectedRows[0].Cells[3].Value.ToString() == "Activate")
                //{
                //    if (Validator.actYear())
                //    {
                //        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                //        {
                //            status = "Deactivate"
                //        });
                //        displayData();
                //    }
                //}
                //else if (dgvUsers.SelectedRows[0].Cells[3].Value.ToString() == "Deactivate")
                //{
                //    if (Validator.deactYear())
                //    {
                //        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                //        {
                //            status = "Activate"
                //        });
                //        displayData();
                //    }
                //}
            }
            else if (colName.Equals("deactivate"))
            {
                if (dgvUsers.SelectedRows[0].Cells[3].Value.Equals("Inactive"))
                {
                    Validator.AlertDanger("This user is already deactivated");
                    return;
                }
                else
                {
                    if (Validator.deactYear())
                    {
                        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Inactive"
                        });
                        displayData();
                    }
                }
            }
            else if (colName.Equals("edit"))
            {
                idd = dgvUsers.Rows[dgvUsers.CurrentRow.Index].Cells[0].Value.ToString();
                var myfrm = new AddUser(this, idd);

                var values = DBContext.GetContext().Query("users")
                    .Where("id", idd).Get();

                foreach (var value in values)
                {
                    myfrm.cmbRole.Text = value.userrole;
                    myfrm.txtName.Text = value.name;
                    myfrm.txtUsername.Text = value.username;
                    myfrm.txtPassword.Text = value.password;
                    myfrm.txtMacAddress.Text = value.macAddress;
                }
                myfrm.btnSave.Text = "Update";
                myfrm.ShowDialog();
            }
        }

        string idd;
        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            var values = DBContext.GetContext().Query("users").WhereLike("id", $"{textboxWatermark1.Text}")
             .OrWhereLike("userrole", $"%{textboxWatermark1.Text}%")
             .OrWhereLike("name", $"%{textboxWatermark1.Text}%")
             .Get();

            dgvUsers.Rows.Clear();
            foreach (var value in values)
            {
                dgvUsers.Rows.Add(value.id, value.name, value.userrole, value.status);
            }

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (Convert.ToString(row.Cells[3].Value) == "Activate")
                {
                    row.Cells[3].Style.ForeColor = Color.Blue;
                    row.Cells[3].Style.SelectionForeColor = Color.Blue;
                }
                else
                {
                    row.Cells[3].Style.ForeColor = Color.Red;
                    row.Cells[3].Style.SelectionForeColor = Color.Red;
                }
            }
        }

        private void Users_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                btnNew.PerformClick();
            }
        }
    }
}