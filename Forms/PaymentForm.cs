// ============================================================
// FILE        : PaymentForm.cs
// PURPOSE     : Records and manages gym payment transactions.
//               Shows revenue summaries and supports Cash,
//               Card, and Online payment methods.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;
using Gym_Management_System.Models;

namespace Gym_Management_System
{
    public partial class PaymentForm : Form
    {
        private readonly PaymentRepository _repo = new PaymentRepository();
        private readonly MemberRepository _mRepo = new MemberRepository();

        public PaymentForm()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : PaymentForm_Load
        // TRIGGER : Fires when the form opens
        // PURPOSE : Sets defaults, loads members, payments, and stats
        // ──────────────────────────────────────────────────────────
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            cmbMethod.SelectedIndex = 0;    // Default: Cash
            dtpDate.Value = DateTime.Today;
            LoadMembersDropdown();
            LoadPayments();
            LoadStats();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadMembersDropdown
        // PURPOSE : Fills the member dropdown with active members only.
        //           Only active members can make payments.
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
        // METHOD  : cmbMember_SelectedIndexChanged
        // TRIGGER : Staff selects a member from the dropdown
        // PURPOSE : Shows member's active plan information to help
        //           staff confirm the correct payment amount
        // ──────────────────────────────────────────────────────────
        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1) return;

            try
            {
                // Display guidance label — staff knows plan is loaded
                lblMemberInfo.Text = "Member selected — enter payment amount";
            }
            catch { }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadStats
        // PURPOSE : Fetches and displays three revenue statistics.
        //           Called on load and after every payment save/delete
        //           to keep the numbers current.
        // ──────────────────────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                // Total Revenue: SUM(Amount) from all payments ever
                lblTotalAmount.Text =
                    "Rs. " + _repo.GetTotalRevenue().ToString("N0");

                // Monthly Revenue: SUM(Amount) for current month only
                lblMonthAmount.Text =
                    "Rs. " + _repo.GetMonthlyRevenue().ToString("N0");

                // Total number of payment records
                lblPaymentCount.Text = _repo.GetTotalCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadPayments
        // PURPOSE : Loads all payment records into the DataGridView.
        //           Repository JOINs Members table to show names.
        // ──────────────────────────────────────────────────────────
        private void LoadPayments()
        {
            try
            {
                DataTable dt = _repo.GetAllPaymentsTable();
                dgvPayments.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Total: " + dt.Rows.Count + " payments";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvPayments.ColumnHeadersHeight = 35;
            dgvPayments.RowTemplate.Height = 30;
            dgvPayments.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvPayments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnSave_Click
        // TRIGGER : User clicks SAVE PAYMENT button
        // PURPOSE : Validates amount, creates Payment object,
        //           and inserts it into the Payments table.
        //
        // IMPORTANT DECISIONS:
        // 1. decimal.TryParse is used instead of Convert.ToDecimal
        //    because TryParse does NOT throw an exception on invalid
        //    input — it returns false safely
        // 2. amount <= 0 check prevents zero or negative payments
        // 3. "m" suffix on 0m declares decimal literal (not double)
        // ──────────────────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the amount!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            // Validate amount is a real positive number.
            // TryParse safely returns false for "abc" or empty without crashing.
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount!",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            try
            {
                // Package all payment details into a Payment model object
                var payment = new Payment
                {
                    MemberID = Convert.ToInt32(cmbMember.SelectedValue),
                    Amount = amount,                              // validated decimal
                    PaymentDate = dtpDate.Value,
                    PaymentMethod = cmbMethod.SelectedItem.ToString(),  // Cash/Card/Online
                    Notes = txtNotes.Text.Trim()
                };

                if (_repo.AddPayment(payment))
                {
                    MessageBox.Show(
                        "Payment of Rs." + amount.ToString("N0") +
                        " saved successfully!",
                        "Payment Saved", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadPayments();  // Refresh grid
                    LoadStats();     // Update revenue totals immediately
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
        // PURPOSE : Removes an incorrect payment record.
        //           Confirmation required — deletion is permanent.
        // ──────────────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPaymentID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a payment row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show(
                "Delete this payment record?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _repo.DeletePayment(Convert.ToInt32(txtPaymentID.Text));
                    MessageBox.Show("Payment deleted.",
                        "Deleted", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadPayments();
                    LoadStats(); // Update revenue stats after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                LoadPayments();
                return;
            }
            try
            {
                DataTable dt = _repo.SearchPayments(txtSearch.Text.Trim());
                dgvPayments.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Found: " + dt.Rows.Count + " payments";
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
            LoadPayments();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : dgvPayments_CellClick
        // TRIGGER : User clicks a row in the payment grid
        // PURPOSE : Loads payment details into form for review/delete
        // ──────────────────────────────────────────────────────────
        private void dgvPayments_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvPayments.Rows[e.RowIndex];
                txtPaymentID.Text = row.Cells["ID"].Value.ToString();
                txtAmount.Text = row.Cells["Amount (Rs.)"].Value.ToString();
                txtNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";
                string method = row.Cells["Method"].Value.ToString();
                cmbMethod.SelectedItem = method;
            }
            catch { }
        }

        private void ClearForm()
        {
            txtPaymentID.Clear();
            txtAmount.Clear();
            txtNotes.Clear();
            cmbMethod.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            lblMemberInfo.Text = "Select a member to see their plan";
            LoadMembersDropdown();   // Refresh member list
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}