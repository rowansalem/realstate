using Models.Core;
using System.Collections.ObjectModel;
using System.Net;

namespace Models.Entity
{
    public class Employee: BaseEntity
    {
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public Guid SalesOfficeId { get; set; }
        public  SalesOffice SalesOffice { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public DateTime Timestamp { get; set; }

        public Collection<SalesOffice> ManagedSalesOffices{ get; set; }
    }


}
