

using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Core;
using Models.DTO;
using Services;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    public class PropertyController : ControllerBase
    {
        #region props and ctot
        private readonly IPropertyService _propertyService;
        private readonly IValidator<PropertyDTO> _propertyValidator;
        public PropertyController(IPropertyService propertyService,  IValidator<PropertyDTO> propertyValidator)
        {
            _propertyService = propertyService;
            _propertyValidator = propertyValidator;
        }
        #endregion

        #region CRUD
        // GET api/Property
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all Property", Description = "Gets all Property and returns the Property DTOs.")]
        [SwaggerResponse(200, "Returns the list of Property DTOs", typeof(ApiResult<PropertyDTO>))]

        public ActionResult GetPropertys()
        {
            List<PropertyDTO> propertys = _propertyService.GetAll(null, ["PropertyOwners", "PropertyOwners.Owner"]).ToList();
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(propertys);
            return Ok(result);
        }

        // GET api/Property/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Property by ID", Description = "Gets a Property by ID and returns the Property DTO.")]
        [SwaggerResponse(200, "Returns the Property DTO", typeof(ApiResult<PropertyDTO>))]
        [SwaggerResponse(404, "If the Property is not found", typeof(ApiResult<PropertyDTO>))]
        public IActionResult GetProperty(Guid id)
        {
            PropertyDTO property = _propertyService.GetById(id, ["SalesOffice", "PropertyOwners", "PropertyOwners.Owner"]);
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(property);
            return Ok(result);
        }

        // POST api/Property/filtered-list
        [HttpPost("filtered-list")]
        [SwaggerOperation(Summary = "Gets a filtered list of Property", Description = "Gets a filtered list of Property and returns the filtered Property DTOs.")]
        [SwaggerResponse(200, "Returns the filtered list of Property DTOs", typeof(ApiResult<PropertyDTO>))]
        public ActionResult GetFilteredProperty([FromBody] FilterModel<PropertyDTO> filter)
        {
            ApiPaginationResult<PropertyDTO> propertys = _propertyService.GetAllPaged(filter);
            return Ok(propertys);
        }

        // POST api/Property
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new Property", Description = "Creates a new Property and returns the created Property DTO.")]
        [SwaggerResponse(200, "Returns the created Property DTO", typeof(ApiResult<PropertyDTO>))]
        [SwaggerResponse(400, "If the address is invalid", typeof(ValidationResult))]
        public ActionResult PostProperty([FromBody] PropertyDTO property)
        {
            ValidationResult validationResult = _propertyValidator.Validate(property);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _propertyService.Create(property);
            _propertyService.SaveChanges();

            string message = "Property Created Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(property, message);
            return Ok(result);
        }


        // PUT api/Property/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates a Property", Description = "Updates a Property and returns the updated Property DTO.")]
        [SwaggerResponse(200, "Returns the updated Property DTO", typeof(ApiResult<PropertyDTO>))]
        [SwaggerResponse(400, "If the Property is invalid", typeof(ValidationResult))]
        public ActionResult PutProperty(Guid id, [FromBody] PropertyDTO property)
        {
            ValidationResult validationResult = _propertyValidator.Validate(property);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != property.Id)
            {
                return BadRequest();
            }

            _propertyService.Update(id, property);
            _propertyService.SaveChanges();

            string message = "Property Updated Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(message);
            return Ok(result);
        }

        // DELETE api/Property/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a Property", Description = "Deletes a Property.")]
        [SwaggerResponse(200, "Returns a success message", typeof(ApiResult<PropertyDTO>))]
        [SwaggerResponse(404, "If the Property is not found", typeof(ApiResult<PropertyDTO>))]
        public ActionResult DeleteProperty(Guid id)
        {
            _propertyService.Delete(id);
            _propertyService.SaveChanges();

            string message = "Property Deleted Successfully";
            ApiResult<PropertyDTO> result = ApiResult<PropertyDTO>.Success(message);
            return Ok(result);
        }
        #endregion
    }
}
