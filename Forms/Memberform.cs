// ============================================================
// FILE        : MemberForm.cs
// PURPOSE     : Manages gym member records. Provides full CRUD
//               (Create, Read, Update, Delete) operations and
//               search functionality for the Members table.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;
using Gym_Management_System.Models;

namespace Gym_Management_System
{
    public partial class MemberForm : Form
    {
        // ── Repository Declaration ─────────────────────────────────
        // MemberRepository handles all Members table DB operations.
        // Single instance reused across all methods in this form.
        private readonly MemberRepository _repo = new MemberRepository();

        public MemberForm()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : MemberForm_Load
        // TRIGGER : Fires when the form opens
        // PURPOSE : Sets default values for input controls and
        //           loads existing member records into the grid
        // ──────────────────────────────────────────────────────────
        private void MemberForm_Load(object sender, EventArgs e)
        {
            // Set default dropdown selections so they are never empty
            cmbGender.SelectedIndex = 0;   // Default: Male
            cmbStatus.SelectedIndex = 0;   // Default: Active

            // Default join date to today — most common scenario
            dtpJoinDate.Value = DateTime.Today;

            // Load all existing members into the grid
            LoadMembers();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadMembers
        // PURPOSE : Fetches all member records from the database
        //           and binds them to the DataGridView.
        //           Called on load and after every CUD operation
        //           (Create, Update, Delete) to keep grid current.
        // ──────────────────────────────────────────────────────────
        private void LoadMembers()
        {
            try
            {
                // GetAllMembersTable returns a formatted DataTable with
                // display-friendly column aliases (e.g., "Full Name")
                DataTable dt = _repo.GetAllMembersTable();
                dgvMembers.DataSource = dt;
                StyleGrid();

                // Update record count label
                lblCount.Text = "Total: " + dt.Rows.Count + " members";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : StyleGrid
        // PURPOSE : Applies professional visual styling to the grid.
        //           Separated into its own method to keep LoadMembers
        //           clean and allow reuse after search results too.
        // ──────────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);       // Navy header
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvMembers.ColumnHeadersHeight = 35;
            dgvMembers.RowTemplate.Height = 30;

            // Alternating row colors improve readability
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvMembers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Orange selection matches the project color scheme
            dgvMembers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnAdd_Click
        // TRIGGER : User clicks ADD MEMBER button
        // PURPOSE : Validates input, creates a Member object,
        //           and inserts it into the Members table.
        //
        // IMPORTANT DECISIONS:
        // 1. Validation happens BEFORE creating the object —
        //    avoids wasted object creation if input is invalid
        // 2. MemberID is NOT set — MySQL AUTO_INCREMENT assigns it
        // 3. IsActive uses SelectedIndex == 0 instead of string
        //    comparison — more reliable, not affected by text changes
        // ──────────────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate required fields before touching the database
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the member's full name!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the phone number!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                // Create Member object — this is the MODEL pattern.
                // All field values are packaged into one object
                // and passed to the repository as a single unit.
                var member = new Member
                {
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Gender = cmbGender.SelectedItem.ToString(),
                    JoinDate = dtpJoinDate.Value,
                    // SelectedIndex==0 means first item "Active" is chosen
                    // Converts to bool: true=Active, false=Inactive
                    IsActive = cmbStatus.SelectedIndex == 0
                    // MemberID intentionally omitted — MySQL assigns it
                };

                if (_repo.AddMember(member))
                {
                    MessageBox.Show("Member added successfully!",
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();      // Reset fields for next entry
                    LoadMembers();    // Refresh grid to show new record
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnUpdate_Click
        // TRIGGER : User clicks UPDATE button
        // PURPOSE : Updates an existing member record.
        //
        // IMPORTANT DECISIONS:
        // 1. MemberID MUST be present — it identifies which row to update.
        //    Without it, the WHERE clause would fail.
        // 2. Staff must click a grid row first to load the MemberID
        //    into txtMemberID — this is enforced by the first check.
        // ──────────────────────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // MemberID must be loaded from the grid before updating.
            // If empty, staff hasn't selected a member to edit.
            if (txtMemberID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a member row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Full name cannot be empty!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var member = new Member
                {
                    // MemberID is required for UPDATE — identifies the row
                    MemberID = Convert.ToInt32(txtMemberID.Text),
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Gender = cmbGender.SelectedItem.ToString(),
                    JoinDate = dtpJoinDate.Value,
                    IsActive = cmbStatus.SelectedIndex == 0
                };

                if (_repo.UpdateMember(member))
                {
                    MessageBox.Show("Member updated successfully!",
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadMembers(); // Refresh to show updated data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnDelete_Click
        // TRIGGER : User clicks DELETE button
        // PURPOSE : Permanently removes a member from the database.
        //
        // IMPORTANT DECISIONS:
        // 1. Confirmation dialog prevents accidental deletion —
        //    deleted records cannot be recovered
        // 2. Error message mentions FK constraint — if the member
        //    has payments or attendance, MySQL blocks deletion
        // ──────────────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMemberID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a member row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Confirmation dialog — deletion is irreversible
            var result = MessageBox.Show(
                "Are you sure you want to delete this member?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_repo.DeleteMember(Convert.ToInt32(txtMemberID.Text)))
                    {
                        MessageBox.Show("Member deleted successfully!",
                            "Deleted", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearForm();
                        LoadMembers();
                    }
                }
                catch (Exception ex)
                {
                    // MySQL FK constraint blocks deleting a member who has
                    // existing records in Payments or Attendance tables
                    MessageBox.Show("Error: " + ex.Message +
                        "\nCannot delete member with existing records.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnSearch_Click
        // TRIGGER : User clicks SEARCH button
        // PURPOSE : Filters the grid to show members matching the
        //           typed keyword in name or phone.
        //
        // DECISION: If search box is empty, show all members instead
        //           of showing empty results — better user experience.
        // ──────────────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // If search box is empty, reload all members
            if (txtSearch.Text.Trim() == "")
            {
                LoadMembers();
                return;
            }

            try
            {
                // Repository uses LIKE '%keyword%' — finds keyword
                // anywhere in FullName or Phone column
                DataTable dt = _repo.SearchMembers(txtSearch.Text.Trim());
                dgvMembers.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Found: " + dt.Rows.Count + " members";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnShowAll_Click
        // TRIGGER : User clicks SHOW ALL button
        // PURPOSE : Clears the search and reloads all member records
        // ──────────────────────────────────────────────────────────
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); // Clear search box
            LoadMembers();     // Reload complete list
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : dgvMembers_CellClick
        // TRIGGER : User clicks any cell in the DataGridView
        // PURPOSE : Loads the clicked member's data into the input
        //           form fields so staff can review or edit them.
        //
        // IMPORTANT DECISIONS:
        // 1. e.RowIndex < 0 check skips header row clicks
        // 2. ?. null-conditional operator handles cells that may
        //    be null (optional fields like Email) safely
        // 3. ?? "" provides empty string fallback for null values
        // 4. Empty try-catch absorbs minor cell mapping errors
        //    without breaking the form
        // ──────────────────────────────────────────────────────────
        private void dgvMembers_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            // Skip if header row is clicked (RowIndex is -1 for headers)
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvMembers.Rows[e.RowIndex];

                // Load each field from the clicked row into the form
                txtMemberID.Text = row.Cells["ID"].Value.ToString();
                txtFullName.Text = row.Cells["Full Name"].Value.ToString();

                // ?. and ?? handle optional fields that may be null
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // Set gender dropdown to match the member's stored gender
                cmbGender.SelectedItem =
                    row.Cells["Gender"].Value?.ToString() ?? "Male";

                // Set join date from grid value
                if (row.Cells["Join Date"].Value != null)
                    dtpJoinDate.Value =
                        Convert.ToDateTime(row.Cells["Join Date"].Value);

                // Set status: "Active" = index 0, anything else = index 1
                cmbStatus.SelectedIndex =
                    row.Cells["Status"].Value.ToString() == "Active" ? 0 : 1;
            }
            catch { }  // Silent catch — minor cell errors don't crash the form
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : ClearForm
        // PURPOSE : Resets all input fields to their default state.
        //           Called after add/update/delete and by btnClear.
        //           Separating this into its own method avoids
        //           repeating 8 lines of reset code in every handler.
        // ──────────────────────────────────────────────────────────
        private void ClearForm()
        {
            txtMemberID.Clear();          // Must clear ID — prevents accidental update
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbGender.SelectedIndex = 0;  // Back to Male
            cmbStatus.SelectedIndex = 0;  // Back to Active
            dtpJoinDate.Value = DateTime.Today;
            txtFullName.Focus();          // Ready for next entry
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnClear_Click
        // TRIGGER : User clicks CLEAR button
        // PURPOSE : Allows staff to reset the form without
        //           performing any database operation
        // ──────────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}