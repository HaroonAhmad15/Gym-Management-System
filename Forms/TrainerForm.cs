// ============================================================
// FILE        : TrainerForm.cs
// PURPOSE     : Manages gym trainer profiles including their
//               specialization and salary information.
//               Full CRUD operations on the Trainers table.
// ============================================================

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gym_Management_System.Database;
using Gym_Management_System.Models;

namespace Gym_Management_System
{
    public partial class TrainerForm : Form
    {
        private readonly TrainerRepository _repo = new TrainerRepository();

        public TrainerForm()
        {
            InitializeComponent();
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0; // Default: Active
            LoadTrainers();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoadTrainers
        // PURPOSE : Fetches all trainer records and binds to grid.
        //           Called on load and after every CUD operation.
        // ──────────────────────────────────────────────────────────
        private void LoadTrainers()
        {
            try
            {
                DataTable dt = _repo.GetAllTrainersTable();
                dgvTrainers.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Total: " + dt.Rows.Count + " trainers";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            dgvTrainers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 42, 74);
            dgvTrainers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTrainers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvTrainers.ColumnHeadersHeight = 35;
            dgvTrainers.RowTemplate.Height = 30;
            dgvTrainers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 242, 245);
            dgvTrainers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 130, 10);
            dgvTrainers.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnAdd_Click
        // TRIGGER : User clicks ADD TRAINER button
        // PURPOSE : Validates input and inserts new trainer record.
        //
        // IMPORTANT DECISION:
        // Salary field uses decimal.TryParse — it is an optional
        // field. If staff leaves it blank, salary defaults to 0.
        // If they type "abc", TryParse quietly returns 0 instead
        // of throwing an exception.
        // ──────────────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter trainer's full name!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter phone number!",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                // Salary is optional — default to 0 if blank or invalid
                decimal salary = 0;
                if (txtSalary.Text.Trim() != "")
                    decimal.TryParse(txtSalary.Text.Trim(), out salary);

                var trainer = new Trainer
                {
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Specialty = txtSpecialty.Text.Trim(),
                    Salary = salary,
                    IsActive = cmbStatus.SelectedIndex == 0
                };

                if (_repo.AddTrainer(trainer))
                {
                    MessageBox.Show("Trainer added successfully!",
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadTrainers();
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
        // PURPOSE : Updates trainer info. TrainerID from txtTrainerID
        //           (hidden field loaded by grid click) identifies
        //           which row to update in the database.
        // ──────────────────────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTrainerID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a trainer row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal salary = 0;
                if (txtSalary.Text.Trim() != "")
                    decimal.TryParse(txtSalary.Text.Trim(), out salary);

                var trainer = new Trainer
                {
                    TrainerID = Convert.ToInt32(txtTrainerID.Text), // Identifies row
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Specialty = txtSpecialty.Text.Trim(),
                    Salary = salary,
                    IsActive = cmbStatus.SelectedIndex == 0
                };

                if (_repo.UpdateTrainer(trainer))
                {
                    MessageBox.Show("Trainer updated successfully!",
                        "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadTrainers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTrainerID.Text.Trim() == "")
            {
                MessageBox.Show("Please click on a trainer row first!",
                    "No Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("Delete this trainer?",
                "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _repo.DeleteTrainer(Convert.ToInt32(txtTrainerID.Text));
                    MessageBox.Show("Trainer deleted.",
                        "Deleted", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                    LoadTrainers();
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
                LoadTrainers();
                return;
            }
            try
            {
                // Searches in both FullName and Specialty columns
                DataTable dt = _repo.SearchTrainers(txtSearch.Text.Trim());
                dgvTrainers.DataSource = dt;
                StyleGrid();
                lblCount.Text = "Found: " + dt.Rows.Count + " trainers";
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
            LoadTrainers();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : dgvTrainers_CellClick
        // TRIGGER : User clicks a row in the trainers grid
        // PURPOSE : Loads trainer data into form fields for editing.
        //           Same pattern as MemberForm's CellClick.
        // ──────────────────────────────────────────────────────────
        private void dgvTrainers_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvTrainers.Rows[e.RowIndex];
                txtTrainerID.Text = row.Cells["ID"].Value.ToString();
                txtFullName.Text = row.Cells["Full Name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtSpecialty.Text = row.Cells["Specialty"].Value?.ToString() ?? "";
                txtSalary.Text = row.Cells["Salary (Rs.)"].Value?.ToString() ?? "";
                cmbStatus.SelectedIndex =
                    row.Cells["Status"].Value.ToString() == "Active" ? 0 : 1;
            }
            catch { }
        }

        private void ClearForm()
        {
            txtTrainerID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtSpecialty.Clear();
            txtSalary.Clear();
            cmbStatus.SelectedIndex = 0;
            txtFullName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}