using Data;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Entity;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DbEntities _context;

        public ReportRepository(DbEntities context)
        {
            _context = context;
        }

        public async Task<PropertiesPerOfficeDTO?> GetPropertiesPerOfficeAsync(Guid officeId)
        {
            var propertiesPerOffice = await _context.SalesOffices
                .Include(office => office.Properties)
                .Where(office => office.Id == officeId)
                .Select(office => new PropertiesPerOfficeDTO
                {
                    OfficeName = office.SalesOfficeName,
                    Properties = office.Properties.Select(p => new PropertyDTO
                    {
                        PropertyID = p.Id,
                        ListPrice = p.ListPrice,
                        Status = p.Status,
                        NoBedrooms = p.NoOfBedrooms,
                        NoOfBathrooms = p.NoOfBathrooms,
                        City = p.City
                    }).ToList()
                }).FirstOrDefaultAsync();

            return propertiesPerOffice;
        }
        public async Task<List<OfficePropertyCountDTO>> GetOfficePropertyCountsAsync()
        {
            var officePropertyCount = await _context.SalesOffices
                .Include(office => office.Properties)
                .Include(office => office.Manager)
                .Select(office => new OfficePropertyCountDTO
                {
                    OfficeName = office.SalesOfficeName,
                    Address = office.Address.AddressLine,
                    NumberOfProperties = office.Properties.Count,
                    Manager = office.Manager.EmpFirstName + " " + office.Manager.EmpLastName
                }).ToListAsync();

            return officePropertyCount;
        }

        public async Task<EmployeesByOfficeDTO?> GetEmployeesByOfficeAsync(Guid officeId)
        {
            var employeesByOffice = await _context.SalesOffices
                .Include(office => office.Employees)
                .Where(office => office.Id == officeId)
                .Select(office => new EmployeesByOfficeDTO
                {
                    OfficeName = office.SalesOfficeName,
                    Employees = office.Employees.Select(e => new EmployeeDTO
                    {
                        EmpFirstName = e.EmpFirstName,
                        EmpLastName  = e.EmpLastName,
                        DateOfBirth = e.DateOfBirth,
                        Age = e.Age
                    }).ToList()
                }).FirstOrDefaultAsync();

            return employeesByOffice;
        }
    }

}
