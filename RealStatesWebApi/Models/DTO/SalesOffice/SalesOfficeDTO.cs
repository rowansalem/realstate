using Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.SalesOffice
{
    public class SalesOfficeDTO : BaseDTO
    {
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }

        public List<Guid>? EmployeesId { get; set; }

        public List<Guid>? PropertiesId { get; set; }

        public Guid ManagerId {  get; set; }
        public EmployeeDTO? Manager { get; set; }
        public Guid AddressId {  get; set; }
        public AddressDTO? Address { get; set; }

    }
}
