using Models.DTO;
using Repositories.Contracts;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId)
        {
            return _reportRepository.GetPropertiesPerOfficeAsync(officeId);
        }
        public Task<List<OfficePropertyCountDTO>> GetOfficePropertyCountsAsync() => _reportRepository.GetOfficePropertyCountsAsync();
        public Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId)
        {
            return _reportRepository.GetEmployeesByOfficeAsync(officeId);
        }
    }
}
