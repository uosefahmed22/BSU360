using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Dtos.Business.ContactsGertAll;
using Account.Core.Models.ProjectBusiness.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Related
{
    public interface IContactRepository
    {
        Task<ContactDto> GetContactByIdAsync(Guid id);
        Task<IEnumerable<ContactDto>> GetAllContactsAsync();
        Task<IEnumerable<ContactDto>> GetAllContactsForBusinessAsync(Guid businessId);
        Task<ApiResponse> AddContactAsync(List<string> emails, List<string> phoneNumbers, List<string> urls);
        Task<ApiResponse> UpdateContactAsync(Guid contactId, List<string> emails, List<string> phoneNumbers, List<string> urls);
        Task<ApiResponse> DeleteContactAsync(Guid id);
    }
}
