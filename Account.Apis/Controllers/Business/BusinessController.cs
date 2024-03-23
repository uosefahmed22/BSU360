using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.Projectbusiness;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Business
{
    public class BusinessController : ApiBaseController
    {
        private readonly IBusnissRepository _businessRepository;

        public BusinessController(IBusnissRepository busnissRepository)
        {
            _businessRepository = busnissRepository;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBusiness([FromBody] BusinessDto businessDto)
        {
            var result = await _businessRepository.AddBusinessAsync(businessDto);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 400)
            {
                return BadRequest(result);
            }
            else if (result.StatusCode == 409)
            {
                return Conflict(result);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        [HttpPut("UpdateBusiness/{id}")]
        public async Task<IActionResult> UpdateBusiness(Guid id, [FromBody] BusinessDto businessDto)
        {
            if (id != businessDto.Id)
            {
                return BadRequest("Business ID in the request body does not match the ID in the URL.");
            }

            var response = await _businessRepository.UpdateBusinessAsync(businessDto, id);

            if (response.StatusCode == 200)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new ApiResponse(400));
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
        {
            var apiResponse = await _businessRepository.DeleteAsync(id);

            return StatusCode(apiResponse.StatusCode, apiResponse);
        }

        [HttpGet("GetAllBusinesses")]
        public async Task<ActionResult<IEnumerable<BusinessModel>>> GetAllBusinesses()
        {
            var businesses = await _businessRepository.GetAllAsync();

            if (businesses == null || !businesses.Any())
            {
                return NotFound(); // Return 404 Not Found if no businesses are found
            }

            return Ok(businesses); // Return 200 OK with the list of businesses
        }

        [HttpGet("GetBusinessById/{id}")]
        public async Task<ActionResult<BusinessModel>> GetBusinessById(Guid id)
        {
            var business = await _businessRepository.GetByIdAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }
    }
}