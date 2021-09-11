using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.UITools
{
    public partial class TextboxWatermark : TextBox
    {
        public TextboxWatermark()
        {
            InitializeComponent();
        }

        private string _watermarktext;
        


        public string WatermarkText
        {
            get { return _watermarktext; }
            set
            {
                _watermarktext = value;
                GetSetWatermark();
            }
        }
       

        private void GetSetWatermark()
        {
            if ((this.Text == WatermarkText) || (this.Text == string.Empty))
            {
                this.ForeColor = Color.LightGray;
                this.Text = WatermarkText;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }

        private void TextboxWatermark_Enter(object sender, EventArgs e)
        {
            if((this.Text == WatermarkText) ||(this.Text == string.Empty)){
                this.Text = string.Empty;
                this.ForeColor = Color.Black;
            }
        }

        private void TextboxWatermark_Leave(object sender, EventArgs e)
        {
            GetSetWatermark();
        }
    }
}
