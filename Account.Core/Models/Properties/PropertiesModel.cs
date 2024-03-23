using Account.Core.Models.Properties.Contacts;
using Account.Core.Models.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Properties
{
    public class PropertiesModel :BaseEntity
    {
        public string NameArabic { get; set; }
        public string? NameEnglish { get; set; }
        public string DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public string AddressArabic { get; set; }
        public string? AddressEnglish { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<PropertiesAlbumUrl> PropertiesAlbumUrl { get; set; } = new List<PropertiesAlbumUrl>();
        public virtual ICollection<ContactsOfProperties> ContactsOfProperties { get; set; } = new List<ContactsOfProperties>();

    }
}

//public Guid UserId { get; set; }