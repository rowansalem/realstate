using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services
{
    public interface IEmployeesService
    {
        Task<List<EmployeeDTO>> GetEmployeesAsync();
    }
}
