using SchoolJournal.Interfaces;    // <-- ОБЯЗАТЕЛЬНО!
using SchoolJournal.Models;

namespace SchoolJournal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "admin" или "user"

        public User(int id, string username, string password, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }
}
