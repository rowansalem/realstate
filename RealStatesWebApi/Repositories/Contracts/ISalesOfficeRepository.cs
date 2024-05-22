using Data.Infrastructure.Repositories;
using Models.DTO;
using Models.DTO.SalesOffice;
using Models.Entity;

namespace Repositories.Contracts
{
    public interface ISalesOfficeRepository : IRepository<SalesOffice>
    {
        Task<List<SalesOfficeDTO>> GetOfficesAsync();
    }
}
