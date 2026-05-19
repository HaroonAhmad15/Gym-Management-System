// ============================================================
// FILE        : MembershipForm.cs
// PURPOSE     : Manages gym membership plan subscriptions.
//               Allows staff to assign, renew, and cancel
//               membership plans. End date is calculated
//               automatically from plan duration.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;
using Gym_Management_System.Models;

namespace Gym_Management_System
{
    public partial class MembershipForm : Form
    {
        // ── Repository Declarations ────────────────────────────────
        // Two repositories needed: one for membership data,
        // one for loading active members into the dropdown.
        private readonly MembershipRepository _repo = new MembershipRepository();
        private readonly MemberRepository _mRepo = new MemberRepository();

        public MembershipForm()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : MembershipForm_Load
        // TRIGGER : Fires when the form opens
        // PURPOSE : Sets defaults and populates all dropdowns
        //           and the membership grid on form open
        // ──────────────────────────────────────────────────────────
        private void MembershipForm_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;       // Default: Active
            dtpStartDate.Value = DateTime.Today; // Default start: today

            // Load dropdowns before the grid so no data is missing
            LoadMembersDropdown();
            LoadPlansDropdown();
            LoadMemberships();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadMembersDropdown
        // PURPOSE : Fills cmbMember with only ACTIVE members.
        //
        // DECISION: Only active members are shown — inactive members
        //           should not be assigned new subscriptions.
        //           DisplayMember shows FullName as visible text,
        //           ValueMember stores MemberID as the hidden value
        //           used when creating the subscription record.
        // ──────────────────────────────────────────────────────────
        private void LoadMembersDropdown()
        {
            try
            {
                var members = _mRepo.GetActiveMembers();

                // DisplayMember = what user sees in dropdown
                cmbMember.DisplayMember = "FullName";
                // ValueMember = what code reads (the hidden ID)
                cmbMember.ValueMember = "MemberID";
                cmbMember.DataSource = members;

                // Set to -1 so no member is pre-selected by default
                cmbMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadPlansDropdown
        // PURPOSE : Fills cmbPlan with available membership plans.
        //           Plans are: Monthly, Quarterly, Yearly
        // ──────────────────────────────────────────────────────────
        private void LoadPlansDropdown()
        {
            try
            {
                var plans = _repo.GetAllPlans();
                cmbPlan.DisplayMember = "PlanName";  // Shows "Monthly" etc.
                cmbPlan.ValueMember = "PlanID";    // Hidden ID for queries
                cmbPlan.DataSource = plans;
                cmbPlan.SelectedIndex = -1;          // No default selection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading plans: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : cmbPlan_SelectedIndexChanged
        // TRIGGER : User selects or changes plan in dropdown
        // PURPOSE : KEY FEATURE — automatically calculates and
        //           displays the membership end date.
        //
        // COMPLEX LOGIC:
        // End date = StartDate + plan.DurationDays
        // Monthly   → StartDate + 30  days
        // Quarterly → StartDate + 90  days
        // Yearly    → StartDate + 365 days
        // This means staff never has to manually calculate expiry.
        // ──────────────────────────────────────────────────────────
        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If no plan selected, reset display labels
            if (cmbPlan.SelectedIndex == -1)
            {
                lblPlanDetails.Text = "Select a plan to see details";
                txtEndDate.Text = "";
                return;
            }

            try
            {
                int planID = Convert.ToInt32(cmbPlan.SelectedValue);

                // Fetch full plan details from database to get DurationDays
                var plan = _repo.GetPlanByID(planID);

                if (plan != null)
                {
                    // Show plan summary for staff confirmation
                    lblPlanDetails.Text =
                        plan.PlanName + "  |  " +
                        plan.DurationDays + " days  |  " +
                        "Rs." + plan.Price.ToString("N0");

                    // KEY CALCULATION: EndDate = StartDate + DurationDays
                    // AddDays() handles month-end and year-end correctly
                    DateTime end = dtpStartDate.Value.AddDays(plan.DurationDays);

                    // Display in dd/MM/yyyy format for easy reading
                    txtEndDate.Text = end.ToString("dd/MM/yyyy");
                }
            }
            catch { }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : dtpStartDate_ValueChanged
        // TRIGGER : Staff changes the start date picker value
        // PURPOSE : Recalculates end date whenever start date changes.
        //           Reuses the plan selection logic by calling the
        //           same method — avoids duplicating calculation code.
        // ──────────────────────────────────────────────────────────
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Recalculate end date using new start date
            // by reusing the plan selection event handler
            cmbPlan_SelectedIndexChanged(sender, e);
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadMemberships
        // PURPOSE : Loads all membership records into the grid.
        //           Uses JOIN query (inside repository) to show
        //           member names and plan names instead of raw IDs.
        // ──────────────────────────────────────────────────────────
        private void LoadMemberships()
        {
            try
            {
                DataTable dt = _repo.GetAllMembershipsTable();
                dgvMemberships.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Total: " + dt.Rows.Count + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : StyleGrid
        // PURPOSE : Applies consistent professional grid styling
        // ──────────────────────────────────────────────────────────
        private void StyleGrid()
        {
            dgvMemberships.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgvMemberships.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMemberships.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvMemberships.ColumnHeadersHeight = 35;
            dgvMemberships.RowTemplate.Height = 30;
            dgvMemberships.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvMemberships.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvMemberships.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvMemberships.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnAssign_Click
        // TRIGGER : User clicks ASSIGN PLAN button
        // PURPOSE : Creates a new membership subscription record.
        //
        // IMPORTANT DECISIONS:
        // 1. Checks for existing active membership first — warns staff
        //    before creating a second active subscription
        // 2. End date calculated here using plan.DurationDays,
        //    consistent with what cmbPlan_SelectedIndexChanged showed
        // 3. MemberMembership object packages all values cleanly
        // ──────────────────────────────────────────────────────────
        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Both member and plan must be selected before assigning
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a plan!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int memberID = Convert.ToInt32(cmbMember.SelectedValue);
                int planID = Convert.ToInt32(cmbPlan.SelectedValue);

                // Check if member already has an active membership
                // SQL: SELECT COUNT(*) WHERE MemberID=X AND Status='Active'
                if (_repo.HasActiveMembership(memberID))
                {
                    var dr = MessageBox.Show(
                        "This member already has an active membership.\n" +
                        "Assign another one anyway?",
                        "Already Has Membership",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                }

                // Calculate end date from plan duration
                var plan = _repo.GetPlanByID(planID);
                DateTime end = dtpStartDate.Value.AddDays(plan.DurationDays);

                // Build the subscription object for the repository
                var sub = new MemberMembership
                {
                    MemberID = memberID,
                    PlanID = planID,
                    StartDate = dtpStartDate.Value,
                    EndDate = end
                    // Status defaults to 'Active' inside the INSERT SQL
                };

                if (_repo.AssignPlan(sub))
                {
                    MessageBox.Show(
                        "Membership assigned!\nExpires: " +
                        end.ToString("dd/MM/yyyy"),
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadMemberships();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnRenew_Click
        // TRIGGER : User clicks RENEW button
        // PURPOSE : Renews a membership — cancels the old one and
        //           creates a fresh Active subscription.
        //
        // IMPORTANT DECISION: Two-step process:
        // Step 1 → Cancel the existing subscription (Status='Cancelled')
        // Step 2 → Insert a new subscription (Status='Active')
        // We keep the old record for history — it is NOT deleted.
        // ──────────────────────────────────────────────────────────
        private void btnRenew_Click(object sender, EventArgs e)
        {
            // Staff must click a row to load the SubID for cancellation
            if (txtSubID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a membership row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a plan!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int planID = Convert.ToInt32(cmbPlan.SelectedValue);
                var plan = _repo.GetPlanByID(planID);
                DateTime end = dtpStartDate.Value.AddDays(plan.DurationDays);

                // STEP 1: Cancel the existing membership (keeps record in history)
                _repo.CancelMembership(Convert.ToInt32(txtSubID.Text));

                // Get MemberID from the selected grid row for new subscription
                int memberID = Convert.ToInt32(
                    dgvMemberships.SelectedRows[0].Cells["ID"].Value);

                // STEP 2: Create new Active subscription
                var sub = new MemberMembership
                {
                    MemberID = memberID,
                    PlanID = planID,
                    StartDate = dtpStartDate.Value,
                    EndDate = end
                };

                if (_repo.AssignPlan(sub))
                {
                    MessageBox.Show(
                        "Membership renewed!\nNew expiry: " +
                        end.ToString("dd/MM/yyyy"),
                        "Renewed", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadMemberships();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnCancel_Click
        // TRIGGER : User clicks CANCEL PLAN button
        // PURPOSE : Marks a membership as Cancelled without deleting.
        //
        // DECISION: Status is changed to 'Cancelled' rather than
        //           deleting the row. This preserves subscription
        //           history for future reference and reporting.
        // ──────────────────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtSubID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show(
                "Cancel this membership?",
                "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // Changes Status='Cancelled' — record is kept in database
                    _repo.CancelMembership(Convert.ToInt32(txtSubID.Text));
                    MessageBox.Show("Membership cancelled.",
                        "Done", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadMemberships();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnSearch_Click
        // TRIGGER : User clicks SEARCH button
        // PURPOSE : Filters membership grid by member name
        // ──────────────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                LoadMemberships();
                return;
            }
            try
            {
                DataTable dt = _repo.SearchMemberships(txtSearch.Text.Trim());
                dgvMemberships.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Found: " + dt.Rows.Count + " records";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMemberships();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : dgvMemberships_CellClick
        // TRIGGER : User clicks a row in the membership grid
        // PURPOSE : Loads the SubID and Status of the selected
        //           membership so RENEW and CANCEL know which row
        //           to operate on
        // ──────────────────────────────────────────────────────────
        private void dgvMemberships_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvMemberships.Rows[e.RowIndex];
                // Load SubID — used by CANCEL and RENEW buttons
                txtSubID.Text = row.Cells["ID"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                cmbStatus.SelectedItem = status;
            }
            catch { }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : ClearForm
        // PURPOSE : Resets all form fields to their default state.
        //           Reloads dropdowns to ensure latest member/plan
        //           data is always available after any operation.
        // ──────────────────────────────────────────────────────────
        private void ClearForm()
        {
            txtSubID.Clear();
            txtEndDate.Text = "Select plan and start date first";
            cmbStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            lblPlanDetails.Text = "Select a plan to see details";

            // Reload dropdowns so any newly added members/plans appear
            LoadMembersDropdown();
            LoadPlansDropdown();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}