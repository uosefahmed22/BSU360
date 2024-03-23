using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.ServiceProvider
{
    public class ServicesProviderContactsDto
    {
        public Guid Id { get; set; }
        public List<string> ServicesProviderContactsDtoEmails { get; set; }
        public List<string> ServicesProviderContactsDtoPhoneNumbers { get; set; }
        public List<string> ServicesProviderContactsDtoUrlSites { get; set; }
    }
}
