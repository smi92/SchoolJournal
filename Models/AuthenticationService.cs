using System.Collections.Generic;
using System.Linq;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;

namespace SchoolJournal.Models
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<User> _users;
        private bool _isAuthenticated;
        private string _currentUser;
        private static string usersFilePath = System.IO.Path.Combine(
            System.AppDomain.CurrentDomain.BaseDirectory, "users.json");

        public bool IsAuthenticated => _isAuthenticated;
        public string CurrentUser => _currentUser;

        public AuthenticationService()
        {
            LoadUsers();
            _isAuthenticated = false;
            _currentUser = null;
        }

        private void LoadUsers()
        {
            _users = new List<User>
            {
                new User(1, "admin", "123", "admin"),
                new User(2, "user", "123", "user")
            };

            // Загружаем сохраненных пользователей из файла
            if (System.IO.File.Exists(usersFilePath))
            {
                try
                {
                    string json = System.IO.File.ReadAllText(usersFilePath);
                    var savedUsers = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
                    if (savedUsers != null)
                    {
                        foreach (var user in savedUsers)
                        {
                            if (!_users.Any(u => u.Username == user.Username))
                            {
                                user.Id = _users.Count + 1;
                                _users.Add(user);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void SaveUsers()
        {
            try
            {
                var usersToSave = _users.Where(u => u.Username != "admin" && u.Username != "user").ToList();
                string json = System.Text.Json.JsonSerializer.Serialize(usersToSave, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(usersFilePath, json);
            }
            catch { }
        }

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.CheckPassword(password))
            {
                _isAuthenticated = true;
                _currentUser = username;
                return true;
            }
            _isAuthenticated = false;
            _currentUser = null;
            return false;
        }

        public string GetUserRole(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return user?.Role ?? "none";
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }

        public bool Register(string username, string password, string role)
        {
            if (UserExists(username))
                return false;

            int newId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            var newUser = new User(newId, username, password, role);
            _users.Add(newUser);
            SaveUsers();
            return true;
        }
    }
}
