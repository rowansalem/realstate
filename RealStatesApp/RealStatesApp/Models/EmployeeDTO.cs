using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Models
{
    public class EmployeeDTO : BaseDTO
    {
        public string? EmpFirstName { get; set; }
        public string? EmpLastName { get; set; }
        public Guid? SalesOfficeId { get; set; }
        public string? SalesOfficeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
