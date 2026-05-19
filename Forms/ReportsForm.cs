// ============================================================
// FILE        : ReportsForm.cs
// PURPOSE     : Generates six types of administrative reports.
//               Each report button fetches data from the
//               appropriate repository and displays in the grid.
//               Expiring Soon report adds color-coded row alerts.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;

namespace Gym_Management_System
{
    public partial class ReportsForm : Form
    {
        // ── Repository Declarations ────────────────────────────────
        // Five repositories are needed — each report draws from
        // a different table or combination of tables.
        private readonly MemberRepository _memberRepo = new MemberRepository();
        private readonly PaymentRepository _paymentRepo = new PaymentRepository();
        private readonly AttendanceRepository _attendanceRepo = new AttendanceRepository();
        private readonly MembershipRepository _membershipRepo = new MembershipRepository();
        private readonly TrainerRepository _trainerRepo = new TrainerRepository();

        public ReportsForm()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : ReportsForm_Load
        // TRIGGER : Fires when the form opens
        // PURPOSE : Loads the All Members report by default so the
        //           grid is not empty when the form first opens
        // ──────────────────────────────────────────────────────────
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            ShowAllMembers(); // Default report on open
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : StyleGrid
        // PURPOSE : Applies consistent professional styling to the
        //           report DataGridView. Same pattern as other forms.
        // ──────────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvReport.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvReport.ColumnHeadersHeight = 35;
            dgvReport.RowTemplate.Height = 30;
            dgvReport.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvReport.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvReport.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ── Report 1: All Members ──────────────────────────────────
        private void ShowAllMembers()
        {
            try
            {
                DataTable dt = _memberRepo.GetAllMembersTable();
                dgvReport.DataSource = dt;
                StyleGrid();
                lblReportTitle.Text = "All Members Report";
                lblRecordCount.Text = "Total: " + dt.Rows.Count + " members";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 2: Active Members ───────────────────────────────
        private void ShowActiveMembers()
        {
            try
            {
                // GetActiveMembers returns List<Member>, so we build
                // a DataTable manually for DataGridView binding
                var members = _memberRepo.GetActiveMembers();
                var dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Full Name");
                dt.Columns.Add("Phone");
                dt.Columns.Add("Email");
                dt.Columns.Add("Gender");
                dt.Columns.Add("Join Date");

                foreach (var m in members)
                    dt.Rows.Add(m.MemberID, m.FullName, m.Phone,
                        m.Email, m.Gender,
                        m.JoinDate.ToString("dd/MM/yyyy"));

                dgvReport.DataSource = dt;
                StyleGrid();
                lblReportTitle.Text = "Active Members Report";
                lblRecordCount.Text = "Total: " + dt.Rows.Count + " active members";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 3: Payment History ──────────────────────────────
        private void ShowPayments()
        {
            try
            {
                DataTable dt = _paymentRepo.GetAllPaymentsTable();
                dgvReport.DataSource = dt;
                StyleGrid();

                // Show both record count AND total revenue in the label
                decimal total = _paymentRepo.GetTotalRevenue();
                lblReportTitle.Text = "Payment History Report";
                lblRecordCount.Text = dt.Rows.Count +
                    " payments  |  Total Revenue: Rs." + total.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 4: Attendance History ───────────────────────────
        private void ShowAttendance()
        {
            try
            {
                DataTable dt = _attendanceRepo.GetAllAttendance();
                dgvReport.DataSource = dt;
                StyleGrid();
                lblReportTitle.Text = "Attendance Report";
                lblRecordCount.Text = "Total: " + dt.Rows.Count + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : ShowExpiring
        // PURPOSE : Shows memberships expiring within 30 days.
        //
        // COMPLEX LOGIC — Color-Coded Alerts:
        // After loading the data, we loop through every row and
        // check the "Days Left" column value. If it is 7 or less,
        // that row is highlighted in light red with dark red text.
        // This gives staff an instant visual warning for urgent cases.
        //
        // DECISION: We use 7 days as the threshold because that gives
        // staff one full working week to contact the member for renewal.
        // ──────────────────────────────────────────────────────────
        private void ShowExpiring()
        {
            try
            {
                DataTable dt = _membershipRepo.GetExpiringMemberships();
                dgvReport.DataSource = dt;
                StyleGrid();
                lblReportTitle.Text = "Expiring Memberships (Next 7 Days)";
                lblRecordCount.Text = dt.Rows.Count + " memberships expiring soon";

                // Loop through each row to apply color-coded alerts
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    if (row.Cells["Days Left"].Value != null)
                    {
                        int days = Convert.ToInt32(row.Cells["Days Left"].Value);

                        // 7 or fewer days left = urgent — highlight red
                        if (days <= 7)
                        {
                            // Light red background to draw attention
                            row.DefaultCellStyle.BackColor =
                                Color.FromArgb(255, 220, 220);
                            // Dark red text for contrast and readability
                            row.DefaultCellStyle.ForeColor =
                                Color.FromArgb(192, 57, 43);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 6: Trainers ─────────────────────────────────────
        private void ShowTrainers()
        {
            try
            {
                DataTable dt = _trainerRepo.GetAllTrainersTable();
                dgvReport.DataSource = dt;
                StyleGrid();
                lblReportTitle.Text = "Trainers Report";
                lblRecordCount.Text = "Total: " + dt.Rows.Count + " trainers";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report Button Click Handlers ───────────────────────────
        // Each button simply calls its corresponding show method.
        // Separation of click handler and show logic means the
        // same report can be triggered from multiple places if needed.

        private void btnAllMembers_Click(object sender, EventArgs e)
        {
            ShowAllMembers();
        }

        private void btnActiveMembers_Click(object sender, EventArgs e)
        {
            ShowActiveMembers();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            ShowPayments();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ShowAttendance();
        }

        private void btnExpiring_Click(object sender, EventArgs e)
        {
            ShowExpiring();
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            ShowTrainers();
        }
    }
}