using System.Text.Json.Serialization;

namespace ContactManager.Entities
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = null!;
        public int OwnerNavigationId { get; set; }
        [JsonIgnore]
        public virtual User? OwnerNavigation { get; set; }
    }
}
