using Models.DTO;
using Models.DTO.SalesOffice;

namespace Repositories.Contracts
{
    public interface ISalesOfficeRepository
    {
        Task<List<GetOfficeListResponse>> GetOfficesAsync();
    }
}
