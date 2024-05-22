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
    public class EmployeeController : ControllerBase
    {
        #region props and ctot
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<OwnerDTO> _employeeValidator;
        public EmployeeController(IEmployeeService employeeService,  IValidator<OwnerDTO> employeeValidator)
        {
            _employeeService = employeeService;
            _employeeValidator = employeeValidator;
        }
        #endregion

        #region CRUD
        // GET api/Employee
        [HttpGet]
        public ActionResult GetEmployees()
        {
            List<OwnerDTO> employees = _employeeService.GetAll().ToList();
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(employees);
            return Ok(result);
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            OwnerDTO employee = _employeeService.GetById(id);
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(employee);
            return Ok(result);
        }

        // POST api/Employee/filtered-list
        [HttpPost("filtered-list")]
        public ActionResult GetFilteredEmployee([FromBody] FilterModel<OwnerDTO> filter)
        {
            ApiPaginationResult<OwnerDTO> employees = _employeeService.GetAllPaged(filter);
            return Ok(employees);
        }

        // POST api/Employee
        [HttpPost]
        public ActionResult PostEmployee([FromBody] OwnerDTO employee)
        {
            ValidationResult validationResult = _employeeValidator.Validate(employee);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _employeeService.Create(employee);
            _employeeService.SaveChanges();

            string message = "Employee Created Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(employee, message);
            return Ok(result);
        }


        // PUT api/Employee/5
        [HttpPut("{id}")]
        public ActionResult PutEmployee(Guid id, [FromBody] OwnerDTO employee)
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

            string message = "Employee Updated Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(message);
            return Ok(result);
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(Guid id)
        {
            _employeeService.Delete(id);
            _employeeService.SaveChanges();

            string message = "Employee Deleted Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(message);
            return Ok(result);
        }
        #endregion
    }
}
