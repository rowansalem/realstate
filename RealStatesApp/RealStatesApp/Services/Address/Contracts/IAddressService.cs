using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Address.Contracts
{
    public interface IAddressService
    {
        Task<List<AddressDTO>> GetAddressAsync();
        Task<AddressDTO?> GetAddressByIdAsync(Guid id);
        Task<bool?> CreateAddressAsync(AddressDTO employee);
        Task<bool?> UpdateAddressAsync(AddressDTO employee);

        Task<bool?> DeleteAddressAsync(Guid id);
    }
}
