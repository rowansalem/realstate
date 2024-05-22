using Data.Infrastructure;
using Data.Infrastructure.Services;
using Mappers;
using Models;
using Models.DTO;
using Models.Entity;
using Repositories;

namespace Services
{
    public class EmployeeService : BaseService<Employee, AddressDTO>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository, IEmployeeMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

    }
}
