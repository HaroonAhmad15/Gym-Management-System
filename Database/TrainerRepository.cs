// ============================================================
// FILE        : TrainerRepository.cs
// DESCRIPTION : Handles all database operations for the Trainers
//               table. The Trainers table is independent — no
//               foreign key links to other tables in this version.
// ============================================================

using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gym_Management_System.Models;

namespace Gym_Management_System.Database
{
    /// <summary>
    /// Repository class for the Trainers table in GymDB.
    /// Inherits BaseRepository for shared database methods.
    /// Used by: TrainerForm, ReportsForm.
    /// Note: Trainers table has no FK links to Members in this version.
    /// </summary>
    public class TrainerRepository : BaseRepository
    {
        // ── Private Mapper ─────────────────────────────────────────

        /// <summary>
        /// Maps one MySqlDataReader row to a Trainer model object.
        /// </summary>
        private Trainer MapTrainer(MySqlDataReader r)
        {
            return new Trainer
            {
                TrainerID = GetInt(r, "TrainerID"),
                FullName = GetString(r, "FullName"),
                Phone = GetString(r, "Phone"),
                Specialty = GetString(r, "Specialty"),
                Salary = GetDecimal(r, "Salary"),  // decimal for exact financial value
                IsActive = GetBoolean(r, "IsActive")
            };
        }

        // ── READ Operations ────────────────────────────────────────

        /// <summary>
        /// Gets all trainer records as a DataTable for grid binding.
        /// CASE converts IsActive (1/0) to "Active"/"Inactive" text for display.
        /// </summary>
        /// <returns>DataTable ready to bind to dgvTrainers.</returns>
        public DataTable GetAllTrainersTable()
        {
            string sql =
                "SELECT TrainerID AS 'ID', " +
                "FullName AS 'Full Name', " +
                "Phone AS 'Phone', " +
                "Specialty AS 'Specialty', " +
                "Salary AS 'Salary (Rs.)', " +
                // Convert boolean (1/0) to readable text
                "CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS 'Status' " +
                "FROM Trainers ORDER BY TrainerID DESC";

            return ExecuteReader(sql);
        }

        /// <summary>
        /// Searches trainers by name or specialty.
        /// LIKE '%keyword%' finds match anywhere in the field.
        /// Example: "Weight" finds "Weight Training", "Weight Loss", etc.
        /// </summary>
        /// <param name="keyword">Search term from txtSearch.</param>
        /// <returns>Filtered DataTable of matching trainers.</returns>
        public DataTable SearchTrainers(string keyword)
        {
            string sql =
                "SELECT TrainerID AS 'ID', FullName AS 'Full Name', " +
                "Phone AS 'Phone', Specialty AS 'Specialty', " +
                "Salary AS 'Salary (Rs.)', " +
                "CASE WHEN IsActive=1 THEN 'Active' ELSE 'Inactive' END AS 'Status' " +
                "FROM Trainers " +
                // Search in both FullName and Specialty columns
                "WHERE FullName LIKE @k OR Specialty LIKE @k";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@k", "%" + keyword + "%")
            };

            return ExecuteReader(sql, p);
        }

        // ── CREATE Operation ───────────────────────────────────────

        /// <summary>
        /// Inserts a new trainer record into the Trainers table.
        /// TrainerID is AUTO_INCREMENT — not included in INSERT.
        /// IsActive stored as 1 (Active) or 0 (Inactive) in MySQL.
        /// </summary>
        /// <param name="trainer">Trainer object filled from TrainerForm fields.</param>
        /// <returns>True if trainer was added successfully.</returns>
        public bool AddTrainer(Trainer trainer)
        {
            string sql =
                "INSERT INTO Trainers " +
                "(FullName, Phone, Specialty, Salary, IsActive) " +
                "VALUES (@name, @phone, @spec, @sal, @active)";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@name",   trainer.FullName),
                new MySqlParameter("@phone",  trainer.Phone),
                new MySqlParameter("@spec",   trainer.Specialty),
                new MySqlParameter("@sal",    trainer.Salary),     // decimal — exact salary
                new MySqlParameter("@active", trainer.IsActive ? 1 : 0) // bool → int
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── UPDATE Operation ───────────────────────────────────────

        /// <summary>
        /// Updates an existing trainer's information.
        /// WHERE TrainerID = @id ensures only that specific trainer is changed.
        /// </summary>
        /// <param name="trainer">Trainer object with updated values and existing TrainerID.</param>
        /// <returns>True if update succeeded.</returns>
        public bool UpdateTrainer(Trainer trainer)
        {
            string sql =
                "UPDATE Trainers SET " +
                "FullName = @name, Phone = @phone, " +
                "Specialty = @spec, Salary = @sal, IsActive = @active " +
                "WHERE TrainerID = @id"; // Only update THIS trainer

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id",     trainer.TrainerID), // identifies which row
                new MySqlParameter("@name",   trainer.FullName),
                new MySqlParameter("@phone",  trainer.Phone),
                new MySqlParameter("@spec",   trainer.Specialty),
                new MySqlParameter("@sal",    trainer.Salary),
                new MySqlParameter("@active", trainer.IsActive ? 1 : 0)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── DELETE Operation ───────────────────────────────────────

        /// <summary>
        /// Permanently deletes a trainer record from the Trainers table.
        /// Alternative: set IsActive = 0 (soft delete) to keep history.
        /// </summary>
        /// <param name="trainerID">The TrainerID of the trainer to delete.</param>
        /// <returns>True if deleted successfully.</returns>
        public bool DeleteTrainer(int trainerID)
        {
            string sql = "DELETE FROM Trainers WHERE TrainerID = @id";

            var p = new MySqlParameter[]
            {
                new MySqlParameter("@id", trainerID)
            };

            return ExecuteNonQuery(sql, p) > 0;
        }

        // ── Count Helper ───────────────────────────────────────────

        /// <summary>
        /// Gets total number of trainer records.
        /// Can be used for stats displays in future versions.
        /// </summary>
        /// <returns>Total trainer count as integer.</returns>
        public int GetTotalCount()
        {
            return Convert.ToInt32(
                ExecuteScalar("SELECT COUNT(*) FROM Trainers"));
        }
    }
}