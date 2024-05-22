﻿using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;

namespace Mappers
{
    public class EmployeeMapper : IEmployeeMapper
    {
         EmployeeDTO IBaseMapper<Employee, EmployeeDTO>.MapToDTO(Employee source)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = source.Id;
            employeeDTO.EmpFirstName = source.EmpFirstName;
            employeeDTO.EmpLastName = source.EmpLastName;
            employeeDTO.DateOfBirth = source.DateOfBirth;
            employeeDTO.Age = source.Age;
            employeeDTO.SalesOfficeId = source.SalesOfficeId;
            if (source.SalesOffice != null)
            {
                employeeDTO.SalesOfficeName = source.SalesOffice.SalesOfficeName;
            }
            return employeeDTO;
        }

        Employee IBaseMapper<Employee, EmployeeDTO>.MapToEntity(EmployeeDTO source)
        {
            Employee employee = new Employee();
            employee.Id = source.Id;
            employee.EmpFirstName = source.EmpFirstName;
            employee.EmpLastName = source.EmpLastName;
            employee.DateOfBirth = source.DateOfBirth;
            employee.Age = source.Age;
            employee.SalesOfficeId = source.SalesOfficeId ?? Guid.Empty;
            return employee;
        }
    }
}
