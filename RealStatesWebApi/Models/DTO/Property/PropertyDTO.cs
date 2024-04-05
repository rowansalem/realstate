using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    
    public class PropertyDTO
    {
        public Guid PropertyID { get; set; }
        public decimal ListPrice { get; set; }
        public string Status { get; set; }
        public int NoBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public string City { get; set; }
    }
}
