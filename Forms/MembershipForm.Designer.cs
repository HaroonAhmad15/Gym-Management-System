namespace Gym_Management_System
{
    partial class MembershipForm
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
            // ── Declare all controls ──
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblSubID = new System.Windows.Forms.Label();
            this.txtSubID = new System.Windows.Forms.TextBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.lblPlanDetails = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvMemberships = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberships)).BeginInit();
            this.SuspendLayout();

            // ════════════════════════════════
            // pnlTop — Dark blue top banner
            // ════════════════════════════════
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
            this.lblTitle.Text = "Membership Management";

            // ════════════════════════════════
            // pnlForm — Left white input panel
            // ════════════════════════════════
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.lblSubID);
            this.pnlForm.Controls.Add(this.txtSubID);
            this.pnlForm.Controls.Add(this.lblMember);
            this.pnlForm.Controls.Add(this.cmbMember);
            this.pnlForm.Controls.Add(this.lblPlan);
            this.pnlForm.Controls.Add(this.cmbPlan);

            this.pnlForm.Controls.Add(this.lblPlanDetails);
            this.pnlForm.Controls.Add(this.lblStartDate);
            this.pnlForm.Controls.Add(this.dtpStartDate);
            this.pnlForm.Controls.Add(this.lblEndDate);
            this.pnlForm.Controls.Add(this.txtEndDate);
            this.pnlForm.Controls.Add(this.lblStatus);
            this.pnlForm.Controls.Add(this.cmbStatus);
            this.pnlForm.Controls.Add(this.btnAssign);
            this.pnlForm.Controls.Add(this.btnRenew);
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Location = new System.Drawing.Point(10, 70);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(340, 580);

            // ── lblSubID ──
            this.lblSubID.AutoSize = true;
            this.lblSubID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubID.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblSubID.Location = new System.Drawing.Point(15, 15);
            this.lblSubID.Name = "lblSubID";
            this.lblSubID.Text = "Subscription ID (Auto)";

            // ── txtSubID ──
            this.txtSubID.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.txtSubID.Enabled = false;
            this.txtSubID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSubID.Location = new System.Drawing.Point(15, 35);
            this.txtSubID.Name = "txtSubID";
            this.txtSubID.Size = new System.Drawing.Size(300, 27);

            // ── lblMember ──
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMember.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblMember.Location = new System.Drawing.Point(15, 75);
            this.lblMember.Name = "lblMember";
            this.lblMember.Text = "Select Member *";

            // ── cmbMember ──
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMember.Location = new System.Drawing.Point(15, 95);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(300, 27);

            // ── lblPlan ──
            this.lblPlan.AutoSize = true;
            this.lblPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlan.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblPlan.Location = new System.Drawing.Point(15, 135);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Text = "Select Plan *";

            // ── cmbPlan ──
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPlan.Location = new System.Drawing.Point(15, 155);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(300, 27);
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);

            // ── lblPlanDetails — shows price and duration ──
            this.lblPlanDetails.AutoSize = false;
            this.lblPlanDetails.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.lblPlanDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlanDetails.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblPlanDetails.Location = new System.Drawing.Point(15, 188);
            this.lblPlanDetails.Name = "lblPlanDetails";
            this.lblPlanDetails.Size = new System.Drawing.Size(300, 25);
            this.lblPlanDetails.Text = "Select a plan to see details";
            this.lblPlanDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── lblStartDate ──
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblStartDate.Location = new System.Drawing.Point(15, 225);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Text = "Start Date *";

            // ── dtpStartDate ──
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(15, 245);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(300, 27);

            // ── lblEndDate ──
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblEndDate.Location = new System.Drawing.Point(15, 285);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Text = "End Date (Auto Calculated)";

            // ── txtEndDate — read only, auto filled ──
            this.txtEndDate.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.txtEndDate.Enabled = false;
            this.txtEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEndDate.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtEndDate.Location = new System.Drawing.Point(15, 305);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(300, 27);
            this.txtEndDate.Text = "Select plan and start date first";

            // ── lblStatus ──
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblStatus.Location = new System.Drawing.Point(15, 345);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";

            // ── cmbStatus ──
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Expired", "Cancelled" });
            this.cmbStatus.Location = new System.Drawing.Point(15, 365);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 27);

            // ── btnAssign — Green ──
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAssign.FlatAppearance.BorderSize = 0;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(15, 420);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(135, 40);
            this.btnAssign.Text = "ASSIGN PLAN";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);

            // ── btnRenew — Blue ──
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Location = new System.Drawing.Point(160, 420);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(155, 40);
            this.btnRenew.Text = "RENEW";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);

            // ── btnCancel — Red ──
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 40);
            this.btnCancel.Text = "CANCEL PLAN";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── btnClear — Grey ──
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(160, 470);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 40);
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ════════════════════════════════
            // pnlSearch — Search bar panel
            // ════════════════════════════════
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Controls.Add(this.btnShowAll);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(360, 70);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(720, 60);

            // ── lblSearch ──
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblSearch.Location = new System.Drawing.Point(10, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search Member:";

            // ── txtSearch ──
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(115, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 27);

            // ── btnSearch ──
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(375, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

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
            this.lblCount.Text = "Total: 0 records";

            // ════════════════════════════════
            // dgvMemberships — Data table
            // ════════════════════════════════
            this.dgvMemberships.AllowUserToAddRows = false;
            this.dgvMemberships.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemberships.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberships.Location = new System.Drawing.Point(360, 140);
            this.dgvMemberships.Name = "dgvMemberships";
            this.dgvMemberships.ReadOnly = true;
            this.dgvMemberships.RowHeadersVisible = false;
            this.dgvMemberships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberships.Size = new System.Drawing.Size(720, 510);
            this.dgvMemberships.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemberships_CellClick);

            // ════════════════════════════════
            // MembershipForm itself
            // ════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.dgvMemberships);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MembershipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Membership Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MembershipForm_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberships)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Control declarations ──
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubID;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblPlanDetails;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtSubID;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvMemberships;
    }
}