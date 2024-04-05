using Models.DTO;

namespace Repositories.Contracts
{
    public interface IReportRepository
    {
        Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId);
        Task<List<OfficePropertyCountDTO>> GetOfficePropertyCountsAsync();
        Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId);
    }
}
