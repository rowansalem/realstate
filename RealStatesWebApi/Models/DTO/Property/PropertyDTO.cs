using Models.Core;
using Models.DTO.SalesOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    
    public class PropertyDTO : BaseDTO
    {
        public Guid PropertyID { get; set; }
        public decimal ListPrice { get; set; }
        public string Status { get; set; }
        public int NoBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public string City { get; set; }

        public List<Guid>? OwnersId { get; set; }
        public List<OwnerDTO>? PropertyOwners { get; set; }

        public SalesOfficeDTO? SalesOffice { get; set; }
    }
}
