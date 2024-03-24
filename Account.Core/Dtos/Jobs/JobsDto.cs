using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Jobs
{
    public class JobsDto
    {
        public Guid Id { get; set; }
        public string CompanyNameOrLocationArabic { get; set; }
        public string? CompanyNameOrLocationEnglish { get; set; }
        public string JobDetailsArabic { get; set; }
        public string? JobDetailsEnglish { get; set; }
        public string AddressArabic { get; set; }
        public string? AddressEnglish { get; set; }
        public string ApplicationRequirementsArabic { get; set; }
        public string? ApplicationRequirementsEnglish { get; set; }
        public decimal Salary { get; set; }
        public JobContactDto Contacts { get; set; }
    }

}
