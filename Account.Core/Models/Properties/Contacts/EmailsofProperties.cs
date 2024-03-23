using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Properties.Contacts
{
    public class EmailsofProperties
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
        public Guid ContactsOfPropertiesId { get; set; }
        public ContactsOfProperties ContactsOfProperties { get; set; }
    }
}
