using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<List<Contact>> GetAllContactsAsync();
        Task<List<Contact>> GetContactsForBusinessAsync(Guid businessId);
        Task<ApiResponse> AddContactAsync(Guid businessId, ContactDto contactDto);
        Task<ApiResponse> UpdateContactAsync(int id , Guid businessId, ContactDto contactDto);
        Task<ApiResponse> DeleteContactAsync(int id);
    }
}
