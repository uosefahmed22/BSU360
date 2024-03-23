using Account.Core.Dtos.ServiceProvider;
using Account.Core.Models.ServiceProvider;
using Account.Core.Services.ServiceProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.ServiceProvider
{
    public class ServiceProviderController : ApiBaseController
    {
        private readonly IServiceProviderReposatory _serviceProviderReposatory;

        public ServiceProviderController(IServiceProviderReposatory serviceProviderReposatory)
        {
            _serviceProviderReposatory = serviceProviderReposatory;
        }
        [HttpPost("AddServiceProvider")]
        public async Task<IActionResult> AddServiceProvider([FromBody] ServicesProviderDto serviceProviderDto)
        {
            var result = await _serviceProviderReposatory.AddServiceProviderAsync(serviceProviderDto);

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


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteServiceProvider(Guid id)
        {
            var apiResponse = await _serviceProviderReposatory.DeleteServiceProviderAsync(id);

            return StatusCode(apiResponse.StatusCode, apiResponse);
        }

        [HttpGet("GetAllServiceProviders")]
        public async Task<ActionResult<IEnumerable<ServicesProviderdModel>>> GetAllServiceProviders()
        {
            var serviceProviders = await _serviceProviderReposatory.GetAllServiceProviderAsync();

            if (serviceProviders == null || !serviceProviders.Any())
            {
                return NotFound(); 
            }

            return Ok(serviceProviders);
        }

        [HttpGet("GetServiceProviderById/{id}")]
        public async Task<ActionResult<ServicesProviderdModel>> GetServiceProviderById(Guid id)
        {
            var serviceProvider = await _serviceProviderReposatory.GetServiceProviderByIdAsync(id);

            if (serviceProvider == null)
            {
                return NotFound();
            }

            return Ok(serviceProvider);
        }

        [HttpPut("UpdateServiceProvider/{id}")]
        public async Task<IActionResult> UpdateServiceProvider(Guid id, [FromBody] ServicesProviderDto serviceProviderDto)
        {
            if (id != serviceProviderDto.Id)
            {
                return BadRequest("Service provider ID in the request body does not match the ID in the URL.");
            }

            var response = await _serviceProviderReposatory.UpdateServiceProviderAsync(serviceProviderDto, id);

            if (response.StatusCode == 200)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response); // Return bad request with the ApiResponse object containing the status code and message
            }
        }
    }
}
