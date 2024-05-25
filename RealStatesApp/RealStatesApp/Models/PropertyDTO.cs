using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Models
{
    
    public class PropertyDTO:BaseDTO
    {
        public Guid PropertyID { get; set; }
        public decimal ListPrice { get; set; }
        public string Status { get; set; }
        public int NoBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public string City { get; set; }
        public List<OwnerDTO>? PropertyOwners { get; set; }
        public Guid? SalesOfficeId { get; set; }
        public SalesOfficeDTO? SalesOffice { get; set; }

        public List<Guid>? OwnersId { get; set; } = new List<Guid>();

        public string OwnerFirstNames
        {

            get
            {
                return PropertyOwners != null && PropertyOwners.Any()
                    ? string.Join(", ", PropertyOwners.Select(o => o.OwnerFirstName))
                    : string.Empty;
            }
        }
    }
}
