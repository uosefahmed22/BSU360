using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.Contacts
{
    public class Contact : BaseEntity
    {
        public List<PhoneNumbers> PhoneNumbers { get; set; }
        public List<Emails> Emails { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string? SiteUrl { get; set; }

        [Required(ErrorMessage = "Business ID is required.")]
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }
    }
}
