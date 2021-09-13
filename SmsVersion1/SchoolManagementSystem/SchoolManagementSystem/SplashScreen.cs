using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
    

namespace SchoolManagementSystem
{
    public partial class SplashScreen : Form
    {
        BackgroundWorker worker;
        public SplashScreen()
        {
            
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            //worker.WorkerSupportsCancellation = true;

            //worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //worker.ProgressChanged +=
            //            new ProgressChangedEventHandler(worker_ProgressChanged);
            //worker.RunWorkerCompleted +=
            //           new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(100);
            if (progressBar1.Value == 30)
            {
                lblLoading.Text = "Loading Students.......";
            }
            if (progressBar1.Value == 50)
            {
                lblLoading.Text = "Loading Teachers.......";
            }
            if (progressBar1.Value == 70)
            {
                lblLoading.Text = "Loading Databases.......";
            }
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                finalDashboard fd = new finalDashboard();
                fd.btnAdmin.Text = label2.Text;
                fd.Show();
                this.Hide();
                lblLoading.Text = "Testing......";
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
