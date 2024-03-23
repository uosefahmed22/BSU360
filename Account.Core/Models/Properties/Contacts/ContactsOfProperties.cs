using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Models.Projectbusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Related;

namespace Account.Core.Models.Properties.Contacts
{
    public class ContactsOfProperties:BaseEntity
    {
        public ContactsOfProperties()
        {
            EmailsofProperties = new List<EmailsofProperties>();
            PhoneNumbersOfProperties = new List<PhoneNumbersOfProperties>();
            URLSitesOfProperties = new List<URLSitesOfProperties>();
        }
       
        public List<EmailsofProperties> EmailsofProperties { get; set; }
        public List<PhoneNumbersOfProperties> PhoneNumbersOfProperties { get; set; }
        public List<URLSitesOfProperties> URLSitesOfProperties { get; set; }

        public Guid PropertiesModelId { get; set; }
        public PropertiesModel PropertiesModel { get; set; }
    }
}
