using Models.Core;
using System.Net;

namespace Models.DTO
{
    public class AddressDTO : BaseDTO
    {
        public required string AddressLine { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public DateTime Timestamp { get; set; }
    }


}
