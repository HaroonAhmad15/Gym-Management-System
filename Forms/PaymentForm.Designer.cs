namespace Gym_Management_System
{
    partial class PaymentForm
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.txtPaymentID = new System.Windows.Forms.TextBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblMemberInfo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblMonthLabel = new System.Windows.Forms.Label();
            this.lblMonthAmount = new System.Windows.Forms.Label();
            this.lblCountLabel = new System.Windows.Forms.Label();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
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
            this.lblTitle.Text = "Payment Management";

            // ── pnlForm ──
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.lblPaymentID);
            this.pnlForm.Controls.Add(this.txtPaymentID);
            this.pnlForm.Controls.Add(this.lblMember);
            this.pnlForm.Controls.Add(this.cmbMember);
            this.pnlForm.Controls.Add(this.lblMemberInfo);
            this.pnlForm.Controls.Add(this.lblAmount);
            this.pnlForm.Controls.Add(this.txtAmount);
            this.pnlForm.Controls.Add(this.lblMethod);
            this.pnlForm.Controls.Add(this.cmbMethod);
            this.pnlForm.Controls.Add(this.lblDate);
            this.pnlForm.Controls.Add(this.dtpDate);
            this.pnlForm.Controls.Add(this.lblNotes);
            this.pnlForm.Controls.Add(this.txtNotes);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Location = new System.Drawing.Point(10, 70);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(340, 580);

            // ── lblPaymentID ──
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentID.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblPaymentID.Location = new System.Drawing.Point(15, 15);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Text = "Payment ID (Auto)";

            // ── txtPaymentID ──
            this.txtPaymentID.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.txtPaymentID.Enabled = false;
            this.txtPaymentID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPaymentID.Location = new System.Drawing.Point(15, 35);
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(300, 27);

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
            this.cmbMember.SelectedIndexChanged += new System.EventHandler(this.cmbMember_SelectedIndexChanged);

            // ── lblMemberInfo ──
            this.lblMemberInfo.AutoSize = false;
            this.lblMemberInfo.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.lblMemberInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMemberInfo.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblMemberInfo.Location = new System.Drawing.Point(15, 128);
            this.lblMemberInfo.Name = "lblMemberInfo";
            this.lblMemberInfo.Size = new System.Drawing.Size(300, 25);
            this.lblMemberInfo.Text = "Select a member to see their plan";
            this.lblMemberInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── lblAmount ──
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblAmount.Location = new System.Drawing.Point(15, 165);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Text = "Amount (Rs.) *";

            // ── txtAmount ──
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAmount.Location = new System.Drawing.Point(15, 185);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(300, 27);

            // ── lblMethod ──
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMethod.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblMethod.Location = new System.Drawing.Point(15, 225);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Text = "Payment Method *";

            // ── cmbMethod ──
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMethod.Items.AddRange(new object[] { "Cash", "Card", "Online" });
            this.cmbMethod.Location = new System.Drawing.Point(15, 245);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(300, 27);

            // ── lblDate ──
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblDate.Location = new System.Drawing.Point(15, 285);
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "Payment Date *";

            // ── dtpDate ──
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(15, 305);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(300, 27);

            // ── lblNotes ──
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.lblNotes.Location = new System.Drawing.Point(15, 345);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Text = "Notes (Optional)";

            // ── txtNotes ──
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(15, 365);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(300, 55);

            // ── btnSave — Green ──
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.Text = "SAVE PAYMENT";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // ── btnDelete — Red ──
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(160, 440);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 40);
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ── btnClear — Grey ──
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(15, 490);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 40);
            this.btnClear.Text = "CLEAR FORM";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── pnlStats — 3 summary cards ──
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlStats.Controls.Add(this.lblCountLabel);
            this.pnlStats.Controls.Add(this.lblPaymentCount);
            this.pnlStats.Controls.Add(this.lblMonthLabel);
            this.pnlStats.Controls.Add(this.lblMonthAmount);
            this.pnlStats.Controls.Add(this.lblTotalLabel);
            this.pnlStats.Controls.Add(this.lblTotalAmount);
            this.pnlStats.Location = new System.Drawing.Point(360, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(720, 60);

            // ── Total Revenue ──
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTotalLabel.Location = new System.Drawing.Point(10, 10);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Text = "TOTAL REVENUE";

            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotalAmount.Location = new System.Drawing.Point(10, 28);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Text = "Rs. 0";

            // ── This Month ──
            this.lblMonthLabel.AutoSize = true;
            this.lblMonthLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblMonthLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblMonthLabel.Location = new System.Drawing.Point(260, 10);
            this.lblMonthLabel.Name = "lblMonthLabel";
            this.lblMonthLabel.Text = "THIS MONTH";

            this.lblMonthAmount.AutoSize = true;
            this.lblMonthAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMonthAmount.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblMonthAmount.Location = new System.Drawing.Point(260, 28);
            this.lblMonthAmount.Name = "lblMonthAmount";
            this.lblMonthAmount.Text = "Rs. 0";

            // ── Total Payments Count ──
            this.lblCountLabel.AutoSize = true;
            this.lblCountLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCountLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblCountLabel.Location = new System.Drawing.Point(510, 10);
            this.lblCountLabel.Name = "lblCountLabel";
            this.lblCountLabel.Text = "TOTAL PAYMENTS";

            this.lblPaymentCount.AutoSize = true;
            this.lblPaymentCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentCount.ForeColor = System.Drawing.Color.FromArgb(245, 130, 10);
            this.lblPaymentCount.Location = new System.Drawing.Point(510, 28);
            this.lblPaymentCount.Name = "lblPaymentCount";
            this.lblPaymentCount.Text = "0";

            // ── pnlSearch ──
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblCount);
            this.pnlSearch.Controls.Add(this.btnShowAll);
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
            this.lblCount.Text = "Total: 0";

            // ── dgvPayments ──
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.Location = new System.Drawing.Point(360, 210);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(720, 440);
            this.dgvPayments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayments_CellClick);

            // ── PaymentForm ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PaymentForm_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblMemberInfo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblMonthLabel;
        private System.Windows.Forms.Label lblMonthAmount;
        private System.Windows.Forms.Label lblCountLabel;
        private System.Windows.Forms.Label lblPaymentCount;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView dgvPayments;
    }
}