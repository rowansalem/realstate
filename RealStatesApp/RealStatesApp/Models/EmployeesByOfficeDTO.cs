using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Models
{
    public class EmployeesByOfficeDTO
    {
        public string OfficeName { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
