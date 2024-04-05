using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Models.DTO;
using Services;

namespace RealStatesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("PropertiesPerOffice/{officeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertiesPerOfficeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPropertiesPerOffice(Guid officeId)
        {
            if (officeId == Guid.Empty)
            {
                return BadRequest("Invalid office ID.");
            }

            var result = await _reportService.GetPropertiesPerOfficeAsync(officeId);
            if (result == null)
            {
                return NotFound($"No properties found for office ID {officeId}.");
            }

            return Ok(result);
        }

        [HttpGet("OfficePropertyCounts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OfficePropertyCountDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfficePropertyCounts()
        {
            List<OfficePropertyCountDTO> result = await _reportService.GetOfficePropertyCountsAsync();
            return Ok(result);
        }

        [HttpGet("EmployeesByOffice/{officeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeesByOfficeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeesByOffice(Guid officeId)
        {
            if (officeId == Guid.Empty)
            {
                return BadRequest("Invalid office ID.");
            }

            EmployeesByOfficeDTO? result = await _reportService.GetEmployeesByOfficeAsync(officeId);
            if (result==null)
            {
                return NotFound("Office not found.");
            }
            return Ok(result);
        }
    }
}
