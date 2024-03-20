using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Contacts
{
    public class URlSites
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UrlSite is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string UrlSite { get; set; }

        public Guid ContactId { get; set; }
        public Contacts Contact { get; set; }

    }
}
