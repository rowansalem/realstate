using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Models.DTO;
using Models.DTO.SalesOffice;
using Services;

namespace RealStatesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class SalesOfficesController : ControllerBase
    {
        private readonly ISalesOfficeService _salesOfficeService;

        public SalesOfficesController(ISalesOfficeService salesOfficeService)
        {
            _salesOfficeService = salesOfficeService;
        }

       

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetOfficeListResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfficePropertyCounts()
        {
            List<GetOfficeListResponse> result = await _salesOfficeService.GetOfficesAsync();
            return Ok(result);
        }

    }
}
