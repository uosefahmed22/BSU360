using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Properties.Contacts
{
    public class PhoneNumbersOfProperties
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }
        public Guid ContactsOfPropertiesId { get; set; }
        public ContactsOfProperties ContactsOfProperties { get; set; }
    }
}
