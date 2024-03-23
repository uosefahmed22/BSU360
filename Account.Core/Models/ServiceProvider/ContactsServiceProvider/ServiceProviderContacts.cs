using Account.Core.Models.Related;
using Account.Core.Models.ServiceProvider.ContactsServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ServiceProvider.ContactsServiceProvider
{
    public class ServiceProviderContacts : BaseEntity
    {
        public ServiceProviderContacts()
        {
            ServiceProviderEmails = new List<ServiceProviderEmails>();
            ServiceProviderPhoneNumbers = new List<ServiceProviderPhoneNumbers>();
            ServiceProviderURLSites = new List<ServiceProviderURLSites>();
        }

        public List<ServiceProviderEmails> ServiceProviderEmails { get; set; }
        public List<ServiceProviderPhoneNumbers> ServiceProviderPhoneNumbers { get; set; }
        public List<ServiceProviderURLSites> ServiceProviderURLSites { get; set; }

        public Guid ServicesProviderdModelId { get; set; }
        public ServicesProviderdModel ServicesProviderdModel { get; set; }
    }

}
