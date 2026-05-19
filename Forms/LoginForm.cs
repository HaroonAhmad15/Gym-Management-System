// ============================================================
// FILE        : LoginForm.cs
// PURPOSE     : First screen of the application.
//               Authenticates admin/staff before granting
//               access to the system.
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gym_Management_System.Database;

namespace Gym_Management_System
{
    public partial class LoginForm : Form
    {
        // ── Repository Declaration ─────────────────────────────────
        // UserRepository handles all database operations for Users table.
        // 'readonly' means this object cannot be replaced after creation.
        // Created once here so it is reused for every login attempt.
        private readonly UserRepository _userRepo = new UserRepository();

        // ── Constructor ────────────────────────────────────────────
        public LoginForm()
        {
            InitializeComponent(); // Loads all controls designed in Designer
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : LoginForm_Load
        // TRIGGER : Fires automatically when the form first opens
        // PURPOSE : Prepares the form visually before user interacts
        // ──────────────────────────────────────────────────────────
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // DECISION: Make the icon label circular using GraphicsPath.
            // By default labels are rectangular. We clip the region to
            // an ellipse shape so it looks like a round icon badge.
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, lblIcon.Width, lblIcon.Height);
            lblIcon.Region = new Region(path);

            // Change cursor to hand pointer when hovering over the button.
            // This signals to the user that the button is clickable.
            btnLogin.Cursor = Cursors.Hand;

            // Automatically focus the username field so the user can
            // start typing immediately without clicking first.
            txtUsername.Focus();
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : btnLogin_Click
        // TRIGGER : User clicks LOGIN button
        // PURPOSE : Validates input, calls repository to check
        //           credentials, then opens Dashboard or shows error
        //
        // IMPORTANT DECISIONS:
        // 1. .Trim() removes leading/trailing spaces — prevents login
        //    failure due to accidental spaces typed by user
        // 2. try-catch-finally pattern — finally block ALWAYS runs,
        //    ensuring button is re-enabled even if an exception occurs
        // 3. Button is disabled during check to prevent double-clicking
        // ──────────────────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Read input — .Trim() removes accidental leading/trailing spaces
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validation: both fields must be filled before querying database.
            // Checking early avoids a wasted database round-trip.
            if (username == "" || password == "")
            {
                MessageBox.Show(
                    "Please enter your username and password!",
                    "Empty Fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Stop here — do not reach the database
            }

            // Disable button to prevent user from clicking LOGIN twice
            // while the database query is still running.
            btnLogin.Enabled = false;
            btnLogin.Text = "Checking...";

            try
            {
                // Ask UserRepository to check credentials against MySQL.
                // Repository returns a User object if found, or null if not.
                // All SQL is inside the repository — the form only gets result.
                var user = _userRepo.Authenticate(username, password);

                if (user != null)
                {
                    // Login successful — credentials matched a row in Users table
                    MessageBox.Show(
                        "Welcome back, " + user.Username + "!",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Open Dashboard and hide (not close) this form.
                    // We hide instead of close so that if user logs out,
                    // they return to login without restarting the application.
                    Dashboard dashForm = new Dashboard();
                    dashForm.Show();
                    this.Hide();
                }
                else
                {
                    // Login failed — no matching row found in Users table
                    MessageBox.Show(
                        "Incorrect username or password.\nPlease try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Clear password box for security and retry convenience.
                    // Do NOT clear username — user only needs to retype password.
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                // This catches database connection failures.
                // Common causes: MySQL service not running, wrong password
                // in DbConnection.cs, or GymDB database does not exist.
                MessageBox.Show(
                    "Connection Error: " + ex.Message +
                    "\n\nCheck:\n" +
                    "1. MySQL service is running\n" +
                    "2. Password is correct in DbConnection.cs",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // IMPORTANT: 'finally' block always executes — success or failure.
                // This guarantees the button is re-enabled so the user
                // can try again, even if an unexpected exception occurred.
                btnLogin.Enabled = true;
                btnLogin.Text = "LOGIN";
            }
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : txtUsername_KeyDown
        // TRIGGER : User presses any key inside the Username textbox
        // PURPOSE : Pressing ENTER moves focus to password field.
        //           This improves keyboard navigation — user does not
        //           need to move hand to mouse between fields.
        // ──────────────────────────────────────────────────────────
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus(); // Jump to password box on Enter
        }

        // ──────────────────────────────────────────────────────────
        // METHOD  : txtPassword_KeyDown
        // TRIGGER : User presses any key inside the Password textbox
        // PURPOSE : Pressing ENTER in password box triggers login —
        //           same as clicking the LOGIN button.
        //           Most users expect Enter to submit a login form.
        // ──────────────────────────────────────────────────────────
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e); // Reuse same login logic
        }
    }
}