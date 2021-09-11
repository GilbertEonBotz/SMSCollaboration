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
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem.FORMS.Scheduling
{
    public partial class voidNotification : Form
    {
        Payment getFunction; MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection conn;
        Connection connect = new Connection();
        public voidNotification(Payment getFunction)
        {
            InitializeComponent();
            this.getFunction = getFunction;
        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {

        }

        private void voidNotification_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textboxWatermark1.Text.Equals("admin"))
            {
                getFunction.comboBox2.Items.Clear();
                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand("update payment set status ='void' where paymentid = '" + getFunction.dgv.SelectedRows[0].Cells[0].Value + "'", conn);
                cmd.ExecuteNonQuery();
                Validator.AlertSuccess("Void");
                getFunction.lbldownpayment.Text = "";
                getFunction.lblpre.Text = "0.00";
                getFunction.lblsemi.Text = "0.00";
                getFunction.lblfin.Text = "0.00";
                getFunction.lblmid.Text = "0.00";
                getFunction.comboBox2.Items.Add("DOWNPAYMENT");
                getFunction.comboBox2.Items.Add("PRELIM");
                getFunction.comboBox2.Items.Add("MIDTERM");
                getFunction.comboBox2.Items.Add("SEMI-FINAL");
                getFunction.comboBox2.Items.Add("FINAL");
                getFunction.printShow();
                getFunction.showw();
                conn.Close();

                foreach (DataGridViewRow row in getFunction.dgv.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "0")
                    {
                        foreach (var cell in row.Cells)
                        {
                            DataGridViewLinkCell linkCell = cell as DataGridViewLinkCell;

                            if (linkCell != null)
                            {
                                linkCell.UseColumnTextForLinkValue = false;
                            }
                        }
                    }
                }
                this.Close();
            }
            else
            {
                Validator.AlertDanger("Secret key is incorrect!");
            }
            
        }

        private void voidNotification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }
    }
}
