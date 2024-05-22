using Data;
using Data.Infrastructure;
using Data.Infrastructure.Helpers;
using Data.Infrastructure.Repositories;
using Models;
using Models.Entity;

namespace Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbEntities context) : base(context)
        {

        }
    }
}
