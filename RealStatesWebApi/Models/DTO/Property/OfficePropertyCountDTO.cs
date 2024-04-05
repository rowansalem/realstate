using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class OfficePropertyCountDTO
    {
        public string OfficeName { get; set; }
        public string Address { get; set; }
        public int NumberOfProperties { get; set; }
        public string Manager { get; set; }
    }
}
