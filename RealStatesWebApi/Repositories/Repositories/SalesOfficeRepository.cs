using Data;
using Data.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.DTO.SalesOffice;
using Models.Entity;
using Repositories.Contracts;


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
                    Id = o.Id,
                    OfficeName = o.SalesOfficeName
                })
                .ToListAsync();
        }
    }

}
