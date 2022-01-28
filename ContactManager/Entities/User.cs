using Bcrypt = BCrypt.Net.BCrypt;
using System.Text.Json.Serialization;

namespace ContactManager.Entities
{
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        [JsonIgnore]
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Contact> Contacts { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
