using System.ComponentModel.DataAnnotations;
using Bcrypt = BCrypt.Net.BCrypt;

namespace ContactManager.Models.Users
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        
        private string _password;
        [Required]
        public string Password
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