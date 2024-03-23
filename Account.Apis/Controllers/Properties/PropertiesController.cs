using Account.Core.Dtos.Properties;
using Account.Core.Models.Properties;
using Account.Core.Services.Properties;
using Account.Reposatory.Reposatories.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers.Properties
{
    public class PropertiesController : ApiBaseController
    {
        private readonly IPropertiesReposatory _propertiesReposatory;

        public PropertiesController(IPropertiesReposatory propertiesReposatory)
        {
            _propertiesReposatory = propertiesReposatory;
        }

        [HttpPost("AddProperty")]
        public async Task<IActionResult> AddProperty([FromBody] PropertiesDto propertyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _propertiesReposatory.AddPropertyAsync(propertyDto);

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


        [HttpPut("UpdateProperty/{id}")]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] PropertiesDto propertyDto)
        {
            if (id != propertyDto.Id)
            {
                return BadRequest("Property ID in the request body does not match the ID in the URL.");
            }

            var response = await _propertiesReposatory.UpdatePropertyAsync(propertyDto, id);

            if (response.StatusCode == 200)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("GetAllProperties")]
        public async Task<ActionResult<IEnumerable<PropertiesModel>>> GetAllProperties()
        {
            var properties = await _propertiesReposatory.GetAllPropertiesAsync();

            if (properties == null || !properties.Any())
            {
                return NotFound();
            }

            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertiesContactsDto>> GetPropertyById(Guid id)
        {
            var propertyDto = await _propertiesReposatory.GetPropertyByIdAsync(id);

            if (propertyDto == null)
            {
                return NotFound();
            }

            return Ok(propertyDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            var apiResponse = await _propertiesReposatory.DeletePropertyAsync(id);

            return StatusCode(apiResponse.StatusCode, apiResponse);
        }
    }
}
