using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business
{
    public class ContactDto
    {
        [Required(ErrorMessage = "At least one phone number is required.")]
        public List<string> PhoneNumbers { get; set; }

        [Required(ErrorMessage = "At least one email is required.")]
        public List<string> Emails { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string SiteUrl { get; set; }
    }
}
