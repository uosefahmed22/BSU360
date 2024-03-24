using Account.Core.Models.Jobs.Contacts;
using Account.Core.Models.Properties.Contacts;
using Account.Core.Models.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Jobs
{
    public class JobsModel :BaseEntity
    {
        public string CompanyNameOrLocationArabic { get; set; }
        public string? CompanyNameOrLocationEnglish { get; set; }

        public string JobDetailsArabic { get; set; }
        public string? JobDetailsEnglish { get; set; }

        public string AddressArabic { get; set; }
        public string? AddressEnglish { get; set; }

        public string ApplicationRequirementsArabic { get; set; }
        public string? ApplicationRequirementsEnglish { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<JobsModelContacts> JobsModelContacts { get; set; } = new List<JobsModelContacts>();
    }
}
//public Guid UserId { get; set; }