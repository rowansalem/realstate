using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;

namespace Mappers
{
    public interface IEmployeeMapper : IBaseMapper<Employee, AddressDTO>
    {
    }
}
