using Data.Infrastructure;
using Data.Infrastructure.Services;
using Mappers;
using Models.DTO;
using Models.DTO.SalesOffice;
using Models.Entity;
using Repositories;
using Repositories.Contracts;

namespace Services
{
    public class SalesOfficeService : BaseService<SalesOffice, SalesOfficeDTO>, ISalesOfficeService
    {
        private readonly ISalesOfficeRepository _salesOfficeRepository;


        public SalesOfficeService(ISalesOfficeRepository repository, ISalesOfficeMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            _salesOfficeRepository = repository;
        }

        public async Task<List<SalesOfficeDTO>> GetOfficesAsync()
        {
            return await _salesOfficeRepository.GetOfficesAsync();
        }
    }
}
