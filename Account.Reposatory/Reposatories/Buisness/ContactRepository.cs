using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class ContactRepository : IContactRepository
    {
        private readonly BusinessDbContext _context;

        public ContactRepository(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> AddContactAsync(Guid businessId, ContactDto contactDto)
        {
            try
            {
                var business = await _context.Businesses.FindAsync(businessId);
                if (business == null)
                {
                    return new ApiResponse(404, "Business not found");
                }

                var contact = new Contact
                {
                    PhoneNumbers = contactDto.PhoneNumbers.Select(p => new PhoneNumbers { PhoneNumber = p }).ToList(),
                    Emails = contactDto.Emails.Select(e => new Emails { Email = e }).ToList(),
                    SiteUrl = contactDto.SiteUrl,
                    BusinessId = businessId
                };

                _context.Contacts.Add(contact);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Contact added successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred while adding the contact: {ex.Message}");
            }
        }

        public Task<ApiResponse> DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetAllContactsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetContactsForBusinessAsync(Guid businessId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateContactAsync(int id, Guid businessId, ContactDto contactDto)
        {
            throw new NotImplementedException();
        }
    }
}
