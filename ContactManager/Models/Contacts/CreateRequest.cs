using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models.Contacts
{
    public class CreateRequest
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public int? OwnerId {
            get => OwnerNavigationId == 0 ? null : OwnerNavigationId;
            set => OwnerNavigationId = value ?? 0;
        }
        
        public int OwnerNavigationId { get; set; }
        
    }
}