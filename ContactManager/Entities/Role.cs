using System.Text.Json.Serialization;

namespace ContactManager.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
