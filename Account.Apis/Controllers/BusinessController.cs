using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.Projectbusiness;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class BusinessController : ApiBaseController
    {
        private readonly IBusnissRepository _businessRepository;

        public BusinessController(IBusnissRepository busnissRepository)
        {
            _businessRepository = busnissRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddBusiness([FromBody] BusinessModel businessModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _businessRepository.AddBusnissAsync(businessModel);

            if (result.StatusCode == 200)
            {
                return Ok(result); // 200 OK with success response
            }
            else
            {
                return StatusCode(result.StatusCode, result); // Return status code and message from ApiResponse
            }
        }


    }
}
