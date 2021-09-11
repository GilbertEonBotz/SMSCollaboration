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
    public partial class UserRole : Form
    {
        public UserRole()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myfrm = new AddUserRole(this, idd);
            FormFade.FadeForm(this, myfrm);
        }

        private void UserRole_Load(object sender, EventArgs e)
        {
            displayData();
        }
        public void displayData()
        {
            var values = DBContext.GetContext().Query("role").Where("status", "activate").Get();

            dgvUsersRole.Rows.Clear();
            foreach (var value in values)
            {
                dgvUsersRole.Rows.Add(value.roleId, value.roletype);
            }
        }

        string idd;
        private void dgvUsersRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUsersRole.Columns[e.ColumnIndex].Name;

            if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("role").Where("roleId", dgvUsersRole.SelectedRows[0].Cells[0].Value).Update(new
                    {
                        status = "deactivate"
                    });
                    displayData();
                }
            }
            else if (colName.Equals("edit"))
            {
                int id = Convert.ToInt32(dgvUsersRole.Rows[dgvUsersRole.CurrentRow.Index].Cells[0].Value);
                idd = id.ToString();
                var myfrm = new AddUserRole(this, idd);
                myfrm.txtRole.Text = dgvUsersRole.Rows[dgvUsersRole.CurrentRow.Index].Cells[1].Value.ToString();
                myfrm.btnSave.Text = "Update";
                myfrm.ShowDialog();
            }
        }
        private void dgvUsersRole_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
