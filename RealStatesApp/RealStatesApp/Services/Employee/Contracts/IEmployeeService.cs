using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Employee.Contracts
{
    public interface IEmployeesService
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id);
        Task<bool?> CreateEmployeeAsync(EmployeeDTO employee);
        Task<bool?> UpdateEmployeeAsync(EmployeeDTO employee);

        Task<bool?> DeleteEmployeeAsync(Guid id);
    }
}
