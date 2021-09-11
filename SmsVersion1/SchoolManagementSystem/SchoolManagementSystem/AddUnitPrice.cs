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
    public partial class AddUnitPrice : Form
    {
        public AddUnitPrice()
        {
            InitializeComponent();
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var myfrm = new AddPerUnit(this);
            myfrm.ShowDialog();
        }

        private void AddUnitPrice_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            var values = DBContext.GetContext().Query("unitPrice").Get();

            dgvPercentage.Rows.Clear();
            foreach(var value in values)
            {
                dgvPercentage.Rows.Add(value.id, value.amount, value.status);
            }

            foreach (DataGridViewRow row in dgvPercentage.Rows)
            {
                if (Convert.ToString(row.Cells[2].Value) == "Active")
                {
                    row.Cells[2].Style.ForeColor = Color.Blue;
                    row.Cells[2].Style.SelectionForeColor = Color.Blue;
                }
                else
                {
                    row.Cells[2].Style.ForeColor = Color.Red;
                    row.Cells[2].Style.SelectionForeColor = Color.Red;
                }
            }
        }
        private void dgvPercentage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPercentage.Columns[e.ColumnIndex].Name;
            if (colName.Equals("open"))
            {
                

                if (dgvPercentage.SelectedRows[0].Cells[2].Value.Equals("Active"))
                {
                    Validator.AlertDanger("This unit price is already activated");
                    return;
                }
                else
                {
                    if (Validator.openUnit())
                    {
                        DBContext.GetContext().Query("unitPrice").Update(new
                        {
                            status = "Inactive",
                        });

                        DBContext.GetContext().Query("unitPrice").Where("id", dgvPercentage.SelectedRows[0].Cells[0].Value).Update(new { 
                            status = "Active",
                        });
                        displayData();
                    }
                }
            }
            else if (colName.Equals("delete"))
            {
                if (dgvPercentage.SelectedRows[0].Cells[2].Value.Equals("Active"))
                {
                    Validator.AlertDanger("Unable to delete this price unit because status is active!");
                    return;
                }
                else
                {
                    if (Validator.DeleteConfirmation())
                    {
                        DBContext.GetContext().Query("unitPrice").Where("id", dgvPercentage.SelectedRows[0].Cells[0].Value).Delete();
                    }
                    displayData();
                }
            }
        }
    }
}
