using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Models.Core;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SalesOfficeDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfficePropertyCounts()
        {
            List<SalesOfficeDTO> result = await _salesOfficeService.GetOfficesAsync();
            return Ok(result);
        }

        #region CRUD
        // GET api/Property
        [HttpGet("Property")]
        public ActionResult GetPropertys()
        {
            List<SalesOfficeDTO> employees = _salesOfficeService.GetAll().ToList();
            ApiResult<SalesOfficeDTO> result = ApiResult<SalesOfficeDTO>.Success(employees);
            return Ok(result);
        }

        // GET api/Property/5
        [HttpGet("{id}")]
        public IActionResult GetProperty(Guid id)
        {
            SalesOfficeDTO employee = _salesOfficeService.GetById(id);
            ApiResult<SalesOfficeDTO> result = ApiResult<SalesOfficeDTO>.Success(employee);
            return Ok(result);
        }

        // POST api/Property/filtered-list
        [HttpPost("filtered-list")]
        public ActionResult GetFilteredProperty([FromBody] FilterModel<SalesOfficeDTO> filter)
        {
            ApiPaginationResult<SalesOfficeDTO> employees = _salesOfficeService.GetAllPaged(filter);
            return Ok(employees);
        }

        // POST api/Property
        [HttpPost]
        public ActionResult PostProperty([FromBody] SalesOfficeDTO employee)
        {
            //ValidationResult validationResult = _employeeValidator.Validate(employee);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}

            _salesOfficeService.Create(employee);
            _salesOfficeService.SaveChanges();

            string message = "Property Created Successfully";
            ApiResult<SalesOfficeDTO> result = ApiResult<SalesOfficeDTO>.Success(employee, message);
            return Ok(result);
        }


        // PUT api/Property/5
        [HttpPut("{id}")]
        public ActionResult PutProperty(Guid id, [FromBody] SalesOfficeDTO employee)
        {
            //ValidationResult validationResult = _employeeValidator.Validate(employee);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _salesOfficeService.Update(id, employee);
            _salesOfficeService.SaveChanges();

            string message = "Property Updated Successfully";
            ApiResult<SalesOfficeDTO> result = ApiResult<SalesOfficeDTO>.Success(message);
            return Ok(result);
        }

        // DELETE api/Property/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProperty(Guid id)
        {
            _salesOfficeService.Delete(id);
            _salesOfficeService.SaveChanges();

            string message = "Property Deleted Successfully";
            ApiResult<SalesOfficeDTO> result = ApiResult<SalesOfficeDTO>.Success(message);
            return Ok(result);
        }
        #endregion


    }
}
