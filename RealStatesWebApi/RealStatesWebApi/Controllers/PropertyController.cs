using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Core;
using Models.DTO;
using Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    public class PropertyController : ControllerBase
    {
        #region props and ctot
        private readonly IPropertyService _employeeService;
        private readonly IValidator<PropertyDTO> _employeeValidator;
        public PropertyController(IPropertyService employeeService,  IValidator<PropertyDTO> employeeValidator)
        {
            _employeeService = employeeService;
            _employeeValidator = employeeValidator;
        }
        #endregion

        #region CRUD
        // GET api/Property
        [HttpGet]
        public ActionResult GetPropertys()
        {
            List<PropertyDTO> employees = _employeeService.GetAll(null, ["PropertyOwners", "PropertyOwners.Owner"]).ToList();
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(employees);
            return Ok(result);
        }

        // GET api/Property/5
        [HttpGet("{id}")]
        public IActionResult GetProperty(Guid id)
        {
            PropertyDTO employee = _employeeService.GetById(id);
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(employee);
            return Ok(result);
        }

        // POST api/Property/filtered-list
        [HttpPost("filtered-list")]
        public ActionResult GetFilteredProperty([FromBody] FilterModel<PropertyDTO> filter)
        {
            ApiPaginationResult<PropertyDTO> employees = _employeeService.GetAllPaged(filter);
            return Ok(employees);
        }

        // POST api/Property
        [HttpPost]
        public ActionResult PostProperty([FromBody] PropertyDTO employee)
        {
            ValidationResult validationResult = _employeeValidator.Validate(employee);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _employeeService.Create(employee);
            _employeeService.SaveChanges();

            string message = "Property Created Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(employee, message);
            return Ok(result);
        }


        // PUT api/Property/5
        [HttpPut("{id}")]
        public ActionResult PutProperty(Guid id, [FromBody] PropertyDTO employee)
        {
            ValidationResult validationResult = _employeeValidator.Validate(employee);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _employeeService.Update(id, employee);
            _employeeService.SaveChanges();

            string message = "Property Updated Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(message);
            return Ok(result);
        }

        // DELETE api/Property/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProperty(Guid id)
        {
            _employeeService.Delete(id);
            _employeeService.SaveChanges();

            string message = "Property Deleted Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(message);
            return Ok(result);
        }
        #endregion
    }
}
