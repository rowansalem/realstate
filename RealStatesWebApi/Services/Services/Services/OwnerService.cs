using Data.Infrastructure;
using Data.Infrastructure.Services;
using Mappers;
using Models;
using Models.DTO;
using Models.Entity;
using Repositories;

namespace Services
{
    public class OwnerService : BaseService<Owner, OwnerDTO>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository, IOwnerMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

    }
}
