using Data;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.DTO.SalesOffice;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SalesOfficeRepository : ISalesOfficeRepository
    {
        private readonly DbEntities _context;

        public SalesOfficeRepository(DbEntities context)
        {
            _context = context;
        }


        public async Task<List<GetOfficeListResponse>> GetOfficesAsync()
        {
            return await _context.SalesOffices
                .Select(o => new GetOfficeListResponse
                {
                    OfficeId = o.Id,
                    OfficeName = o.SalesOfficeName
                })
                .ToListAsync();
        }
    }

}
