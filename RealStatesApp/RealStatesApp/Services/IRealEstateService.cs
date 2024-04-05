using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services
{
    public interface IRealEstateService
    {
        Task<List<GetOfficeListResponse>> GetOfficesAsync();

        Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId);
        Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId);
        Task<List<OfficePropertyCountDTO>?> GetOfficePropertyCountsAsync();
    }
}
