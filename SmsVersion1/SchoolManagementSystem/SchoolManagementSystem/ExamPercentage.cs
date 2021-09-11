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
using SchoolManagementSystem.UITools;
using SqlKata.Execution;

namespace SchoolManagementSystem
{
    public partial class ExamPercentage : Form
    {
        public ExamPercentage()
        {
            InitializeComponent();
        }

        private void ExamPercentage_Load(object sender, EventArgs e)
        {
            displayData();
        }
        public void displayData()
        {
            dgvPercentage.Rows.Clear();

            var values = DBContext.GetContext().Query("percentage").Get();
            foreach (var value in values)
            {
                dgvPercentage.Rows.Add(value.id, $"{strDisplayPercentage(value.prelim).ToString("N0")} %", $"{strDisplayPercentage(value.midterm).ToString("N0")} %"
                    , $"{strDisplayPercentage(value.semiFinals).ToString("N0")} %", $"{strDisplayPercentage(value.finals).ToString("N0")} %", value.downpayment, value.status);
            }

            foreach (DataGridViewRow row in dgvPercentage.Rows)
            {
                if (Convert.ToString(row.Cells[7].Value) == "Active")
                {
                    row.Cells[7].Style.ForeColor = Color.Blue;
                    row.Cells[7].Style.SelectionForeColor = Color.Blue;
                }
                else
                {
                    row.Cells[7].Style.ForeColor = Color.Red;
                    row.Cells[7].Style.SelectionForeColor = Color.Red;
                }
            }
        }

        public decimal strDisplayPercentage(decimal value)
        {
            return value * 100;
        }


        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var myfrm = new AddExamPercentage(this,idd);
            FormFade.FadeForm(this, myfrm);
        }

        string idd;
        private void dgvPercentage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvPercentage.Columns[e.ColumnIndex].Name;
            if (colName.Equals("activate"))
            {
                if (dgvPercentage.SelectedRows[0].Cells[7].Value.Equals("Active"))
                {
                    Validator.AlertDanger("This exam percentage is already activated");
                    return;
                }
                else
                {
                    if (Validator.openPercentage())
                    {
                        DBContext.GetContext().Query("percentage").Update(new
                        {
                            status = "Inactive",
                        });

                        DBContext.GetContext().Query("percentage").Where("id", dgvPercentage.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Active",
                        });
                        displayData();
                    }
                }
            }
            else if (colName.Equals("delete"))
            {
                if (dgvPercentage.SelectedRows[0].Cells[7].Value.Equals("Active"))
                {
                    Validator.AlertDanger("Unable to delete this exam percentage because status is active!");
                    return;
                }
                else
                {
                    if (Validator.deletePercentage())
                    {
                        DBContext.GetContext().Query("percentage").Where("id", dgvPercentage.SelectedRows[0].Cells[0].Value).Delete();
                        displayData();
                    }
                }
            }
            else if (colName.Equals("edit"))
            {
                idd = dgvPercentage.SelectedRows[0].Cells[0].Value.ToString();
                var myfrm = new AddExamPercentage(this, idd);
                var value = DBContext.GetContext().Query("percentage").Where("id", dgvPercentage.SelectedRows[0].Cells[0].Value).First();

                
                myfrm.txtDownpayment.Text = value.downpayment.ToString();
                myfrm.txtFullpayment.Text = value.downpayment.ToString();
                myfrm.txtPrelim.Text = value.prelim.ToString();
                myfrm.txtMidterm.Text =  value.midterm.ToString();
                myfrm.txtSemi.Text = value.semiFinals.ToString();
                myfrm.txtFinal.Text = value.finals.ToString();
                myfrm.btnSave.Text = "Update";
                myfrm.ShowDialog();
            }
            //string colName = dgvPercentage.Columns[e.ColumnIndex].Name;

            //if (colName.Equals("edit"))
            //{
            //    if (dgvPercentage.SelectedRows[0].Cells[5].Value.ToString().Equals(""))
            //    {
            //        if (Validator.actYear())
            //        {
            //            DBContext.GetContext().Query("percentage").Update(new
            //            {
            //                status = "Activate"
            //            });

            //            int id = Convert.ToInt32(dgvPercentage.SelectedRows[0].Cells[0].Value);
            //            DBContext.GetContext().Query("percentage").Where("id", id).Update(new
            //            {
            //                status = "Deactivate"
            //            });
            //            displayData();
            //        }
            //    }

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPercentage_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
            e.Handled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}