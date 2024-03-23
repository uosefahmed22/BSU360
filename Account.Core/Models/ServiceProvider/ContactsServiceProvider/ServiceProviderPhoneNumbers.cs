using Account.Core.Models.ProjectBusiness.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider.ContactsServiceProvider
{
    public class ServiceProviderPhoneNumbers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        public Guid ServiceProviderContactsId { get; set; }
        public ServiceProviderContacts ServiceProviderContacts { get; set; }
    }
}
