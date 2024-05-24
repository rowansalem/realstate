using Data.Infrastructure;
using Models.DTO;
using Models;
using Models.Entity;
using Models.DTO.SalesOffice;

namespace Mappers
{
    public class SalesOfficeMapper : ISalesOfficeMapper
    {
        SalesOfficeDTO IBaseMapper<SalesOffice, SalesOfficeDTO>.MapToDTO(SalesOffice source)
        {
            SalesOfficeDTO salesofficeDTO = new SalesOfficeDTO();
            salesofficeDTO.Id = source.Id;
            salesofficeDTO.OfficeName = source.SalesOfficeName;
            if(source.Properties != null)
            {
                source.Properties.Select(x => new PropertyDTO()
                {
                    City = x.City,
                    Id = x.Id,
                    ListPrice = x.ListPrice,
                    NoBedrooms = x.NoOfBedrooms,
                    NoOfBathrooms = x.NoOfBathrooms,
                });
            }
            if(source.Employees != null)
            {
                source.Employees.Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    Age = x.Age,
                    DateOfBirth = x.DateOfBirth,
                    EmpFirstName = x.EmpFirstName,
                    EmpLastName = x.EmpLastName,
                });
            }
            if(source.Manager != null)
            {
                salesofficeDTO.ManagerId = source.Manager.Id;
                salesofficeDTO.Manager = new EmployeeDTO()
                {
                    Age = source.Manager.Age,
                    DateOfBirth = source.Manager.DateOfBirth,
                    EmpFirstName = source.Manager.EmpFirstName,
                    EmpLastName = source.Manager.EmpLastName,
                    Id = source.Manager.Id
                };
            }
            if(source.Address != null)
            {
                salesofficeDTO.AddressId = source.Address.Id;
                salesofficeDTO.Address = new AddressDTO()
                {
                    AddressLine = source.Address.AddressLine,
                    Id = source.Address.Id,
                    City = source.Address.City,
                    State = source.Address.State,
                    ZipCode = source.Address.ZipCode,
                    Timestamp = source.Address.Timestamp,
                };
            }
            return salesofficeDTO;
        }

        SalesOffice IBaseMapper<SalesOffice, SalesOfficeDTO>.MapToEntity(SalesOfficeDTO source)
        {
            SalesOffice salesoffice = new SalesOffice();
            salesoffice.SalesOfficeName = source.OfficeName;
            salesoffice.Id = source.Id;
            salesoffice.ManagerId = source.ManagerId;
            salesoffice.AddressId = source.AddressId;
            return salesoffice;
        }
    }
}
