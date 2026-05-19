// ============================================================
// FILE        : Dashboard.cs
// PURPOSE     : Main screen after login. Displays real-time
//               business statistics, live clock, recent members,
//               and membership expiry alerts. Also handles
//               navigation to all other modules.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;

namespace Gym_Management_System
{
    public partial class Dashboard : Form
    {
        // ── Repository Declarations ────────────────────────────────
        // Four repositories are needed because Dashboard shows data
        // from four different database tables simultaneously.
        // Each repository is readonly — created once, reused always.
        private readonly MemberRepository _memberRepo = new MemberRepository();
        private readonly PaymentRepository _paymentRepo = new PaymentRepository();
        private readonly AttendanceRepository _attendanceRepo = new AttendanceRepository();
        private readonly MembershipRepository _membershipRepo = new MembershipRepository();

        public Dashboard()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : Dashboard_Load
        // TRIGGER : Fires automatically when Dashboard form opens
        // PURPOSE : Initializes all dashboard elements with live data
        //           from the database and starts the real-time clock
        // ──────────────────────────────────────────────────────────
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Display today's date on the dashboard header
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");

            // Start the 1-second timer that drives the live clock display.
            // Timer Interval is set to 1000ms (1 second) in the Designer.
            timerClock.Start();

            // Load all four data sections from the database
            LoadStats();                 // Fill the 4 stat cards
            LoadRecentMembers();         // Fill recent members grid
            LoadExpiringMemberships();   // Fill expiry alert grid

            // Highlight the Dashboard nav button to show current page
            HighlightButton(btnDashboard);
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadStats
        // PURPOSE : Fetches four live statistics from the database
        //           and displays them in the colored stat cards.
        //           Called on load and when user clicks Dashboard nav.
        // IMPORTANT: Each value uses a separate SQL query via its
        //            own repository method for clarity and reusability.
        // ──────────────────────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                // Total Members → COUNT(*) FROM Members
                lblTotalMembers.Text =
                    _memberRepo.GetTotalCount().ToString();

                // Active Members → COUNT(*) WHERE IsActive = 1
                lblActiveMembers.Text =
                    _memberRepo.GetActiveCount().ToString();

                // Today's Attendance → COUNT(*) WHERE DATE(CheckInTime)=CURDATE()
                lblTodayAttendance.Text =
                    _attendanceRepo.GetTodayCount().ToString();

                // Total Revenue → IFNULL(SUM(Amount), 0) FROM Payments
                // "N0" format adds comma separators: 150000 → "150,000"
                decimal revenue = _paymentRepo.GetTotalRevenue();
                lblTotalRevenue.Text = "Rs." + revenue.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadRecentMembers
        // PURPOSE : Fills the recent members DataGridView with the
        //           latest member records from the database.
        // ──────────────────────────────────────────────────────────
        private void LoadRecentMembers()
        {
            try
            {
                // GetAllMembersTable returns a formatted DataTable
                // with display-friendly column names for the grid
                DataTable dt = _memberRepo.GetAllMembersTable();
                dgvRecentMembers.DataSource = dt;
                StyleGrid(dgvRecentMembers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadExpiringMemberships
        // PURPOSE : Fills the expiry alert grid with memberships
        //           that expire within the next 7 days.
        //           Helps staff proactively contact members for renewal.
        // ──────────────────────────────────────────────────────────
        private void LoadExpiringMemberships()
        {
            try
            {
                // SQL inside repository uses DATEDIFF(EndDate, CURDATE())
                // BETWEEN 0 AND 7 to find memberships expiring this week
                DataTable dt = _membershipRepo.GetExpiringMemberships();
                dgvExpiring.DataSource = dt;
                StyleGrid(dgvExpiring);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expiring: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : StyleGrid
        // PURPOSE : Applies consistent professional styling to any
        //           DataGridView passed to it.
        //           Written once here and called for both grids —
        //           avoids duplicating the same 8 style lines twice.
        // ──────────────────────────────────────────────────────────
        private void StyleGrid(DataGridView dgv)
        {
            // Navy header background with white bold text
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;

            // Row height for comfortable reading
            dgv.RowTemplate.Height = 30;

            // Alternating row color — improves readability of long lists
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);

            // Auto-fit all columns to fill available width
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Orange selection highlight — matches project color scheme
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : HighlightButton
        // PURPOSE : Visually shows which navigation section is active.
        //           Resets ALL buttons to navy, then makes the active
        //           one orange. This gives clear visual feedback.
        // DECISION: Array approach — adding a new button only requires
        //           adding it to the array, not writing new reset code.
        // ──────────────────────────────────────────────────────────
        private void HighlightButton(Button activeBtn)
        {
            // Reset all nav buttons to default navy color
            Button[] allButtons = {
                btnDashboard, btnMembers, btnMembership,
                btnPayments,  btnAttendance, btnTrainers, btnReports
            };
            foreach (Button b in allButtons)
                b.BackColor = Color.FromArgb(27, 42, 74); // Navy

            // Highlight only the active button in orange
            activeBtn.BackColor = Color.FromArgb(245, 130, 10);
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : timerClock_Tick
        // TRIGGER : Fires every 1000ms (1 second) from timerClock
        // PURPOSE : Updates the live clock label every second.
        //           This gives staff an accurate time reference when
        //           marking attendance without checking their phone.
        // ──────────────────────────────────────────────────────────
        private void timerClock_Tick(object sender, EventArgs e)
        {
            // Update label with current date and time every second
            lblDateTime.Text =
                DateTime.Now.ToString("dddd, dd MMM yyyy   HH:mm:ss");
        }

        // ── Navigation Button Handlers ─────────────────────────────
        // Each button highlights itself, updates the page title,
        // and opens the corresponding form module.

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HighlightButton(btnDashboard);
            lblPageTitle.Text = "Dashboard Overview";

            // Refresh all stats and grids with latest database data
            LoadStats();
            LoadRecentMembers();
            LoadExpiringMemberships();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMembers);
            lblPageTitle.Text = "Member Management";
            MemberForm mf = new MemberForm();
            mf.Show();
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            HighlightButton(btnMembership);
            lblPageTitle.Text = "Membership Management";
            MembershipForm msf = new MembershipForm();
            msf.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPayments);
            lblPageTitle.Text = "Payment Management";
            PaymentForm pf = new PaymentForm();
            pf.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            HighlightButton(btnAttendance);
            lblPageTitle.Text = "Attendance Management";
            AttendanceForm af = new AttendanceForm();
            af.Show();
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTrainers);
            lblPageTitle.Text = "Trainer Management";
            TrainerForm tf = new TrainerForm();
            tf.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReports);
            lblPageTitle.Text = "Reports";
            ReportsForm rf = new ReportsForm();
            rf.Show();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnLogout_Click
        // TRIGGER : User clicks the Logout button
        // PURPOSE : Safely ends the current session.
        //
        // IMPORTANT DECISIONS:
        // 1. Confirmation dialog prevents accidental logout
        // 2. Timer is stopped to release the system resource
        // 3. LoginForm is shown BEFORE closing Dashboard —
        //    prevents the application from having no visible window
        // ──────────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before ending the session
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Stop the 1-second timer — release system resources
                timerClock.Stop();

                // Show login form first, then close dashboard.
                // Order matters: showing login before closing ensures
                // the application remains visible on screen.
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            // If No → do nothing, stay on dashboard
        }
    }
}