using Account.Core.Models.ProjectBusiness.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider.ContactsServiceProvider
{
    public class ServiceProviderEmails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        public Guid ServiceProviderContactsId { get; set; }
        public ServiceProviderContacts ServiceProviderContacts { get; set; }
    }
}
