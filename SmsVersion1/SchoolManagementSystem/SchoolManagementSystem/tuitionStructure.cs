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
    public partial class tuitionStructure : Form
    {
        tuitionfee tuit = new tuitionfee();
        int catid;
        public tuitionStructure(string val)
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rooms = DBContext.GetContext().Query("tuitioncategory").Where("category", comboBox1.Text).First();

            catid = rooms.tuitionCatID;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tuitionStructure_Load(object sender, EventArgs e)
        {
            tuit.select();
            comboBox1.DataSource = tuit.datafill;
            comboBox2.DataSource = tuit.datafillsubj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBContext.GetContext().Query("tuition").Insert(new
            {
                tuitionCatID = catid,
                subjectCode = comboBox2.Text
            });
            MessageBox.Show("success");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
