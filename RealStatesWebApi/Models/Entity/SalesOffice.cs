using Models.Core;
using System.Net;

namespace Models.Entity
{
    public class SalesOffice:BaseEntity
    {
        public string SalesOfficeName { get; set; }
        public Guid AddressId { get; set; }
        public  Address Address { get; set; }
        public Guid ManagedByEmployeeId { get; set; }
        public  Employee Manager { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation property
        public ICollection<Property> Properties { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}
