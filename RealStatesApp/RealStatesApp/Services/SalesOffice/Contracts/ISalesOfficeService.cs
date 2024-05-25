using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.SalesOffice.Contracts
{
    public interface ISalesOfficeService
    {
        Task<List<SalesOfficeDTO>> GetSalesOfficesListAsync();
        Task<SalesOfficeDTO?> GetSalesOfficeByIdAsync(Guid id);
        Task<bool?> CreateSalesOfficeAsync(SalesOfficeDTO salesOffice);
        Task<bool?> UpdateSalesOfficeAsync(SalesOfficeDTO salesOffice);

        Task<bool?> DeleteSalesOfficeAsync(Guid id);
    }
}
