// ============================================================
// FILE        : AttendanceRepository.cs
// DESCRIPTION : Handles all database operations for the
//               Attendance table. Records check-ins with exact
//               timestamps and provides daily/historical queries.
// ============================================================

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for the Attendance table in GymDB.
    /// Inherits BaseRepository for shared database methods.
    /// Used by: AttendanceForm, Dashboard (today's count), ReportsForm.
    /// </summary>
    public class AttendanceRepository : BaseRepository
    {
        // ── Mark Attendance ────────────────────────────────────────

        /// <summary>
        /// Records a member's check-in by inserting a row into Attendance table.
        /// CheckInTime is set to DateTime.Now — the exact current date AND time.
        /// Example stored value: '2025-05-10 09:30:45'
        /// MemberID is NOT included in the INSERT — MySQL AUTO_INCREMENT handles AttendanceID.
        /// </summary>
        /// <param name="memberID">The ID of the member checking in.</param>
        /// <returns>True if attendance was marked successfully.</returns>
        public bool MarkAttendance(int memberID)
        {
            string sql =
                "INSERT INTO Attendance (MemberID, CheckInTime) " +
                "VALUES (@mid, @time)";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@mid",  memberID),
                // DateTime.Now captures the EXACT moment of check-in
                new MySqlParameter("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── Duplicate Check ────────────────────────────────────────

        /// <summary>
        /// Checks if a member has already been marked present TODAY.
        /// DATE(CheckInTime) extracts only the date part, ignoring time.
        /// CURDATE() returns today's date in MySQL.
        /// Called by AttendanceForm BEFORE marking attendance.
        /// </summary>
        /// <param name="memberID">The member ID to check.</param>
        /// <returns>True if already marked today, false if not yet marked.</returns>
        public bool IsAlreadyMarkedToday(int memberID)
        {
            string sql =
                "SELECT COUNT(*) FROM Attendance " +
                "WHERE MemberID = @mid " +
                // DATE() extracts date only — ignores time part
                "AND DATE(CheckInTime) = CURDATE()";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@mid", memberID)
            };

            // If COUNT(*) > 0, member is already marked
            return Convert.ToInt32(ExecuteScalar(sql, p)) > 0;
        }

        // ── READ Operations ────────────────────────────────────────

        /// <summary>
        /// Gets attendance records for TODAY ONLY.
        /// DATE(CheckInTime) = CURDATE() filters to current date.
        /// TIME(CheckInTime) shows just the time part for display.
        /// JOINs Members table to show member name and phone.
        /// Default view when AttendanceForm opens.
        /// </summary>
        /// <returns>DataTable of today's attendance records.</returns>
        public DataTable GetTodayAttendance()
        {
            string sql =
                "SELECT a.AttendanceID AS 'ID', " +
                "m.FullName AS 'Member Name', " +
                "m.Phone AS 'Phone', " +
                "DATE(a.CheckInTime) AS 'Date', " +
                // TIME() extracts just the time portion for display
                "TIME(a.CheckInTime) AS 'Check-In Time' " +
                "FROM Attendance a " +
                "JOIN Members m ON a.MemberID = m.MemberID " +
                // Only return records where date matches today
                "WHERE DATE(a.CheckInTime) = CURDATE() " +
                "ORDER BY a.AttendanceID DESC";

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Gets ALL attendance records from all dates (complete history).
        /// Called when staff clicks "Show All" button on AttendanceForm.
        /// No date filter — returns every check-in ever recorded.
        /// </summary>
        /// <returns>DataTable of all attendance records.</returns>
        public DataTable GetAllAttendance()
        {
            string sql =
                "SELECT a.AttendanceID AS 'ID', " +
                "m.FullName AS 'Member Name', " +
                "m.Phone AS 'Phone', " +
                "DATE(a.CheckInTime) AS 'Date', " +
                "TIME(a.CheckInTime) AS 'Check-In Time' " +
                "FROM Attendance a " +
                "JOIN Members m ON a.MemberID = m.MemberID " +
                "ORDER BY a.AttendanceID DESC"; // newest check-in first

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Searches attendance records by member name.
        /// </summary>
        /// <param name="keyword">Search term from txtSearch.</param>
        /// <returns>Filtered DataTable of attendance records.</returns>
        public DataTable SearchAttendance(string keyword)
        {
            string sql =
                "SELECT a.AttendanceID AS 'ID', " +
                "m.FullName AS 'Member Name', m.Phone AS 'Phone', " +
                "DATE(a.CheckInTime) AS 'Date', " +
                "TIME(a.CheckInTime) AS 'Check-In Time' " +
                "FROM Attendance a " +
                "JOIN Members m ON a.MemberID = m.MemberID " +
                "WHERE m.FullName LIKE @k " +
                "ORDER BY a.AttendanceID DESC";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@k", "%" + keyword + "%")
            };

            return ExecuteReader(sql, p);
        }

        // ── Count Helpers ──────────────────────────────────────────

        /// <summary>
        /// Counts how many members checked in TODAY.
        /// Used by Dashboard "Today's Attendance" stat card.
        /// Uses DATE() to compare only the date portion of CheckInTime.
        /// </summary>
        /// <returns>Today's attendance count as integer.</returns>
        public int GetTodayCount()
        {
            return Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM Attendance " +
                "WHERE DATE(CheckInTime) = CURDATE()"));
        }

        /// <summary>
        /// Counts total attendance records from ALL dates.
        /// Used by AttendanceForm "Total Records" stat label.
        /// </summary>
        /// <returns>All-time attendance count as integer.</returns>
        public int GetTotalCount()
        {
            return Convert.ToInt32(
                ExecuteScalar("SELECT COUNT(*) FROM Attendance"));
        }
    }
}