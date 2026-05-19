// ============================================================
// FILE        : PaymentRepository.cs
// DESCRIPTION : Handles all database operations for the Payments
//               table. Manages payment recording, deletion,
//               searching, and revenue calculations.
// ============================================================

using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gym_Management_System.Models;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for the Payments table in GymDB.
    /// Inherits BaseRepository for shared database methods.
    /// Used by: PaymentForm, Dashboard (revenue stat card), ReportsForm.
    /// </summary>
    public class PaymentRepository : BaseRepository
    {
        // ── CREATE Operation ───────────────────────────────────────

        /// <summary>
        /// Inserts a new payment transaction into the Payments table.
        /// PaymentID is NOT set — MySQL AUTO_INCREMENT assigns it.
        /// Amount uses decimal type for exact financial accuracy.
        /// </summary>
        /// <param name="payment">Payment object filled from PaymentForm fields.</param>
        /// <returns>True if payment was saved successfully.</returns>
        public bool AddPayment(Payment payment)
        {
            string sql =
                "INSERT INTO Payments " +
                "(MemberID, Amount, PaymentDate, PaymentMethod, Notes) " +
                "VALUES (@mid, @amt, @date, @method, @notes)";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@mid",    payment.MemberID),
                new MySqlParameter("@amt",    payment.Amount),   // decimal — exact value
                new MySqlParameter("@date",   payment.PaymentDate.ToString("yyyy-MM-dd")),
                new MySqlParameter("@method", payment.PaymentMethod), // Cash/Card/Online
                new MySqlParameter("@notes",  payment.Notes ?? "") // null-safe default
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── DELETE Operation ───────────────────────────────────────

        /// <summary>
        /// Deletes a payment record from the Payments table.
        /// Used when staff removes an incorrect payment entry.
        /// </summary>
        /// <param name="paymentID">The PaymentID of the record to delete.</param>
        /// <returns>True if deleted successfully.</returns>
        public bool DeletePayment(int paymentID)
        {
            string sql = "DELETE FROM Payments WHERE PaymentID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", paymentID)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── READ Operations ────────────────────────────────────────

        /// <summary>
        /// Gets all payment records as a DataTable using JOIN.
        /// JOINs Payments and Members tables to show member name
        /// instead of just MemberID number.
        /// Ordered by newest payment first (DESC).
        /// </summary>
        /// <returns>DataTable ready to bind to dgvPayments.</returns>
        public DataTable GetAllPaymentsTable()
        {
            // JOIN with Members to get FullName instead of just MemberID
            string sql =
                "SELECT p.PaymentID AS 'ID', " +
                "m.FullName AS 'Member Name', " +
                "p.Amount AS 'Amount (Rs.)', " +
                "p.PaymentMethod AS 'Method', " +
                "p.PaymentDate AS 'Date', " +
                "p.Notes AS 'Notes' " +
                "FROM Payments p " +
                "JOIN Members m ON p.MemberID = m.MemberID " +
                "ORDER BY p.PaymentID DESC"; // newest first

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Searches payment records by member name.
        /// Used when staff types in txtSearch on PaymentForm.
        /// </summary>
        /// <param name="keyword">Search term from txtSearch.</param>
        /// <returns>DataTable of matching payment records.</returns>
        public DataTable SearchPayments(string keyword)
        {
            string sql =
                "SELECT p.PaymentID AS 'ID', m.FullName AS 'Member Name', " +
                "p.Amount AS 'Amount (Rs.)', p.PaymentMethod AS 'Method', " +
                "p.PaymentDate AS 'Date', p.Notes AS 'Notes' " +
                "FROM Payments p " +
                "JOIN Members m ON p.MemberID = m.MemberID " +
                "WHERE m.FullName LIKE @k ORDER BY p.PaymentID DESC";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@k", "%" + keyword + "%")
            };

            return ExecuteReader(sql, p);
        }

        // ── Revenue Calculations ───────────────────────────────────

        /// <summary>
        /// Calculates total revenue from ALL payments ever recorded.
        /// IFNULL(SUM, 0) returns 0 instead of NULL if no payments exist.
        /// Used by Dashboard "Total Revenue" stat card and PaymentForm stats.
        /// </summary>
        /// <returns>Total revenue as decimal (exact financial value).</returns>
        public decimal GetTotalRevenue()
        {
            // IFNULL prevents NULL result when table is empty
            object result = ExecuteScalar(
                "SELECT IFNULL(SUM(Amount), 0) FROM Payments");

            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// Calculates revenue for the CURRENT month only.
        /// MONTH() and YEAR() extract from PaymentDate for filtering.
        /// Used by PaymentForm "This Month" stat card.
        /// </summary>
        /// <returns>This month's total revenue as decimal.</returns>
        public decimal GetMonthlyRevenue()
        {
            // Filter by current month AND current year
            object result = ExecuteScalar(
                "SELECT IFNULL(SUM(Amount), 0) FROM Payments " +
                "WHERE MONTH(PaymentDate) = MONTH(CURDATE()) " +
                "AND YEAR(PaymentDate) = YEAR(CURDATE())");

            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// Gets the total number of payment records.
        /// Used by PaymentForm "Payment Count" stat card.
        /// </summary>
        /// <returns>Total payment count as integer.</returns>
        public int GetTotalCount()
        {
            return Convert.ToInt32(
                ExecuteScalar("SELECT COUNT(*) FROM Payments"));
        }
    }
}