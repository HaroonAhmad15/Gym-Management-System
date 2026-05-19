namespace Gym_Management_System
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAllMembers = new System.Windows.Forms.Button();
            this.btnActiveMembers = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnExpiring = new System.Windows.Forms.Button();
            this.btnTrainers = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.btnAllMembers);
            this.pnlButtons.Controls.Add(this.btnActiveMembers);
            this.pnlButtons.Controls.Add(this.btnPayments);
            this.pnlButtons.Controls.Add(this.btnAttendance);
            this.pnlButtons.Controls.Add(this.btnExpiring);
            this.pnlButtons.Controls.Add(this.btnTrainers);
            this.pnlButtons.Location = new System.Drawing.Point(10, 70);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1030, 70);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnAllMembers
            // 
            this.btnAllMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAllMembers.FlatAppearance.BorderSize = 0;
            this.btnAllMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAllMembers.ForeColor = System.Drawing.Color.White;
            this.btnAllMembers.Location = new System.Drawing.Point(10, 15);
            this.btnAllMembers.Name = "btnAllMembers";
            this.btnAllMembers.Size = new System.Drawing.Size(155, 40);
            this.btnAllMembers.TabIndex = 0;
            this.btnAllMembers.Text = "All Members";
            this.btnAllMembers.UseVisualStyleBackColor = false;
            this.btnAllMembers.Click += new System.EventHandler(this.btnAllMembers_Click);
            // 
            // btnActiveMembers
            // 
            this.btnActiveMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnActiveMembers.FlatAppearance.BorderSize = 0;
            this.btnActiveMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiveMembers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActiveMembers.ForeColor = System.Drawing.Color.White;
            this.btnActiveMembers.Location = new System.Drawing.Point(175, 15);
            this.btnActiveMembers.Name = "btnActiveMembers";
            this.btnActiveMembers.Size = new System.Drawing.Size(155, 40);
            this.btnActiveMembers.TabIndex = 1;
            this.btnActiveMembers.Text = "Active Members";
            this.btnActiveMembers.UseVisualStyleBackColor = false;
            this.btnActiveMembers.Click += new System.EventHandler(this.btnActiveMembers_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(340, 15);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(155, 40);
            this.btnPayments.TabIndex = 2;
            this.btnPayments.Text = "Payment History";
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(505, 15);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(155, 40);
            this.btnAttendance.TabIndex = 3;
            this.btnAttendance.Text = "Attendance Report";
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnExpiring
            // 
            this.btnExpiring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExpiring.FlatAppearance.BorderSize = 0;
            this.btnExpiring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpiring.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExpiring.ForeColor = System.Drawing.Color.White;
            this.btnExpiring.Location = new System.Drawing.Point(670, 15);
            this.btnExpiring.Name = "btnExpiring";
            this.btnExpiring.Size = new System.Drawing.Size(155, 40);
            this.btnExpiring.TabIndex = 4;
            this.btnExpiring.Text = "Expiring Soon";
            this.btnExpiring.UseVisualStyleBackColor = false;
            this.btnExpiring.Click += new System.EventHandler(this.btnExpiring_Click);
            // 
            // btnTrainers
            // 
            this.btnTrainers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(130)))), ((int)(((byte)(10)))));
            this.btnTrainers.FlatAppearance.BorderSize = 0;
            this.btnTrainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTrainers.ForeColor = System.Drawing.Color.White;
            this.btnTrainers.Location = new System.Drawing.Point(835, 15);
            this.btnTrainers.Name = "btnTrainers";
            this.btnTrainers.Size = new System.Drawing.Size(155, 40);
            this.btnTrainers.TabIndex = 5;
            this.btnTrainers.Text = "Trainers Report";
            this.btnTrainers.UseVisualStyleBackColor = false;
            this.btnTrainers.Click += new System.EventHandler(this.btnTrainers_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.lblRecordCount);
            this.pnlGrid.Controls.Add(this.lblReportTitle);
            this.pnlGrid.Controls.Add(this.dgvReport);
            this.pnlGrid.Location = new System.Drawing.Point(10, 146);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1030, 494);
            this.pnlGrid.TabIndex = 0;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblRecordCount.Location = new System.Drawing.Point(900, 14);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(0, 25);
            this.lblRecordCount.TabIndex = 0;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lblReportTitle.Location = new System.Drawing.Point(10, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(340, 36);
            this.lblReportTitle.TabIndex = 1;
            this.lblReportTitle.Text = "Select a report from above";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersHeight = 34;
            this.dgvReport.Location = new System.Drawing.Point(0, 49);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 62;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1029, 444);
            this.dgvReport.TabIndex = 2;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        // ── Control Declarations ──
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnAllMembers;
        private System.Windows.Forms.Button btnActiveMembers;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnExpiring;
        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}