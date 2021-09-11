
namespace SchoolManagementSystem.FORMS.MainForm
{
    partial class login_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            this.drp_logo = new System.Windows.Forms.PictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.login_button = new FontAwesome.Sharp.IconButton();
            this.password_txt_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.password_txt_box = new System.Windows.Forms.TextBox();
            this.username_txt_box = new System.Windows.Forms.TextBox();
            this.password_panel = new System.Windows.Forms.Panel();
            this.username_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drp_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.username_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // drp_logo
            // 
            this.drp_logo.Image = ((System.Drawing.Image)(resources.GetObject("drp_logo.Image")));
            this.drp_logo.Location = new System.Drawing.Point(83, 40);
            this.drp_logo.Name = "drp_logo";
            this.drp_logo.Size = new System.Drawing.Size(127, 111);
            this.drp_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drp_logo.TabIndex = 0;
            this.drp_logo.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(89, 188);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(24, 22);
            this.iconPictureBox2.TabIndex = 20;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 22;
            this.iconPictureBox1.Location = new System.Drawing.Point(90, 286);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(24, 22);
            this.iconPictureBox1.TabIndex = 19;
            this.iconPictureBox1.TabStop = false;
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.IconChar = FontAwesome.Sharp.IconChar.None;
            this.login_button.IconColor = System.Drawing.Color.Black;
            this.login_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.login_button.Location = new System.Drawing.Point(102, 374);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(97, 25);
            this.login_button.TabIndex = 18;
            this.login_button.Text = "Log In";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // password_txt_label
            // 
            this.password_txt_label.AutoSize = true;
            this.password_txt_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.password_txt_label.Location = new System.Drawing.Point(116, 287);
            this.password_txt_label.Name = "password_txt_label";
            this.password_txt_label.Size = new System.Drawing.Size(59, 15);
            this.password_txt_label.TabIndex = 17;
            this.password_txt_label.Text = "Password";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.username_label.Location = new System.Drawing.Point(114, 189);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(64, 15);
            this.username_label.TabIndex = 16;
            this.username_label.Text = "Username";
            // 
            // password_txt_box
            // 
            this.password_txt_box.BackColor = System.Drawing.Color.White;
            this.password_txt_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_txt_box.Location = new System.Drawing.Point(46, 318);
            this.password_txt_box.Name = "password_txt_box";
            this.password_txt_box.PasswordChar = '*';
            this.password_txt_box.Size = new System.Drawing.Size(200, 16);
            this.password_txt_box.TabIndex = 15;
            this.password_txt_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // username_txt_box
            // 
            this.username_txt_box.BackColor = System.Drawing.Color.White;
            this.username_txt_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_txt_box.ForeColor = System.Drawing.SystemColors.InfoText;
            this.username_txt_box.Location = new System.Drawing.Point(46, 220);
            this.username_txt_box.Name = "username_txt_box";
            this.username_txt_box.Size = new System.Drawing.Size(200, 16);
            this.username_txt_box.TabIndex = 14;
            this.username_txt_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // password_panel
            // 
            this.password_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password_panel.Location = new System.Drawing.Point(46, 337);
            this.password_panel.Name = "password_panel";
            this.password_panel.Size = new System.Drawing.Size(200, 1);
            this.password_panel.TabIndex = 13;
            // 
            // username_panel
            // 
            this.username_panel.BackColor = System.Drawing.Color.Black;
            this.username_panel.Controls.Add(this.panel2);
            this.username_panel.Controls.Add(this.panel1);
            this.username_panel.Location = new System.Drawing.Point(46, 240);
            this.username_panel.Name = "username_panel";
            this.username_panel.Size = new System.Drawing.Size(200, 1);
            this.username_panel.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 3;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(66)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 15;
            this.iconPictureBox3.Location = new System.Drawing.Point(265, 12);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(15, 15);
            this.iconPictureBox3.TabIndex = 21;
            this.iconPictureBox3.TabStop = false;
            this.iconPictureBox3.Click += new System.EventHandler(this.iconPictureBox3_Click);
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(292, 450);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_txt_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.password_txt_box);
            this.Controls.Add(this.username_txt_box);
            this.Controls.Add(this.password_panel);
            this.Controls.Add(this.username_panel);
            this.Controls.Add(this.drp_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login_form";
            ((System.ComponentModel.ISupportInitialize)(this.drp_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.username_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drp_logo;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton login_button;
        private System.Windows.Forms.Label password_txt_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox password_txt_box;
        private System.Windows.Forms.TextBox username_txt_box;
        private System.Windows.Forms.Panel password_panel;
        private System.Windows.Forms.Panel username_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
    }
}