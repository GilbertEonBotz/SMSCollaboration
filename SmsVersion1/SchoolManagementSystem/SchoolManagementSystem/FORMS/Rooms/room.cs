using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EonBotzLibrary;
using SchoolManagementSystem.UITools;
using SqlKata.Execution;



namespace SchoolManagementSystem
{
    public partial class room : Form
    {
        public room()
        {
            InitializeComponent();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            displayData();
            var myfrm = new AddRoom(this, idd);
            FormFade.FadeForm(this, myfrm);

        }

        private void room_Load(object sender, EventArgs e)
        {
            displayData();
        }

        public void displayData()
        {
            dgvRooms.Rows.Clear();
            var rooms = DBContext.GetContext().Query("rooms").Get();

            foreach (var room in rooms)
            {
                dgvRooms.Rows.Add(room.roomId, room.name, room.description);
            }
        }

        private void dgvRooms_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvRooms_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Focus);
            e.Handled = true;
        }

        string idd;
        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvRooms.Columns[e.ColumnIndex].Name;

            if (colName.Equals("edit"))
            {
                int id = Convert.ToInt32(dgvRooms.Rows[dgvRooms.CurrentRow.Index].Cells[0].Value);
                idd = id.ToString();
                var myfrm = new AddRoom(this, idd);
                var rooms = DBContext.GetContext().Query("rooms").Where("roomId", id).First();

                myfrm.txtDescription.Text = rooms.description;
                myfrm.txtName.Text = rooms.name;
                myfrm.btnAddRoom.Text = "Update";
                myfrm.ShowDialog();
            }
            else if (colName.Equals("delete"))
            {
                if (Validator.DeleteConfirmation())
                {
                    DBContext.GetContext().Query("rooms").Where("roomId", dgvRooms.SelectedRows[0].Cells[0].Value.ToString()).Delete();
                    displayData();
                }
            }
        }

        private void textboxWatermark1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxWatermark1.Text))
            {
                displayData();
            }
            else if (textboxWatermark1.Text.Equals("Search"))
            {
                displayData();
            }
            else
            {
                var values = DBContext.GetContext().Query("rooms").WhereLike("roomId", $"{textboxWatermark1.Text}")
              .OrWhereLike("name", $"%{textboxWatermark1.Text}%")
              .Get();

                dgvRooms.Rows.Clear();
                foreach (var value in values)
                {
                    dgvRooms.Rows.Add(value.roomId, value.name, value.description);
                }
            }
        }
    }
}
