using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReportService
    {
        Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId);
        Task<List<OfficePropertyCountDTO>> GetOfficePropertyCountsAsync();
        Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId);
    }
}
