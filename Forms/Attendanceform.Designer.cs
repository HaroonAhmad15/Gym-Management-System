namespace Gym_Management_System
{
    partial class AttendanceForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnMarkAttendance = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlTodayStats = new System.Windows.Forms.Panel();
            this.lblTodayLabel = new System.Windows.Forms.Label();
            this.lblTodayCount = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlTodayStats.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);

            // ── lblTitle ──
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Attendance Management";

            // ── pnlForm ──
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.lblMember);
            this.pnlForm.Controls.Add(this.cmbMember);
            this.pnlForm.Controls.Add(this.lblDate);
            this.pnlForm.Controls.Add(this.dtpDate);
            this.pnlForm.Controls.Add(this.lblTime);
            this.pnlForm.Controls.Add(this.lblCurrentTime);
            this.pnlForm.Controls.Add(this.btnMarkAttendance);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Location = new System.Drawing.Point(10, 70);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(340, 580);

            // ── lblMember ──
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMember.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblMember.Location = new System.Drawing.Point(15, 20);
            this.lblMember.Name = "lblMember";
            this.lblMember.Text = "Select Member *";

            // ── cmbMember ──
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMember.Location = new System.Drawing.Point(15, 42);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(300, 27);

            // ── lblDate ──
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblDate.Location = new System.Drawing.Point(15, 85);
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "Date";

            // ── dtpDate ──
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(15, 105);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(300, 27);

            // ── lblTime ──
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblTime.Location = new System.Drawing.Point(15, 148);
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "Current Time";

            // ── lblCurrentTime ──
            this.lblCurrentTime.AutoSize = false;
            this.lblCurrentTime.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTime.Location = new System.Drawing.Point(15, 168);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(300, 55);
            this.lblCurrentTime.Text = "00:00:00";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── btnMarkAttendance ──
            this.btnMarkAttendance.BackColor = System.Drawing.Color.FromArgb(245, 130, 10);
            this.btnMarkAttendance.FlatAppearance.BorderSize = 0;
            this.btnMarkAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAttendance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.White;
            this.btnMarkAttendance.Location = new System.Drawing.Point(15, 260);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(300, 55);
            this.btnMarkAttendance.Text = "MARK ATTENDANCE";
            this.btnMarkAttendance.Click += new System.EventHandler(this.btnMarkAttendance_Click);

            // ── btnClear ──
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(15, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 40);
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── pnlTodayStats ──
            this.pnlTodayStats.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlTodayStats.Controls.Add(this.lblTotalLabel);
            this.pnlTodayStats.Controls.Add(this.lblTotalCount);
            this.pnlTodayStats.Controls.Add(this.lblTodayLabel);
            this.pnlTodayStats.Controls.Add(this.lblTodayCount);
            this.pnlTodayStats.Location = new System.Drawing.Point(360, 70);
            this.pnlTodayStats.Name = "pnlTodayStats";
            this.pnlTodayStats.Size = new System.Drawing.Size(720, 60);

            // ── lblTodayLabel ──
            this.lblTodayLabel.AutoSize = true;
            this.lblTodayLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTodayLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTodayLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTodayLabel.Name = "lblTodayLabel";
            this.lblTodayLabel.Text = "TODAY ATTENDANCE";

            // ── lblTodayCount ──
            this.lblTodayCount.AutoSize = true;
            this.lblTodayCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTodayCount.ForeColor = System.Drawing.Color.FromArgb(245, 130, 10);
            this.lblTodayCount.Location = new System.Drawing.Point(10, 28);
            this.lblTodayCount.Name = "lblTodayCount";
            this.lblTodayCount.Text = "0 members";

            // ── lblTotalLabel ──
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalLabel.Location = new System.Drawing.Point(400, 10);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Text = "TOTAL RECORDS";

            // ── lblTotalCount ──
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblTotalCount.Location = new System.Drawing.Point(400, 28);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Text = "0 records";

            // ── pnlSearch ──
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.btnToday);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(360, 140);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(720, 60);

            // ── lblSearch ──
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblSearch.Location = new System.Drawing.Point(10, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // ── txtSearch ──
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(65, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);

            // ── btnSearch ──
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(275, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ── btnToday ──
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(375, 15);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(100, 30);
            this.btnToday.Text = "TODAY";
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);

            // ── btnShowAll ──
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(245, 130, 10);
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(485, 15);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(100, 30);
            this.btnShowAll.Text = "SHOW ALL";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // ── lblCount ──
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblCount.Location = new System.Drawing.Point(600, 20);
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "Total: 0";

            // ── dgvAttendance ──
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendance.Location = new System.Drawing.Point(360, 210);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(720, 440);

            // ── timerClock ──
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // ── AttendanceForm ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTodayStats);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AttendanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AttendanceForm_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlTodayStats.ResumeLayout(false);
            this.pnlTodayStats.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
        }

        // ── ALL control declarations ──
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlTodayStats;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTodayLabel;
        private System.Windows.Forms.Label lblTodayCount;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnMarkAttendance;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Timer timerClock;
    }
}