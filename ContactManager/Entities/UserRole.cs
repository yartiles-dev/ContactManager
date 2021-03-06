using System.Text.Json.Serialization;

namespace ContactManager.Entities
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public virtual Role? Role { get; set; } = null!;
        [JsonIgnore]
        public virtual User? User { get; set; } = null!;
    }
}
