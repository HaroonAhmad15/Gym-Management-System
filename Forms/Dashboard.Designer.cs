namespace Gym_Management_System
{
    partial class Dashboard
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
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTrainers = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnMembership = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblGymName = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblActiveMembers = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblTodayAttendance = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.dgvRecentMembers = new System.Windows.Forms.DataGridView();
            this.dgvExpiring = new System.Windows.Forms.DataGridView();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlNav.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiring)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.pnlNav.Controls.Add(this.btnLogout);
            this.pnlNav.Controls.Add(this.btnReports);
            this.pnlNav.Controls.Add(this.btnTrainers);
            this.pnlNav.Controls.Add(this.btnAttendance);
            this.pnlNav.Controls.Add(this.btnPayments);
            this.pnlNav.Controls.Add(this.btnMembership);
            this.pnlNav.Controls.Add(this.btnMembers);
            this.pnlNav.Controls.Add(this.btnDashboard);
            this.pnlNav.Controls.Add(this.lblGymName);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(220, 660);
            this.pnlNav.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 600);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 50);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "  🚪  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 360);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(220, 50);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "  📈  Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnTrainers
            // 
            this.btnTrainers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnTrainers.FlatAppearance.BorderSize = 0;
            this.btnTrainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTrainers.ForeColor = System.Drawing.Color.White;
            this.btnTrainers.Location = new System.Drawing.Point(0, 310);
            this.btnTrainers.Name = "btnTrainers";
            this.btnTrainers.Size = new System.Drawing.Size(220, 50);
            this.btnTrainers.TabIndex = 2;
            this.btnTrainers.Text = "  🏃  Trainers";
            this.btnTrainers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainers.UseVisualStyleBackColor = false;
            this.btnTrainers.Click += new System.EventHandler(this.btnTrainers_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(0, 260);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(220, 50);
            this.btnAttendance.TabIndex = 3;
            this.btnAttendance.Text = "  📅  Attendance";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(0, 210);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(220, 50);
            this.btnPayments.TabIndex = 4;
            this.btnPayments.Text = "  💰  Payments";
            this.btnPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnMembership
            // 
            this.btnMembership.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnMembership.FlatAppearance.BorderSize = 0;
            this.btnMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembership.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMembership.ForeColor = System.Drawing.Color.White;
            this.btnMembership.Location = new System.Drawing.Point(0, 160);
            this.btnMembership.Name = "btnMembership";
            this.btnMembership.Size = new System.Drawing.Size(220, 50);
            this.btnMembership.TabIndex = 5;
            this.btnMembership.Text = "  📋  Memberships";
            this.btnMembership.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembership.UseVisualStyleBackColor = false;
            this.btnMembership.Click += new System.EventHandler(this.btnMembership_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.Location = new System.Drawing.Point(0, 110);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(220, 50);
            this.btnMembers.TabIndex = 6;
            this.btnMembers.Text = "  👥  Members";
            this.btnMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(130)))), ((int)(((byte)(10)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 60);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(220, 50);
            this.btnDashboard.TabIndex = 7;
            this.btnDashboard.Text = "  📊  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblGymName
            // 
            this.lblGymName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(56)))));
            this.lblGymName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGymName.ForeColor = System.Drawing.Color.White;
            this.lblGymName.Location = new System.Drawing.Point(0, 0);
            this.lblGymName.Name = "lblGymName";
            this.lblGymName.Size = new System.Drawing.Size(220, 60);
            this.lblGymName.TabIndex = 8;
            this.lblGymName.Text = "🏋️ GYM SYSTEM";
            this.lblGymName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(868, 65);
            this.pnlHeader.TabIndex = 6;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblDateTime.Location = new System.Drawing.Point(650, 23);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(88, 25);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "Loading...";
            this.lblDateTime.Click += new System.EventHandler(this.lblDateTime_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lblPageTitle.Location = new System.Drawing.Point(20, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(345, 38);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "📊  Dashboard Overview";
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Controls.Add(this.lblTotalMembers);
            this.pnlCard1.Location = new System.Drawing.Point(240, 85);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(190, 110);
            this.pnlCard1.TabIndex = 3;
            // 
            // lblCard1Title
            // 
            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.BackColor = System.Drawing.Color.Transparent;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.lblCard1Title.Location = new System.Drawing.Point(15, 78);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Size = new System.Drawing.Size(137, 21);
            this.lblCard1Title.TabIndex = 0;
            this.lblCard1Title.Text = "TOTAL MEMBERS";
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalMembers.ForeColor = System.Drawing.Color.White;
            this.lblTotalMembers.Location = new System.Drawing.Point(15, 15);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(64, 74);
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "0";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Controls.Add(this.lblActiveMembers);
            this.pnlCard2.Location = new System.Drawing.Point(450, 85);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(190, 110);
            this.pnlCard2.TabIndex = 2;
            // 
            // lblCard2Title
            // 
            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.BackColor = System.Drawing.Color.Transparent;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(245)))), ((int)(((byte)(227)))));
            this.lblCard2Title.Location = new System.Drawing.Point(15, 78);
            this.lblCard2Title.Name = "lblCard2Title";
            this.lblCard2Title.Size = new System.Drawing.Size(146, 21);
            this.lblCard2Title.TabIndex = 0;
            this.lblCard2Title.Text = "ACTIVE MEMBERS";
            // 
            // lblActiveMembers
            // 
            this.lblActiveMembers.AutoSize = true;
            this.lblActiveMembers.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveMembers.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblActiveMembers.ForeColor = System.Drawing.Color.White;
            this.lblActiveMembers.Location = new System.Drawing.Point(15, 15);
            this.lblActiveMembers.Name = "lblActiveMembers";
            this.lblActiveMembers.Size = new System.Drawing.Size(64, 74);
            this.lblActiveMembers.TabIndex = 1;
            this.lblActiveMembers.Text = "0";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(130)))), ((int)(((byte)(10)))));
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Controls.Add(this.lblTodayAttendance);
            this.pnlCard3.Location = new System.Drawing.Point(660, 85);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(190, 110);
            this.pnlCard3.TabIndex = 1;
            // 
            // lblCard3Title
            // 
            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.BackColor = System.Drawing.Color.Transparent;
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(208)))));
            this.lblCard3Title.Location = new System.Drawing.Point(15, 78);
            this.lblCard3Title.Name = "lblCard3Title";
            this.lblCard3Title.Size = new System.Drawing.Size(171, 21);
            this.lblCard3Title.TabIndex = 0;
            this.lblCard3Title.Text = "TODAY ATTENDANCE";
            // 
            // lblTodayAttendance
            // 
            this.lblTodayAttendance.AutoSize = true;
            this.lblTodayAttendance.BackColor = System.Drawing.Color.Transparent;
            this.lblTodayAttendance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTodayAttendance.ForeColor = System.Drawing.Color.White;
            this.lblTodayAttendance.Location = new System.Drawing.Point(15, 15);
            this.lblTodayAttendance.Name = "lblTodayAttendance";
            this.lblTodayAttendance.Size = new System.Drawing.Size(64, 74);
            this.lblTodayAttendance.TabIndex = 1;
            this.lblTodayAttendance.Text = "0";
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.pnlCard4.Controls.Add(this.lblCard4Title);
            this.pnlCard4.Controls.Add(this.lblTotalRevenue);
            this.pnlCard4.Location = new System.Drawing.Point(870, 85);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(200, 110);
            this.pnlCard4.TabIndex = 0;
            // 
            // lblCard4Title
            // 
            this.lblCard4Title.AutoSize = true;
            this.lblCard4Title.BackColor = System.Drawing.Color.Transparent;
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(219)))), ((int)(((byte)(216)))));
            this.lblCard4Title.Location = new System.Drawing.Point(15, 78);
            this.lblCard4Title.Name = "lblCard4Title";
            this.lblCard4Title.Size = new System.Drawing.Size(133, 21);
            this.lblCard4Title.TabIndex = 0;
            this.lblCard4Title.Text = "TOTAL REVENUE";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(15, 18);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(110, 60);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "Rs.0";
            // 
            // dgvRecentMembers
            // 
            this.dgvRecentMembers.AllowUserToAddRows = false;
            this.dgvRecentMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentMembers.ColumnHeadersHeight = 34;
            this.dgvRecentMembers.Location = new System.Drawing.Point(240, 220);
            this.dgvRecentMembers.Name = "dgvRecentMembers";
            this.dgvRecentMembers.ReadOnly = true;
            this.dgvRecentMembers.RowHeadersVisible = false;
            this.dgvRecentMembers.RowHeadersWidth = 62;
            this.dgvRecentMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentMembers.Size = new System.Drawing.Size(500, 380);
            this.dgvRecentMembers.TabIndex = 4;
            // 
            // dgvExpiring
            // 
            this.dgvExpiring.AllowUserToAddRows = false;
            this.dgvExpiring.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpiring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpiring.ColumnHeadersHeight = 34;
            this.dgvExpiring.Location = new System.Drawing.Point(755, 220);
            this.dgvExpiring.Name = "dgvExpiring";
            this.dgvExpiring.ReadOnly = true;
            this.dgvExpiring.RowHeadersVisible = false;
            this.dgvExpiring.RowHeadersWidth = 62;
            this.dgvExpiring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpiring.Size = new System.Drawing.Size(320, 380);
            this.dgvExpiring.TabIndex = 5;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.dgvRecentMembers);
            this.Controls.Add(this.dgvExpiring);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlNav);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gym Management System — Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.pnlNav.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiring)).EndInit();
            this.ResumeLayout(false);

        }

        // ── Control Declarations ──
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblGymName;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblActiveMembers;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblTodayAttendance;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnMembership;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvRecentMembers;
        private System.Windows.Forms.DataGridView dgvExpiring;
        private System.Windows.Forms.Timer timerClock;
    }
}