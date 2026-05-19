// ============================================================
// FILE        : BaseRepository.cs
// DESCRIPTION : Abstract base class for all repository classes.
//               Contains shared database methods so they are
//               written ONCE and reused by all 7 repositories.
//               This follows the DRY principle:
//               Don't Repeat Yourself.
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Abstract base class that all repository classes inherit from.
    /// Provides five core database methods:
    ///   - ExecuteNonQuery  → INSERT, UPDATE, DELETE
    ///   - ExecuteScalar    → COUNT(*), SUM()
    ///   - ExecuteReader    → SELECT many rows → DataTable
    ///   - ExecuteSingle    → SELECT one row → single object
    ///   - ExecuteList      → SELECT all rows → List of objects
    ///
    /// WHY abstract? You cannot create a BaseRepository object directly.
    /// You always use it through a child class like MemberRepository.
    /// </summary>
    public abstract class BaseRepository
    {
        // ── Connection Helper ──────────────────────────────────────

        /// <summary>
        /// Gets a new MySQL connection from DbConnection.
        /// Every database method calls this to open a connection.
        /// </summary>
        protected MySqlConnection GetConnection()
        {
            return DbConnection.GetConnection();
        }

        // ── Core Database Methods ──────────────────────────────────

        /// <summary>
        /// Executes INSERT, UPDATE, or DELETE SQL statements.
        /// Uses parameterized queries to prevent SQL injection.
        /// </summary>
        /// <param name="sql">The SQL command to execute.</param>
        /// <param name="parameters">Optional MySQL parameters for safe value injection.</param>
        /// <returns>Number of rows affected (1 = success, 0 = failed).</returns>
        protected int ExecuteNonQuery(string sql, MySqlParameter[] parameters = null)
        {
            // 'using' ensures the connection is closed automatically
            using (var conn = GetConnection())
            {
                conn.Open(); // Open connection to MySQL

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // Add parameters if provided (prevents SQL injection)
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    // Execute and return number of rows affected
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executes a SELECT query that returns a SINGLE value.
        /// Used for COUNT(*), SUM(Amount), MAX() etc.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional MySQL parameters.</param>
        /// <returns>The first column of the first row as an object.</returns>
        protected object ExecuteScalar(string sql, MySqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    // Returns one value — e.g., COUNT(*) returns 25
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Executes a SELECT query that returns MULTIPLE rows.
        /// Fills a DataTable which can be bound directly to a DataGridView.
        /// </summary>
        /// <param name="sql">The SQL SELECT query.</param>
        /// <param name="parameters">Optional MySQL parameters.</param>
        /// <returns>DataTable containing all matching rows.</returns>
        protected DataTable ExecuteReader(string sql, MySqlParameter[] parameters = null)
        {
            var dataTable = new DataTable(); // Will hold the results

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    // MySqlDataAdapter fills the DataTable automatically
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable; // Ready to bind to DataGridView
        }

        /// <summary>
        /// Executes a SELECT query and maps the FIRST row to one object.
        /// Used when fetching a single record by ID.
        /// Returns default(T) — which is null — if no row found.
        /// </summary>
        /// <typeparam name="T">The model type to return (e.g., Member, User).</typeparam>
        /// <param name="sql">The SQL SELECT query.</param>
        /// <param name="mapper">Function that converts a DataReader row to object T.</param>
        /// <param name="parameters">Optional MySQL parameters.</param>
        /// <returns>One object of type T, or null if not found.</returns>
        protected T ExecuteSingle<T>(string sql,
            Func<MySqlDataReader, T> mapper,
            MySqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Read first row only — map it to object
                        if (reader.Read())
                            return mapper(reader);

                        // No rows found — return null
                        return default(T);
                    }
                }
            }
        }

        /// <summary>
        /// Executes a SELECT query and maps ALL rows to a List of objects.
        /// Used when fetching all records of a type (e.g., all members).
        /// </summary>
        /// <typeparam name="T">The model type (e.g., Member, MembershipPlan).</typeparam>
        /// <param name="sql">The SQL SELECT query.</param>
        /// <param name="mapper">Function that converts each row to object T.</param>
        /// <param name="parameters">Optional MySQL parameters.</param>
        /// <returns>List of T objects. Empty list if no rows found.</returns>
        protected List<T> ExecuteList<T>(string sql,
            Func<MySqlDataReader, T> mapper,
            MySqlParameter[] parameters = null)
        {
            var results = new List<T>(); // Will hold all mapped objects

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Loop through ALL rows and map each to an object
                        while (reader.Read())
                            results.Add(mapper(reader));
                    }
                }
            }

            return results;
        }

        // ── Safe Value Reader Helpers ──────────────────────────────
        // These helpers safely read values from MySqlDataReader.
        // They handle NULL values from the database automatically.
        // Without these, a NULL value would throw a NullReferenceException.

        /// <summary>Returns a string from the reader, or empty string if NULL.</summary>
        protected string GetString(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? string.Empty : r.GetString(i);
        }

        /// <summary>Returns an integer from the reader, or 0 if NULL.</summary>
        protected int GetInt(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }

        /// <summary>Returns a decimal from the reader, or 0.00 if NULL.
        /// Used for financial values (Amount, Price, Salary).</summary>
        protected decimal GetDecimal(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0m : r.GetDecimal(i);
        }

        /// <summary>Returns a DateTime from the reader, or DateTime.MinValue if NULL.</summary>
        protected DateTime GetDateTime(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.MinValue : r.GetDateTime(i);
        }

        /// <summary>Returns a boolean from the reader, or false if NULL.
        /// MySQL stores BOOLEAN as 0 (false) or 1 (true).</summary>
        protected bool GetBoolean(MySqlDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return !r.IsDBNull(i) && r.GetBoolean(i);
        }
    }
}