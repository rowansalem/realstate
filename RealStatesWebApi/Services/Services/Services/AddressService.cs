using Data.Infrastructure;
using Data.Infrastructure.Services;
using Mappers;
using Models;
using Models.DTO;
using Models.Entity;
using Repositories;

namespace Services
{
    public class AddressService : BaseService<Address, AddressDTO>, IAddressService
    {
        public AddressService(IAddressRepository repository, IAddressMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

    }
}
