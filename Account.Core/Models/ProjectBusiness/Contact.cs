using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Contact : BaseEntity
    {
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [Required(ErrorMessage = "First phone number is required.")]
        public string FirstPhoneNumber { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? SecondPhoneNumber { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? ThirdPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? EmailAddress { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string? SiteUrl { get; set; }

        [Required(ErrorMessage = "Business ID is required.")]
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }
    }
}
