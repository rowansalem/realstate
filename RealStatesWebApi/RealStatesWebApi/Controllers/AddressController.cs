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
    public class AddressController : ControllerBase
    {
        #region props and ctot
        private readonly IAddressService _addressService;
        private readonly IValidator<AddressDTO> _addressValidator;
        public AddressController(IAddressService addressService,  IValidator<AddressDTO> addressValidator)
        {
            _addressService = addressService;
            _addressValidator = addressValidator;
        }
        #endregion

        #region CRUD
        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>A list of address DTOs.</returns>
        /// <response code="200">Returns the list of addresses</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all addresses", Description = "Returns a list of address DTOs.")]
        [SwaggerResponse(200, "Returns the list of addresses", typeof(ApiResult<AddressDTO>))]
        [SwaggerResponse(500, "If there is an internal server error")]
        public ActionResult GetAddresss()
        {
            List<AddressDTO> addresss = _addressService.GetAll().ToList();
            ApiResult<AddressDTO> result = ApiResult<AddressDTO>.Success(addresss);
            return Ok(result);
        }

        /// <summary>
        /// Gets an address by ID.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <returns>An address DTO.</returns>
        /// <response code="200">Returns the address DTO</response>
        /// <response code="404">If the address is not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets an address by ID", Description = "Returns an address DTO by the specified ID.")]
        [SwaggerResponse(200, "Returns the address DTO", typeof(ApiResult<AddressDTO>))]
        [SwaggerResponse(404, "If the address is not found")]
        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            AddressDTO address = _addressService.GetById(id);
            ApiResult<AddressDTO> result = ApiResult<AddressDTO>.Success(address);
            return Ok(result);
        }

        /// <summary>
        /// Gets a filtered list of addresses.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <returns>A paginated list of address DTOs.</returns>
        /// <response code="200">Returns the filtered list of addresses</response>
        [HttpPost("filtered-list")]
        [SwaggerOperation(Summary = "Gets a filtered list of addresses", Description = "Returns a paginated list of address DTOs based on the filter criteria.")]
        [SwaggerResponse(200, "Returns the filtered list of addresses", typeof(ApiPaginationResult<AddressDTO>))]

        public ActionResult GetFilteredAddress([FromBody] FilterModel<AddressDTO> filter)
        {
            ApiPaginationResult<AddressDTO> addresss = _addressService.GetAllPaged(filter);
            return Ok(addresss);
        }

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address DTO.</param>
        /// <returns>The created address DTO.</returns>
        /// <response code="200">Returns the created address DTO</response>
        /// <response code="400">If the address is invalid</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new address", Description = "Creates a new address and returns the created address DTO.")]
        [SwaggerResponse(200, "Returns the created address DTO", typeof(ApiResult<AddressDTO>))]
        [SwaggerResponse(400, "If the address is invalid", typeof(ValidationResult))]
        public ActionResult PostAddress([FromBody] AddressDTO address)
        {
            ValidationResult validationResult = _addressValidator.Validate(address);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _addressService.Create(address);
            _addressService.SaveChanges();

            string message = "Address Created Successfully";
            ApiResult<AddressDTO> result = ApiResult<AddressDTO>.Success(address, message);
            return Ok(result);
        }


        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <param name="address">The updated address DTO.</param>
        /// <returns>A success message.</returns>
        /// <response code="200">Returns a success message</response>
        /// <response code="400">If the address is invalid or the IDs do not match</response>
        /// <response code="404">If the address is not found</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing address", Description = "Updates an existing address and returns a success message.")]
        [SwaggerResponse(200, "Returns a success message", typeof(ApiResult<AddressDTO>))]
        [SwaggerResponse(400, "If the address is invalid or the IDs do not match")]
        [SwaggerResponse(404, "If the address is not found")]
        public ActionResult PutAddress(Guid id, [FromBody] AddressDTO address)
        {
            ValidationResult validationResult = _addressValidator.Validate(address);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != address.Id)
            {
                return BadRequest();
            }

            _addressService.Update(id, address);
            _addressService.SaveChanges();

            string message = "Address Updated Successfully";
            ApiResult<AddressDTO> result = ApiResult<AddressDTO>.Success(message);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an address by ID.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <returns>A success message.</returns>
        /// <response code="200">Returns a success message</response>
        /// <response code="404">If the address is not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes an address by ID", Description = "Deletes an address by the specified ID and returns a success message.")]
        [SwaggerResponse(200, "Returns a success message", typeof(ApiResult<AddressDTO>))]
        [SwaggerResponse(404, "If the address is not found")]
        public ActionResult DeleteAddress(Guid id)
        {
            _addressService.Delete(id);
            _addressService.SaveChanges();

            string message = "Address Deleted Successfully";
            ApiResult<AddressDTO> result = ApiResult<AddressDTO>.Success(message);
            return Ok(result);
        }
        #endregion
    }
}
