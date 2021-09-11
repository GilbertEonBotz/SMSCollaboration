using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EonBotzLibrary;
using MySql.Data.MySqlClient;
namespace SchoolManagementSystem
{
    public partial class reports : Form
    {
        double amount;
        double total;
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public reports()
        {
            InitializeComponent();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.Series[0]["ColumnLabelStyle"] = "inside";

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand(" SELECT sum(total),date,TIMESTAMPDIFF(day,date,CURDATE())   FROM Billing    where TIMESTAMPDIFF(week,date,CURDATE())=0 group by date", conn);
            dr = cmd.ExecuteReader();
            int counter = 0;
    
            while (dr.Read())
            {
                //amount +=Convert.ToDouble(dr[0]);



                //decimal value = Convert.ToDecimal(dr[0].ToString());
                ////MessageBox.Show(value.ToString());

                //DateTime dt = DateTime.Parse(dr[1].ToString());
                //DayOfWeek day = dt.DayOfWeek;
                //chart1.Series["Series2"].Points.Add(Convert.ToDouble(value));
                //chart1.Series["Series2"].Points[counter].Color = Color.SlateBlue;
                //chart1.Series["Series2"].Points[counter].AxisLabel = day.ToString();
                ////chart1.Series["Series2"].Points[counter].LegendText = value.ToString();
                //chart1.Series["Series2"].IsValueShownAsLabel = true;
                //counter++;
                decimal value = Convert.ToDecimal(dr[0].ToString());
                DateTime birthDate = DateTime.Parse(dr[1].ToString());

                var year = birthDate.Year;
                var month = birthDate.Month;
                var days = birthDate.Day;





                DateTime dt = DateTime.Parse(dr[1].ToString());


                chart1.Series["Series2"].Points.Add(Convert.ToDouble(value));
                chart1.Series["Series2"].Points[counter].Color = Color.Blue;
                //   chart1.Series["Series2"].YValueMembers = quantity;
                chart1.Series["Series2"].Points[counter].AxisLabel = days.ToString();
                chart1.Series["Series2"].Points[counter].LegendText = month.ToString();
                chart1.Series["Series2"].IsValueShownAsLabel = true;


                counter++;
            }


            total = amount;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
