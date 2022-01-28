namespace ContactManager.Models.Contacts
{
    public class UpdateRequest
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Email { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public string? Phone { get; set; }
        
        public int? OwnerId {
            get => OwnerNavigationId == 0 ? null : OwnerNavigationId;
            set => OwnerNavigationId = value ?? 0;
        }
        
        public int OwnerNavigationId { get; set; }
    }
}