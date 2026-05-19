// ============================================================
// FILE        : AttendanceForm.cs
// PURPOSE     : Records daily member check-ins with exact
//               timestamps. Features live clock display and
//               prevents duplicate attendance on same day.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;

namespace Gym_Management_System
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceRepository _repo = new AttendanceRepository();
        private readonly MemberRepository _mRepo = new MemberRepository();

        public AttendanceForm()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : AttendanceForm_Load
        // TRIGGER : Fires when the form opens
        // PURPOSE : Starts the live clock timer and loads today's
        //           attendance records immediately
        // ──────────────────────────────────────────────────────────
        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;

            // Start the timer that updates the clock every second.
            // Timer Interval is set to 1000ms in Designer.
            // A live clock helps staff record accurate check-in times.
            timerClock.Start();
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            LoadMembersDropdown();    // Active members only
            LoadTodayAttendance();    // Show today's records by default
            LoadStats();             // Show today count and total count
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : timerClock_Tick
        // TRIGGER : Fires every 1000ms (1 second) from timerClock
        // PURPOSE : Updates the displayed clock every second so
        //           staff can see the exact time of check-in.
        //           This is important for accurate time records.
        // ──────────────────────────────────────────────────────────
        private void timerClock_Tick(object sender, EventArgs e)
        {
            // Update time label — hh:mm:ss tt gives 12-hour format with AM/PM
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadMembersDropdown
        // PURPOSE : Fills cmbMember with active members only.
        //           Inactive members cannot check in — they are
        //           excluded from the dropdown.
        // ──────────────────────────────────────────────────────────
        private void LoadMembersDropdown()
        {
            try
            {
                var members = _mRepo.GetActiveMembers();
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberID";
                cmbMember.DataSource = members;
                cmbMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadStats
        // PURPOSE : Updates the today count and total records labels
        // ──────────────────────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                // Today count: COUNT(*) WHERE DATE(CheckInTime)=CURDATE()
                lblTodayCount.Text = _repo.GetTodayCount() + " members";

                // Total count: COUNT(*) with no date filter
                lblTotalCount.Text = _repo.GetTotalCount() + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadTodayAttendance
        // PURPOSE : Shows only TODAY's check-in records.
        //           Default view — most relevant for daily operations.
        // ──────────────────────────────────────────────────────────
        private void LoadTodayAttendance()
        {
            try
            {
                // Repository SQL uses DATE(CheckInTime) = CURDATE()
                DataTable dt = _repo.GetTodayAttendance();
                dgvAttendance.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Today: " + dt.Rows.Count + " check-ins";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadAllAttendance
        // PURPOSE : Shows complete attendance history (all dates).
        //           Called when staff clicks SHOW ALL button.
        // ──────────────────────────────────────────────────────────
        private void LoadAllAttendance()
        {
            try
            {
                // Repository SQL has no date filter — returns all records
                DataTable dt = _repo.GetAllAttendance();
                dgvAttendance.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Total: " + dt.Rows.Count + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvAttendance.ColumnHeadersHeight = 35;
            dgvAttendance.RowTemplate.Height = 30;
            dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvAttendance.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvAttendance.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnMarkAttendance_Click
        // TRIGGER : User clicks MARK ATTENDANCE button
        // PURPOSE : Records the member check-in with current timestamp.
        //
        // COMPLEX LOGIC — Duplicate Prevention:
        // Before inserting, IsAlreadyMarkedToday() runs:
        // SELECT COUNT(*) WHERE MemberID=X AND DATE(CheckInTime)=CURDATE()
        // If count > 0 → member already marked → ask confirmation.
        // This prevents accidental double-marking of the same member.
        //
        // IMPORTANT: DateTime.Now inside repository captures the
        // EXACT second of the check-in, not just the date.
        // ──────────────────────────────────────────────────────────
        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int memberID = Convert.ToInt32(cmbMember.SelectedValue);
            string memberName = cmbMember.Text;

            // Check for duplicate attendance on today's date
            if (_repo.IsAlreadyMarkedToday(memberID))
            {
                var dr = MessageBox.Show(
                    memberName + " is already marked present today.\n" +
                    "Mark attendance again?",
                    "Already Marked",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // If staff says No, stop — do not mark again
                if (dr == DialogResult.No) return;
            }

            try
            {
                // Insert attendance record with DateTime.Now timestamp
                if (_repo.MarkAttendance(memberID))
                {
                    MessageBox.Show(
                        "Attendance marked for " + memberName + "\n" +
                        "Time: " + DateTime.Now.ToString("hh:mm:ss tt"),
                        "Marked!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadTodayAttendance(); // Refresh today's grid
                    LoadStats();          // Update count labels
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                LoadTodayAttendance();
                return;
            }
            try
            {
                DataTable dt = _repo.SearchAttendance(txtSearch.Text.Trim());
                dgvAttendance.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Found: " + dt.Rows.Count + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show today's records only
        private void btnToday_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadTodayAttendance();
        }

        // Show all attendance records from all dates
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadAllAttendance();
        }

        private void ClearForm()
        {
            cmbMember.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            LoadMembersDropdown();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}