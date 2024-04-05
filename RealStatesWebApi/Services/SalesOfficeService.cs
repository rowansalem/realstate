using Models.DTO;
using Models.DTO.SalesOffice;
using Repositories.Contracts;

namespace Services
{
    public class SalesOfficeService : ISalesOfficeService
    {
        private readonly ISalesOfficeRepository _salesOfficeRepository;

        public SalesOfficeService(ISalesOfficeRepository salesOfficeRepository)
        {
            _salesOfficeRepository = salesOfficeRepository;
        }

        public async Task<List<GetOfficeListResponse>> GetOfficesAsync()
        {
            return await _salesOfficeRepository.GetOfficesAsync();
        }
    }
}
