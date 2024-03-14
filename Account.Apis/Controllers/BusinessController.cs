using Account.Apis.Errors;
using Account.Core.Dtos.Business.Request;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class BusinessController : ApiBaseController
    {
        private readonly IBusnissRepository _busnissRepository;

        public BusinessController(IBusnissRepository busnissRepository)
        {
            _busnissRepository = busnissRepository;
        }
        //[Authorize(Roles = "BussinesOwner")] 
        [HttpPost("CreateBussines")]
        public async Task<IActionResult> CreateBusiness([FromBody] BaseBusnisRequest businessRequest)
        {
            // var userId = HttpContext.User.FindFirst("userId")?.Value;
            // if (string.IsNullOrEmpty(userId))
            //    return Unauthorized(new ApiResponse(401, "Invalid User ID"));

            var result = await _busnissRepository.CreateBusinessAsync(businessRequest, Guid.NewGuid()); // Generate a temporary GUID for testing

            if (result.StatusCode == 409)
                return Conflict(new ApiResponse(409, "A business already exists for the current user."));
            else if (result.StatusCode == 400)
                return BadRequest(new ApiResponse(400, "Invalid request. Please check the provided data."));
            else if (result.StatusCode == 500)
                return StatusCode(500, new ApiResponse(500, "An error occurred while processing the request. Please try again later."));

            // Extract relevant data from ApiResponse and construct
            var businessId = result.Message; // business ID is returned in the message
            var response = new
            {
                BusinessId = businessId,
                Message = "Business created successfully."
            };

            return Ok(response);
        }

        //[Authorize(Roles = "BussinesOwner")]
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest(new ApiResponse(400, "Category data is required."));
            }

            var result = await _busnissRepository.CreateCategoryAsync(categoryDto);

            if (result.StatusCode == 200)
            {
                return Ok("Category has successfully created.");
            }
            else if (result.StatusCode == 409)
            {
                return Conflict("A category with the same name already exists.");
            }
            else
            {
                return StatusCode(result.StatusCode, "An error occurred while creating the category.");
            }
        }





    }
}
