using Data.Infrastructure;
using Data.Infrastructure.Services;
using Mappers;
using Models;
using Models.DTO;
using Models.Entity;
using Repositories;

namespace Services
{
    public class PropertyService : BaseService<Property, PropertyDTO>, IPropertyService
    {
        public PropertyService(IPropertyRepository repository, IPropertyMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

    }
}
