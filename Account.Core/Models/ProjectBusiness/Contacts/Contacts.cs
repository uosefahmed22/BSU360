using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Contacts
{
    public class Contacts : BaseEntity
    {
        public Contacts()
        {
            Emails = new List<Emails>();
            PhoneNumbers = new List<PhoneNumbers>();
            URlSites = new List<URlSites>();
        }

        public List<Emails> Emails { get; set; }
        public List<PhoneNumbers> PhoneNumbers { get; set; }
        public List<URlSites> URlSites { get; set; }
    }


}
