using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;

namespace Mappers
{
    public class OwnerMapper : IOwnerMapper
    {

        OwnerDTO IBaseMapper<Owner, OwnerDTO>.MapToDTO(Owner source)
        {
            OwnerDTO ownerDTO = new();
            ownerDTO.Id = source.Id;
            source.OwnerFirstName = ownerDTO.OwnerFirstName;
            source.OwnerLastName = ownerDTO.OwnerLastName;
            return ownerDTO;
        }

        Owner IBaseMapper<Owner, OwnerDTO>.MapToEntity(OwnerDTO source)
        {
            Owner owner = new Owner();
            owner.Id = source.Id;
            return owner;
        }
    }
}
