using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;

namespace Mappers
{
    public class AddressMapper : IAddressMapper
    {

        AddressDTO IBaseMapper<Address, AddressDTO>.MapToDTO(Address source)
        {
            AddressDTO addressDTO = new() { AddressLine = source.AddressLine };
            addressDTO.Id = source.Id;
            addressDTO.City = source.City;
            addressDTO.ZipCode = source.ZipCode;
            addressDTO.State = source.State;
            addressDTO.Timestamp = source.Timestamp;
            return addressDTO;
        }

        Address IBaseMapper<Address, AddressDTO>.MapToEntity(AddressDTO source)
        {
            Address address = new Address();
            address.Id = source.Id;
            return address;
        }
    }
}
