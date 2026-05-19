// ============================================================
// FILE        : MembershipRepository.cs
// DESCRIPTION : Handles all database operations for
//               MembershipPlans and MemberMemberships tables.
//               Manages plan assignment, renewal, cancellation,
//               and expiry tracking.
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Gym_Management_System.Models;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for MembershipPlans and MemberMemberships tables.
    /// Inherits BaseRepository for shared database methods.
    /// Used by: MembershipForm, Dashboard (expiry alerts), ReportsForm.
    /// </summary>
    public class MembershipRepository : BaseRepository
    {
        // ── Plan Operations ────────────────────────────────────────

        /// <summary>
        /// Gets all available membership plans from MembershipPlans table.
        /// Returns as List so it can bind to cmbPlan dropdown.
        /// Current plans: Monthly (30d, Rs.2500), Quarterly (90d, Rs.6500),
        ///                Yearly (365d, Rs.20000).
        /// </summary>
        /// <returns>List of MembershipPlan objects ordered by price.</returns>
        public List<MembershipPlan> GetAllPlans()
        {
            string sql =
                "SELECT PlanID, PlanName, DurationDays, Price " +
                "FROM MembershipPlans ORDER BY Price";

            return ExecuteList(sql, r => new MembershipPlan
            {
                PlanID = GetInt(r, "PlanID"),
                PlanName = GetString(r, "PlanName"),
                DurationDays = GetInt(r, "DurationDays"),
                Price = GetDecimal(r, "Price")
            });
        }

        /// <summary>
        /// Gets one specific plan by PlanID.
        /// Used in MembershipForm when a plan is selected from dropdown.
        /// DurationDays from this object is used to calculate EndDate:
        ///   EndDate = StartDate.AddDays(plan.DurationDays)
        /// </summary>
        /// <param name="planID">The ID of the plan to retrieve.</param>
        /// <returns>MembershipPlan object, or null if not found.</returns>
        public MembershipPlan GetPlanByID(int planID)
        {
            string sql =
                "SELECT PlanID, PlanName, DurationDays, Price " +
                "FROM MembershipPlans WHERE PlanID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", planID)
            };

            return ExecuteSingle(sql, r => new MembershipPlan
            {
                PlanID = GetInt(r, "PlanID"),
                PlanName = GetString(r, "PlanName"),
                DurationDays = GetInt(r, "DurationDays"),
                Price = GetDecimal(r, "Price")
            }, p);
        }

        // ── Membership READ Operations ─────────────────────────────

        /// <summary>
        /// Gets all membership records as a DataTable using JOIN.
        /// JOINs three tables: MemberMemberships + Members + MembershipPlans
        /// to show member name and plan name instead of just IDs.
        /// DATEDIFF calculates days remaining until expiry.
        /// </summary>
        /// <returns>DataTable ready to bind to dgvMemberships.</returns>
        public DataTable GetAllMembershipsTable()
        {
            // JOIN combines three tables so we can show names, not just IDs
            // DATEDIFF(EndDate, CURDATE()) = days left until expiry
            string sql =
                "SELECT mm.SubID AS 'ID', " +
                "m.FullName AS 'Member Name', " +
                "p.PlanName AS 'Plan', " +
                "p.Price AS 'Price (Rs.)', " +
                "mm.StartDate AS 'Start Date', " +
                "mm.EndDate AS 'End Date', " +
                "DATEDIFF(mm.EndDate, CURDATE()) AS 'Days Left', " +
                "mm.Status AS 'Status' " +
                "FROM MemberMemberships mm " +
                "JOIN Members m ON mm.MemberID = m.MemberID " +         // get member name
                "JOIN MembershipPlans p ON mm.PlanID = p.PlanID " +     // get plan name
                "ORDER BY mm.SubID DESC";

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Searches memberships by member name.
        /// LIKE '%keyword%' finds matches anywhere in the name.
        /// </summary>
        /// <param name="keyword">Search term from txtSearch.</param>
        /// <returns>Filtered DataTable of matching memberships.</returns>
        public DataTable SearchMemberships(string keyword)
        {
            string sql =
                "SELECT mm.SubID AS 'ID', m.FullName AS 'Member Name', " +
                "p.PlanName AS 'Plan', p.Price AS 'Price (Rs.)', " +
                "mm.StartDate AS 'Start Date', mm.EndDate AS 'End Date', " +
                "DATEDIFF(mm.EndDate, CURDATE()) AS 'Days Left', " +
                "mm.Status AS 'Status' " +
                "FROM MemberMemberships mm " +
                "JOIN Members m ON mm.MemberID = m.MemberID " +
                "JOIN MembershipPlans p ON mm.PlanID = p.PlanID " +
                "WHERE m.FullName LIKE @k ORDER BY mm.SubID DESC";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@k", "%" + keyword + "%")
            };

            return ExecuteReader(sql, p);
        }

        /// <summary>
        /// Gets memberships expiring within the next 7 days.
        /// Used by Dashboard Expiring Soon grid and Reports Expiring report.
        /// DATEDIFF(EndDate, CURDATE()) BETWEEN 0 AND 7 = 0 to 7 days remaining.
        /// </summary>
        /// <returns>DataTable of soon-to-expire memberships.</returns>
        public DataTable GetExpiringMemberships()
        {
            string sql =
                "SELECT m.FullName AS 'Member', " +
                "p.PlanName AS 'Plan', " +
                "mm.EndDate AS 'Expires On', " +
                "DATEDIFF(mm.EndDate, CURDATE()) AS 'Days Left' " +
                "FROM MemberMemberships mm " +
                "JOIN Members m ON mm.MemberID = m.MemberID " +
                "JOIN MembershipPlans p ON mm.PlanID = p.PlanID " +
                "WHERE mm.Status = 'Active' " +
                // Only show memberships that expire within 7 days
                "AND DATEDIFF(mm.EndDate, CURDATE()) BETWEEN 0 AND 7 " +
                "ORDER BY mm.EndDate ASC"; // Soonest expiry first

            return ExecuteReader(sql);
        }

        // ── Membership WRITE Operations ────────────────────────────

        /// <summary>
        /// Assigns a membership plan to a member.
        /// Inserts a new row into MemberMemberships table.
        /// Status defaults to 'Active' — the new subscription is immediately valid.
        /// EndDate is calculated by MembershipForm before calling this method:
        ///   EndDate = StartDate.AddDays(plan.DurationDays)
        /// </summary>
        /// <param name="sub">MemberMembership object with all required values.</param>
        /// <returns>True if assigned successfully.</returns>
        public bool AssignPlan(MemberMembership sub)
        {
            string sql =
                "INSERT INTO MemberMemberships " +
                "(MemberID, PlanID, StartDate, EndDate, Status) " +
                "VALUES (@mid, @pid, @start, @end, 'Active')";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@mid",   sub.MemberID),
                new MySqlParameter("@pid",   sub.PlanID),
                // Store dates in YYYY-MM-DD format for MySQL
                new MySqlParameter("@start", sub.StartDate.ToString("yyyy-MM-dd")),
                new MySqlParameter("@end",   sub.EndDate.ToString("yyyy-MM-dd"))
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        /// <summary>
        /// Cancels an existing membership by changing Status to 'Cancelled'.
        /// The row is NOT deleted — we keep history of all subscriptions.
        /// This is called when staff clicks CANCEL or before RENEW (cancel old first).
        /// </summary>
        /// <param name="subID">The SubID of the subscription to cancel.</param>
        /// <returns>True if status was updated successfully.</returns>
        public bool CancelMembership(int subID)
        {
            // Update Status — do NOT delete the row
            string sql =
                "UPDATE MemberMemberships SET Status = 'Cancelled' " +
                "WHERE SubID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", subID)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        /// <summary>
        /// Checks if a member already has an Active membership.
        /// Called before assigning a new plan to warn the staff.
        /// COUNT(*) > 0 means at least one active subscription exists.
        /// </summary>
        /// <param name="memberID">The ID of the member to check.</param>
        /// <returns>True if member has an active membership, false if available.</returns>
        public bool HasActiveMembership(int memberID)
        {
            string sql =
                "SELECT COUNT(*) FROM MemberMemberships " +
                "WHERE MemberID = @mid AND Status = 'Active'";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@mid", memberID)
            };

            // Convert COUNT(*) result to int and check if greater than 0
            return Convert.ToInt32(ExecuteScalar(sql, p)) > 0;
        }
    }
}