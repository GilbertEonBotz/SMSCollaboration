using SchoolManagementSystem.UITools;
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

namespace SchoolManagementSystem
{
    public partial class OrNumberMaintenance : Form
    {
        public OrNumberMaintenance()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            var myfrm = new addOrNumber(this);
            FormFade.FadeForm(this, myfrm);
        }

        private void OrNumberMaintenance_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            var values = DBContext.GetContext().Query("ornumber").Get();

            dgvOrNumber.Rows.Clear();
            foreach(var value in values)
            {
                dgvOrNumber.Rows.Add(value.id, value.startNum, value.endNum, value.status);
            }
        }

        private void dgvOrNumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrNumber.Columns[e.ColumnIndex].Name;

            if (colName.Equals("delete"))
            {
                if (dgvOrNumber.SelectedRows[0].Cells[3].Value.Equals("Active"))
                {
                    Validator.AlertDanger("Unable to delete OR Number because status is active!");
                    return;
                }
                else
                {
                    if (Validator.DeleteConfirmation())
                    {
                        DBContext.GetContext().Query("ornumber").Where("id", dgvOrNumber.SelectedRows[0].Cells[0].Value).Delete();
                    }
                    displayData();
                }
            }
        }
    }
}
