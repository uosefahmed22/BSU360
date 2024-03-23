using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Properties.Contacts
{
    public class URLSitesOfProperties
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UrlSite is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string UrlSite { get; set; }
        public Guid ContactsOfPropertiesId { get; set; }
        public ContactsOfProperties ContactsOfProperties { get; set; }
    }
}
