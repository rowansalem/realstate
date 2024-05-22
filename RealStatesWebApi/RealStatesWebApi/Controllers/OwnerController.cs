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
    public class OwnerController : ControllerBase
    {
        #region props and ctot
        private readonly IOwnerService _ownerService;
        private readonly IValidator<OwnerDTO> _ownerValidator;
        public OwnerController(IOwnerService ownerService,  IValidator<OwnerDTO> ownerValidator)
        {
            _ownerService = ownerService;
            _ownerValidator = ownerValidator;
        }
        #endregion

        #region CRUD
        /// <summary>
        /// Gets all owneres.
        /// </summary>
        /// <returns>A list of owner DTOs.</returns>
        /// <response code="200">Returns the list of owneres</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all owneres", Description = "Returns a list of owner DTOs.")]
        [SwaggerResponse(200, "Returns the list of owneres", typeof(ApiResult<OwnerDTO>))]
        [SwaggerResponse(500, "If there is an internal server error")]
        public ActionResult GetOwners()
        {
            List<OwnerDTO> owners = _ownerService.GetAll().ToList();
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(owners);
            return Ok(result);
        }

        /// <summary>
        /// Gets an owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner.</param>
        /// <returns>An owner DTO.</returns>
        /// <response code="200">Returns the owner DTO</response>
        /// <response code="404">If the owner is not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets an owner by ID", Description = "Returns an owner DTO by the specified ID.")]
        [SwaggerResponse(200, "Returns the owner DTO", typeof(ApiResult<OwnerDTO>))]
        [SwaggerResponse(404, "If the owner is not found")]
        public IActionResult GetOwner(Guid id)
        {
            OwnerDTO owner = _ownerService.GetById(id);
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(owner);
            return Ok(result);
        }

        /// <summary>
        /// Gets a filtered list of owneres.
        /// </summary>
        /// <param name="filter">The filter criteria.</param>
        /// <returns>A paginated list of owner DTOs.</returns>
        /// <response code="200">Returns the filtered list of owneres</response>
        [HttpPost("filtered-list")]
        [SwaggerOperation(Summary = "Gets a filtered list of owneres", Description = "Returns a paginated list of owner DTOs based on the filter criteria.")]
        [SwaggerResponse(200, "Returns the filtered list of owneres", typeof(ApiPaginationResult<OwnerDTO>))]

        public ActionResult GetFilteredOwner([FromBody] FilterModel<OwnerDTO> filter)
        {
            ApiPaginationResult<OwnerDTO> owners = _ownerService.GetAllPaged(filter);
            return Ok(owners);
        }

        /// <summary>
        /// Creates a new owner.
        /// </summary>
        /// <param name="owner">The owner DTO.</param>
        /// <returns>The created owner DTO.</returns>
        /// <response code="200">Returns the created owner DTO</response>
        /// <response code="400">If the owner is invalid</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new owner", Description = "Creates a new owner and returns the created owner DTO.")]
        [SwaggerResponse(200, "Returns the created owner DTO", typeof(ApiResult<OwnerDTO>))]
        [SwaggerResponse(400, "If the owner is invalid", typeof(ValidationResult))]
        public ActionResult PostOwner([FromBody] OwnerDTO owner)
        {
            ValidationResult validationResult = _ownerValidator.Validate(owner);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _ownerService.Create(owner);
            _ownerService.SaveChanges();

            string message = "Owner Created Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(owner, message);
            return Ok(result);
        }


        /// <summary>
        /// Updates an existing owner.
        /// </summary>
        /// <param name="id">The ID of the owner.</param>
        /// <param name="owner">The updated owner DTO.</param>
        /// <returns>A success message.</returns>
        /// <response code="200">Returns a success message</response>
        /// <response code="400">If the owner is invalid or the IDs do not match</response>
        /// <response code="404">If the owner is not found</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing owner", Description = "Updates an existing owner and returns a success message.")]
        [SwaggerResponse(200, "Returns a success message", typeof(ApiResult<OwnerDTO>))]
        [SwaggerResponse(400, "If the owner is invalid or the IDs do not match")]
        [SwaggerResponse(404, "If the owner is not found")]
        public ActionResult PutOwner(Guid id, [FromBody] OwnerDTO owner)
        {
            ValidationResult validationResult = _ownerValidator.Validate(owner);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (id != owner.Id)
            {
                return BadRequest();
            }

            _ownerService.Update(id, owner);
            _ownerService.SaveChanges();

            string message = "Owner Updated Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(message);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner.</param>
        /// <returns>A success message.</returns>
        /// <response code="200">Returns a success message</response>
        /// <response code="404">If the owner is not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes an owner by ID", Description = "Deletes an owner by the specified ID and returns a success message.")]
        [SwaggerResponse(200, "Returns a success message", typeof(ApiResult<OwnerDTO>))]
        [SwaggerResponse(404, "If the owner is not found")]
        public ActionResult DeleteOwner(Guid id)
        {
            _ownerService.Delete(id);
            _ownerService.SaveChanges();

            string message = "Owner Deleted Successfully";
            ApiResult<OwnerDTO> result = ApiResult<OwnerDTO>.Success(message);
            return Ok(result);
        }
        #endregion
    }
}
