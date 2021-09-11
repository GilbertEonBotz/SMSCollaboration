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
    public partial class AddRoom : Form
    {
        room reloadDatagrid;
        string idd;
        public AddRoom(room reloadDatagrid, string idd)
        {
            InitializeComponent();
            this.reloadDatagrid = reloadDatagrid;
            this.idd = idd;

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            TextBox[] inputs = { txtDescription };

            if (btnAddRoom.Text.Equals("Update"))
            {
                var values = DBContext.GetContext().Query("rooms").Get();
                if (Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    foreach (var value in values)
                    {
                        if (value.roomId.Equals(Convert.ToInt32(idd)) && value.name.Equals(txtName.Text))
                        {
                            DBContext.GetContext().Query("rooms").Where("roomId", idd).Update(new
                            {
                                name = txtName.Text.Trim().ToUpper(),
                                description = txtDescription.Text.Trim()
                            });
                            reloadDatagrid.displayData();
                            this.Close();
                            return;
                        }
                        else if (value.roomId != Convert.ToInt32(idd) && value.name.Equals(txtName.Text))
                        {
                            Validator.AlertDanger("Room name already existed");
                            return;
                        }
                    }
                }

                DBContext.GetContext().Query("rooms").Where("roomId", idd).Update(new
                {
                    name = txtName.Text.Trim().ToUpper(),
                    description = txtDescription.Text.Trim()
                });
                reloadDatagrid.displayData();
                this.Close();
            }
            else if (btnAddRoom.Text.Equals("Save"))
            {
                if (Validator.isEmpty(inputs))
                {
                    try
                    {
                        DBContext.GetContext().Query("rooms").Where("name", txtName.Text).First();
                        Validator.AlertDanger("Room is already existed");
                    }
                    catch (Exception)
                    {
                        DBContext.GetContext().Query("rooms").Insert(new
                        {
                            name = txtName.Text.Trim().ToUpper(),
                            description = txtDescription.Text.Trim(),
                        });
                        Validator.AlertSuccess("Room Added");
                        txtDescription.Text = "";
                        txtName.Text = "";
                        reloadDatagrid.displayData();

                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
