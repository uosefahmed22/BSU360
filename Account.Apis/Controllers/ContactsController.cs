using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Dtos.Business.ContactsGertAll;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Account.Apis.Controllers
{
    public class ContactsController : ApiBaseController
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact([FromBody] ContactsDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _contactRepository.AddContactAsync(model.Emails, model.PhoneNumbers, model.URlSites);

            if (response.StatusCode == 200)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            try
            {
                var response = await _contactRepository.DeleteContactAsync(id);

                if (response.StatusCode == 200)
                {
                    return Ok(response);
                }
                else if (response.StatusCode == 404)
                {
                    return NotFound(response);
                }
                else
                {
                    return StatusCode(response.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Failed to delete contact: " + ex.Message));
            }
        }

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var contacts = await _contactRepository.GetAllContactsAsync();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, "Failed to retrieve contacts: " + ex.Message));
            }
        }

        [HttpGet("{businessId}/GetAllContactsForBusiness")]
        public async Task<IActionResult> GetAllContactsForBusiness(Guid businessId)
        {
            try
            {
                var contacts = await _contactRepository.GetAllContactsForBusinessAsync(businessId);

                if (contacts == null || !contacts.Any())
                {
                    return NotFound(new ApiResponse(404, "No contacts found for the specified business."));
                }

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                // Log the exception somewhere
                return StatusCode(500, new ApiResponse(500, "Failed to retrieve contacts for the business: " + ex.Message));
            }
        }

        [HttpGet("GetContactById/{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            try
            {
                var contactDto = await _contactRepository.GetContactByIdAsync(id);

                if (contactDto == null)
                {
                    return NotFound(new ApiResponse(404, "Contact not found."));
                }

                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                // Log the exception somewhere
                return StatusCode(500, new ApiResponse(500, "Failed to retrieve contact: " + ex.Message));
            }
        }

        [HttpPut("UpdateContact/{contactId}")]
        public async Task<IActionResult> UpdateContact(Guid contactId, [FromBody] ContactDto request)
        {
            try
            {
                var response = await _contactRepository.UpdateContactAsync(contactId, request.Emails, request.PhoneNumbers, request.UrlSites);

                if (response.StatusCode == 200)
                {
                    return Ok(response);
                }
                else if (response.StatusCode == 404)
                {
                    return NotFound(response);
                }
                else
                {
                    return StatusCode(response.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                // Log the exception somewhere
                return StatusCode(500, new ApiResponse(500, "Failed to update contact: " + ex.Message));
            }
        }
    }
}
