using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;

namespace Mappers
{
    public class PropertyMapper : IPropertyMapper
    {
         PropertyDTO IBaseMapper<Property, PropertyDTO>.MapToDTO(Property source)
        {
            PropertyDTO propertyDTO = new PropertyDTO();
            propertyDTO.PropertyID = source.Id;
            propertyDTO.NoBedrooms = source.NoOfBedrooms;
            propertyDTO.NoOfBathrooms = source.NoOfBathrooms;
            propertyDTO.Status = source.Status;
            propertyDTO.ListPrice = source.ListPrice;

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
            return property;
        }
    }
}
