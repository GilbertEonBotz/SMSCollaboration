using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SchoolManagementSystem
{
    public partial class addReport : Form
    {

        public addReport()
        {
            InitializeComponent();

        }
        ReportDataSource rs = new ReportDataSource();
        private void button1_Click(object sender, EventArgs e)
        {
            List<Studentss> lst = new List<Studentss>();
            lst.Clear();
            Form2 frm = new Form2();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                lst.Add(new Studentss
                {
                    name = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    lastname = dataGridView1.Rows[i].Cells[1].Value.ToString()
                });

                rs.Name = "DataSet1";
                rs.Value = lst;
               
                frm.reportViewer1.LocalReport.DataSources.Clear();
                frm.reportViewer1.LocalReport.DataSources.Add(rs);
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report1.rdlc";

            }
            frm.ShowDialog();

        }



        private void addReport_Load(object sender, EventArgs e)
        {

        }

    }

    public class Studentss
    {
        public string name { get; set; }
        public string lastname { get; set; }
    }
}