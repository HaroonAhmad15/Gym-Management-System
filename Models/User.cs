// Models/User.cs
// This is a plain C# class that represents one row in the Users table
// It only has properties — no database logic here
namespace Gym_Management_System.Models
{
    public class User
    {
        // Auto-incremented ID from database
        public int UserID { get; set; }

        // Login username
        public string Username { get; set; }

        // Login password
        public string Password { get; set; }

        // Role: Admin or Staff
        public string Role { get; set; }
    }
}