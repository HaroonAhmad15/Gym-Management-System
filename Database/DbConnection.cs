// ============================================================
// FILE        : DbConnection.cs
// DESCRIPTION : Manages the MySQL database connection.
//               Provides a centralized connection string so
//               all repository classes connect to the same
//               database without repeating configuration.
// ============================================================

using MySql.Data.MySqlClient;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Static class that manages the MySQL database connection.
    /// All repository classes use this class to get a connection.
    /// Centralizing the connection string here means if the
    /// password or database name changes, only ONE place needs updating.
    /// </summary>
    public static class DbConnection
    {
        // ── Connection String ──────────────────────────────────────
        // Server   = localhost  → MySQL is on this same computer
        // Port     = 3306       → MySQL's default port number
        // Database = GymDB      → Our gym database name
        // Uid      = root       → MySQL username
        // Pwd      = gym123     → MySQL password (change if needed)
        // ──────────────────────────────────────────────────────────
        private static string _connectionString =
            "Server=localhost;Port=3306;Database=GymDB;Uid=root;Pwd=gym123;";

        /// <summary>
        /// Gets the full MySQL connection string.
        /// Used by GetConnection() to build the connection.
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// Creates and returns a new MySqlConnection object.
        /// The caller is responsible for opening and closing it.
        /// Every repository calls this method to get a connection.
        /// </summary>
        /// <returns>A new MySqlConnection using the stored connection string.</returns>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Tests whether the MySQL database is reachable.
        /// Called on startup to verify the connection works.
        /// Returns true if connection succeeds, false if it fails.
        /// </summary>
        /// <returns>True if connected successfully, false otherwise.</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    // If we reach here, connection was successful
                    return conn.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                // Connection failed — MySQL not running or wrong password
                return false;
            }
        }
    }
}