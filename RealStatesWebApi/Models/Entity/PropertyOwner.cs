using System.Net;

namespace Models.Entity
{
    public class PropertyOwner : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public decimal PercentOwned { get; set; }
        public DateTime Timestamp { get; set; }
    }


}
