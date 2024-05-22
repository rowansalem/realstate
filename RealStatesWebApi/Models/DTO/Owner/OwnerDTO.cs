using Models.Core;
using System.Net;

namespace Models.DTO
{
    public class OwnerDTO : BaseDTO
    {
        public string? OwnerFirstName { get; set; }
        public string? OwnerLastName { get; set; }
        public Guid? OwnerId { get; set; }
        public DateTime Timestamp { get; set; }
    }


}
