using Data;
using Data.Infrastructure;
using Data.Infrastructure.Helpers;
using Data.Infrastructure.Repositories;
using Models;
using Models.Entity;

namespace Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(DbEntities context) : base(context)
        {

        }
    }
}
