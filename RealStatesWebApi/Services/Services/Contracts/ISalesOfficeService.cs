using Data.Infrastructure.Services;
using Models.DTO;
using Models.DTO.SalesOffice;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISalesOfficeService : IService<SalesOffice, SalesOfficeDTO>
    {
        Task<List<SalesOfficeDTO>> GetOfficesAsync();
    }
}
