using System.Net;

namespace Models.Entity
{
    public class Owner : BaseEntity
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation property
        public ICollection<PropertyOwner> PropertyOwners { get; set; }
    }


}
