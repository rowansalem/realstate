using Models.Core;

namespace Models.Entity
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
