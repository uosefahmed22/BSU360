using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business
{
    public class ContactsDto
    {
        public List<string> Emails { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public List<string> URlSites { get; set; }
    }
}
