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
    public partial class billing : Form
    {
        string individualSubj;
        string studentid = "45";
        Decimal wew;
        string TOTAL;
        public billing()
        {
            InitializeComponent();
        }

        private void billing_Load(object sender, EventArgs e)
        {
            StudentTuition stud = new StudentTuition();
            dgv.Rows.Clear();

            var values = DBContext.GetContext().Query("studentSched").Where("studentId", studentid).First();
            string str = values.schedId;

            var words = str.Split(' ');

            for (int i = 1; i < words.Length; i++)
            {
                individualSubj = words[i];
                stud.indsub = individualSubj;



                stud.viewSubj();
                foreach (DataRow Drow in stud.dt.Rows)
                {

                    wew += Convert.ToDecimal(Drow["Amount"].ToString());
                }
            }
            TOTAL = wew.ToString("N2");
            MessageBox.Show(TOTAL);
        }
    }
}


