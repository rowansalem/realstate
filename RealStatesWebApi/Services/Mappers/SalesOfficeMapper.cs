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
            salesofficeDTO.OfficeName = source.SalesOfficeName;
            salesofficeDTO.OfficeId = source.Id;
            return salesofficeDTO;
        }

        SalesOffice IBaseMapper<SalesOffice, SalesOfficeDTO>.MapToEntity(SalesOfficeDTO source)
        {
            SalesOffice salesoffice = new SalesOffice();
            salesoffice.SalesOfficeName = source.OfficeName;
            salesoffice.Id = source.OfficeId;
            return salesoffice;
        }
    }
}
