using Data;
using Data.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.DTO.SalesOffice;
using Models.Entity;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SalesOfficeRepository : BaseRepository<SalesOffice> , ISalesOfficeRepository
    {
        private readonly DbEntities _context;

        public SalesOfficeRepository(DbEntities context):base(context) 
        {
            _context = context;
        }


        public async Task<List<SalesOfficeDTO>> GetOfficesAsync()
        {
            return await _context.SalesOffices
                .Select(o => new SalesOfficeDTO
                {
                    OfficeId = o.Id,
                    OfficeName = o.SalesOfficeName
                })
                .ToListAsync();
        }
    }

}
