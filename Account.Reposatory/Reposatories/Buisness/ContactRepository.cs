using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Dtos.Business.ContactsGertAll;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Services;
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
        private readonly BusinessDbContext _dbContext;
        public ContactRepository(BusinessDbContext context)
        {
            _dbContext = context;
        }
        public async Task<ApiResponse> AddContactAsync(List<string> emails, List<string> phoneNumbers, List<string> urls)
        {
            try
            {
                var contact = new Contacts();

                foreach (var email in emails)
                {
                    contact.Emails.Add(new Emails { Email = email });
                }

                foreach (var phoneNumber in phoneNumbers)
                {
                    contact.PhoneNumbers.Add(new PhoneNumbers { PhoneNumber = phoneNumber });
                }

                foreach (var url in urls)
                {
                    contact.URlSites.Add(new URlSites { UrlSite = url });
                }

                _dbContext.Contacts.Add(contact);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse(200, "Contact added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, "Failed to add contact: " + ex.Message);
            }
        }
        public async Task<ApiResponse> UpdateContactAsync(Guid contactId, List<string> emails, List<string> phoneNumbers, List<string> urls)
        {
            try
            {
                var contact = await _dbContext.Contacts
                    .Include(c => c.Emails)
                    .Include(c => c.PhoneNumbers)
                    .Include(c => c.URlSites)
                    .FirstOrDefaultAsync(c => c.Id == contactId);

                if (contact == null)
                {
                    return new ApiResponse(404, "Contact not found.");
                }

                contact.Emails.Clear();
                contact.PhoneNumbers.Clear();
                contact.URlSites.Clear();

                foreach (var email in emails)
                {
                    contact.Emails.Add(new Emails { Email = email });
                }

                foreach (var phoneNumber in phoneNumbers)
                {
                    contact.PhoneNumbers.Add(new PhoneNumbers { PhoneNumber = phoneNumber });
                }

                foreach (var url in urls)
                {
                    contact.URlSites.Add(new URlSites { UrlSite = url });
                }

                await _dbContext.SaveChangesAsync();

                return new ApiResponse(200, "Contact updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, "Failed to update contact: " + ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteContactAsync(Guid id)
        {
            try
            {
                var contact = await _dbContext.Contacts.FindAsync(id);
                if (contact == null)
                    return new ApiResponse(404, "Contact not found.");

                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse(200, "Contact deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, "Failed to delete contact: " + ex.Message);
            }
        }
        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
        {
            var contacts = await _dbContext.Contacts
                .Select(c => new ContactDto
                {
                    Emails = c.Emails.Select(e => e.Email).ToList(),
                    PhoneNumbers = c.PhoneNumbers.Select(p => p.PhoneNumber).ToList(),
                    UrlSites = c.URlSites.Select(u => u.UrlSite).ToList()
                })
                .ToListAsync();

            return contacts;
        }
        public async Task<IEnumerable<ContactDto>> GetAllContactsForBusinessAsync(Guid businessId)
        {
            var contacts = await _dbContext.Businesses
                .Where(b => b.Id == businessId)
                .SelectMany(b => b.Contacts) 
                .Select(c => new ContactDto
                {
                    Emails = c.Emails.Select(e => e.Email).ToList(),
                    PhoneNumbers = c.PhoneNumbers.Select(p => p.PhoneNumber).ToList(),
                    UrlSites = c.URlSites.Select(u => u.UrlSite).ToList()
                })
                .ToListAsync();

            return contacts;
        }
        public async Task<ContactDto> GetContactByIdAsync(Guid id)
        {
            var contactDto = await _dbContext.Contacts
            .Where(c => c.Id == id)
            .Select(c => new ContactDto
            {
                Emails = c.Emails.Select(e => e.Email).ToList(),
                PhoneNumbers = c.PhoneNumbers.Select(p => p.PhoneNumber).ToList(),
                UrlSites = c.URlSites.Select(u => u.UrlSite).ToList()
            })
            .FirstOrDefaultAsync();

            return contactDto;
        }
    }
}