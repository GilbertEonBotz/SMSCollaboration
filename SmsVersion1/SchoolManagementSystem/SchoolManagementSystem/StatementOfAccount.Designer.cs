
namespace SchoolManagementSystem
{
    partial class StatementOfAccount
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.EnrolledSubjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feeBillingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuitionBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.examDivisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discountedPriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.YearTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SchedulingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EnrolledSubjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeBillingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitionBillingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.examDivisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountedPriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearTypeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EnrolledSubjectsBindingSource
            // 
            this.EnrolledSubjectsBindingSource.DataSource = typeof(SchoolManagementSystem.EnrolledSubjects);
            // 
            // feeBillingsBindingSource
            // 
            this.feeBillingsBindingSource.DataSource = typeof(SchoolManagementSystem.feeBillings);
            // 
            // tuitionBillingBindingSource
            // 
            this.tuitionBillingBindingSource.DataSource = typeof(SchoolManagementSystem.tuitionBilling);
            // 
            // examDivisionBindingSource
            // 
            this.examDivisionBindingSource.DataSource = typeof(SchoolManagementSystem.examDivision);
            // 
            // paymentDetailsBindingSource
            // 
            this.paymentDetailsBindingSource.DataSource = typeof(SchoolManagementSystem.paymentDetails);
            // 
            // discountedPriceBindingSource
            // 
            this.discountedPriceBindingSource.DataSource = typeof(SchoolManagementSystem.discountedPrice);
            // 
            // YearTypeBindingSource
            // 
            this.YearTypeBindingSource.DataSource = typeof(SchoolManagementSystem.YearType);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(7, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 58);
            this.panel1.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(377, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 24);
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
            this.btnExit.IconSize = 25;
            this.btnExit.Location = new System.Drawing.Point(877, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(44, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.EnrolledSubjectsBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.feeBillingsBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.tuitionBillingBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.examDivisionBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.paymentDetailsBindingSource;
            reportDataSource6.Name = "DataSet6";
            reportDataSource6.Value = this.discountedPriceBindingSource;
            reportDataSource7.Name = "DataSet7";
            reportDataSource7.Value = this.YearTypeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SchoolManagementSystem.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 64);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(923, 498);
            this.reportViewer1.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(7, 603);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(926, 7);
            this.panel4.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 610);
            this.panel2.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(933, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(7, 610);
            this.panel3.TabIndex = 39;
            // 
            // StatementOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 610);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatementOfAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatementOfAccount";
            this.Load += new System.EventHandler(this.StatementOfAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EnrolledSubjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeBillingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuitionBillingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.examDivisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountedPriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearTypeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnExit;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource SchedulingsBindingSource;
        private System.Windows.Forms.BindingSource EnrolledSubjectsBindingSource;
        private System.Windows.Forms.BindingSource feeBillingsBindingSource;
        private System.Windows.Forms.BindingSource tuitionBillingBindingSource;
        private System.Windows.Forms.BindingSource examDivisionBindingSource;
        private System.Windows.Forms.BindingSource paymentDetailsBindingSource;
        private System.Windows.Forms.BindingSource discountedPriceBindingSource;
        private System.Windows.Forms.BindingSource YearTypeBindingSource;
    }
}