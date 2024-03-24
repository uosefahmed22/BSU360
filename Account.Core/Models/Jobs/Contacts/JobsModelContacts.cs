using Account.Core.Models.Properties.Contacts;
using Account.Core.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Related;

namespace Account.Core.Models.Jobs.Contacts
{
    public class JobsModelContacts : BaseEntity
    {
        public JobsModelContacts()
        {
            JobsModelEmails = new List<JobsModelEmails>();
            JobsModelPhoneNumbers = new List<JobsModelPhoneNumbers>();
            JobsModelURLSites = new List<JobsModelURLSites>();
        }

        public List<JobsModelEmails> JobsModelEmails { get; set; }
        public List<JobsModelPhoneNumbers> JobsModelPhoneNumbers { get; set; }
        public List<JobsModelURLSites> JobsModelURLSites { get; set; }

        public Guid JobsModelId { get; set; }
        public JobsModel JobsModel { get; set; }
    }
}
