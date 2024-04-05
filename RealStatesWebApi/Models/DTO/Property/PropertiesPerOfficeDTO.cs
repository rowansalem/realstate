using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PropertiesPerOfficeDTO
    {
        public string OfficeName { get; set; }
        public List<PropertyDTO> Properties { get; set; }
    }
}
