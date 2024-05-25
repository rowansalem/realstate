using RealStatesApp.Models;
using System.Net;

namespace RealStatesApp.Models
{
    public class OwnerDTO : BaseDTO
    {
        public string? OwnerFirstName { get; set; }
        public string? OwnerLastName { get; set; }
        public IEnumerable<Guid>? PropertiesId { get; set; }
        public List<PropertyDTO>? Properties { get; set; }  
        public DateTime Timestamp { get; set; }
    }


}
