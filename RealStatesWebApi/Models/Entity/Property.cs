using Models.Core;
using System.Net;

namespace Models.Entity
{
    public class Property: BaseEntity
    {
        public decimal ListPrice { get; set; }
        public string Status { get; set; }
        public int NoOfBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public string City { get; set; }
        public Guid SalesOfficeId { get; set; }
        public virtual SalesOffice SalesOffice { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation property
        public ICollection<PropertyOwner> PropertyOwners { get; set; }
    }


}
