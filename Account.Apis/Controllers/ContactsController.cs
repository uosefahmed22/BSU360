using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class ContactsController : ApiBaseController
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        [Route("AddContact/{businessId}")]
        public async Task<IActionResult> AddContact(Guid businessId, [FromBody] ContactDto contactDto)
        {
            var result = await _contactRepository.AddContactAsync(businessId, contactDto);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result); 
            }
            else
            {
                return StatusCode(result.StatusCode, result);
            }
        }



    }
}
