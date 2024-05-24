using Models.Core;
using System.Net;

namespace Models.DTO
{
    public class EmployeeDTO: BaseDTO
    {
        public string? EmpFirstName { get; set; }
        public string? EmpLastName { get; set; }
        public Guid? SalesOfficeId { get; set; }
        public  string? SalesOfficeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public DateTime Timestamp { get; set; }
    }


}
