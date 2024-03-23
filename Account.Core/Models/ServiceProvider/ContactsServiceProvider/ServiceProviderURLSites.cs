using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider.ContactsServiceProvider
{
    public class ServiceProviderURLSites
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UrlSite is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string UrlSite { get; set; }
        public Guid ServiceProviderContactsId { get; set; }
        public ServiceProviderContacts ServiceProviderContacts { get; set; }
    }
}
