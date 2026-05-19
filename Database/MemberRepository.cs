// ============================================================
// FILE        : MemberRepository.cs
// DESCRIPTION : Handles all database operations for the Members
//               table. Provides full CRUD (Create, Read, Update,
//               Delete) and search functionality.
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Gym_Management_System.Models;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for the Members table in GymDB.
    /// Inherits BaseRepository for shared database methods.
    /// Used by: MemberForm, Dashboard, ReportsForm.
    /// </summary>
    public class MemberRepository : BaseRepository
    {
        // ── Private Mapper ─────────────────────────────────────────

        /// <summary>
        /// Maps one MySqlDataReader row to a Member model object.
        /// Uses safe helper methods (GetInt, GetString, etc.)
        /// that handle NULL database values without throwing exceptions.
        /// </summary>
        private Member MapMember(MySqlDataReader r)
        {
            return new Member
            {
                MemberID = GetInt(r, "MemberID"),
                FullName = GetString(r, "FullName"),
                Phone = GetString(r, "Phone"),
                Email = GetString(r, "Email"),
                Gender = GetString(r, "Gender"),
                JoinDate = GetDateTime(r, "JoinDate"),
                IsActive = GetBoolean(r, "IsActive")
            };
        }

        // ── READ Operations ────────────────────────────────────────

        /// <summary>
        /// Gets all members as a List of Member objects.
        /// Used by dropdowns in MembershipForm, PaymentForm,
        /// and AttendanceForm that need member names and IDs.
        /// </summary>
        /// <returns>List of all Member objects ordered by name.</returns>
        public List<Member> GetAllMembers()
        {
            string sql =
                "SELECT MemberID, FullName, Phone, Email, " +
                "Gender, JoinDate, IsActive " +
                "FROM Members ORDER BY MemberID DESC";

            return ExecuteList(sql, r => MapMember(r));
        }

        /// <summary>
        /// Gets only ACTIVE members (IsActive = 1).
        /// Used by Membership, Payment, and Attendance form dropdowns
        /// because only active members can use gym facilities.
        /// </summary>
        /// <returns>List of active Member objects ordered by FullName.</returns>
        public List<Member> GetActiveMembers()
        {
            string sql =
                "SELECT MemberID, FullName, Phone, Email, " +
                "Gender, JoinDate, IsActive " +
                "FROM Members WHERE IsActive = 1 ORDER BY FullName";

            return ExecuteList(sql, r => MapMember(r));
        }

        /// <summary>
        /// Gets all members formatted as a DataTable for direct grid binding.
        /// Column names are aliased (e.g., "MemberID" → "ID") for
        /// display-friendly headers in the DataGridView.
        /// Status column shows "Active"/"Inactive" instead of 1/0.
        /// </summary>
        /// <returns>DataTable ready to bind to dgvMembers.</returns>
        public DataTable GetAllMembersTable()
        {
            string sql =
                "SELECT MemberID AS 'ID', " +
                "FullName AS 'Full Name', " +
                "Phone AS 'Phone', " +
                "Email AS 'Email', " +
                "Gender AS 'Gender', " +
                "JoinDate AS 'Join Date', " +
                // CASE converts 1→"Active" and 0→"Inactive" for display
                "CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS 'Status' " +
                "FROM Members ORDER BY MemberID DESC";

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Searches members whose FullName or Phone contains the keyword.
        /// LIKE '%keyword%' finds the keyword ANYWHERE in the field.
        /// Example: keyword="Ali" finds "Ali Ahmed", "Muhammad Ali", etc.
        /// </summary>
        /// <param name="keyword">Search term entered in txtSearch.</param>
        /// <returns>DataTable of matching members.</returns>
        public DataTable SearchMembers(string keyword)
        {
            string sql =
                "SELECT MemberID AS 'ID', FullName AS 'Full Name', " +
                "Phone AS 'Phone', Email AS 'Email', Gender AS 'Gender', " +
                "JoinDate AS 'Join Date', " +
                "CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS 'Status' " +
                "FROM Members " +
                "WHERE FullName LIKE @k OR Phone LIKE @k " +
                "ORDER BY FullName";

            // @k is replaced with '%keyword%' — % means any characters
            var p = new MySqlParameter[]
            {
                new MySqlParameter("@k", "%" + keyword + "%")
            };

            return ExecuteReader(sql, p);
        }

        /// <summary>
        /// Gets one specific member by their MemberID.
        /// Used when loading a specific member's details.
        /// </summary>
        /// <param name="memberID">The primary key of the member.</param>
        /// <returns>Member object, or null if not found.</returns>
        public Member GetMemberByID(int memberID)
        {
            string sql =
                "SELECT MemberID, FullName, Phone, Email, " +
                "Gender, JoinDate, IsActive " +
                "FROM Members WHERE MemberID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", memberID)
            };

            return ExecuteSingle(sql, r => MapMember(r), p);
        }

        // ── CREATE Operation ───────────────────────────────────────

        /// <summary>
        /// Inserts a new member record into the Members table.
        /// MemberID is NOT included — MySQL AUTO_INCREMENT assigns it.
        /// IsActive is stored as 1 (true) or 0 (false) in MySQL.
        /// </summary>
        /// <param name="member">Member object filled from MemberForm fields.</param>
        /// <returns>True if insert succeeded, false if failed.</returns>
        public bool AddMember(Member member)
        {
            string sql =
                "INSERT INTO Members " +
                "(FullName, Phone, Email, Gender, JoinDate, IsActive) " +
                "VALUES (@name, @phone, @email, @gender, @date, @active)";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@name",   member.FullName),
                new MySqlParameter("@phone",  member.Phone),
                new MySqlParameter("@email",  member.Email),
                new MySqlParameter("@gender", member.Gender),
                // Format date as YYYY-MM-DD — MySQL DATE format
                new MySqlParameter("@date",   member.JoinDate.ToString("yyyy-MM-dd")),
                // Convert bool to int: true=1 (Active), false=0 (Inactive)
                new MySqlParameter("@active", member.IsActive ? 1 : 0)
            };

            // Returns true if 1 or more rows were inserted
            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── UPDATE Operation ───────────────────────────────────────

        /// <summary>
        /// Updates an existing member record in the Members table.
        /// WHERE MemberID = @id ensures ONLY that specific member is updated.
        /// MemberID comes from the hidden txtMemberID field in MemberForm.
        /// </summary>
        /// <param name="member">Member object with updated values AND existing MemberID.</param>
        /// <returns>True if update succeeded.</returns>
        public bool UpdateMember(Member member)
        {
            string sql =
                "UPDATE Members SET " +
                "FullName = @name, Phone = @phone, Email = @email, " +
                "Gender = @gender, JoinDate = @date, IsActive = @active " +
                "WHERE MemberID = @id";  // Only update THIS member

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id",     member.MemberID), // identifies which row
                new MySqlParameter("@name",   member.FullName),
                new MySqlParameter("@phone",  member.Phone),
                new MySqlParameter("@email",  member.Email),
                new MySqlParameter("@gender", member.Gender),
                new MySqlParameter("@date",   member.JoinDate.ToString("yyyy-MM-dd")),
                new MySqlParameter("@active", member.IsActive ? 1 : 0)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── DELETE Operation ───────────────────────────────────────

        /// <summary>
        /// Deletes a member from the Members table permanently.
        /// WHERE MemberID = @id ensures only the selected member is deleted.
        /// Note: Will fail if member has linked records in other tables (FK constraint).
        /// </summary>
        /// <param name="memberID">The ID of the member to delete.</param>
        /// <returns>True if deleted, false if failed (e.g., FK constraint).</returns>
        public bool DeleteMember(int memberID)
        {
            string sql = "DELETE FROM Members WHERE MemberID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", memberID)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── Count Helpers ──────────────────────────────────────────

        /// <summary>
        /// Counts total number of members in the Members table.
        /// Used by Dashboard to show "Total Members" stat card.
        /// </summary>
        /// <returns>Total member count as integer.</returns>
        public int GetTotalCount()
        {
            // COUNT(*) counts ALL rows regardless of status
            return Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM Members"));
        }

        /// <summary>
        /// Counts members where IsActive = 1 (currently active).
        /// Used by Dashboard to show "Active Members" stat card.
        /// </summary>
        /// <returns>Active member count as integer.</returns>
        public int GetActiveCount()
        {
            return Convert.ToInt32(
                ExecuteScalar("SELECT COUNT(*) FROM Members WHERE IsActive = 1"));
        }
    }
}