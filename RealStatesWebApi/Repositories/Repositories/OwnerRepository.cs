using Data;
using Data.Infrastructure;
using Data.Infrastructure.Helpers;
using Data.Infrastructure.Repositories;
using Models;
using Models.Entity;

namespace Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DbEntities context) : base(context)
        {

        }
    }
}
