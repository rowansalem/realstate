using Models.DTO;
using Models.DTO.SalesOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISalesOfficeService
    {
        Task<List<GetOfficeListResponse>> GetOfficesAsync();
    }
}
