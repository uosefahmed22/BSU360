using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Properties
{
    public class PropertiesDto
    {
        public Guid Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string DescriptionArabic { get; set; }
        public string DescriptionEnglish { get; set; }
        public string AddressArabic { get; set; }
        public string AddressEnglish { get; set; }
        public decimal Salary { get; set; }
        public List<string> AlbumUrls { get; set; }
        public PropertiesContactsDto PropertiesContactsDto { get; set; }

    }
}
//public Guid UserId { get; set; }
