using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.ContactsGertAll
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public List<string> Emails { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public List<string> UrlSites { get; set; }
    }
}
