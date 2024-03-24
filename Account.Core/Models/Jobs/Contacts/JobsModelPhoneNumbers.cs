using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Jobs.Contacts
{
    public class JobsModelPhoneNumbers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }
        public Guid JobsModelContactsId { get; set; }
        public JobsModelContacts JobsModelContacts { get; set; }
    }
}
