// ============================================================
// FILE        : UserRepository.cs
// DESCRIPTION : Handles all database operations for the Users
//               table. Inherits BaseRepository for shared DB
//               methods. Currently used only for Login.
// ============================================================

using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Gym_Management_System.Models;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for the Users table in GymDB.
    /// Inherits BaseRepository which provides ExecuteReader,
    /// ExecuteNonQuery, ExecuteSingle etc.
    /// Used by: LoginForm.cs
    /// </summary>
    public class UserRepository : BaseRepository
    {
        // ── Private Mapper ─────────────────────────────────────────

        /// <summary>
        /// Maps one row from the MySqlDataReader to a User object.
        /// This is the mapper function passed to ExecuteSingle/ExecuteList.
        /// Called automatically for every row returned by a query.
        /// </summary>
        /// <param name="r">The MySqlDataReader pointing to current row.</param>
        /// <returns>A populated User model object.</returns>
        private User MapUser(MySqlDataReader r)
        {
            return new User
            {
                UserID = GetInt(r, "UserID"),
                Username = GetString(r, "Username"),
                Password = GetString(r, "Password"),
                Role = GetString(r, "Role")
            };
        }

        // ── Authentication ─────────────────────────────────────────

        /// <summary>
        /// Authenticates a user by checking username and password
        /// against the Users table in MySQL.
        /// Uses parameterized query — safe from SQL injection.
        /// Called by: LoginForm.btnLogin_Click()
        /// </summary>
        /// <param name="username">Username entered by the user.</param>
        /// <param name="password">Password entered by the user.</param>
        /// <returns>
        /// User object if credentials match, null if not found.
        /// LoginForm checks: if (user != null) → success
        /// </returns>
        public User Authenticate(string username, string password)
        {
            // Parameterized query — @u and @p are replaced safely
            // This prevents SQL injection attacks
            string sql =
                "SELECT UserID, Username, Password, Role " +
                "FROM Users " +
                "WHERE Username = @u AND Password = @p";

            // Parameters replace @u and @p with actual values
            var p = new MySqlParameter[]
            {
                new MySqlParameter("@u", username),
                new MySqlParameter("@p", password)
            };

            // ExecuteSingle returns one User object or null
            return ExecuteSingle(sql, r => MapUser(r), p);
        }

        // ── CRUD Operations ────────────────────────────────────────

        /// <summary>
        /// Retrieves all users from the Users table.
        /// Can be used for user management in future versions.
        /// </summary>
        /// <returns>List of all User objects.</returns>
        public List<User> GetAllUsers()
        {
            string sql = "SELECT UserID, Username, Password, Role FROM Users";
            return ExecuteList(sql, r => MapUser(r));
        }

        /// <summary>
        /// Checks if a username already exists in the Users table.
        /// Used to prevent duplicate usernames when adding new users.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if username exists, false if available.</returns>
        public bool UsernameExists(string username)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            var p = new MySqlParameter[]
            {
                new MySqlParameter("@u", username)
            };

            // Convert the COUNT(*) result to integer for comparison
            long count = System.Convert.ToInt64(ExecuteScalar(sql, p));
            return count > 0;
        }

        /// <summary>
        /// Adds a new user to the Users table.
        /// Checks for duplicate username before inserting.
        /// </summary>
        /// <param name="user">User object with all required fields.</param>
        /// <returns>True if added successfully, false if username already exists.</returns>
        public bool AddUser(User user)
        {
            // Prevent duplicate usernames
            if (UsernameExists(user.Username)) return false;

            string sql =
                "INSERT INTO Users (Username, Password, Role) " +
                "VALUES (@u, @p, @r)";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@u", user.Username),
                new MySqlParameter("@p", user.Password),
                new MySqlParameter("@r", user.Role)
            };

            // ExecuteNonQuery returns rows affected: 1 = success
            return ExecuteNonQuery(sql, parameters) > 0;
        }

        /// <summary>
        /// Updates the password for an existing user.
        /// </summary>
        /// <param name="userID">The ID of the user to update.</param>
        /// <param name="newPassword">The new password to set.</param>
        /// <returns>True if updated, false if user not found.</returns>
        public bool ChangePassword(int userID, string newPassword)
        {
            string sql = "UPDATE Users SET Password = @p WHERE UserID = @id";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p",  newPassword),
                new MySqlParameter("@id", userID)
            };
            return ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}