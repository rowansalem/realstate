using Data.Infrastructure.Services;
using Models;
using Models.DTO;
using Models.Entity;

namespace Services
{
    public interface IAddressService : IService<Address, AddressDTO>
    {
    }
}
