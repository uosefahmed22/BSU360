using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.Request
{
    public class ContactDto
    {
        [Required(ErrorMessage = "First phone number is required.")]
        public string FirstPhoneNumber { get; set; }

        public string? SecondPhoneNumber { get; set; }

        public string? ThirdPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        public string EmailAddress { get; set; }

        public string? SiteUrl { get; set; }
    }
}
