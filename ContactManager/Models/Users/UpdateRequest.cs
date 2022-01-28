using Bcrypt = BCrypt.Net.BCrypt;

namespace ContactManager.Models.Users
{
    public class UpdateRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        
        private string _password;
        public string? Password
        {
            get { return _password; }
            set { _password = setPassword(value); }
        }
        
        private static string setPassword(string password)
        {
            var rounds = 8;
            var hashedPassword = Bcrypt.HashPassword(password, rounds);
            return hashedPassword;
        }
    }
}