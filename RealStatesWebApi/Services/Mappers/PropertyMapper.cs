using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;
using Models.DTO.SalesOffice;

namespace Mappers
{
    public class PropertyMapper : IPropertyMapper
    {
         PropertyDTO IBaseMapper<Property, PropertyDTO>.MapToDTO(Property source)
        {
            PropertyDTO propertyDTO = new PropertyDTO();
            propertyDTO.Id = source.Id;
            propertyDTO.NoBedrooms = source.NoOfBedrooms;
            propertyDTO.NoOfBathrooms = source.NoOfBathrooms;
            propertyDTO.Status = source.Status;
            propertyDTO.ListPrice = source.ListPrice;
            propertyDTO.City = source.City;
            propertyDTO.PropertyID = source.Id;

            if(source.SalesOffice != null)
            {

                propertyDTO.SalesOffice = new SalesOfficeDTO()
                {
                    Id = source.SalesOffice.Id,
                    OfficeName = source.SalesOffice.SalesOfficeName,
                };
            }

            if(source.PropertyOwners != null && source.PropertyOwners.Count > 0)
            {
                propertyDTO.PropertyOwners = new List<OwnerDTO>();
                foreach (var owner in source.PropertyOwners)
                {
                    OwnerDTO ownerDTO = new OwnerDTO();
                    ownerDTO.Id = owner.OwnerId;
                    ownerDTO.OwnerFirstName = owner.Owner?.OwnerFirstName ?? null;
                    ownerDTO.OwnerLastName = owner.Owner?.OwnerLastName ?? null;
                    propertyDTO.PropertyOwners.Add(ownerDTO);
                }
            }

            return propertyDTO;
        }

        Property IBaseMapper<Property, PropertyDTO>.MapToEntity(PropertyDTO source)
        {
            Property property = new Property();
            property.Status = source.Status;
            property.ListPrice = source.ListPrice;
            property.NoOfBedrooms = source.NoBedrooms;
            property.NoOfBathrooms = source.NoOfBathrooms;
            property.City = source.City;

            if(source.SalesOffice != null)
            {
                property.SalesOfficeId = source.SalesOffice.Id;
            }

            if(source.OwnersId != null && source.OwnersId.Count > 0)
            {
                property.PropertyOwners = new List<PropertyOwner>();
                foreach (var ownerId in source.OwnersId)
                {
                    PropertyOwner propertyOwner = new PropertyOwner();
                    propertyOwner.OwnerId = ownerId;
                    propertyOwner.PercentOwned = 100;
                    property.PropertyOwners.Add(propertyOwner);
                }
            }
            return property;
        }
    }
}
