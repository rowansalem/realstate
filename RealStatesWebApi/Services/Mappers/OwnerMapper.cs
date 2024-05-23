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
            ownerDTO.OwnerFirstName = source.OwnerFirstName;
            ownerDTO.OwnerLastName = source.OwnerLastName;
            if(source.PropertyOwners != null && source.PropertyOwners.Count > 0)
            {
                ownerDTO.Properties = new List<PropertyDTO>();
                foreach (var propertyOwner in source.PropertyOwners)
                {
                    ownerDTO.Properties.Add(new PropertyDTO { 
                        Id = propertyOwner.PropertyId,
                        City = propertyOwner.Property?.City ?? null,
                        ListPrice = propertyOwner.Property?.ListPrice ?? 0,
                        NoOfBathrooms = propertyOwner.Property?.NoOfBedrooms ?? 0,
                        NoBedrooms = propertyOwner.Property?.NoOfBedrooms ?? 0,
                        Status = propertyOwner.Property?.Status ?? null,
                        PropertyID = propertyOwner.PropertyId
                    });
                }
            }
            return ownerDTO;
        }

        Owner IBaseMapper<Owner, OwnerDTO>.MapToEntity(OwnerDTO source)
        {
            Owner owner = new Owner();
            owner.Id = source.Id;
            owner.OwnerFirstName = source.OwnerFirstName;
            owner.OwnerLastName = source.OwnerLastName;
            if(source.PropertiesId != null && source.PropertiesId.Count() >0)
            {
                owner.PropertyOwners = new List<PropertyOwner>();
                foreach (var propertyId in source.PropertiesId)
                {
                    owner.PropertyOwners.Add(new PropertyOwner { PropertyId = propertyId });
                }
            }
            return owner;
        }
    }
}
