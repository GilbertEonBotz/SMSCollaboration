
namespace SchoolManagementSystem
{
    partial class AddSubject
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.lstPrereq = new System.Windows.Forms.ListBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCourseCode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TotalPrice = new System.Windows.Forms.Label();
            this.txtLabprice = new System.Windows.Forms.TextBox();
            this.txtLecPrice = new System.Windows.Forms.TextBox();
            this.txtTotalUnits = new System.Windows.Forms.TextBox();
            this.cmbPreReq = new System.Windows.Forms.ComboBox();
            this.txtLab = new System.Windows.Forms.TextBox();
            this.txtLec = new System.Windows.Forms.TextBox();
            this.txtDescriptiveTitle = new System.Windows.Forms.TextBox();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblIDD = new System.Windows.Forms.Label();
            this.btnAdmissionForm = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLectotal = new System.Windows.Forms.Label();
            this.lblabTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddSubjects = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lstPrereq);
            this.panel6.Controls.Add(this.cmbCourse);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.cmbCourseCode);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.TotalPrice);
            this.panel6.Controls.Add(this.txtLabprice);
            this.panel6.Controls.Add(this.txtLecPrice);
            this.panel6.Controls.Add(this.txtTotalUnits);
            this.panel6.Controls.Add(this.cmbPreReq);
            this.panel6.Controls.Add(this.txtLab);
            this.panel6.Controls.Add(this.txtLec);
            this.panel6.Controls.Add(this.txtDescriptiveTitle);
            this.panel6.Controls.Add(this.txtSubjectCode);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.lblLectotal);
            this.panel6.Controls.Add(this.lblabTotal);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.panel6.Location = new System.Drawing.Point(6, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(439, 474);
            this.panel6.TabIndex = 10;
            // 
            // lstPrereq
            // 
            this.lstPrereq.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPrereq.FormattingEnabled = true;
            this.lstPrereq.ItemHeight = 20;
            this.lstPrereq.Location = new System.Drawing.Point(104, 399);
            this.lstPrereq.Name = "lstPrereq";
            this.lstPrereq.Size = new System.Drawing.Size(316, 64);
            this.lstPrereq.TabIndex = 23;
            this.lstPrereq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPrereq_MouseDoubleClick);
            // 
            // cmbCourse
            // 
            this.cmbCourse.BackColor = System.Drawing.Color.White;
            this.cmbCourse.DropDownWidth = 200;
            this.cmbCourse.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.ItemHeight = 20;
            this.cmbCourse.Location = new System.Drawing.Point(104, 58);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(316, 28);
            this.cmbCourse.TabIndex = 1;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            this.cmbCourse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCourse_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "COURSE";
            // 
            // cmbCourseCode
            // 
            this.cmbCourseCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCourseCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCourseCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourseCode.FormattingEnabled = true;
            this.cmbCourseCode.Location = new System.Drawing.Point(104, 90);
            this.cmbCourseCode.Name = "cmbCourseCode";
            this.cmbCourseCode.Size = new System.Drawing.Size(316, 28);
            this.cmbCourseCode.TabIndex = 2;
            this.cmbCourseCode.SelectedIndexChanged += new System.EventHandler(this.cmbCourseCode_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "COURSE CODE";
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSize = true;
            this.TotalPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPrice.Location = new System.Drawing.Point(335, 470);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(85, 21);
            this.TotalPrice.TabIndex = 14;
            this.TotalPrice.Text = "total price";
            this.TotalPrice.Visible = false;
            // 
            // txtLabprice
            // 
            this.txtLabprice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabprice.Location = new System.Drawing.Point(302, 302);
            this.txtLabprice.Name = "txtLabprice";
            this.txtLabprice.ReadOnly = true;
            this.txtLabprice.Size = new System.Drawing.Size(118, 27);
            this.txtLabprice.TabIndex = 8;
            this.txtLabprice.TabStop = false;
            this.txtLabprice.Visible = false;
            this.txtLabprice.TextChanged += new System.EventHandler(this.txtLabprice_TextChanged);
            this.txtLabprice.Enter += new System.EventHandler(this.txtLabprice_Enter);
            this.txtLabprice.Leave += new System.EventHandler(this.txtLabprice_Leave);
            // 
            // txtLecPrice
            // 
            this.txtLecPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLecPrice.Location = new System.Drawing.Point(302, 269);
            this.txtLecPrice.Name = "txtLecPrice";
            this.txtLecPrice.ReadOnly = true;
            this.txtLecPrice.Size = new System.Drawing.Size(118, 27);
            this.txtLecPrice.TabIndex = 6;
            this.txtLecPrice.TabStop = false;
            this.txtLecPrice.Visible = false;
            this.txtLecPrice.TextChanged += new System.EventHandler(this.txtLecPrice_TextChanged);
            this.txtLecPrice.Enter += new System.EventHandler(this.txtLecPrice_Enter);
            this.txtLecPrice.Leave += new System.EventHandler(this.txtLecPrice_Leave);
            // 
            // txtTotalUnits
            // 
            this.txtTotalUnits.Enabled = false;
            this.txtTotalUnits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalUnits.Location = new System.Drawing.Point(105, 335);
            this.txtTotalUnits.Name = "txtTotalUnits";
            this.txtTotalUnits.Size = new System.Drawing.Size(315, 27);
            this.txtTotalUnits.TabIndex = 9;
            this.txtTotalUnits.TextChanged += new System.EventHandler(this.txtTotalUnits_TextChanged);
            // 
            // cmbPreReq
            // 
            this.cmbPreReq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPreReq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPreReq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPreReq.FormattingEnabled = true;
            this.cmbPreReq.Location = new System.Drawing.Point(105, 368);
            this.cmbPreReq.Name = "cmbPreReq";
            this.cmbPreReq.Size = new System.Drawing.Size(315, 25);
            this.cmbPreReq.TabIndex = 10;
            this.cmbPreReq.SelectedIndexChanged += new System.EventHandler(this.cmbPreReq_SelectedIndexChanged);
            // 
            // txtLab
            // 
            this.txtLab.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLab.Location = new System.Drawing.Point(105, 302);
            this.txtLab.Name = "txtLab";
            this.txtLab.Size = new System.Drawing.Size(315, 27);
            this.txtLab.TabIndex = 7;
            this.txtLab.Text = "0";
            this.txtLab.TextChanged += new System.EventHandler(this.txtLab_TextChanged);
            this.txtLab.Enter += new System.EventHandler(this.txtLab_Enter);
            this.txtLab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLab_KeyPress);
            this.txtLab.Leave += new System.EventHandler(this.txtLab_Leave);
            // 
            // txtLec
            // 
            this.txtLec.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLec.Location = new System.Drawing.Point(105, 269);
            this.txtLec.Name = "txtLec";
            this.txtLec.Size = new System.Drawing.Size(315, 27);
            this.txtLec.TabIndex = 5;
            this.txtLec.Text = "0";
            this.txtLec.TextChanged += new System.EventHandler(this.txtLec_TextChanged);
            this.txtLec.Enter += new System.EventHandler(this.txtLec_Enter);
            this.txtLec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLec_KeyPress);
            this.txtLec.Leave += new System.EventHandler(this.txtLec_Leave);
            // 
            // txtDescriptiveTitle
            // 
            this.txtDescriptiveTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriptiveTitle.Location = new System.Drawing.Point(105, 195);
            this.txtDescriptiveTitle.Multiline = true;
            this.txtDescriptiveTitle.Name = "txtDescriptiveTitle";
            this.txtDescriptiveTitle.Size = new System.Drawing.Size(315, 68);
            this.txtDescriptiveTitle.TabIndex = 4;
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.Location = new System.Drawing.Point(105, 121);
            this.txtSubjectCode.Multiline = true;
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(315, 68);
            this.txtSubjectCode.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "PRE - REQ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "TOTAL UNITS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "LAB UNITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "LECTURE UNITS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "SUBJECT TITLE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "SUBJECT CODE";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 35);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(435, 1);
            this.panel8.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel7.Controls.Add(this.lblIDD);
            this.panel7.Controls.Add(this.btnAdmissionForm);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(435, 35);
            this.panel7.TabIndex = 0;
            // 
            // lblIDD
            // 
            this.lblIDD.AutoSize = true;
            this.lblIDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIDD.Location = new System.Drawing.Point(232, 8);
            this.lblIDD.Name = "lblIDD";
            this.lblIDD.Size = new System.Drawing.Size(105, 20);
            this.lblIDD.TabIndex = 30;
            this.lblIDD.Text = "Subject Code";
            this.lblIDD.Visible = false;
            // 
            // btnAdmissionForm
            // 
            this.btnAdmissionForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmissionForm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdmissionForm.FlatAppearance.BorderSize = 0;
            this.btnAdmissionForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdmissionForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAdmissionForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmissionForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmissionForm.ForeColor = System.Drawing.Color.DimGray;
            this.btnAdmissionForm.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdmissionForm.IconColor = System.Drawing.Color.DimGray;
            this.btnAdmissionForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdmissionForm.IconSize = 20;
            this.btnAdmissionForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmissionForm.Location = new System.Drawing.Point(0, 3);
            this.btnAdmissionForm.Name = "btnAdmissionForm";
            this.btnAdmissionForm.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnAdmissionForm.Size = new System.Drawing.Size(203, 32);
            this.btnAdmissionForm.TabIndex = 5;
            this.btnAdmissionForm.TabStop = false;
            this.btnAdmissionForm.Text = "Subject Form";
            this.btnAdmissionForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmissionForm.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(230, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "LAB PRICE";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "LEC PRICE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Visible = false;
            // 
            // lblLectotal
            // 
            this.lblLectotal.AutoSize = true;
            this.lblLectotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLectotal.ForeColor = System.Drawing.Color.DarkGray;
            this.lblLectotal.Location = new System.Drawing.Point(419, 273);
            this.lblLectotal.Name = "lblLectotal";
            this.lblLectotal.Size = new System.Drawing.Size(18, 20);
            this.lblLectotal.TabIndex = 17;
            this.lblLectotal.Text = "0";
            this.lblLectotal.Visible = false;
            // 
            // lblabTotal
            // 
            this.lblabTotal.AutoSize = true;
            this.lblabTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblabTotal.ForeColor = System.Drawing.Color.DarkGray;
            this.lblabTotal.Location = new System.Drawing.Point(419, 305);
            this.lblabTotal.Name = "lblabTotal";
            this.lblabTotal.Size = new System.Drawing.Size(18, 20);
            this.lblabTotal.TabIndex = 16;
            this.lblabTotal.Text = "0";
            this.lblabTotal.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(274, 467);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 25);
            this.label11.TabIndex = 20;
            this.label11.Text = "Total:";
            this.label11.Visible = false;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnAddSubjects.FlatAppearance.BorderSize = 0;
            this.btnAddSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubjects.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAddSubjects.ForeColor = System.Drawing.Color.White;
            this.btnAddSubjects.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAddSubjects.IconColor = System.Drawing.Color.White;
            this.btnAddSubjects.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddSubjects.IconSize = 30;
            this.btnAddSubjects.Location = new System.Drawing.Point(262, 522);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.Size = new System.Drawing.Size(80, 28);
            this.btnAddSubjects.TabIndex = 11;
            this.btnAddSubjects.Text = "Save";
            this.btnAddSubjects.UseVisualStyleBackColor = false;
            this.btnAddSubjects.Click += new System.EventHandler(this.btnAddSubjects_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(6, 554);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(439, 6);
            this.panel4.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(445, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(6, 518);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 518);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 42);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(97, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "School Management System";
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(414, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.TabStop = false;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Tomato;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(348, 522);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(80, 28);
            this.iconButton1.TabIndex = 12;
            this.iconButton1.Text = "Cancel";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // AddSubject
            // 
            this.AcceptButton = this.btnAddSubjects;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(451, 560);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAddSubjects);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(530, 50);
            this.Name = "AddSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddSubject";
            this.Load += new System.EventHandler(this.AddSubject_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSubject_KeyDown);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        public FontAwesome.Sharp.IconButton btnAddSubjects;
        public System.Windows.Forms.TextBox txtLab;
        public System.Windows.Forms.TextBox txtLec;
        public System.Windows.Forms.TextBox txtDescriptiveTitle;
        public System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton btnAdmissionForm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnExit;
        public System.Windows.Forms.ComboBox cmbPreReq;
        public System.Windows.Forms.TextBox txtTotalUnits;
        public System.Windows.Forms.Label lblIDD;
        public FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label lblLectotal;
        private System.Windows.Forms.Label lblabTotal;
        private System.Windows.Forms.Label TotalPrice;
        public System.Windows.Forms.TextBox txtLabprice;
        public System.Windows.Forms.TextBox txtLecPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cmbCourseCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ListBox lstPrereq;
    }
}