using Data;
using Data.Infrastructure;
using Data.Infrastructure.Helpers;
using Data.Infrastructure.Repositories;
using Models;
using Models.Entity;

namespace Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DbEntities context) : base(context)
        {

        }
    }
}
